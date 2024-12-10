using iClinic.Application.Base;
using iClinic.Application.Features.StatusHistories.Querires.Responses;
using MediatR;

namespace iClinic.Application.Features.StatusHistories.Querires.Models
{
    public class GetStatusHistoryByIdQuery : IRequest<BaseResponse<GetSingleStatusHistoryResponse>>
    {
        public int Id { get; set; }
        public GetStatusHistoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
