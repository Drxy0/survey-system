using MediatR;
using SurveySystem.Application.Abstractions.Messaging;
using SurveySystem.Application.Exceptions;
using SurveySystem.Domain.Abstractions;
using SurveySystem.Domain.Surveys;

namespace SurveySystem.Application.Surveys.UpdateSurvey;

internal sealed class UpdateSurveyCommandHandler : ICommandHandler<UpdateSurveyCommand, Guid>
{
    private ISurveyRepository _surveyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateSurveyCommandHandler(ISurveyRepository surveyRepository, IUnitOfWork unitOfWork)
    {
        _surveyRepository = surveyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(UpdateSurveyCommand request, CancellationToken cancellationToken)
    {
        Survey? survey = await _surveyRepository.GetByIdAsync(request.Id, cancellationToken);
        if (survey is null)
        {
            return Result.Failure<Guid>(SurveyErrors.NotFound);
        }

        try
        {
            survey.QuestionsAndAnwsers = request.Answers;
            _surveyRepository.Add(survey);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return survey.Id;
        }
        catch (ConcurrencyException)
        {
            return Result.Failure<Guid>(SurveyErrors.Overlap);
        }
    }
}
