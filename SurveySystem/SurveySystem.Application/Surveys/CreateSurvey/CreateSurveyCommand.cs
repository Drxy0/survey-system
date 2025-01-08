using SurveySystem.Application.Abstractions.Messaging;

namespace SurveySystem.Application.Surveys.CreateSurvey;

public record CreateSurveyCommand(
    Guid SurveyId

    ) : ICommand<Guid>;
