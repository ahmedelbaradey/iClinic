using iClinic.Application.Base;
using iClinic.Application.Features.Documents.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.Documents.Queries.Models
{
    public class GetDocumentByIdQuery : IRequest<BaseResponse<GetSingleDocumentResponse>>
    {

        public int Id { get; set; }
        public GetDocumentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
