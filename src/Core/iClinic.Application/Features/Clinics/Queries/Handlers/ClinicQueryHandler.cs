using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.Clinics.Queries.Models;
using iClinic.Application.Features.Clinics.Queries.Response;
using  iClinic.Application.Abstracts.Presistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace iClinic.Application.Features.Clinics.Queries.Handlers
{
    public class ClinicQueryHandler : BaseResponseHandler,
        IRequestHandler<IsClinicExistByNameQuery, BaseResponse<string>>,
        IRequestHandler<IsClinicExistByIdQuery, BaseResponse<string>>,
        IRequestHandler<GetClinicListQuery, BaseResponse<List<GetClinicListResponse>>>
    {
        #region Fileds
        private readonly IClinicService _clinicService;
        private readonly ILogger<ClinicQueryHandler> _logger;
        private readonly IMapper _mapper;
        #endregion


        #region Constructor(s)

        public ClinicQueryHandler(IClinicService clinicService,
            ILogger<ClinicQueryHandler> logger, IMapper mapper)
        {
            _clinicService = clinicService;
            _logger = logger;
            _mapper = mapper;
        }
        #endregion


        #region Functions
        public async Task<BaseResponse<string>> Handle(IsClinicExistByNameQuery request, CancellationToken cancellationToken)
        {
            try
            {


                var IsClinicExist = await _clinicService.IsClinicExistByNameAsync(request.ClinicName);
                if (!IsClinicExist)
                    return NotFound<string>("clinic with this name is't exist.");

                return Success("clinic with this name is exist.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<BaseResponse<string>> Handle(IsClinicExistByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var IsClinicExist = await _clinicService.IsClinicExistByIdAsync(request.Id);
                if (!IsClinicExist)
                    return NotFound<string>("clinic with this Id is't exist.");

                return Success("clinic with this Id is exist.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<BaseResponse<List<GetClinicListResponse>>> Handle(GetClinicListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var clinicList = await _clinicService.GetClinicListAsync();
                var clinicListMapper = _mapper.Map<List<GetClinicListResponse>>(clinicList);

                return Success(clinicListMapper);

            }
            catch (Exception ex)
            {
                return ServerError<List<GetClinicListResponse>>(ex.Message);
            }
        }
        #endregion

    }
}
