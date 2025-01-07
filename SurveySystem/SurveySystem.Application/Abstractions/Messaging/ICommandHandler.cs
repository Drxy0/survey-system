using SurveySystem.Domain.Abstractions;
using MediatR;

namespace SurveySystem.Application.Abstractions.Messaging;

// Handle commands that do not return a specific response, only report success/failure
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}

// Handle commands that reutn a specific response
public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}