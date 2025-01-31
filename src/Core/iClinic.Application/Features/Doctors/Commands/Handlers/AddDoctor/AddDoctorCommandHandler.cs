using AutoMapper;
using iClinic.Application.Base;
using iClinic.Domain.Entities;
using iClinic.Presistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;
using iClinic.Logger.Contract;

namespace iClinic.Application.Features.Doctors.Commands.Handlers.AddDoctor
{
    public class AddDoctorCommandHandler : BaseResponseHandler,ICommandHandler<AddDoctorCommand, BaseResponse<string>>
    {

        #region Fileds
        private readonly ILoggerManager _logger;
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public AddDoctorCommandHandler(IDoctorService doctorService, IMapper mapper, ILoggerManager logger)
        {
            _logger = logger;
            _doctorService = doctorService;
            _mapper = mapper;
        }
        #endregion

        #region Handle Functions
        public async Task<BaseResponse<string>> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank");

                var doctorMapper = _mapper.Map<Doctor>(request);
                var result = await _doctorService.CreateDoctorAsync(doctorMapper);
                if (!result)
                    return BadRequest<string>("Added Operation Failed.");

                return Success("Added Operation Successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: in AddDoctorCommand");
                return ServerError<string>(ex.Message);
            }
        }

        #endregion

    }
}
