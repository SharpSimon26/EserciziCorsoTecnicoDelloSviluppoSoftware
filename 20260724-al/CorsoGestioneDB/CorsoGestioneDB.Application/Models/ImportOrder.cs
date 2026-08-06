namespace CorsoGestioneDB.Application.Models;

public class ImportOrder
{
    public string OrderID { get; set; } = string.Empty;
    public DateTime? OrderDate { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string SalesChannel { get; set; } = string.Empty;
    public string OrderStatus { get; set; } = string.Empty;
    public DateTime? DeliveryDate { get; set; }
}