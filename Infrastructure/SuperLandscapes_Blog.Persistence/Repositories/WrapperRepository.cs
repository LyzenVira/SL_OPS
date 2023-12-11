using SuperLandscapes_Blog.Application.Interfaces;
using SuperLandscapes_Blog.Domain.Common;
using SuperLandscapes_Blog.Persistence.Context;
using System.Collections;

namespace SuperLandscapes_Blog.Persistence.Repositories
{
    public class WrapperRepository : IWrapperRepository
    {
        private readonly DataContext _context;
        private Hashtable _repositories;
        private bool _disposed;

        public WrapperRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Dispose() => _context.Dispose();

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : AuditableEntity
        {
            if (_repositories is null) { _repositories = new Hashtable(); }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return _repositories[type] as IGenericRepository<TEntity>;

        }

        public Task Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            return Task.CompletedTask;
        }

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys)
        {
            throw new NotImplementedException();
        }
    }
}
