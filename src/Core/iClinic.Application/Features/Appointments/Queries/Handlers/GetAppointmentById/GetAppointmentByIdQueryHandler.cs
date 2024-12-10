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

namespace iClinic.Application.Features.Appointments.Queries.Handlers.GetAppointmentById
{
    public class GetAppointmentByIdQueryHandler : BaseResponseHandler, IQueryHandler<GetAppointmentByIdQuery, BaseResponse<GetSingleAppointmentResponse>>
    {
        #region Fileds
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IAppointmentService _appointmentService;
        #endregion

        #region Constructors

        public GetAppointmentByIdQueryHandler(IAppointmentService appointmentService,IMapper mapper, ILoggerManager logger)
        {
            _logger = logger;
            _appointmentService = appointmentService;
            _mapper = mapper;
        }
        #endregion
        public async Task<BaseResponse<GetSingleAppointmentResponse>> Handle(GetAppointmentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var appointment = await _appointmentService.GetAppointmentByIdAsync(request.Id);
                if (appointment == null)
                    return NotFound<GetSingleAppointmentResponse>("Appointment with this id not found.");

                var resultMapper = _mapper.Map<GetSingleAppointmentResponse>(appointment);
                return Success(resultMapper);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: in GetAppointmentByIdQuery");
                return ServerError<GetSingleAppointmentResponse>(ex.Message);
            }
        }

    }
}
