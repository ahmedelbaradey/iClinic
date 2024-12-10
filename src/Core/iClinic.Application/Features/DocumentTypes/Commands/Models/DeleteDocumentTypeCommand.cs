using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.DocumentTypes.Commands.Models
{
    public class DeleteDocumentTypeCommand : IRequest<BaseResponse<string>>
    {
        public DeleteDocumentTypeCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
