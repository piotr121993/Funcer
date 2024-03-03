using Funcer.Tests.Common;

namespace Funcer.Tests.Extensions.Ensure;

public class ValueResultEnsureTests_Task_Right
{
    public static IEnumerable<object[]> TestData1 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, Tasks.Returns.True, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Alpha1, Tasks.Returns.False, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, Tasks.Returns.True, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, Tasks.Returns.False, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData1))]
    public async Task ValueResult_Ensure_ConditionTask(Result<Types.Alpha> first, Func<Task<bool>> condition, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, Values.TestError);

        validate(result, Values.Alpha1);
    }
    
    public static IEnumerable<object[]> TestData2 => 
        new List<object[]>
        {
            new object[] { Results.Success.Alpha1, Tasks.Takes.Alpha.Returns.IsTrue, Values.Alpha1, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Alpha2, Tasks.Takes.Alpha.Returns.IsFalse, Values.Alpha2, Assertions.ValueResultSuccess },
            new object[] { Results.Success.Alpha1, Tasks.Takes.Alpha.Returns.IsFalse, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Success.Alpha2, Tasks.Takes.Alpha.Returns.IsTrue, Values.Alpha2, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, Tasks.Takes.Alpha.Returns.IsTrue, Values.Alpha1, Assertions.ValueResultFailure },
            new object[] { Results.Failure.Alpha, Tasks.Takes.Alpha.Returns.IsFalse, Values.Alpha1, Assertions.ValueResultFailure }
        };

    [Theory, MemberData(nameof(TestData2))]
    public async Task ValueResult_Ensure_ConditionTaskWithParameter(Result<Types.Alpha> first, Func<Types.Alpha, Task<bool>> condition, Types.Alpha expectedValue, Action<Result<Types.Alpha>, Types.Alpha> validate)
    {
        var result = await first
            .Ensure(condition, Values.TestError);

        validate(result, expectedValue);
    }
}