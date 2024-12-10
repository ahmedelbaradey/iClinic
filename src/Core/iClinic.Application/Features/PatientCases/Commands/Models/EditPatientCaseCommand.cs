﻿using iClinic.Application.Base;
using MediatR;

namespace iClinic.Application.Features.PatientCases.Commands.Models
{
    public class EditPatientCaseCommand : IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool InProgress { get; set; }
        public decimal TotalCost { get; set; }
        public decimal AmountPaid { get; set; }
    }
}
