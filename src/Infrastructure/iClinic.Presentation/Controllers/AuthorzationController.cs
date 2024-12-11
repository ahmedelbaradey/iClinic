using iClinic.Presentation.Bases;
using Microsoft.AspNetCore.Mvc;
using iClinic.Application.Features.Authorizations.Commands.Handlers.EditRole;
using iClinic.Application.Features.Authorizations.Commands.Handlers.EditUserRoles;
using iClinic.Application.Features.Authorizations.Queries.Handlers.GetRoleList;
using iClinic.Application.Features.Authorizations.Queries.Handlers.GetRoleById;
using iClinic.Application.Features.Authorizations.Commands.Handlers.AddRole;
using iClinic.Application.Features.Authorizations.Commands.Handlers.DeleteRole;
using iClinic.Application.Features.Authorizations.Queries.Handlers.ManageUserRoles;

namespace iClinic.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorzationController : AppControllerBase
    {
        [HttpGet("List")]
        public async Task<IActionResult> GetRoleList()
        {
            var response = await Mediator.Send(new GetRoleListQuery());
            return NewResult(response);
        }

        [HttpGet("Role/{Id:int}")]
        public async Task<IActionResult> GetRoleById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetRoleByIdQuery { Id=id});
            return NewResult(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateRole([FromForm] AddRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> EditRole([FromForm] EditRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> DeleteRole([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteRoleCommand { Id=id});
            return NewResult(response);
        }

        [HttpGet("Manager-User-Roles/{id:int}")]
        public async Task<IActionResult> ManagerUserRoles([FromRoute] int id)
        {
            var response = await Mediator.Send(new ManageUserRolesQuery { Id=id});
            return NewResult(response);
        }


        [HttpPut("Update-User-Roles")]
        public async Task<IActionResult> UpdateUserRoles([FromBody] EditUserRolesCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
