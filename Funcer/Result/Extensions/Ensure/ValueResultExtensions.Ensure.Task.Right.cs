using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static async Task<Result<TValue>> Ensure<TValue>(this Result<TValue> result, Func<Task<bool>> condition, ErrorMessage error)
    {
        return result.IsFailure 
            ? result 
            : await condition() ? result : Result<TValue>.Failure(error);
    }
    
    public static async Task<Result<TValue>> Ensure<TValue>(this Result<TValue> result, Func<TValue, Task<bool>> condition, ErrorMessage error)
    {
        return result.IsFailure 
            ? result 
            : await condition(result.Value!) ? result : Result<TValue>.Failure(error);
    }
}