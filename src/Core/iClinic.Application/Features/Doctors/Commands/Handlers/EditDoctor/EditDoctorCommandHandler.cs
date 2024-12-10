using AutoMapper;
using iClinic.Application.Base;
using iClinic.Domain.Entities;
using  iClinic.Application.Abstracts.Presistence;
using MediatR;
using Microsoft.Extensions.Logging;
using iClinic.Application.Abstracts.Logger;

namespace iClinic.Application.Features.Doctors.Commands.Handlers.EditDoctor
{
    public class EditDoctorCommandHandler : BaseResponseHandler, ICommandHandler<EditDoctorCommand, BaseResponse<string>>
    {

        #region Fileds
        private readonly ILoggerManager _logger;
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public EditDoctorCommandHandler(IDoctorService doctorService, IMapper mapper, ILoggerManager logger)
        {
            _logger = logger;
            _doctorService = doctorService;
            _mapper = mapper;
        }
        #endregion

        #region Handle Functions
        public async Task<BaseResponse<string>> Handle(EditDoctorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank");

                var isExist = await _doctorService.IsDoctorExistById(request.Id);
                if (!isExist)
                    return NotFound<string>("doctor with this id not found!");

                var doctorMapper = _mapper.Map<Doctor>(request);
                var result = await _doctorService.UpdateDoctorAsync(doctorMapper);
                if (!result)
                    return BadRequest<string>("Updated Operation Failed.");

                return Success("Updated Operation Successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: in EditDoctorCommand");
                return ServerError<string>(ex.Message);
            }
        }
        #endregion

    }
}
