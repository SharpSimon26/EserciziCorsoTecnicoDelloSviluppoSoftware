namespace CorsoGestioneDB.Application.Models;

public class ImportOrderLine
{
    public string OrderID { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public int DiscountPct { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal Revenue { get; set; }
}