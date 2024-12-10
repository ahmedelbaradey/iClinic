using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Clinics.Commands.Models
{
    public class DeleteClinicCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }

        public DeleteClinicCommand(int id)
        {
            Id = id;
        }
    }
}
