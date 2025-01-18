using MediatR;
using SurveySystem.Domain.Abstractions;

namespace SurveySystem.Application.Abstractions.Messaging;

// Represents a query request
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}