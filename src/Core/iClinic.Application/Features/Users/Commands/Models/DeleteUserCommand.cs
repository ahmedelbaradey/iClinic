using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Users.Commands.Models
{
    public class DeleteUserCommand : IRequest<BaseResponse<string>>
    {
        public DeleteUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
