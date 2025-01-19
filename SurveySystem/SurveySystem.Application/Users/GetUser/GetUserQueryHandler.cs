using SurveySystem.Application.Abstractions.Data;
using SurveySystem.Application.Abstractions.Messaging;
using SurveySystem.Domain.Abstractions;
using SurveySystem.Domain.Users;
using Dapper;

namespace SurveySystem.Application.Users.GetUser;

internal sealed class GetUserQueryHandler : IQueryHandler<GetUserQuery, IReadOnlyList<User>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public GetUserQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<User>>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                a.id AS Id,
                a.name AS Name,
                a.surname AS Surname,
                a.password AS Password,
                a.street_address AS StreetAddress,
                a.city AS City,
                a.country AS Country,
                a.phone_number AS PhoneNumber,
                a.email AS Email
            FROM users AS a
            WHERE a.email = '@Email';
            """;

        var users = await connection.QueryAsync<User>(
            sql,
            new { Email = request.Email }
        );

        return Result<IReadOnlyList<User>>.Success(users.ToList() as IReadOnlyList<User>);
    }
}
