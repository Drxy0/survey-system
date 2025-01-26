using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SurveySystem.Application.Users.CreateUser;
using SurveySystem.Application.Users.GetUser;
using SurveySystem.Application.Users.Login;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        var command = new LoginCommand(request.Email, request.Password);

        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }
        return Ok(result.Value);
    }

    //[HttpPost("logout")]
    //public async Task<ActionResult> Logout(string token, CancellationToken cancellationToken)
    //{
    //    var command = new LogoutCommand();

    //    var result = await _sender.Send(command, cancellationToken);

    //    if (result.IsFailure)
    //    {
    //        return BadRequest(result.Error);
    //    }
    //    return Ok(result.Value);
    //}

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