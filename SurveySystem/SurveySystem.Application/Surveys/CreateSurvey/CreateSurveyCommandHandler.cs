using SurveySystem.Application.Abstractions.Messaging;
using SurveySystem.Domain.Abstractions;
using SurveySystem.Domain.Surveys;
using SurveySystem.Domain.Users;

namespace SurveySystem.Application.Surveys.CreateSurvey;

internal sealed class CreateSurveyCommandHandler : ICommandHandler<CreateSurveyCommand, Guid>
{
    private readonly ISurveyRepository _surveyRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSurveyCommandHandler(
        ISurveyRepository surveyRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _surveyRepository = surveyRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public static Create()
    {
        throw new NotImplementedException();
    }
    public Task<Result<Guid>> Handle(CreateSurveyCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
