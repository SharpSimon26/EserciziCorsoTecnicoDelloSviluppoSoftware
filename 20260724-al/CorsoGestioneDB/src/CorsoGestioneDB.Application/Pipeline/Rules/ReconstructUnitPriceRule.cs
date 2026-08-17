using CorsoGestioneDB.Application.Engine;

namespace CorsoGestioneDB.Application.Pipeline.Rules;

public class ReconstructUnitPriceRule : IReconstructionRule
{
    public bool CanApply(ImportContext context)
    {
        var line = context.Data.OrderLine;

        return line.Revenue.HasValue && line.Revenue > 0 &&
               line.Quantity.HasValue && line.Quantity > 0 &&
               line.UnitPrice.HasValue && line.UnitPrice <= 0 &&
               line.DiscountPct.HasValue && line.DiscountPct >= 0;
    }
    
    public async Task ApplyAsync(ImportContext context)
    {
        var line = context.Data.OrderLine;
        //line.Revenue = line.Quantity * line.UnitPrice * (1 - line.DiscountPct / 100m);
        var calculatedUnitPrice = (line.Revenue - line.ShippingCost) / (line.Quantity * (1 - line.DiscountPct / 100m));
        context.Messages.Add(string.Format("UnitPrice modificato in {0} valore originale {1}", calculatedUnitPrice, line.UnitPrice));

        line.UnitPrice = calculatedUnitPrice;
    }
}