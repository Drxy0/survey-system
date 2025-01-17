using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveySystem.Application.Users.GetUser;
using System.Threading;

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

    [HttpGet]
    public async Task<IActionResult> GetUser(string email, CancellationToken cancellationToken)
    {

        var query = new GetUserQuery(email);
        // sends the query to MediatR, which routes it to GetUserQueryHandler
        var result = await _sender.Send(query, cancellationToken);
        return Ok(result.Value);
    }
}
