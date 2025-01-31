using AutoMapper;
using iClinic.Application.Base;
using iClinic.Domain.Entities;
using iClinic.Presistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;
using iClinic.Logger.Contract;

namespace iClinic.Application.Features.Doctors.Commands.Handlers.DeleteDoctor
{
    public class DeleteDoctorCommandHandler : BaseResponseHandler, ICommandHandler<DeleteDoctorCommand, BaseResponse<string>>
    {

        #region Fileds
        private readonly ILoggerManager _logger;
        private readonly IDoctorService _doctorService;
        #endregion

        #region Constructors
        public DeleteDoctorCommandHandler(IDoctorService doctorService,ILoggerManager logger)
        {
            _logger = logger;
            _doctorService = doctorService;
        }
        #endregion

        #region Handle
        public async Task<BaseResponse<string>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var doctor = await _doctorService.GetDoctorByIdAsync(request.Id);
                if (doctor == null)
                    return NotFound<string>("doctor with this id not found!");

                var result = await _doctorService.DeleteDoctorAsync(doctor);
                if (!result)
                    return BadRequest<string>("Deleted Operation Failed.");

                return Success("Deleted Operation Successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: in DeleteDoctorCommand");
                return ServerError<string>(ex.Message);
            }
        }
        #endregion

    }
}
