using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SuperLandscapes_Blog.Application.Interfaces;
using SuperLandscapes_Blog.Domain.Entities;
using SuperLandscapes_Blog.Shared.ResultResponse;
using System.Linq;


namespace SuperLandscapes_Blog.Application.Features.Authors.Queries.GetAllAuthors
{
    public record GetAuthorQuery : IRequest<Result<IEnumerable<GetAuthorDTO>>>;
    
    public class GetAuthorQueriesHandler : IRequestHandler<GetAuthorQuery, Result<IEnumerable<GetAuthorDTO>>>
    {
        private readonly IWrapperRepository _unitOfWork;
        private readonly IMapper _mapper;

        public GetAuthorQueriesHandler(IWrapperRepository unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<GetAuthorDTO>>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var employee = await _unitOfWork.Repository<Author>().Entities
                .ProjectTo<GetAuthorDTO>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<IEnumerable<GetAuthorDTO>>.SuccessAsync(employee,
                _unitOfWork.Repository<Author>().RetunrAllEntitiesAsync().Result.Message);
        }
    }
}
