namespace Funcer;

public static class ResultExtensions_Compel
{
    public static void Compel(this Result result)
    {
        if (result.IsFailure) throw new FailureResultException(result.Errors);
    }
}