
using SurveySystem.Application.Abstractions.Messaging;
using SurveySystem.Domain.Abstractions;
using SurveySystem.Domain.Surveys;
using SurveySystem.Domain.Users;

namespace SurveySystem.Application.Surveys.GetSurvey;

internal sealed class GetSurveyQueryHandler : IQueryHandler<GetSurveyQuery, Survey>
{
    private readonly ISurveyRepository _surveyRepository;

    public GetSurveyQueryHandler(ISurveyRepository surveyRepository)
    {
        _surveyRepository = surveyRepository;
    }
    public async Task<Result<Survey>> Handle(GetSurveyQuery request, CancellationToken cancellationToken)
    {
        Survey? survey = await _surveyRepository.GetByIdAsync(request.Id, cancellationToken);
        if (survey is null)
        {
            return Result.Failure<Survey>(SurveyErrors.NotFound);
        }
        return survey;
    }
}
