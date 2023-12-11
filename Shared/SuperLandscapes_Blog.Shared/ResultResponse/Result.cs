
using SuperLandscapes_Blog.Shared.ResultResponse.Interfaces;

namespace SuperLandscapes_Blog.Shared.ResultResponse
{
    public class Result<TEntity> : IResult<TEntity>
    {
        public TEntity? Entity { get; set; }

        public string Message { get; set; } = string.Empty;

        public bool Succeeded { get; set; } = true;

        public int StatusCode { get; set; }

        public static Result<TEntity> Success(TEntity result)
        {
            return new Result<TEntity>()
            {
                Succeeded = true, 
                Entity = result
            };
        }

        public static Result<TEntity> Success(TEntity result, string messages)
        {
            return new Result<TEntity>()
            {
                Succeeded = true,
                Entity = result,
                Message = messages,
                StatusCode = 200
            };
        }

        public static Task<Result<TEntity>> SuccessAsync(TEntity result, string messages)
        {
            return Task.FromResult(Success(result, messages));
        }

        public static Task<Result<TEntity>> SuccessAsync(TEntity result)
        {
            return Task.FromResult(Success(result));
        }
    }
}
