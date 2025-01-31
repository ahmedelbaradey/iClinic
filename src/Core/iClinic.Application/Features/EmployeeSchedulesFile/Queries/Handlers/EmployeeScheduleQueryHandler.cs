﻿using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.EmployeeSchedulesFile.Queries.Models;
using iClinic.Application.Features.EmployeeSchedulesFile.Queries.Responses;
using iClinic.Application.Wappers;
using iClinic.Domain.Entities;
using iClinic.Presistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace iClinic.Application.Features.EmployeeSchedulesFile.Queries.Handlers
{
    public class EmployeeScheduleQueryHandler : BaseResponseHandler,
        IRequestHandler<GetEmployeeScheduleListQuery, BaseResponse<List<GetEmployeeScheduleListResponse>>>,
        IRequestHandler<GetEmployeeScheduleByIdQuery, BaseResponse<GetSingleEmployeeScheduleResponse>>,
        IRequestHandler<GetEmployeeSchedulePaginatedQuery, PaginatedResult<GetEmployeeSchedulePaginatedResponse>>
    {
        private readonly ILogger<EmployeeScheduleQueryHandler> _logger;
        private readonly IEmployeeScheduleService _employeeScheduleService;
        private readonly IMapper _mapper;
        #region Fileds

        #endregion

        #region Constructors

        public EmployeeScheduleQueryHandler(ILogger<EmployeeScheduleQueryHandler> logger,
            IEmployeeScheduleService employeeScheduleService, IMapper mapper)
        {
            _logger = logger;
            _employeeScheduleService = employeeScheduleService;
            _mapper = mapper;
        }
        #endregion

        #region Functions
        /*
        *  try
                   {

                   }catch(Exception ex)
                   {
        return ServerError<List<GetDoctorsListResponse>>(ex.Message);
                   }
        */

        public async Task<BaseResponse<List<GetEmployeeScheduleListResponse>>> Handle(GetEmployeeScheduleListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _employeeScheduleService.GetEmployeeSchedulesListAsync();
                var listMapper = _mapper.Map<List<GetEmployeeScheduleListResponse>>(result);
                return Success(listMapper);
            }
            catch (Exception ex)
            {
                return ServerError<List<GetEmployeeScheduleListResponse>>(ex.Message);
            }
        }

        public async Task<BaseResponse<GetSingleEmployeeScheduleResponse>> Handle(GetEmployeeScheduleByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var employeSchedule = await _employeeScheduleService.GetEmployeeScheduleByIdAsync(request.Id);
                if (employeSchedule == null)
                    return BadRequest<GetSingleEmployeeScheduleResponse>("employeSchedule with this id not found.");

                var resultMapper = _mapper.Map<GetSingleEmployeeScheduleResponse>(employeSchedule);
                return Success(resultMapper);
            }
            catch (Exception ex)
            {
                return ServerError<GetSingleEmployeeScheduleResponse>(ex.Message);
            }
        }

        public async Task<PaginatedResult<GetEmployeeSchedulePaginatedResponse>> Handle(GetEmployeeSchedulePaginatedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<EmployeeSchedules, GetEmployeeSchedulePaginatedResponse>> expression =
                    entity => new GetEmployeeSchedulePaginatedResponse(entity.EmployeeSchedulesId,
                    entity.TimeFrom, entity.TimeTo, entity.IsActive, entity.Doctor.FirstName + " " + entity.Doctor.LastName, entity.ClinicDepartment.DepartmentName);

                var filterResult = _employeeScheduleService.FilterEmployeeSchedulesPaginatedQuerable(request.IsActive);
                var paginatedList = await filterResult.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

                return paginatedList;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error: in GetEmployeeSchedulePaginatedQuery");
                throw;
            }
        }

        #endregion

    }
}
