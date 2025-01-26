using SurveySystem.Domain.Surveys;

namespace SurveySystem.Api.Controllers.Surveys;

public sealed record CreateSurveyRequest(
    string Title,
    List<QuestionAnwserPair> Qa,
    List<string> EmailList,
    bool IsAnonymous);
