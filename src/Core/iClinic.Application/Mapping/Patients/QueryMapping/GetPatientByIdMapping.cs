using iClinic.Application.Features.Patients.Queries.Responses;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.Patients
{
    public partial class PatientProfile
    {

        public void GetPatientByIdMapping()
        {
            CreateMap<Patient, GetPatientByIdResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(s => s.PatientId));
        }
    }
}
