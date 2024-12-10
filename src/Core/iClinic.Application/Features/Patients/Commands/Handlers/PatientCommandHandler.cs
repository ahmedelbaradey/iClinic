using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.Patients.Commands.Models;
using iClinic.Domain.Entities;
using  iClinic.Application.Abstracts.Presistence;
using MediatR;

namespace iClinic.Application.Features.Patients.Commands.Handlers
{
    public class PatientCommandHandler : BaseResponseHandler,
        IRequestHandler<AddPatientCommand, BaseResponse<string>>,
        IRequestHandler<EditPatientCommand, BaseResponse<string>>,
        IRequestHandler<DeletePatientCommand, BaseResponse<string>>
    {
        #region Fileds
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor(s)
        public PatientCommandHandler(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }
        #endregion

        #region Handle Functions
        public async Task<BaseResponse<string>> Handle(AddPatientCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                return BadRequest<string>("the request can't be blank");

            var patientMapper = _mapper.Map<Patient>(request);
            var result = await _patientService.CreatePatientAsync(patientMapper);

            if (!result)
                return BadRequest<string>("Added Operation Failed.");

            return Success("Added Operation Successfully.");
        }

        public async Task<BaseResponse<string>> Handle(EditPatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientService.GetPatientByIdAsync(request.Id);
            if (patient == null)
                return BadRequest<string>("Patient with this id not found!");

            var patientMapper = _mapper.Map<Patient>(request);
            var result = await _patientService.UpdatePatientAsync(patientMapper);
            if (!result)
                return BadRequest<string>("Updated Operation Failed.");

            return Success("Updated Operation Successfully.");
        }

        public async Task<BaseResponse<string>> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientService.GetPatientByIdAsync(request.Id);
            if (patient == null)
                return BadRequest<string>("Patient with this id not found!");

            var result = await _patientService.DeletePatientAsync(patient);
            if (!result)
                return BadRequest<string>("Deleted Operation Failed.");

            return Success("Deleted Operation Successfully.");
        }
        #endregion

    }
}
