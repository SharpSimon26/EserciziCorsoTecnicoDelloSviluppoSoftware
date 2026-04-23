namespace ConsAppEccezioni.Exceptions;

internal class MyCustomException : Exception
{
    public int UserId { get; set; }

    public MyCustomException(int userid)
    {
        UserId = userid;
    }

    public MyCustomException(int userid, string msg) : base(msg)
    {
        UserId = userid;
    }
}