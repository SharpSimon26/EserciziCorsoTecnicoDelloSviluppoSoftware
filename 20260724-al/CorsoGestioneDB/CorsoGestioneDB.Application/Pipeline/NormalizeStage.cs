using CorsoGestioneDB.Application.Engine;
using CorsoGestioneDB.Application.Helpers;
using CorsoGestioneDB.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace CorsoGestioneDB.Application.Pipeline;

public class NormalizeStage : StageBase
{
    public NormalizeStage(ILogger<NormalizeStage> logger) : base(logger)
    {
    }

    public override async Task ExecuteAsync(ImportContext context)
    {
        NormalizeOrder(context);
        NormalizeOrderLine(context);
        NormalizeCustomer(context);
        NormalizeProduct(context);
    }

    private static void NormalizeOrder(ImportContext context)
    {
        var orderId = TextHelper.Normalize(context.RawOrder.OrderID);
        if (orderId.Changed)
        {
            context.RawOrder.OrderID = orderId.Value;
        }

        // TextHelper.Normalize(context.RawOrder.OrderDate);

        var paymentMethod = TextHelper.Normalize(context.RawOrder.PaymentMethod);
        if (paymentMethod.Changed)
        {
            context.RawOrder.PaymentMethod = paymentMethod.Value;
        }

        var salesChannel = TextHelper.Normalize(context.RawOrder.SalesChannel);

        var orderStatus = TextHelper.Normalize(context.RawOrder.OrderStatus);

        // TextHelper.Normalize(context.RawOrder.DeliveryDate);
    }

    private static void NormalizeOrderLine(ImportContext context)
    {
        // TextHelper.Normalize(context.RawOrder.Quantity);
        // TextHelper.Normalize(context.RawOrder.UnitPrice);
        // TextHelper.Normalize(context.RawOrder.DiscountPct);
        // TextHelper.Normalize(context.RawOrder.ShippingCost);
        // TextHelper.Normalize(context.RawOrder.Revenue);
    }

    private static void NormalizeCustomer(ImportContext context)
    {
        // TextHelper.Normalize(context.RawOrder.CustomerID);

        var firstName = TextHelper.Normalize(context.RawOrder.FirstName);

        var lastName = TextHelper.Normalize(context.RawOrder.LastName);

        var email = EmailHelper.Normalize(context.RawOrder.Email);

        var phone = TextHelper.Normalize(context.RawOrder.Phone);

        var city = TextHelper.Normalize(context.RawOrder.City);

        var province = TextHelper.Normalize(context.RawOrder.Province);

        var region = TextHelper.Normalize(context.RawOrder.Region);

        // TextHelper.Normalize(context.RawOrder.SignupDate);
    }

    private static void NormalizeProduct(ImportContext context)
    {
        var productCode = TextHelper.Normalize(context.RawOrder.ProductCode);

        var productName = TextHelper.Normalize(context.RawOrder.ProductName);

        var category = TextHelper.Normalize(context.RawOrder.Category);
    }
}
