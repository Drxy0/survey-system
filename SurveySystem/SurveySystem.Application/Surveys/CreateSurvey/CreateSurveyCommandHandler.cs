using MediatR;
using SurveySystem.Application.Abstractions.Messaging;
using SurveySystem.Application.Exceptions;
using SurveySystem.Domain.Abstractions;
using SurveySystem.Domain.Surveys;
using SurveySystem.Domain.Users;

namespace SurveySystem.Application.Surveys.CreateSurvey;

internal sealed class CreateSurveyCommandHandler : ICommandHandler<CreateSurveyCommand, Guid>
{
    private readonly ISurveyRepository _surveyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSurveyCommandHandler(
        ISurveyRepository surveyRepository,
        IUnitOfWork unitOfWork)
    {
        _surveyRepository = surveyRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<Guid>> Handle(CreateSurveyCommand command, CancellationToken cancellationToken)
    {
        if (command.EmailList.Count > 50)
        {
            return Result.Failure<Guid>(SurveyErrors.TooManyEmails);
        }
        try
        {
            var newSurvey = Survey.Create(command.Title, command.Qa, command.EmailList, command.IsAnonymous);
            _surveyRepository.Add(newSurvey);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return newSurvey.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(SurveyErrors.Overlap);
        }
    }
}
