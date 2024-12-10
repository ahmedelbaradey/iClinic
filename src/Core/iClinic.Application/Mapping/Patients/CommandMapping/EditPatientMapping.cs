using iClinic.Application.Features.Patients.Commands.Models;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.Patients
{
    public partial class PatientProfile
    {
        public void EditPatientMapping()
        {
            CreateMap<EditPatientCommand, Patient>()
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
