using Funcer.Messages;

namespace Funcer;

public static class ResultExtensions_Ensure_Task_Left
{
    public static async Task<Result> Ensure(this Task<Result> resultTask, bool condition, ErrorMessage error)
    {
        var result = await resultTask;
        return result.Ensure(condition, error);
    }
    
    public static async Task<Result> Ensure(this Task<Result> resultTask, Func<bool> condition, ErrorMessage error)
    {
        var result = await resultTask;
        return result.Ensure(condition, error);
    }
}