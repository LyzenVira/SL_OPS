
using AutoMapper;
using MediatR;
using SuperLandscapes_Blog.Application.Common.Mappings.Interface;
using SuperLandscapes_Blog.Application.Interfaces;
using SuperLandscapes_Blog.Domain.Entities;
using SuperLandscapes_Blog.Shared.ResultResponse;

namespace SuperLandscapes_Blog.Application.Features.Authors.Commands.InsertAuthor
{
    public record InsertAuthorCommand : IRequest<Result<Author>>, IMappingFrom<Author>
    {
        public string Fullname { get; set; } = null!;
        public string Employment { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public string LinkedIn { get; set; } = null!;
        public string Description { get; set; } = null!;
    }

    internal class InsertAuthorCommandHandler : IRequestHandler<InsertAuthorCommand, Result<Author>>
    {
        private readonly IWrapperRepository _unitOfWork;
        private readonly IMapper _mapper;

        public InsertAuthorCommandHandler(IWrapperRepository unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Author>> Handle(InsertAuthorCommand request, CancellationToken cancellationToken)
        {
            Author author = new Author()
            {
                Fullname = request.Fullname,
                Employment = request.Employment,
                Avatar = request.Avatar,
                LinkedIn = request.LinkedIn,
                Description = request.Description
            };

            await _unitOfWork.Repository<Author>().InsertEntityAsync(author);
            author.AddDomainEvent(new InsertAuthorEvent(author));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Author>.SuccessAsync(author,
                _unitOfWork.Repository<Author>().InsertEntityAsync(author).Result.Message);
        }
    }
}
