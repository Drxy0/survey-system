using SurveySystem.Domain.Abstractions;
using MediatR;

namespace SurveySystem.Application.Abstractions.Messaging;

// Handles queries, enforces a structure for query handlers in the CQRS pattern
public interface IQueryHandler<TQuery, TResponse> :
    IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
