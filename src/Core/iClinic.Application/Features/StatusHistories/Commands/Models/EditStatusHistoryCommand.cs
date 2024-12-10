using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.StatusHistories.Commands.Models
{
    public class EditStatusHistoryCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public string? details { get; set; }
        public int AppointmentId { get; set; }
        public int AppointmentStatusID { get; set; }
    }
}
