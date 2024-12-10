using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Documents.Commands.Models
{
    public class AddDocumentCommand : IRequest<BaseResponse<string>>
    {
        public string DocumentName { get; set; } = null!;
        public string? Details { get; set; }
        public int DocumentTypeId { get; set; }
        public int AppointmentId { get; set; }
    }
}
