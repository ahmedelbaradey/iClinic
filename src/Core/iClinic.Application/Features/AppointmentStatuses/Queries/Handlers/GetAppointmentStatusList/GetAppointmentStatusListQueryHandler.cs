using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.AppointmentStatuses.Queries.Responses;
using iClinic.Application.Abstracts.Presistence;
using MediatR;
using iClinic.Application.Features.AppointmentStatuses.Queries.Handlers.GetAppointmentStatusLById;
using iClinic.Application.Abstracts.Logger;

namespace iClinic.Application.Features.AppointmentStatuses.Queries.Handlers.GetAppointmentStatusList
{
    public class GetAppointmentStatusListQueryHandler : BaseResponseHandler,IQueryHandler<GetAppointmentStatusListQuery, BaseResponse<List<GetAppointmentStatusListResponse>>>
    {

        #region Fileds
        private readonly IAppointmentStatusService _appointmentStatusService;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        #endregion

        #region Constructors
        public GetAppointmentStatusListQueryHandler(IAppointmentStatusService appointmentStatusService, IMapper mapper, ILoggerManager logger)
        {
            _appointmentStatusService = appointmentStatusService;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region Functions
        public async Task<BaseResponse<List<GetAppointmentStatusListResponse>>> Handle(GetAppointmentStatusListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var list = await _appointmentStatusService.GetAppointmentStatusListAsync();
                var listMapper = _mapper.Map<List<GetAppointmentStatusListResponse>>(list);
                return Success(listMapper);

            }
            catch (Exception ex)
            {
                return ServerError<List<GetAppointmentStatusListResponse>>(ex.Message);
            }
        }

        #endregion


    }
}
