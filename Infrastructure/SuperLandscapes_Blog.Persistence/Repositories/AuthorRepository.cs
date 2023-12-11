using Microsoft.EntityFrameworkCore;
using SuperLandscapes_Blog.Application.Interfaces;
using SuperLandscapes_Blog.Domain.Entities;
using SuperLandscapes_Blog.Persistence.Context;
using SuperLandscapes_Blog.Shared.ResultResponse;

namespace SuperLandscapes_Blog.Persistence.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IGenericRepository<Author> _repository;
        private readonly DataContext _context;
        public AuthorRepository(DataContext context, IGenericRepository<Author> repository)
        {
            _repository = repository;
            _context = context;
        }
    }
}