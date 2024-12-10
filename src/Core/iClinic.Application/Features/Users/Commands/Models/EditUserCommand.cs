using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Users.Commands.Models
{
    public class EditUserCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
    }
}
