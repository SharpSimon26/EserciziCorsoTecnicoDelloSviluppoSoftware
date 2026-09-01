using System.Data;

namespace Todo.DataAccess.Database;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnection();
}
