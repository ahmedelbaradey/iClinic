using iClinic.Application.Base;
using iClinic.Application.Features.StatusHistories.Querires.Responses;
using MediatR;

namespace iClinic.Application.Features.StatusHistories.Querires.Models
{
    public class GetStatusHistoryListQuery : IRequest<BaseResponse<List<GetStatusHistoryListResponse>>>
    {

    }
}
