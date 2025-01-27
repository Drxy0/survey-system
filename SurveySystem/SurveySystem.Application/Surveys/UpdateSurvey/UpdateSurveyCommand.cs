using SurveySystem.Application.Abstractions.Messaging;
using SurveySystem.Domain.Surveys;

namespace SurveySystem.Application.Surveys.UpdateSurvey;

public sealed record UpdateSurveyCommand(
    Guid Id,
    List<QuestionAnwserPair> Answers) : ICommand<Guid>;
