using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Clinics.Commands.Models
{
    public class AddClinicCommand : IRequest<BaseResponse<string>>
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Details { get; set; }
    }
}
