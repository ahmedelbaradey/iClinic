using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Clinics.Commands.Models
{
    public class EditClinicCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string? Details { get; set; }
    }
}
