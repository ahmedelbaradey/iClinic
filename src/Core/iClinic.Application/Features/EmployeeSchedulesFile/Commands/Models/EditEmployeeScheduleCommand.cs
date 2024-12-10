using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.EmployeeSchedulesFile.Commands.Models
{
    public class EditEmployeeScheduleCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int DepartmentId { get; set; }

        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public bool IsActive { get; set; }

    }
}
