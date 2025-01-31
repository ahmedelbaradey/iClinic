﻿using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.PatientCases.Queries.Models;
using iClinic.Application.Features.PatientCases.Queries.Responses;
using iClinic.Application.Wappers;
using iClinic.Domain.Entities;
using iClinic.Presistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace iClinic.Application.Features.PatientCases.Queries.Handlers
{
    public class PatientCaseQueryHandler : BaseResponseHandler,
        IRequestHandler<GetPatientCaseListQuery, BaseResponse<List<GetPatientCaseListResponse>>>,
        IRequestHandler<GetPatientCaseByIdQuery, BaseResponse<GetSinglePatientCaseResponse>>,
        IRequestHandler<GetPatientCasePaginatedQuery, PaginatedResult<GetPatientCasePaginatedResponse>>
    {
        #region Fileds
        private readonly IMapper _mapper;
        private readonly ILogger<PatientCaseQueryHandler> _logger;
        private readonly IPatientCaseService _patientCaseService;
        #endregion

        #region Constructors
        public PatientCaseQueryHandler(IMapper mapper, ILogger<PatientCaseQueryHandler> logger,
            IPatientCaseService patientCaseService)
        {
            _mapper = mapper;
            _logger = logger;
            _patientCaseService = patientCaseService;
        }
        #endregion

        #region Functions
        public async Task<BaseResponse<List<GetPatientCaseListResponse>>> Handle(GetPatientCaseListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _patientCaseService.GetPatientCaseListAsync();
                var listMapper = _mapper.Map<List<GetPatientCaseListResponse>>(result);
                return Success(listMapper);
            }
            catch (Exception ex)
            {
                return ServerError<List<GetPatientCaseListResponse>>(ex.Message);
            }
        }

        public async Task<BaseResponse<GetSinglePatientCaseResponse>> Handle(GetPatientCaseByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var patientCase = await _patientCaseService.GetPatientCaseByIdAsync(request.Id);
                if (patientCase == null)
                    return NotFound<GetSinglePatientCaseResponse>("patientCase with this id not found.");

                var resultMapper = _mapper.Map<GetSinglePatientCaseResponse>(patientCase);
                return Success(resultMapper);
            }
            catch (Exception ex)
            {
                return ServerError<GetSinglePatientCaseResponse>(ex.Message);
            }
        }

        public async Task<PaginatedResult<GetPatientCasePaginatedResponse>> Handle(GetPatientCasePaginatedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<PatientCase, GetPatientCasePaginatedResponse>> expression =
                    entity => new GetPatientCasePaginatedResponse(entity.PatientCaseId, entity.StartTime, entity.EndTime,
                    entity.InProgress, entity.TotalCost, entity.AmountPaid, entity.Patient.FirstName + " " + entity.Patient.LastName);

                var filterResult = _patientCaseService.FilterPatientCasePaginatedQuerable(request.search);
                var paginatedList = await filterResult.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);

                return paginatedList;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error: in GetPatientCasePaginatedQuery");
                throw;
            }
        }
        #endregion

    }
}
