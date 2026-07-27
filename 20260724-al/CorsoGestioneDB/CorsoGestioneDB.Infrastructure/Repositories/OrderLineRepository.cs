using CorsoGestioneDB.Abstractions.Interfaces;
using CorsoGestioneDB.Infrastructure.Database;

namespace CorsoGestioneDB.Infrastructure.Repositories;

public class OrderLineRepository : AbstractRepository, IOrderLineRepository
{
    public OrderLineRepository(DbConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }
}
