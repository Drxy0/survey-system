using SurveySystem.Domain.Abstractions;
using MediatR;

namespace SurveySystem.Application.Abstractions.Messaging;

// Represents a query request
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}