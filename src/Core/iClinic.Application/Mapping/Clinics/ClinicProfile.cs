using AutoMapper;

namespace iClinic.Application.Mapping.Clinics
{
    public partial class ClinicProfile : Profile
    {
        public ClinicProfile()
        {
            AddClinicMapping();
            EditClinicMapping();
            GetClinicListMapping();

        }
    }
}
