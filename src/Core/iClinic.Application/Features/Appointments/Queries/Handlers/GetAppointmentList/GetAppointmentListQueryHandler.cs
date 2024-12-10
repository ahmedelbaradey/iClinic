using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.Appointments.Queries.Responses;
using iClinic.Application.Wappers;
using iClinic.Domain.Entities;
using  iClinic.Application.Abstracts.Presistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using iClinic.Application.Abstracts.Logger;

namespace iClinic.Application.Features.Appointments.Queries.Handlers.GetAppointmentList
{
    public class GetAppointmentListQueryHandler : BaseResponseHandler, IQueryHandler<GetAppointmentListQuery, BaseResponse<List<GetAppointmentListResponse>>>
    {
        #region Fileds
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IAppointmentService _appointmentService;
        #endregion

        #region Constructors

        public GetAppointmentListQueryHandler(IMapper mapper, ILoggerManager logger, IAppointmentService appointmentService)
        {
            _mapper = mapper;
            _logger = logger;
            _appointmentService = appointmentService;
        }
        #endregion
        public async Task<BaseResponse<List<GetAppointmentListResponse>>> Handle(GetAppointmentListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _appointmentService.GetAppointmentListAsync();
                var listMapper = _mapper.Map<List<GetAppointmentListResponse>>(result);
                return Success(listMapper);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: in GetAppointmentListQuery");
                return ServerError<List<GetAppointmentListResponse>>(ex.Message);
            }
        }
    }
}
