using CorsoGestioneDB.Abstractions.Interfaces;
using CorsoGestioneDB.Infrastructure.Database;

namespace CorsoGestioneDB.Infrastructure.Repositories;

public class CustomerRepository : AbstractRepository, ICustomerRepository
{
    public CustomerRepository(DbConnectionFactory connectionFactory) : base(connectionFactory)
    {
    }
}
