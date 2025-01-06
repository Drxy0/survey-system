using SurveySystem.Domain.Abstractions;
namespace SurveySystem.Domain.Survey.Events;

public sealed record SurveyCreatedDomainEvent(Guid SurveyId) : IDomainEvent;