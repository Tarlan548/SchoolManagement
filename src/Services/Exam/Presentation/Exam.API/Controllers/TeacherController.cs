using Exam.Application.Features.Commands.TeacherCommands.CreateTeacher;
using Exam.Application.Features.Commands.TeacherCommands.DeleteTeacher;
using Exam.Application.Features.Commands.TeacherCommands.UpdateTeacher;
using Exam.Application.Features.Queries.TeacherQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exam.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TeacherController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllPagination([FromQuery] GetTeacherQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTeacherCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTeacherCommandRequest requset)
    {
        return Ok(await mediator.Send(requset));
    }

    [HttpPut]
    public async Task<IActionResult> Delete([FromBody] DeleteTeacherCommandRequest requset)
    {
        return Ok(await mediator.Send(requset));
    }
}