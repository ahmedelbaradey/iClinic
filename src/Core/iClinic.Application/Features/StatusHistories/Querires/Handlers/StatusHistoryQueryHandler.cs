﻿using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.StatusHistories.Querires.Models;
using iClinic.Application.Features.StatusHistories.Querires.Responses;
using iClinic.Application.Wappers;
using iClinic.Domain.Entities;
using  iClinic.Application.Abstracts.Presistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace iClinic.Application.Features.StatusHistories.Querires.Handlers
{
    public class StatusHistoryQueryHandler : BaseResponseHandler,
        IRequestHandler<GetStatusHistoryListQuery, BaseResponse<List<GetStatusHistoryListResponse>>>,
        IRequestHandler<GetStatusHistoryByIdQuery, BaseResponse<GetSingleStatusHistoryResponse>>,
        IRequestHandler<GetStatusHistoryPaginatedQuery, PaginatedResult<GetStatusHistoryPaginatedResponse>>
    {
        #region Fileds
        private readonly IStatusHistoryService _statusHistoryService;
        private readonly IMapper _mapper;
        private readonly ILogger<StatusHistoryQueryHandler> _logger;
        #endregion

        #region Constructors
        public StatusHistoryQueryHandler(IMapper mapper, ILogger<StatusHistoryQueryHandler> logger,
            IStatusHistoryService statusHistoryService)
        {
            _mapper = mapper;
            _logger = logger;
            _statusHistoryService = statusHistoryService;
        }
        #endregion

        #region Functions
        public async Task<BaseResponse<List<GetStatusHistoryListResponse>>> Handle(GetStatusHistoryListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _statusHistoryService.GetStatusHistoryListAsync();
                var listMapper = _mapper.Map<List<GetStatusHistoryListResponse>>(result);
                return Success(listMapper);
            }
            catch (Exception ex)
            {
                return ServerError<List<GetStatusHistoryListResponse>>(ex.Message);
            }
        }

        public async Task<PaginatedResult<GetStatusHistoryPaginatedResponse>> Handle(GetStatusHistoryPaginatedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<StatusHistory, GetStatusHistoryPaginatedResponse>> expression =
                    entity => new GetStatusHistoryPaginatedResponse(entity.StatusHistoryId,
                    entity.StatusTime, entity.AppointmentStatus.StatusName, entity.details);

                var filterResult = _statusHistoryService.FilterStatusHistoryPaginatedQuerable(request.statusName);

                var paginatedList = await filterResult.Select(expression).ToPaginatedListAsync(request.PageNumer, request.PageSize);
                return paginatedList;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error: in GetStatusHistoryPaginatedQuery");
                throw;
            }
        }

        public async Task<BaseResponse<GetSingleStatusHistoryResponse>> Handle(GetStatusHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _statusHistoryService.GetStatusHistoryByIdAsync(request.Id);
                if (result == null)
                    return NotFound<GetSingleStatusHistoryResponse>("status history with this id not found!");


                var statusMaper = _mapper.Map<GetSingleStatusHistoryResponse>(result);
                return Success(statusMaper);
            }
            catch (Exception ex)
            {
                return ServerError<GetSingleStatusHistoryResponse>(ex.Message);
            }
        }
        #endregion

    }
}
