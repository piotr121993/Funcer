namespace Funcer;

public static class ResultExtensions_Compel
{
    public static void Compel(this Result result)
    {
        if (result.IsFailure) throw new FailureResultException(result.Errors);
    }
    
    public static void Compel(this Result result, Func<IList<Error>, Exception> exception)
    {
        if (result.IsFailure) throw exception(result.Errors);
    }
}