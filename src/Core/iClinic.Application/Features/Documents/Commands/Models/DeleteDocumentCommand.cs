using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.Documents.Commands.Models
{
    public class DeleteDocumentCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }

        public DeleteDocumentCommand(int id)
        {
            Id = id;
        }
    }
}
