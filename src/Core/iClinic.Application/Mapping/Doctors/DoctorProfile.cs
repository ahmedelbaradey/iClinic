using AutoMapper;

namespace iClinic.Application.Mapping.Doctors
{
    public partial class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            AddDoctorMapping();
            EditDoctorMapping();
            GetDoctorsListMapping();
            GetSingleDoctorMapping();
            GetDoctorsPaginatedMapping();
        }
    }
}
