using CorsoGestioneDB.Application.Models;
using CorsoGestioneDB.Domain.Entities;

namespace CorsoGestioneDB.Application.Engine;

public class ImportContext
{
    public StagingOrder RawOrder { get; private set; }
    public ImportOrder Order { get; private set; }
    public ImportOrderLine OrderLine { get; private set; }
    public ImportCustomer Customer { get; private set; }
    public ImportProduct Product { get; private set; }
    public List<string> Messages { get; private set; }
    public bool IsRejected { get; private set; }
    public string? RejectReason { get; private set; }

    public ImportContext(StagingOrder rawOrder)
    {
        RawOrder = rawOrder;
        Order = new();
        OrderLine = new();
        Customer = new();
        Product = new();
        Messages = [];
    }

    public void Reject(string reason)
    {
        IsRejected = true;
        RejectReason = reason;
    }
}
