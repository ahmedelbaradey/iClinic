using iClinic.Application.Base;
using iClinic.Application.Features.DocumentTypes.Queriers.Response;
using MediatR;

namespace iClinic.Application.Features.DocumentTypes.Queriers.Models
{
    public class GetDocumentTypeListQuery : IRequest<BaseResponse<List<GetDocumentTypeListResponse>>>
    {

    }
}
