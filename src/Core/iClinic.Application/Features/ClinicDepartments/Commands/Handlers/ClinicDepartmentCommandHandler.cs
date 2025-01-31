using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.ClinicDepartments.Commands.Models;
using iClinic.Domain.Entities;
using iClinic.Presistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace iClinic.Application.Features.ClinicDepartments.Commands.Handlers
{
    public class ClinicDepartmentCommandHandler : BaseResponseHandler,
        IRequestHandler<AddClinicDepartmentCommand, BaseResponse<string>>,
        IRequestHandler<EditClinicDepartmentCommand, BaseResponse<string>>,
        IRequestHandler<DeleteClinicDepartmentCommand, BaseResponse<string>>
    {
        #region Fileds
        private readonly IClinicDepartmentService _clinicDepartmentService;
        private readonly IMapper _mapper;
        private readonly ILogger<ClinicDepartmentCommandHandler> _logger;
        #endregion

        #region Constructor(s)
        public ClinicDepartmentCommandHandler(IClinicDepartmentService clinicDepartmentService,
            IMapper mapper, ILogger<ClinicDepartmentCommandHandler> logger)
        {
            _clinicDepartmentService = clinicDepartmentService;
            _mapper = mapper;
            _logger = logger;
        }

        #endregion

        #region Handle Functions
        public async Task<BaseResponse<string>> Handle(AddClinicDepartmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var clinicDepartmentMapper = _mapper.Map<ClinicDepartment>(request);
                var result = await _clinicDepartmentService.AddClinicDepartmentAsync(clinicDepartmentMapper);
                if (!result)
                    return BadRequest<string>("Added Operation Failed.");

                return Success("Addded Operation Successfully.");
            }
            catch (Exception ex)
            {

                return ServerError<string>(ex.Message);
            }

        }


        public async Task<BaseResponse<string>> Handle(EditClinicDepartmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var clinicDepartment = await _clinicDepartmentService.GetClinicDepartmentByIdAsync(request.Id);
                if (clinicDepartment == null)
                    return NotFound<string>("Department with this id not found!");

                //already i check if clinic Id is exist or not from Validatior

                var requestMapper = _mapper.Map<ClinicDepartment>(request);

                var IsEdited = await _clinicDepartmentService.EditClinicDepartmentAsync(requestMapper);
                if (!IsEdited)
                    return BadRequest<string>("Updated Operation Failed.");

                return Success("Updated Operation Done.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }

        }

        public async Task<BaseResponse<string>> Handle(DeleteClinicDepartmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var clinicDepartment = await _clinicDepartmentService.GetClinicDepartmentByIdAsync(request.Id);

                if (clinicDepartment == null)
                    return NotFound<string>("Department With this id not found!");

                var IsDeleted = await _clinicDepartmentService.DeleteClinicDepartmentAsync(clinicDepartment);
                if (!IsDeleted)
                    return BadRequest<string>("Deleted Operation Failed.");

                return Success("Deleted Operation done.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }

        }
        #endregion

    }
}
