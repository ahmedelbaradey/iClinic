using AutoMapper;
using iClinic.Application.Base;
using iClinic.Domain.Entities;
using iClinic.Presistence.Contract;
using MediatR;
using iClinic.Logger.Contract;

namespace iClinic.Application.Features.Appointments.Commands.Handlers.AddAppointment
{
    public class AddAppointmentCommandHandler : BaseResponseHandler, ICommandHandler<AddAppointmentCommand, BaseResponse<string>>
    {

        #region Fileds
        private readonly IMapper _mapper;
        private readonly IAppointmentService _appointmentService;
        private readonly ILoggerManager _logger;
        #endregion

        #region Constructors
        public AddAppointmentCommandHandler(IMapper mapper, IAppointmentService appointmentService, ILoggerManager logger)
        {
            _mapper = mapper;
            _appointmentService = appointmentService;
            _logger = logger;   
        }
        #endregion

        #region Functions
        public async Task<BaseResponse<string>> Handle(AddAppointmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank.");

                var AppointmentMapper = _mapper.Map<Appointment>(request);
                AppointmentMapper.TimeCreated = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

                var result = await _appointmentService.AddAppointmentAsync(AppointmentMapper);

                if (!result)
                    return BadRequest<string>("Added Operation Failed.");

                return Success("Added Operation Successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: in AddAppointmentCommand");
                return ServerError<string>(ex.Message);
            }
        }
        #endregion

    }
}
