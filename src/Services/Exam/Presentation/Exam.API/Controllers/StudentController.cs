using Exam.Application.Features.Commands.StudentCommands.CreateStudent;
using Exam.Application.Features.Commands.StudentCommands.DeleteStudent;
using Exam.Application.Features.Commands.StudentCommands.UpdateStudent;
using Exam.Application.Features.Queries.StudentQueries.StudentGetAllQuery;
using Exam.Application.Features.Queries.StudentQueries.StudentPaginationQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exam.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllPagination([FromQuery] GetStudentQueryRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllStudentQueryRequest()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentCommandRequest requset)
        {
            return Ok(await mediator.Send(requset));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStudentCommandRequest requset)
        {
            return Ok(await mediator.Send(requset));
        }

        [HttpPut]
        public async Task<IActionResult> Delete([FromBody] DeleteStudentCommandRequest requset)
        {
            return Ok(await mediator.Send(requset));
        }
    }
}
