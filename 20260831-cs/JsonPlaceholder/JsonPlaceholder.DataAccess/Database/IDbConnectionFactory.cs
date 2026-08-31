using System.Data;

namespace JsonPlaceholder.DataAccess.Database;

public interface IDbConnectionFactory
{
    Task<IDbConnection> CreateConnection();
}
