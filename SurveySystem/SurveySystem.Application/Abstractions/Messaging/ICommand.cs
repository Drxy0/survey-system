using SurveySystem.Domain.Abstractions;
using MediatR;

namespace SurveySystem.Application.Abstractions.Messaging;

// Commands that don't return a specific response
// IRequest<Result> - provided by MediatR
// will return a Result (indicating success or failure).
public interface ICommand : IRequest<Result>, IBaseCommand
{
}

// Commands sthat do return a specific response, specific type
// IRequest<Result<TResponse>> - provided by MediatR
// will return a Result<TResponse> (a success/failure result containing the response type TResponse).
public interface ICommand<TReponse> : IRequest<Result<TReponse>>, IBaseCommand
{
}

// Base interface that all commands extend
public interface IBaseCommand
{
}