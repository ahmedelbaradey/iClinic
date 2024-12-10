using  iClinic.Application.Abstracts.Presistence;
using iClinic.Application.Base;
using iClinic.Application.Features.AppointmentStatuses.Commands.Models;
using iClinic.Domain.Entities;
using MediatR;

namespace iClinic.Application.Features.AppointmentStatuses.Commands.Handlers
{
    public class AppointmentStatusCommandHandler : BaseResponseHandler,
        IRequestHandler<AddAppointmentStatusCommand, BaseResponse<string>>,
        IRequestHandler<UpdateAppointmentStatusCommand, BaseResponse<string>>,
        IRequestHandler<DeleteAppointmentStatusCommand, BaseResponse<string>>
    {
        #region Fileds
        private readonly IAppointmentStatusService _appointmentStatusService;

        #endregion

        #region Constructors
        public AppointmentStatusCommandHandler(IAppointmentStatusService appointmentStatusService)
        {
            _appointmentStatusService = appointmentStatusService;
        }
        #endregion

        #region Functions


        #endregion
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
                return ServerError<string>(ex.Message);
            }
        }

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

        public async Task<BaseResponse<string>> Handle(DeleteAppointmentStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var isFind = await _appointmentStatusService.GetAppointmentStatusByIdAsync(request.ID);
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
    }
}
