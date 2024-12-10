using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Doctors.Commands.Handlers.DeleteDoctor
{
    public class DeleteDoctorCommand : ICommand<BaseResponse<string>>
    {
        public int Id { get; set; }
 
    }
}
