using CorsoGestioneDB.Application.Engine;

namespace CorsoGestioneDB.Application.Pipeline.Rules;

public class ReconstructQuantityRule : IReconstructionRule
{
    public bool CanApply(ImportContext context)
    {
        var line = context.Data.OrderLine;

        return line.Revenue.HasValue && line.Revenue > 0 &&
               line.Quantity.HasValue && line.Quantity <= 0 &&
               line.UnitPrice.HasValue && line.UnitPrice > 0 &&
               line.DiscountPct.HasValue && line.DiscountPct >= 0;
    }

    public async Task ApplyAsync(ImportContext context)
    {
        var line = context.Data.OrderLine;
        var calculatedQuantity = (line.Revenue - line.ShippingCost) / (line.UnitPrice * (1 - line.DiscountPct / 100m));

        if (calculatedQuantity == Math.Truncate(calculatedQuantity.GetValueOrDefault()))
        {
            line.Quantity = (int)calculatedQuantity;
            context.Messages.Add(string.Format("Quantity modificato in {0} valore originale {1}", calculatedQuantity, line.Quantity));
        }
    }
}