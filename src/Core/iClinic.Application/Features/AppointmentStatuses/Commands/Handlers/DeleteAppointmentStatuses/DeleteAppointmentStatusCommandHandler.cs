using iClinic.Application.Abstracts.Logger;
using iClinic.Application.Abstracts.Presistence;
using iClinic.Application.Base;
using iClinic.Application.Features.AppointmentStatuses.Commands.Handlers.AddAppointmentStatuses;
using iClinic.Application.Features.AppointmentStatuses.Commands.Handlers.DeleteAppointmentStatuses;
using iClinic.Application.Features.AppointmentStatuses.Commands.Handlers.UpdateAppointmentStatuses;
using iClinic.Domain.Entities;
using MediatR;

namespace iClinic.Application.Features.AppointmentStatuses.Commands.Handlers
{
    public class DeleteAppointmentStatusCommandHandler : BaseResponseHandler,ICommandHandler<DeleteAppointmentStatusCommand, BaseResponse<string>>
    {
        #region Fileds
        private readonly IAppointmentStatusService _appointmentStatusService;
        private readonly ILoggerManager _logger;
        #endregion

        #region Constructors
        public DeleteAppointmentStatusCommandHandler(IAppointmentStatusService appointmentStatusService, ILoggerManager logger)
        {
            _appointmentStatusService = appointmentStatusService;
            _logger = logger;
        }
        #endregion


        #region Functions
        public async Task<BaseResponse<string>> Handle(DeleteAppointmentStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var isFind = await _appointmentStatusService.GetAppointmentStatusByIdAsync(request.Id);
                if (isFind == null)
                    return NotFound<string>("This Appointment status with this id not found");


                var IsDeleted = await _appointmentStatusService.DeleteAppointmentStatusAsync(isFind);
                if (!IsDeleted)
                    return BadRequest<string>("Deleted Operation Failed.");

                return Success("Deleted Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        #endregion

    }
}
