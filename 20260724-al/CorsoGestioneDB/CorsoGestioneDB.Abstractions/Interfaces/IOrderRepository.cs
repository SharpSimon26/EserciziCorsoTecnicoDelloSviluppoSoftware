using CorsoGestioneDB.Domain.Entities;

namespace CorsoGestioneDB.Abstractions.Interfaces;

public interface IOrderRepository
{
    Task<Order?> GetOrderById(string orderId);
}
