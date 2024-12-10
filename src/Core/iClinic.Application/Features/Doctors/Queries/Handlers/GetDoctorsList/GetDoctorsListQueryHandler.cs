using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.Doctors.Queries.Response;
using iClinic.Application.Wappers;
using iClinic.Domain.Entities;
using  iClinic.Application.Abstracts.Presistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using iClinic.Application.Features.Doctors.Queries.Handlers.GetDoctorsList;
using iClinic.Application.Abstracts.Logger;

namespace iClinic.Application.Features.Doctors.Queries.Handlers
{
    public class GetDoctorsListQueryHandler : BaseResponseHandler, IQueryHandler<GetDoctorsListQuery, BaseResponse<List<GetDoctorsListResponse>>>
    {
        #region Fileds
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        #endregion

        #region Constructor(s)
        public GetDoctorsListQueryHandler(IDoctorService doctorService, IMapper mapper, ILoggerManager logger)
        {
            _logger = logger;
            _doctorService = doctorService;
            _mapper = mapper;
        }
        #endregion

        #region Functions


        public async Task<BaseResponse<List<GetDoctorsListResponse>>> Handle(GetDoctorsListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _doctorService.GetDoctorListAsync();
                var doctorsMapper = _mapper.Map<List<GetDoctorsListResponse>>(result);
                return Success(doctorsMapper);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: in GetDoctorsListQuery");
                return ServerError<List<GetDoctorsListResponse>>(ex.Message);
            }
        }
        #endregion
    }
}
