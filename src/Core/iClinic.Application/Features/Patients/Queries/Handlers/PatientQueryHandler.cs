using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.Patients.Queries.Models;
using iClinic.Application.Features.Patients.Queries.Responses;
using iClinic.Application.Wappers;
using iClinic.Domain.Entities;
using  iClinic.Application.Abstracts.Presistence;
using MediatR;
using System.Linq.Expressions;

namespace iClinic.Application.Features.Patients.Queries.Handlers
{
    public class PatientQueryHandler : BaseResponseHandler,
        IRequestHandler<GetPatientsListQuery, BaseResponse<List<GetPatientsListResponse>>>,
        IRequestHandler<GetPatientByIdQuery, BaseResponse<GetPatientByIdResponse>>,
        IRequestHandler<GetPatientsPaginatedListQuery, PaginatedResult<GetPatientsPaginatedListResponse>>
    {

        #region Fileds
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructors

        public PatientQueryHandler(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        #endregion

        #region Handle Functions
        public async Task<BaseResponse<List<GetPatientsListResponse>>> Handle(GetPatientsListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var patientsList = await _patientService.GetPatientListAsync();
                if (patientsList == null)
                    return NotFound<List<GetPatientsListResponse>>("There are no patients.");

                var patientsMapper = _mapper.Map<List<GetPatientsListResponse>>(patientsList);
                return Success(patientsMapper);

            }
            catch (Exception ex)
            {
                return ServerError<List<GetPatientsListResponse>>(ex.Message);
            }

        }

        public async Task<BaseResponse<GetPatientByIdResponse>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var patient = await _patientService.GetPatientByIdAsync(request.Id);
                if (patient == null)
                    return NotFound<GetPatientByIdResponse>("patient with this Id not Found.");

                var patientMapper = _mapper.Map<GetPatientByIdResponse>(patient);
                return Success(patientMapper);
            }
            catch (Exception ex)
            {
                return ServerError<GetPatientByIdResponse>(ex.Message);
            }
        }

        public async Task<PaginatedResult<GetPatientsPaginatedListResponse>> Handle(GetPatientsPaginatedListQuery request, CancellationToken cancellationToken)
        {

            Expression<Func<Patient, GetPatientsPaginatedListResponse>> expression =
                 entity => new GetPatientsPaginatedListResponse(entity.PatientId,
                 entity.FirstName, entity.LastName, entity.Email);

            var filterResult = _patientService.FilterPatientPaginatedQuerable(request.Serach);
            var paginatedList = await filterResult.Select(expression).ToPaginatedListAsync(request.PageNumber,
                request.PageSize);

            return paginatedList;

        }

        #endregion

    }
}
