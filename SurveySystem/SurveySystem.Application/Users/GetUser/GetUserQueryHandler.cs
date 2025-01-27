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

        User? user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (user is null)
        {
            return Result.Failure<User>(UserErrors.NotFound);
        }
        return user;
    }
}