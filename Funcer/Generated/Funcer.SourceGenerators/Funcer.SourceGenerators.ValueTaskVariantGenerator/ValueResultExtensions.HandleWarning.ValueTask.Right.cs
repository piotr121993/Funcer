﻿using Funcer.Messages;

namespace Funcer;

public static class ValueResultExtensions_HandleWarning_ValueTask_Right
{
    public static async ValueTask<Result<TValue>> HandleWarning<TValue>(this Result<TValue> result, string errorType, Func<IEnumerable<WarningMessage>, ValueTask<TValue>> onWarning)
    {
        if (result.IsFailure) return result;
        
        var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

        if (!handledWarnings.Any()) return result;

        await onWarning(handledWarnings);

        foreach (var warning in handledWarnings)
        {
            result.RemoveWarning(warning);
        }

        return result;
    }
    
    public static async ValueTask<Result<TValue>> HandleWarning<TValue>(this Result<TValue> result, string errorType, Func<ValueTask<TValue>> onWarning)
    {
        if (result.IsFailure) return result;
        
        var handledWarnings = result.Warnings.Where(e => e.Type == errorType).ToList();

        if (!handledWarnings.Any()) return result;

        await onWarning();

        foreach (var warning in handledWarnings)
        {
            result.RemoveWarning(warning);
        }

        return result;
    }
}