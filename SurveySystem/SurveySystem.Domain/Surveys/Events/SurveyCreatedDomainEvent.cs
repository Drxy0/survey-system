using SurveySystem.Domain.Abstractions;
namespace SurveySystem.Domain.Surveys.Events;

public sealed record SurveyCreatedDomainEvent(Guid SurveyId) : IDomainEvent;