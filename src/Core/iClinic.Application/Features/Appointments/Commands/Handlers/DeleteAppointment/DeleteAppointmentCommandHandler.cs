using AutoMapper;
using iClinic.Application.Base;
using iClinic.Domain.Entities;
using iClinic.Presistence.Contract;
using MediatR;
using iClinic.Logger.Contract;

namespace iClinic.Application.Features.Appointments.Commands.Handlers.DeleteAppointment
{
    public class DeleteAppointmentCommandHandler : BaseResponseHandler, ICommandHandler<DeleteAppointmentCommand, BaseResponse<string>>
    {

        #region Fileds
        private readonly IAppointmentService _appointmentService;
        private readonly ILoggerManager _logger;
        #endregion

        #region Constructors
        public DeleteAppointmentCommandHandler(IAppointmentService appointmentService, ILoggerManager logger)
        {
            _appointmentService = appointmentService;
            _logger = logger;   
        }
        #endregion

        #region Functions
        public async Task<BaseResponse<string>> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank");

                var isExist = await _appointmentService.GetAppointmentByIdAsync(request.Id);
                if (isExist == null)
                    return NotFound<string>("Appointment with this id not found!");


                var result = await _appointmentService.DeleteAppointmentAsync(isExist);
                if (!result)
                    return BadRequest<string>("Deleted Operation Failed.");

                return Success("Deleted Operation Successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: in DeleteAppointmentCommand");
                return ServerError<string>(ex.Message);
            }
        }
        #endregion

    }
}
