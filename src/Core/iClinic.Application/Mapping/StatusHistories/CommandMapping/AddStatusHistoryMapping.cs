using iClinic.Application.Features.StatusHistories.Commands.Models;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.StatusHistories
{
    public partial class StatusHistoryProfile
    {
        public void AddStatusHistoryMapping()
        {
            CreateMap<AddStatusHistoryCommand, StatusHistory>();
        }
    }
}
