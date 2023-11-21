using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.BlogFeature.Commands.Create
{
    public record CreateBlogCommand : IRequest<Result<int>>, IMappingFrom        <Blog>
    {
        public string Title { get; set; } 
        public string Description { get; set; } 
        public int Viewers { get; set; }
        public Guid AuthorId { get; set; }
    }
    internal class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateBlogCommand command, CancellationToken cancellationToken)
        {
            var blog = new Blog()
            {
                Title = command.Title,
                Description = command.Description,
                Viewers = command.Viewers,
                AuthorId = command.AuthorId
            };

            await _unitOfWork.Repository<Blog>().AddAsync(blog);
            blog.AddDomainEvent(new BlogCreatedEvent(blog));
            await _unitOfWork.Save(cancellationToken);
            return await Result<int>.SuccessAsync(blog.Id, "Blog Created.");
        }

    }
}
