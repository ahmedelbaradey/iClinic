using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Users.Commands.Models
{
    public class AddUserCommand : IRequest<BaseResponse<string>>
    {
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
    }
}
