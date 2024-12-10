using iClinic.Application.Features.StatusHistories.Commands.Models;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.StatusHistories
{
    public partial class StatusHistoryProfile
    {
        public void EditStatusHistoryMapping()
        {
            CreateMap<EditStatusHistoryCommand, StatusHistory>().ForMember(dest => dest.StatusHistoryId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
