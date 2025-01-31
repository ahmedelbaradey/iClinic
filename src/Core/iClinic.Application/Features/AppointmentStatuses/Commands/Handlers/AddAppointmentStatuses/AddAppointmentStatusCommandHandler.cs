using iClinic.Logger.Contract;
using iClinic.Presistence.Contract;
using iClinic.Application.Base;
using iClinic.Application.Features.AppointmentStatuses.Commands.Handlers.AddAppointmentStatuses;
using iClinic.Application.Features.AppointmentStatuses.Commands.Handlers.DeleteAppointmentStatuses;
using iClinic.Application.Features.AppointmentStatuses.Commands.Handlers.UpdateAppointmentStatuses;
using iClinic.Domain.Entities;
using MediatR;

namespace iClinic.Application.Features.AppointmentStatuses.Commands.Handlers
{
    public class AddAppointmentStatusCommandHandler : BaseResponseHandler,ICommandHandler<AddAppointmentStatusCommand, BaseResponse<string>>
    {
        #region Fileds
        private readonly IAppointmentStatusService _appointmentStatusService;
        private readonly ILoggerManager _logger;
        #endregion

        #region Constructors
        public AddAppointmentStatusCommandHandler(IAppointmentStatusService appointmentStatusService , ILoggerManager logger)
        {
            _appointmentStatusService = appointmentStatusService;
            _logger = logger;   
        }
        #endregion

        #region Functions

        public async Task<BaseResponse<string>> Handle(AddAppointmentStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {


                var IsStatusNameExist = await _appointmentStatusService.IsAppointmentStatusByNameAsync(request.StatusName);
                if (IsStatusNameExist)
                    return BadRequest<string>("This status name already exists.");

                AppointmentStatus appointmentStatus = new AppointmentStatus();
                appointmentStatus.StatusName = request.StatusName;

                var IsAdded = await _appointmentStatusService.CreateAppointmentStatusAsync(appointmentStatus);
                if (!IsAdded)
                    return BadRequest<string>("Added Operation Failed.");

                return Success("Added Operation Successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);    
                return ServerError<string>(ex.Message);
            }
        }
        #endregion


    }
}
