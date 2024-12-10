using iClinic.Application.Features.Clinics.Queries.Response;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.Clinics
{
    public partial class ClinicProfile
    {
        public void GetClinicListMapping()
        {

            CreateMap<Clinic, GetClinicListResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ClinicId));
        }
    }
}
