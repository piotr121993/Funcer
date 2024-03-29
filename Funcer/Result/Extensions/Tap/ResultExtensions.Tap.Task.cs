namespace Funcer;

public static partial class ResultExtensions
{
    public static async Task<Result> Tap(this Task<Result> resultTask, Func<Task<Result>> next)
    {
        var result = await resultTask;
        return await result.Tap(next);
    }
    
    public static async Task<Result> Tap<TValue>(this Task<Result> resultTask, Func<Task<Result<TValue>>> next)
    {
        var result = await resultTask;
        return await result.Tap(next);
    }
    
    public static async Task<Result> Tap(this Task<Result> resultTask, Func<Task> next)
    {
        var result = await resultTask;
        return await result.Tap(next);
    }
    
    public static async Task<Result> Tap<TValue>(this Task<Result> resultTask, Func<Task<TValue>> next)
    {
        var result = await resultTask;
        return await result.Tap(next);
    }
}