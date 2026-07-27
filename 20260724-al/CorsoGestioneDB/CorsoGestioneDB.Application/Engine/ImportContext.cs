using CorsoGestioneDB.Domain.Entities;

namespace CorsoGestioneDB.Application.Engine;

public class ImportContext
{
    public StagingOrder RawOrder { get; private set; }
    public List<string> Messages { get; private set; }
    public bool IsRejected { get; private set; }
    public string? RejectReason { get; private set; }

    public ImportContext(StagingOrder rawOrder)
    {
        RawOrder = rawOrder;
        Messages = [];
    }

    public void Reject(string reason)
    {
        IsRejected = true;
        RejectReason = reason;
    }
}
