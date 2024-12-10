using iClinic.Application.Features.Patients.Commands.Models;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.Patients
{
    public partial class PatientProfile
    {
        public void AddPatienMapping()
        {
            CreateMap<AddPatientCommand, Patient>();
        }
    }
}
