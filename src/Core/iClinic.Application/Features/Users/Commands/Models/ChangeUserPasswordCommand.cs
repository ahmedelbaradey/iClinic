using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Users.Commands.Models
{
    public class ChangeUserPasswordCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public string CurrentPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
    }
}
