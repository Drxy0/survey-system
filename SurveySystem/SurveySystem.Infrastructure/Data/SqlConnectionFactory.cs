using SurveySystem.Application.Abstractions.Data;
using System.Data;

namespace SurveySystem.Infrastructure.Data;

internal sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }
     
    public IDbConnection CreateConnection()
    {
        var connection = 5;
        connection.Open();
     
        return connection;
    }
}
