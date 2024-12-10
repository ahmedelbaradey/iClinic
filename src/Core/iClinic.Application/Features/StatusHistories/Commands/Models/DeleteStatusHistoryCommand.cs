using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.StatusHistories.Commands.Models
{
    public class DeleteStatusHistoryCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public DeleteStatusHistoryCommand(int id)
        {
            Id = id;
        }
    }
}
