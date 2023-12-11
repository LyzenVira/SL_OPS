using SuperLandscapes_Blog.Domain.Common.Interfaces;
using SuperLandscapes_Blog.Shared.ResultResponse;

namespace SuperLandscapes_Blog.Application.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : IEntity
    {
        IQueryable<TEntity> Entities { get; }

        Task<Result<IEnumerable<TEntity>>> RetunrAllEntitiesAsync();

        Task<Result<TEntity>> ReturnEntityByIdAsync(Guid id);

        Task<Result<TEntity>> InsertEntityAsync(TEntity entity);

        Task<Result<TEntity>> UpdateEntityAsync(TEntity entity);

        Task<Result<IEnumerable<TEntity>>> DeleteEntityByIdAsync(Guid id);

    }
}
