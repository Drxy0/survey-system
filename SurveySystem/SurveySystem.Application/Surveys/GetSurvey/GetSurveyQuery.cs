using SurveySystem.Application.Abstractions.Messaging;
using SurveySystem.Domain.Surveys;
using SurveySystem.Domain.Users;

namespace SurveySystem.Application.Surveys.GetSurvey;

public sealed record GetSurveyQuery(Guid Id) : IQuery<Survey>;
