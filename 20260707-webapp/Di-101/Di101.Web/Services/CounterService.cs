namespace Di101.Web.Services;

public class CounterService
{
    private int count;
    public Guid MyGuid { get; set; }

    public CounterService(InitialCounterService start)
    {
        count = start.Value;
        MyGuid = Guid.NewGuid();
    }

    public int GetCount()
    {
        return ++count;
    }
}