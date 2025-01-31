using iClinic.Logger.Contract;
using iClinic.Presistence.Contract;
using iClinic.Application.Base;
using iClinic.Application.Features.AppointmentStatuses.Commands.Handlers.AddAppointmentStatuses;
using iClinic.Application.Features.AppointmentStatuses.Commands.Handlers.DeleteAppointmentStatuses;
using iClinic.Domain.Entities;
using MediatR;

namespace iClinic.Application.Features.AppointmentStatuses.Commands.Handlers.UpdateAppointmentStatuses
{
    public class UpdateAppointmentStatusCommandHandler : BaseResponseHandler,ICommandHandler<UpdateAppointmentStatusCommand, BaseResponse<string>>
    {
        #region Fileds
        private readonly IAppointmentStatusService _appointmentStatusService;
        private readonly ILoggerManager _logger;
        #endregion

        #region Constructors
        public UpdateAppointmentStatusCommandHandler(IAppointmentStatusService appointmentStatusService, ILoggerManager logger)
        {
            _appointmentStatusService = appointmentStatusService;
            _logger = logger;
        }
        #endregion

        #region Functions
        public async Task<BaseResponse<string>> Handle(UpdateAppointmentStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var isFind = await _appointmentStatusService.IsAppointmentStatusByIdAsync(request.Id);
                if (!isFind)
                    return NotFound<string>("This Appointment status with this id not found");

                var IsStatusNameExist = await _appointmentStatusService.IsAppointmentStatusByNameAsync(request.statusName);
                if (IsStatusNameExist)
                    return BadRequest<string>("This status name already exists.");

                AppointmentStatus appointmentStatus = new AppointmentStatus();
                appointmentStatus.AppointmentStatusId = request.Id;
                appointmentStatus.StatusName = request.statusName;

                var IsEdit = await _appointmentStatusService.EditAppointmentStatusAsync(appointmentStatus);
                if (!IsEdit)
                    return BadRequest<string>("Updated Operation Failed.");

                return Success("Updated Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        #endregion




    }
}
