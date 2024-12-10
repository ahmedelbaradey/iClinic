using iClinic.Application.Base;
using iClinic.Application.Features.Documents.Queries.Responses;
using MediatR;

namespace iClinic.Application.Features.Documents.Queries.Models
{
    public class GetDocumentListQuery : IRequest<BaseResponse<List<GetDocumentListResponse>>>
    {

    }
}
