using MediatR;
using Microsoft.AspNetCore.Mvc;
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
}