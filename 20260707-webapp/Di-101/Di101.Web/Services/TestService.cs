namespace Di101.Web.Services;

public class TestService
{
    public CounterService Counter { get; private set; }

    public TestService(CounterService counter)
    {
        Counter = counter;
    }
}