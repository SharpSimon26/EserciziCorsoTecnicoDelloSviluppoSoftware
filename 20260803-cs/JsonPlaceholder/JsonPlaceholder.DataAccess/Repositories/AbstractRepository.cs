using JsonPlaceholder.DataAccess.Database;

namespace JsonPlaceholder.DataAccess.Repositories;

public class AbstractRepository
{
    protected readonly DbConnectionFactory connectionFactory;

    protected AbstractRepository(DbConnectionFactory connectionFactory)
    {
        this.connectionFactory = connectionFactory;
    }
}
