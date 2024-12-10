using iClinic.Presentation.Bases;
using iClinic.Application.Features.EmployeeSchedulesFile.Commands.Models;
using iClinic.Application.Features.EmployeeSchedulesFile.Queries.Models;
using  iClinic.Application.Abstracts.Presistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace iClinic.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeScheduleController : AppControllerBase
    {
        private readonly IClinicDepartmentService _clinicDepartmentService;

        public EmployeeScheduleController(IClinicDepartmentService clinicDepartmentService)
        {
            _clinicDepartmentService = clinicDepartmentService;
        }

        [HttpGet("List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetEmployeeScheduleList()
        {
            var response = await Mediator.Send(new GetEmployeeScheduleListQuery());
            return NewResult(response);
        }

        [HttpGet("Paginated/List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetEmployeeSchedulePaginatedList([FromQuery] GetEmployeeSchedulePaginatedQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetEmployeeScheduleById([FromRoute] int Id)
        {
            var response = await Mediator.Send(new GetEmployeeScheduleByIdQuery(Id));
            return NewResult(response);
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateEmployeeSchedule([FromBody] AddEmployeeScheduleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> UpdateEmployeeSchedule([FromBody] EditEmployeeScheduleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteEmployeeSchedule([FromRoute] int Id)
        {
            var response = await Mediator.Send(new DeleteEmployeeScheduleCommand(Id));
            return NewResult(response);
        }
    }
}
