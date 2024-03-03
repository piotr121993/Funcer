using FluentAssertions;
using Funcer.Tests.Common;

namespace Funcer.Tests.Combine;

public class ResultTests_Combine
{
    public static IEnumerable<object[]> TestData =>
        new List<object[]>
        {
            new object[]
            {
                new List<IResult>
                {
                    Results.Success.Nothing,
                    Results.Success.Nothing,
                    Results.Success.Nothing
                },
                true
            },
            new object[]
            {
                new List<IResult>
                {
                    Results.Failure.Nothing,
                    Results.Success.Nothing,
                    Results.Success.Nothing
                },
                false
            }
            ,
            new object[]
            {
                new List<IResult>
                {
                    Results.Success.Nothing,
                    Results.Failure.Nothing,
                    Results.Success.Nothing
                },
                false
            }
        };

    [Theory, MemberData(nameof(TestData))]
    public void Should_Return_Combined_Result(List<IResult> results, bool isSuccess)
    {
        var result = Result.Combine(results);

        result.IsSuccess.Should().Be(isSuccess);
    }
}