using Microsoft.EntityFrameworkCore;
using SuperLandscapes_Blog.Application.Interfaces;
using SuperLandscapes_Blog.Domain.Common;
using SuperLandscapes_Blog.Persistence.Context;
using SuperLandscapes_Blog.Shared.ResultResponse;

namespace SuperLandscapes_Blog.Persistence.Repositories
{
    public class GenericRepository<TEntiy> : IGenericRepository<TEntiy>
        where TEntiy : AuditableEntity
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }
        public IQueryable<TEntiy> Entities => _context.Set<TEntiy>();

        public async Task<Result<IEnumerable<TEntiy>>> DeleteEntityByIdAsync(Guid id)
        {
            var resul = new Result<IEnumerable<TEntiy>>();

            var exist = await Entities.FirstOrDefaultAsync(x => x.Id == id);

            if (exist is null)
            {
                throw new KeyNotFoundException($"The specified entity ID {id} was not found in the database. Please verify the ID and try again.");
            }

            _context.Remove(exist);

            resul.Entity = await this.Entities.AsNoTracking().ToListAsync();

            resul.Message = "Deletion Successful: Your code has successfully removed the specified data from the database.";
            return resul;
        }


        public async Task<Result<TEntiy>> InsertEntityAsync(TEntiy entity)
        {
            var result = new Result<TEntiy>() { Entity = entity };

            await _context.Set<TEntiy>().AddAsync(entity);

            result.Message = "The data has been successfully inserted into the table, " +
                "showcasing your expertise in database operations and precise implementation in C#. Well done!";
            return result;
        }

        public async Task<Result<IEnumerable<TEntiy>>> RetunrAllEntitiesAsync()
        {
            var result = new Result<IEnumerable<TEntiy>>();

            result.Entity = await this.Entities.AsNoTracking().ToListAsync();

            result.Message = "Impressive work! Your method for fetching all entities from the database in C# is top-notch. Great job!";
            return result;
        }

        public async Task<Result<TEntiy>> ReturnEntityByIdAsync(Guid id)
        {
            var result = new Result<TEntiy>();

            result.Entity = await this.Entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            result.Message = $"Impressive work! Your method for fetching entity using its ID {id} from the database in C# is top-notch. Great job!";
            return result;
        }

        public async Task<Result<TEntiy>> UpdateEntityAsync(TEntiy entity)
        {
            var result = new Result<TEntiy>() { Entity = entity };

            result.Entity = await this.Entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (result.Entity is null)
            {
                throw new KeyNotFoundException($"The specified entity ID {entity.Id} was not found in the database. Please verify the ID and try again.");
            }

            _context.Update(entity);

            result.Message = "Entity Update Successful! Your code executed flawlessly, resulting in the successful update of the entity. Great job!";

            return result;
        }
    }
}
