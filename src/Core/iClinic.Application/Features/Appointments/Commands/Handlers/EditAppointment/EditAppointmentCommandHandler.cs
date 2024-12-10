using AutoMapper;
using iClinic.Application.Base;
using iClinic.Domain.Entities;
using  iClinic.Application.Abstracts.Presistence;
using MediatR;
using iClinic.Application.Abstracts.Logger;


namespace iClinic.Application.Features.Appointments.Commands.Handlers.EditAppointment
{
    public class EditAppointmentCommandHandler : BaseResponseHandler, ICommandHandler<EditAppointmentCommand, BaseResponse<string>>
    {

        #region Fileds
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IAppointmentService _appointmentService;
        #endregion

        #region Constructors
        public EditAppointmentCommandHandler(IMapper mapper, IAppointmentService appointmentService , ILoggerManager logger)
        {
            _mapper = mapper;
            _appointmentService = appointmentService;
            _logger = logger;
        }
        #endregion

        #region Functions
        public async Task<BaseResponse<string>> Handle(EditAppointmentCommand request, CancellationToken cancellationToken)
        {

            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank");

                var isExist = await _appointmentService.IsAppointmentExistByIdAsync(request.Id);
                if (!isExist)
                    return NotFound<string>("Appointment with this id not found!");

                var AppointmentMapper = _mapper.Map<Appointment>(request);
                AppointmentMapper.TimeCreated = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

                var result = await _appointmentService.UpdateAppointmentAsync(AppointmentMapper);
                if (!result)
                    return BadRequest<string>("Updated Operation Failed.");

                return Success("Updated Operation Successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: in EditAppointmentCommand");
                return ServerError<string>(ex.Message);
            }
        }
        #endregion

    }
}
