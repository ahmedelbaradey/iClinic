using iClinic.Application.Features.Doctors.Queries.Response;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.Doctors
{
    public partial class DoctorProfile
    {
        public void GetSingleDoctorMapping()
        {
            CreateMap<Doctor, GetSingleDoctorResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DoctorId));
        }
    }
}
