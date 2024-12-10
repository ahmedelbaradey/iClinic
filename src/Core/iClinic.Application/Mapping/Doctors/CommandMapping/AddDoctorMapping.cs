
using iClinic.Application.Features.Doctors.Commands.Handlers.AddDoctor;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.Doctors
{
    public partial class DoctorProfile
    {

        public void AddDoctorMapping()
        {
            CreateMap<AddDoctorCommand, Doctor>();
        }
    }
}
