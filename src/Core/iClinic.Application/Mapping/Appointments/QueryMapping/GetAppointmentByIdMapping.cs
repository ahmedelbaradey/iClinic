﻿using iClinic.Application.Features.Appointments.Queries.Responses;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.Appointments
{
    public partial class AppointmentProfile
    {
        public void GetAppointmentByIdMapping()
        {
            CreateMap<Appointment, GetSingleAppointmentResponse>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AppointmentId))
               .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Doctor.FirstName + " " + src.Doctor.LastName))
               .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => src.PatientCase.Patient.FirstName + " " + src.PatientCase.Patient.LastName))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.AppointmentStatus.StatusName))
               .ForMember(dest => dest.TotalCost, opt => opt.MapFrom(src => src.PatientCase.TotalCost))
               .ForMember(dest => dest.AmountPaid, opt => opt.MapFrom(src => src.PatientCase.AmountPaid));
        }
    }
}
