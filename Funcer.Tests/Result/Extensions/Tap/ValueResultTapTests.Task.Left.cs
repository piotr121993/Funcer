using Funcer.Tests.Common;

namespace Funcer.Tests.Result.Extensions.Tap;

using Result = Funcer.Result;

public class ValueResultTapTests_Task_Left
{
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Result<Types.Alpha>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData1 => new()
    {
        { TestResult.Alpha.Async.Success.V2, TestFunc.Returns.Success.Alpha1, TestValues.Alpha2, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V2, TestFunc.Returns.Failure.Alpha, TestValues.Alpha2, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.Success.Alpha1, TestValues.Alpha2, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.Failure.Alpha, TestValues.Alpha2, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResultTask_Tap_ValueResultFunction(Task<Result<Types.Alpha>> first, Func<Result<Types.Alpha>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Result>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData2 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.Success.Empty, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.Failure.Empty, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.Success.Empty, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.Failure.Empty, TestValues.Alpha1, Assertions.ValueResultFailure },
    };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResultTask_Tap_ResultFunction(Task<Result<Types.Alpha>> first, Func<Result> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(_ => next());

        validate(result, expectedValue);
    }

    public static TheoryData<Task<Result<Types.Alpha>>, Func<Result<Types.Beta>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData3 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.Success.Beta1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.Failure.Beta, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.Success.Beta1, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.Failure.Beta, TestValues.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData3))]
    public async Task ValueResultTask1_Tap_ValueResult2Function(Task<Result<Types.Alpha>> first, Func<Result<Types.Beta>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(_ => next());

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Alpha, Result<Types.Beta>>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData4 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Takes.Alpha.Returns.Success.Beta1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Takes.Alpha.Returns.Failure.Beta, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Takes.Alpha.Returns.Success.Beta1, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Takes.Alpha.Returns.Failure.Beta, TestValues.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData4))]
    public async Task ValueResultTask1_Tap_ValueResult2Function_Param(Task<Result<Types.Alpha>> first, Func<Types.Alpha, Result<Types.Beta>> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Alpha, Result>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData5 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Takes.Alpha.Returns.Success.Empty, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Success.V1, TestFunc.Takes.Alpha.Returns.Failure.Empty, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Takes.Alpha.Returns.Success.Empty, TestValues.Alpha1, Assertions.ValueResultFailure },
        { TestResult.Alpha.Async.Failure, TestFunc.Takes.Alpha.Returns.Failure.Empty, TestValues.Alpha1, Assertions.ValueResultFailure },
    };
    
    [Theory, MemberData(nameof(TestData5))]
    public async Task ValueResultTask_Tap_ResultFunction_Param(Task<Result<Types.Alpha>> first, Func<Types.Alpha, Result> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Action, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData6 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.Void, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.Void, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData6))]
    public async Task ValueResultTask_Tap_Action(Task<Result<Types.Alpha>> first, Action next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);
    
        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Func<Types.Beta>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData7 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Returns.Beta1, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Failure, TestFunc.Returns.Beta1, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData7))]
    public async Task ValueResultTask1_Tap_Value2Function(Task<Result<Types.Alpha>> first, Func<Types.Beta> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
    
    public static TheoryData<Task<Result<Types.Alpha>>, Action<Types.Alpha>, Types.Alpha, Action<Result<Types.Alpha>, Types.Alpha>> TestData8 => new()
    {
        { TestResult.Alpha.Async.Success.V1, TestFunc.Takes.Alpha.Returns.Nothing, TestValues.Alpha1, Assertions.ValueResultSuccess },
        { TestResult.Alpha.Async.Failure, TestFunc.Takes.Alpha.Returns.Nothing, TestValues.Alpha1, Assertions.ValueResultFailure }
    };

    [Theory, MemberData(nameof(TestData8))]
    public async Task ValueResultTask_Tap_Action_Param(Task<Result<Types.Alpha>> first, Action<Types.Alpha> next, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Tap(next);

        validate(result, expectedValue);
    }
}