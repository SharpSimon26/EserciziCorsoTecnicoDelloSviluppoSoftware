using CorsoGestioneDB.Application.Models;
using CorsoGestioneDB.Domain.Entities;

namespace CorsoGestioneDB.Application.Engine;

public class ImportContext
{
    public StagingOrder RawOrder { get; private set; }
    public ImportData Data { get; private set; }
    public List<string> Messages { get; private set; }
    public ImportRecordStatus Status { get; private set; }
    public string? RejectReason { get; private set; }

    public ImportContext(StagingOrder rawOrder)
    {
        RawOrder = rawOrder;
        Status = ImportRecordStatus.Pending;
        Data = new();
        Messages = [];
    }

    public bool IsProcessable()
    {
        return Status == ImportRecordStatus.Pending;
    }

    public bool IsRejected()
    {
        return Status == ImportRecordStatus.Rejected || Status == ImportRecordStatus.Duplicate;
    }

    public void Reject(string reason)
    {
        Status = ImportRecordStatus.Rejected;
        RejectReason = reason;
    }
}
