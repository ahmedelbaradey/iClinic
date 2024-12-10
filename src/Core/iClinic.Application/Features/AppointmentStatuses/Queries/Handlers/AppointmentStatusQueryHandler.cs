using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.AppointmentStatuses.Queries.Models;
using iClinic.Application.Features.AppointmentStatuses.Queries.Responses;
using  iClinic.Application.Abstracts.Presistence;
using MediatR;

namespace iClinic.Application.Features.AppointmentStatuses.Queries.Handlers
{
    public class AppointmentStatusQueryHandler : BaseResponseHandler,
        IRequestHandler<GetAppointmentStatusListQuery, BaseResponse<List<GetAppointmentStatusListResponse>>>,
        IRequestHandler<GetAppointmentStatusLByIdQuery, BaseResponse<GetSingleAppointmentStatusResponse>>
    {

        #region Fileds
        private readonly IAppointmentStatusService _appointmentStatusService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors
        public AppointmentStatusQueryHandler(IAppointmentStatusService appointmentStatusService, IMapper mapper)
        {
            _appointmentStatusService = appointmentStatusService;
            _mapper = mapper;
        }
        #endregion

        #region Functions

        #endregion
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
    }
}
