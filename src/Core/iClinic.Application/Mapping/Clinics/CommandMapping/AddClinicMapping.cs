using iClinic.Application.Features.Clinics.Commands.Models;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.Clinics
{
    public partial class ClinicProfile
    {
        public void AddClinicMapping()
        {
            CreateMap<AddClinicCommand, Clinic>();
        }

    }
}
