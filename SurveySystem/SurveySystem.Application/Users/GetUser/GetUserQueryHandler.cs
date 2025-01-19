using SurveySystem.Application.Abstractions.Messaging;
using SurveySystem.Domain.Abstractions;
using SurveySystem.Domain.Users;

namespace SurveySystem.Application.Users.GetUser;

internal sealed class GetUserQueryHandler : IQueryHandler<GetUserQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        // TODO: Getting with email should only be an application layer operation, not an End-to-End one.
        // TODO: Make it get by Id because you shouldn't pass email through the URL params (=
        // TODO: Handle the case if a user with a given username is not found

        // The argument for dapper can be made here so that you don't have to pass this request to the extra level of abstraction
        // Aka the infrastructure layer, but I am not in favour of using multiple different database methods of accessing the database
        // If you really want it you can return the dapper implementation 

        User? user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        return user;
    }
}