using Funcer.Messages;

namespace Funcer;

public static partial class ValueResultExtensions
{
    public static Task Resolve<TValue>(this Result<TValue> result, Func<TValue, Task> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        if (result.IsFailure) return onFailure(result.Errors);
        else return onSuccess(result.Value!);
    }
    
    public static Task Resolve<TValue>(this Result<TValue> result, Func<TValue, Task> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        if (result.IsFailure) onFailure(result.Errors);
        else return onSuccess(result.Value!);
        return Task.CompletedTask;
    }
    
    public static Task Resolve<TValue>(this Result<TValue> result, Action<TValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        if (result.IsFailure) return onFailure(result.Errors);
        else onSuccess(result.Value!);
        return Task.CompletedTask;
    }
    
    
    public static Task Resolve<TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, Task> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        if (result.IsFailure) return onFailure(result.Errors);
        else return onSuccess(result.Value!, result.Warnings);
    }
    
    public static Task Resolve<TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, Task> onSuccess, Action<IEnumerable<ErrorMessage>> onFailure)
    {
        if (result.IsFailure) onFailure(result.Errors);
        else return onSuccess(result.Value!, result.Warnings);
        return Task.CompletedTask;
    }
    
    public static Task Resolve<TValue>(this Result<TValue> result, Action<TValue, IEnumerable<WarningMessage>> onSuccess, Func<IEnumerable<ErrorMessage>, Task> onFailure)
    {
        if (result.IsFailure) return onFailure(result.Errors);
        else onSuccess(result.Value!, result.Warnings);
        return Task.CompletedTask;
    }
    
    
    public static Task Resolve<TValue>(this Result<TValue> result, Func<TValue, Task> onSuccess, Func<Task> onFailure)
    {
        if (result.IsFailure) return onFailure();
        else return onSuccess(result.Value!);
    }
    
    public static Task Resolve<TValue>(this Result<TValue> result, Func<TValue, Task> onSuccess, Action onFailure)
    {
        if (result.IsFailure) onFailure();
        else return onSuccess(result.Value!);
        return Task.CompletedTask;
    }
    
    public static Task Resolve<TValue>(this Result<TValue> result, Action<TValue> onSuccess, Func<Task> onFailure)
    {
        if (result.IsFailure) return onFailure();
        else onSuccess(result.Value!);
        return Task.CompletedTask;
    }
    
    
    public static Task Resolve<TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, Task> onSuccess, Func<Task> onFailure)
    {
        if (result.IsFailure) return onFailure();
        else return onSuccess(result.Value!, result.Warnings);
    }
    
    public static Task Resolve<TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, Task> onSuccess, Action onFailure)
    {
        if (result.IsFailure) onFailure();
        else return onSuccess(result.Value!, result.Warnings);
        return Task.CompletedTask;
    }
    
    public static Task Resolve<TValue>(this Result<TValue> result, Action<TValue, IEnumerable<WarningMessage>> onSuccess, Func<Task> onFailure)
    {
        if (result.IsFailure) return onFailure();
        else onSuccess(result.Value!, result.Warnings);
        return Task.CompletedTask;
    }
    

    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : await onSuccess(result.Value!);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : await onSuccess(result.Value!);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : onSuccess(result.Value!);
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : await onSuccess(result.Value!, result.Warnings);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : await onSuccess(result.Value!, result.Warnings);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : onSuccess(result.Value!, result.Warnings);
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Task<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : await onSuccess;
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Task<TReturnValue> onSuccess, Func<IEnumerable<ErrorMessage>, TReturnValue> onFailure)
    {
        return result.IsFailure ? onFailure(result.Errors) : await onSuccess;
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, TReturnValue onSuccess, Func<IEnumerable<ErrorMessage>, Task<TReturnValue>> onFailure)
    {
        return result.IsFailure ? await onFailure(result.Errors) : onSuccess;
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Task<TReturnValue> onSuccess, Task<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : await onSuccess;
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Task<TReturnValue> onSuccess, TReturnValue onFailure)
    {
        return result.IsFailure ? onFailure : await onSuccess;
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, TReturnValue onSuccess, Task<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : onSuccess;
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, Task<TReturnValue>> onSuccess, Task<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : await onSuccess(result.Value!);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, Task<TReturnValue>> onSuccess, TReturnValue onFailure)
    {
        return result.IsFailure ? onFailure : await onSuccess(result.Value!);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, TReturnValue> onSuccess, Task<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : onSuccess(result.Value!);
    }
    
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, Task<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : await onSuccess(result.Value!, result.Warnings);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, Task<TReturnValue>> onSuccess, TReturnValue onFailure)
    {
        return result.IsFailure ? onFailure : await onSuccess(result.Value!, result.Warnings);
    }
    
    public static async Task<TReturnValue> Resolve<TReturnValue, TValue>(this Result<TValue> result, Func<TValue, IEnumerable<WarningMessage>, TReturnValue> onSuccess, Task<TReturnValue> onFailure)
    {
        return result.IsFailure ? await onFailure : onSuccess(result.Value!, result.Warnings);
    }
}