using AutoMapper;

namespace iClinic.Application.Mapping.Patients
{
    public partial class PatientProfile : Profile
    {

        public PatientProfile()
        {
            GetPatientListMapping();
            GetPatientByIdMapping();
            AddPatienMapping();
            EditPatientMapping();
        }
    }
}
