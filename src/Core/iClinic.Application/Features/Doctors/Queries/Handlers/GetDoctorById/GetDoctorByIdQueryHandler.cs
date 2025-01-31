using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.Doctors.Queries.Response;
using iClinic.Application.Wappers;
using iClinic.Domain.Entities;
using iClinic.Presistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using iClinic.Application.Features.Doctors.Queries.Handlers.GetDoctorById;
using iClinic.Logger.Contract;

namespace iClinic.Application.Features.Doctors.Queries.Handlers
{
    public class GetDoctorByIdQueryHandler : BaseResponseHandler, IQueryHandler<GetDoctorByIdQuery, BaseResponse<GetSingleDoctorResponse>>
    {
        #region Fileds
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        #endregion

        #region Constructor(s)
        public GetDoctorByIdQueryHandler(IDoctorService doctorService, IMapper mapper, ILoggerManager logger)
        {
            _logger = logger;
            _doctorService = doctorService;
            _mapper = mapper;
        }
        #endregion

        #region Functions
        public async Task<BaseResponse<GetSingleDoctorResponse>> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var doctor = await _doctorService.GetDoctorByIdAsync(request.Id);
                if (doctor == null)
                    return NotFound<GetSingleDoctorResponse>("doctor with this Id not found!");

                var doctorMapper = _mapper.Map<GetSingleDoctorResponse>(doctor);
                return Success(doctorMapper);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: in GetDoctorByIdQuery");
                return ServerError<GetSingleDoctorResponse>(ex.Message);
            }
        }
 
        #endregion
    }
}
