using SurveySystem.Application.Abstractions.Messaging;
using SurveySystem.Domain.Surveys;

namespace SurveySystem.Application.Surveys.CreateSurvey;

public record CreateSurveyCommand(
    string Title,
    List<QuestionAnwserPair> Qa,
    List<string> EmailList,
    bool IsAnonymous) : ICommand<Guid>;
