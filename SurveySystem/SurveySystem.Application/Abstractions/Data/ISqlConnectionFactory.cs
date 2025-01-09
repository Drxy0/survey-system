using System.Data;

namespace SurveySystem.Application.Abstractions.Data;

// This inteface is implemented in the infrastructure layer
// Even still, the current, application layer uses this inteface
// to call the implementation in the infrastructure layer by using dependency injection
public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}
