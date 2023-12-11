
using SuperLandscapes_Blog.Persistence.Context;

namespace BLL.Services.Author
{
    public class AuthorService : IAuthorService
    {
        private readonly DataContext _context;
        public AuthorService(DataContext context)
        {
            _context = context;
        }

        
    }
}
