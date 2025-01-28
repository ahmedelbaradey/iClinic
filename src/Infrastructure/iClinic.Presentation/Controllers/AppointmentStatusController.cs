using iClinic.Presentation.Bases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using iClinic.Application.Features.AppointmentStatuses.Commands.Handlers.AddAppointmentStatuses;
using iClinic.Application.Features.AppointmentStatuses.Commands.Handlers.UpdateAppointmentStatuses;
using iClinic.Application.Features.AppointmentStatuses.Queries.Handlers.GetAppointmentStatusList;
using iClinic.Application.Features.AppointmentStatuses.Queries.Handlers.GetAppointmentStatusLById;
using iClinic.Application.Features.AppointmentStatuses.Commands.Handlers.DeleteAppointmentStatuses;

namespace iClinic.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentStatusController : AppControllerBase
    {


        [HttpGet("List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAppointmentStatusList()
        {
            var response = await Mediator.Send(new GetAppointmentStatusListQuery());
            return NewResult(response);
        }

        [HttpGet("{Id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAppointmentStatusById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetAppointmentStatusLByIdQuery() {Id = id });
            return NewResult(response);
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateAppointmentStatus([FromBody] AddAppointmentStatusCommand command)
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
        public async Task<IActionResult> UpdateAppointmentStatus([FromBody] UpdateAppointmentStatusCommand command)
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
        public async Task<IActionResult> DeleteAppointmentStatus([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteAppointmentStatusCommand() { Id= id});
            return NewResult(response);
        }
    }
}
