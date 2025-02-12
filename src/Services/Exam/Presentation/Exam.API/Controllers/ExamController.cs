using Exam.Application.Features.Commands.ExamCommands.CreateExam;
using Exam.Application.Features.Commands.ExamCommands.DeleteExam;
using Exam.Application.Features.Commands.ExamCommands.UpdateExam;
using Exam.Application.Features.Queries.ExamQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exam.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllPagination([FromQuery] GetExamQueryRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExamCommandRequest requset)
        {
            return Ok(await mediator.Send(requset));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateExamCommandRequest requset)
        {
            return Ok(await mediator.Send(requset));
        }

        [HttpPut]
        public async Task<IActionResult> Delete([FromBody] DeleteExamCommandRequest requset)
        {
            return Ok(await mediator.Send(requset));
        }
    }
}
