using CorsoGestioneDB.Application.Engine;
using CorsoGestioneDB.Application.Helpers;
using Microsoft.Extensions.Logging;

namespace CorsoGestioneDB.Application.Pipeline;

public class ConvertStage : StageBase
{
    public ConvertStage(ILogger<ConvertStage> logger) : base(logger)
    {
    }

    public override async Task ExecuteAsync(ImportContext context)
    {
        ConvertOrder(context);
        ConvertOrderLine(context);
        ConvertCustomer(context);
        ConvertProduct(context);
    }

    public static void ConvertOrder(ImportContext context)
    {
        // OrderID
        context.Order.OrderID = context.RawOrder.OrderID;

        // OrderDate
        var dtOrderDate = ConvertHelper.ToDateTime(context.RawOrder.OrderDate);
    
        if (dtOrderDate.Success)
        {
            context.Order.OrderDate = dtOrderDate.Value;
        }
        else
        {
            context.Messages.Add(dtOrderDate.ErrorMessage);
        }
        
        // PaymentMethod
        context.Order.PaymentMethod = context.RawOrder.PaymentMethod;

        // SalesChannel
        context.Order.SalesChannel = context.RawOrder.SalesChannel;

        // OrderStatus
        context.Order.OrderStatus = context.RawOrder.OrderStatus;

        // DeliveryDate -> potrebbe essere null
        if (!string.IsNullOrWhiteSpace(context.RawOrder.DeliveryDate))
        {
            var dtDeliveryDate = ConvertHelper.ToDateTime(context.RawOrder.DeliveryDate);

            if (dtDeliveryDate.Success)
            {
                context.Order.DeliveryDate = dtDeliveryDate.Value;
            }
            else
            {
                context.Messages.Add(dtDeliveryDate.ErrorMessage);
            }
        }
    }

    public static void ConvertOrderLine(ImportContext context)
    {
        // Quantity
        var qty = ConvertHelper.ToInt(context.RawOrder.Quantity);

        if (qty.Success)
        {
            context.OrderLine.Quantity = qty.Value;
        }
        else
        {
            context.Messages.Add(qty.ErrorMessage);
        }

        // UnitPrice
        var unitPrice = ConvertHelper.ToDecimal(context.RawOrder.UnitPrice);

        if (unitPrice.Success)
        {
            context.OrderLine.UnitPrice = unitPrice.Value;
        }
        else
        {
            context.Messages.Add(unitPrice.ErrorMessage);
        }

        // DiscountPct
        var discountPct = ConvertHelper.ToInt(context.RawOrder.DiscountPct);

        if (discountPct.Success)
        {
            context.OrderLine.DiscountPct = discountPct.Value;
        }
        else
        {
            context.Messages.Add(discountPct.ErrorMessage);
        }

        // ShippingCost
        var shippingCost = ConvertHelper.ToDecimal(context.RawOrder.ShippingCost);

        if (shippingCost.Success)
        {
            context.OrderLine.ShippingCost = shippingCost.Value;
        }
        else
        {
            context.Messages.Add(shippingCost.ErrorMessage);
        }

        // Revenue
        var revenue = ConvertHelper.ToDecimal(context.RawOrder.Revenue);

        if (revenue.Success)
        {
            context.OrderLine.Revenue = revenue.Value;
        }
        else
        {
            context.Messages.Add(revenue.ErrorMessage);
        }
    }

    public static void ConvertCustomer(ImportContext context)
    {
        // CustomerID
        var customerId = ConvertHelper.ToInt(context.RawOrder.CustomerID);

        if (customerId.Success)
        {
            context.Customer.CustomerID = customerId.Value;
        }
        else
        {
            context.Messages.Add(customerId.ErrorMessage);
        }

        // FirstName
        context.Customer.FirstName = context.RawOrder.FirstName;

        // LastName
        context.Customer.LastName = context.RawOrder.LastName;

        // Email
        context.Customer.Email = context.RawOrder.Email;

        // City
        context.Customer.City = context.RawOrder.City;

        // Province
        context.Customer.Province = context.RawOrder.Province;

        // Region
        context.Customer.Region = context.RawOrder.Region;

        // SignupDate
        var signupDate = ConvertHelper.ToDateTime(context.RawOrder.SignupDate);

        if (signupDate.Success)
        {
            context.Customer.SignupDate = signupDate.Value;
        }
        else
        {
            context.Messages.Add(signupDate.ErrorMessage);
        }
    }

    public static void ConvertProduct(ImportContext context)
    {
        // ProductCode
        context.Product.ProductCode = context.RawOrder.ProductCode;

        // ProductName
        context.Product.ProductName = context.RawOrder.ProductName;

        // Category
        context.Product.CategoryName = context.RawOrder.Category;
    }
}