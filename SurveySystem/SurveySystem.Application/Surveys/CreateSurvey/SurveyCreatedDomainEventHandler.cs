using SurveySystem.Domain.Surveys;
using SurveySystem.Domain.Surveys.Events;
using MediatR;

namespace SurveySystem.Application.Surveys.CreateSurvey;

internal sealed class SurveyCreatedDomainEventHandler : INotificationHandler<SurveyCreatedDomainEvent>
{
    public Task Handle(SurveyCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
