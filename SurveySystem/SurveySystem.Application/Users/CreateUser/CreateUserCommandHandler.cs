using SurveySystem.Application.Exceptions;
using SurveySystem.Domain.Abstractions;
using SurveySystem.Domain.Users;
using  SurveySystem.Application.Abstractions.Messaging;

namespace SurveySystem.Application.Users.CreateUser;

internal sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Guid>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user is not null)
        {
            return Result.Failure<Guid>(UserErrors.AlreadyExists);
        }

        try
        {
            var newUser = User.Create(
                request.Name,
                request.Surname,
                request.Email,
                request.Password,
                request.PhoneNumber,
                request.Address,
                request.City,
                request.Country);

            _userRepository.Add(newUser);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return newUser.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(UserErrors.NotFound);
        }
    }
}
