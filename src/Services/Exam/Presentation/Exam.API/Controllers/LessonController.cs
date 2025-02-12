using Exam.Application.Features.Commands.LessonCommands.CreateLesson;
using Exam.Application.Features.Commands.LessonCommands.DeleteLesson;
using Exam.Application.Features.Commands.LessonCommands.UpdateLesson;
using Exam.Application.Features.Queries.LessonQueries.LessonGetAllQuery;
using Exam.Application.Features.Queries.LessonQueries.LessonPaginationQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exam.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LessonController(IMediator mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAllPagination([FromQuery] GetLessonQueryRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllLessonQueryRequest()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLessonCommandRequest requset)
        {
            return Ok(await mediator.Send(requset));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateLessonCommandRequest requset)
        {
            return Ok(await mediator.Send(requset));
        }

        [HttpPut]
        public async Task<IActionResult> Delete([FromBody] DeleteLessonCommandRequest requset)
        {
            return Ok(await mediator.Send(requset));
        }
    }
}
