using SurveySystem.Application.Abstractions.Messaging;
using SurveySystem.Domain.Abstractions;
using SurveySystem.Domain.Users;

namespace SurveySystem.Application.Users.Login;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public LoginCommandHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Guid>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user is null)
        {
            return Result.Failure<Guid>(UserErrors.AlreadyExists);
        }

        if (user.Password.Equals(request.Password))
        {
            return user.Id;
        }
        else
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }
    }
}