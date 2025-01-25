using MediatR;
using Microsoft.AspNetCore.Mvc;
using SurveySystem.Application.Users.CreateUser;
using SurveySystem.Application.Users.GetUser;

namespace SurveySystem.Api.Controllers.Users;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    // MediatR's abstraction for sending requests
    private readonly ISender _sender;

    public UsersController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{email}")]
    public async Task<ActionResult> GetUser(string email, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetUserQuery(email), cancellationToken);
        return Ok(result.Value);
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand(
            request.Name,
            request.Surname,
            request.Email,
            request.Password,
            request.PhoneNumber,
            request.Address,
            request.City,
            request.Country
        );

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        return Ok(result.Value);
    }
}