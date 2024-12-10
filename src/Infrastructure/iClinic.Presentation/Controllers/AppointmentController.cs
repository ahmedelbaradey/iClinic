﻿using iClinic.Presentation.Bases;
using iClinic.Application.Features.Appointments.Commands.Handlers.AddAppointment;
using iClinic.Application.Features.Appointments.Commands.Handlers.DeleteAppointment;
using iClinic.Application.Features.Appointments.Commands.Handlers.EditAppointment;
using iClinic.Application.Features.Appointments.Queries.Handlers.GetAppointmentById;
using iClinic.Application.Features.Appointments.Queries.Handlers.GetAppointmentList;
using iClinic.Application.Features.Appointments.Queries.Handlers.GetAppointmentPaginated;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace iClinic.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("admin,user,doctor")]
    public class AppointmentController : AppControllerBase
    {
        [HttpGet("List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAppointmentList()
        {
            var response = await Mediator.Send(new GetAppointmentListQuery());
            return NewResult(response);
        }

        [HttpGet("Paginated/List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAppointmentPaginated([FromQuery] GetAppointmentPaginatedQuery query)
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
        public async Task<IActionResult> GetAppointmentById([FromRoute] int id)
        {
            var command = new GetAppointmentByIdQuery { Id = id };
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> CreateAppointment([FromBody] AddAppointmentCommand command)
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
        public async Task<IActionResult> UpdateAppointment([FromBody] EditAppointmentCommand command)
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
        public async Task<IActionResult> DeleteAppointment([FromRoute] int id)
        {
            var command = new DeleteAppointmentCommand { Id =  id };
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
