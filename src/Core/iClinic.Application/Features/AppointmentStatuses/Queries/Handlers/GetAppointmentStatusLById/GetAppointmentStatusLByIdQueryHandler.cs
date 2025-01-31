using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.AppointmentStatuses.Queries.Responses;
using iClinic.Presistence.Contract;
using MediatR;
using iClinic.Application.Features.AppointmentStatuses.Queries.Handlers.GetAppointmentStatusLById;
using iClinic.Application.Features.AppointmentStatuses.Queries.Handlers.GetAppointmentStatusList;
using iClinic.Logger.Contract;

namespace iClinic.Application.Features.AppointmentStatuses.Queries.Handlers
{
    public class GetAppointmentStatusLByIdQueryHandler : BaseResponseHandler,IQueryHandler<GetAppointmentStatusLByIdQuery, BaseResponse<GetSingleAppointmentStatusResponse>>
    {

        #region Fileds
        private readonly IAppointmentStatusService _appointmentStatusService;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        #endregion

        #region Constructors
        public GetAppointmentStatusLByIdQueryHandler(IAppointmentStatusService appointmentStatusService, IMapper mapper, ILoggerManager logger)
        {
            _appointmentStatusService = appointmentStatusService;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region Functions
        public async Task<BaseResponse<GetSingleAppointmentStatusResponse>> Handle(GetAppointmentStatusLByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var single = await _appointmentStatusService.GetAppointmentStatusByIdAsync(request.Id);
                var singleMapper = _mapper.Map<GetSingleAppointmentStatusResponse>(single);
                if (singleMapper == null)
                    return NotFound<GetSingleAppointmentStatusResponse>("the appointment status not exist.");

                return Success(singleMapper);

            }
            catch (Exception ex)
            {
                return ServerError<GetSingleAppointmentStatusResponse>(ex.Message);
            }
        }
        #endregion



    }
}
