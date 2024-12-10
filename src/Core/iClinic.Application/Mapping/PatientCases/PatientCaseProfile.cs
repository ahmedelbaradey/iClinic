using AutoMapper;

namespace iClinic.Application.Mapping.PatientCases
{
    public partial class PatientCaseProfile : Profile
    {

        public PatientCaseProfile()
        {
            AddPatientCaseMapping();
            EditPatientCaseMapping();
            GetPatientCaseListMapping();
            GetPatientCaseByIdMapping();
        }
    }
}
