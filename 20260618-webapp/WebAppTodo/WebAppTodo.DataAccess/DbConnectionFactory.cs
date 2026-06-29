using Oracle.ManagedDataAccess.Client;
using WebAppTodo.DataAccess.Models;

namespace WebAppTodo.DataAccess;

public class DbConnectionFactory
{
    private readonly string _connectionString;

    public DbConnectionFactory(OracleDbSettings dbSettings)
    {
        _connectionString = $"User Id={dbSettings.Username};Password={dbSettings.Password};Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCPS)(HOST={dbSettings.Host})(PORT={dbSettings.Port}))(CONNECT_DATA=(SERVICE_NAME={dbSettings.ServiceName})))";
    }

    public OracleConnection CreateConnection()
    {
        return new OracleConnection(_connectionString);
    }
}