﻿using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.ClinicDepartments.Queries.Models;
using iClinic.Application.Features.ClinicDepartments.Queries.Responses;
using iClinic.Application.Wappers;
using iClinic.Domain.Entities;
using iClinic.Presistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace iClinic.Application.Features.ClinicDepartments.Queries.Handlers
{
    public class ClinicDepartmentQueryHandler : BaseResponseHandler,
        IRequestHandler<GetClinicDepartmentListQuery, BaseResponse<List<GetClinicDepartmentResponse>>>,
        IRequestHandler<GetClinicDepartmentByIdQuery, BaseResponse<GetClinicDepartmentResponse>>,
        IRequestHandler<GetClinicDepartmentByNameQuery, BaseResponse<GetClinicDepartmentResponse>>,
        IRequestHandler<GetClinicDepartmentPaginatedQuery, PaginatedResult<GetClinicDepartmentPaginatedResponse>>
    {
        private readonly ILogger<ClinicDepartmentQueryHandler> _logger;
        private readonly IClinicDepartmentService _clinicDepartmentService;
        private readonly IMapper _mapper;

        #region Fileds

        #endregion

        #region Constructor(s)

        public ClinicDepartmentQueryHandler(ILogger<ClinicDepartmentQueryHandler> logger,
            IClinicDepartmentService clinicDepartmentService, IMapper mapper)
        {
            _logger = logger;
            _clinicDepartmentService = clinicDepartmentService;
            _mapper = mapper;
        }
        #endregion

        #region Handle Functions

        public async Task<BaseResponse<List<GetClinicDepartmentResponse>>> Handle(GetClinicDepartmentListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var clinicDepartmentList = await _clinicDepartmentService.GetClinicDepartmentListAsync();
                var departmentMapper = _mapper.Map<List<GetClinicDepartmentResponse>>(clinicDepartmentList);

                return Success(departmentMapper);
            }
            catch (Exception ex)
            {
                return ServerError<List<GetClinicDepartmentResponse>>(ex.Message);
            }

        }

        public async Task<BaseResponse<GetClinicDepartmentResponse>> Handle(GetClinicDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var clinicDepartment = await _clinicDepartmentService.GetClinicDepartmentByIdAsync(request.Id);

                if (clinicDepartment == null)
                    return NotFound<GetClinicDepartmentResponse>("department with this id not found!");

                var departmentMapper = _mapper.Map<GetClinicDepartmentResponse>(clinicDepartment);
                return Success(departmentMapper);
            }
            catch (Exception ex)
            {
                return ServerError<GetClinicDepartmentResponse>(ex.Message);
            }
        }

        public async Task<BaseResponse<GetClinicDepartmentResponse>> Handle(GetClinicDepartmentByNameQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var clinicDepartment = await _clinicDepartmentService.GetClinicDepartmentByNameAsync(request.DepartmentName);

                if (clinicDepartment == null)
                    return NotFound<GetClinicDepartmentResponse>("department with this name not found!");

                var departmentMapper = _mapper.Map<GetClinicDepartmentResponse>(clinicDepartment);
                return Success(departmentMapper);
            }
            catch (Exception ex)
            {
                return ServerError<GetClinicDepartmentResponse>(ex.Message);
            }
        }

        public async Task<PaginatedResult<GetClinicDepartmentPaginatedResponse>> Handle(GetClinicDepartmentPaginatedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<ClinicDepartment, GetClinicDepartmentPaginatedResponse>> expression =
                 entity => new GetClinicDepartmentPaginatedResponse(entity.DepartmentId,
                 entity.DepartmentName, entity.Description, entity.Clinic.Name);

                var filterResult = _clinicDepartmentService.FilterClinicDepartmentPaginatedQuerable(request.Search);
                var paginatedList = await filterResult.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

                return paginatedList;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetClinicDepartmentPaginatedQuery");
                throw;
            }
        }

        #endregion
    }
}
