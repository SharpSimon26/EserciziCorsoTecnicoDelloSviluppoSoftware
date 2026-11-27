using Todo.DataAccess.Database;

namespace Todo.DataAccess.Repositories;

public class AbstractRepository
{
    protected readonly IDbConnectionFactory connectionFactory;

    protected AbstractRepository(IDbConnectionFactory connectionFactory)
    {
        this.connectionFactory = connectionFactory;
    }
}