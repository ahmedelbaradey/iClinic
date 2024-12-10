﻿using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.Appointments.Queries.Responses;
using iClinic.Application.Wappers;
using iClinic.Domain.Entities;
using  iClinic.Application.Abstracts.Presistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using iClinic.Application.Abstracts.Logger;

namespace iClinic.Application.Features.Appointments.Queries.Handlers.GetAppointmentPaginated
{
    public class GetAppointmentPaginatedQueryHandler : BaseResponseHandler, IQueryHandler<GetAppointmentPaginatedQuery, PaginatedResult<GetAppointmentPaginatedResponse>>
    {
        #region Fileds
        private readonly ILoggerManager _logger;
        private readonly IAppointmentService _appointmentService;
        #endregion

        #region Constructors

        public GetAppointmentPaginatedQueryHandler(ILoggerManager logger, IAppointmentService appointmentService)
        {
            _logger = logger;
            _appointmentService = appointmentService;
        }
        #endregion
        public async Task<PaginatedResult<GetAppointmentPaginatedResponse>> Handle(GetAppointmentPaginatedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<Appointment, GetAppointmentPaginatedResponse>> expression =
                    entity => new GetAppointmentPaginatedResponse(entity.AppointmentId, entity.TimeCreated, entity.StartTime,
                    entity.EndTime, entity.PatientCase.Patient.FirstName + " " + entity.PatientCase.Patient.LastName,
                    entity.Doctor.FirstName + " " + entity.Doctor.LastName, entity.PatientCase.TotalCost, entity.PatientCase.AmountPaid, entity.AppointmentStatus.StatusName);

                var filterResult = _appointmentService.FilterAppointmentPaginatedQuerable(request.DoctorName,
                    request.PatientName, request.StatusName);

                var paginatedList = await filterResult.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
                return paginatedList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: in GetAppointmentPaginatedQuery");
                throw;
            }
        }
    }
}