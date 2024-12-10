﻿using iClinic.Application.Features.PatientCases.Queries.Responses;
using iClinic.Domain.Entities;

namespace iClinic.Application.Mapping.PatientCases
{
    public partial class PatientCaseProfile
    {
        public void GetPatientCaseListMapping()
        {
            CreateMap<PatientCase, GetPatientCaseListResponse>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PatientCaseId))
                 .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.HasValue ?
                new DateOnly(src.EndTime.Value.Year, src.EndTime.Value.Month, src.EndTime.Value.Day)
                : (DateOnly?)null))
                 .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FirstName + " " + src.Patient.LastName));

        }
    }
}
