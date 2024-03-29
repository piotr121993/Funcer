namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task<Result<TValue>> Map<TValue>(this Result result, Func<Task<Result<TValue>>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : (await next()).WithContext(result);
    }
    
    public static async Task<Result<TValue>> Map<TValue>(this Result result, Func<Task<TValue>> next)
    {
        return result.IsFailure ? Result<TValue>.Failure(result.Errors) : Result.Success(await next()).WithContext(result);
    }
}