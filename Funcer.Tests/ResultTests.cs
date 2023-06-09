using FluentAssertions;
using Funcer.Tests.Common;
using Xunit.Abstractions;

namespace Funcer.Tests;

public class ResultTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ResultTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    public void Should_Return_Success()
    {
        var result = Result.Create(true, Values.TestError)
            .Map(() => "one")
            .Tap(x => _testOutputHelper.WriteLine(x))
            .Tap(_testOutputHelper.WriteLine)
            .Tap(_ => _testOutputHelper.WriteLine("abc"))
            .Map(x => 7)
            .Map(x => { _testOutputHelper.WriteLine(x.ToString()); })
            .Tap(() => { })
            .Map(() => "abc")
            .Ensure(Functions.Returns.True, Values.TestError)
            .Map(x => x + "def")
            .Ensure(x => x is "abcdef", Values.TestError)
            .Tap(() => "abc")
            .Roll(Result.Success("ghi"))
            .Side(() => Result.Failure(Values.TestError))
            .Map((first, second) => first + second);
            
    
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("abcdefghi");
        result.Warnings.Should().Contain(x => x.Type == Values.TestError.Type);
    }
}