using iClinic.Application.Features.Clinics.Commands.Models;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.Clinics
{
    public partial class ClinicProfile
    {
        public void EditClinicMapping()
        {
            CreateMap<EditClinicCommand, Clinic>().ForMember(dest => dest.ClinicId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
