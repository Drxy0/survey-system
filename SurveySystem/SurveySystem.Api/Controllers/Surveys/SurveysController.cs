using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveySystem.Application.Surveys.CreateSurvey;
using SurveySystem.Application.Surveys.GetSurvey;
using System;

namespace SurveySystem.Api.Controllers.Surveys;

[Route("api/surveys")]
[ApiController]
public class SurveysController : ControllerBase
{
    private readonly ISender _sender;

    public SurveysController(ISender sender)
    {
        _sender = sender;
    }

    // Create new survey
    [HttpPost("create")]
    public async Task<ActionResult> CreateSurvey(CreateSurveyRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateSurveyCommand(request.Title, request.Qa, request.EmailList, request.IsAnonymous);
        var result = await _sender.Send(command, cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return Ok(result.Value);

    }

    // get survey by id
    [HttpGet("{id}")]
    public async Task<ActionResult> GetSurvey(Guid id, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new GetSurveyQuery(id), cancellationToken]);
        return Ok(result.Value);
    }
    // update survey (anwser the questions)
    [HttpPut("{id:Guid}")]
    public async Task<ActionResult> UpdateSurvey(Guid id, [FromBody] UpdateSurveyCommand answers, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new UpdateSurveyCommand(answers.X, answers.Y), cancellationToken]);
        // if the result if it's failure or not...
        return Ok(result.Value);
    }

}
