using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.StatusHistories.Commands.Models;
using iClinic.Domain.Entities;
using iClinic.Presistence.Contract;
using MediatR;

namespace iClinic.Application.Features.StatusHistories.Commands.Handlers
{
    public class StatusHistoryCommandHandler : BaseResponseHandler,
        IRequestHandler<AddStatusHistoryCommand, BaseResponse<string>>,
        IRequestHandler<EditStatusHistoryCommand, BaseResponse<string>>,
        IRequestHandler<DeleteStatusHistoryCommand, BaseResponse<string>>
    {

        #region Fileds
        private readonly IStatusHistoryService _statusHistoryService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public StatusHistoryCommandHandler(IMapper mapper,
            IStatusHistoryService statusHistoryService)
        {
            _mapper = mapper;
            _statusHistoryService = statusHistoryService;
        }
        #endregion
        #region Functions
        public async Task<BaseResponse<string>> Handle(AddStatusHistoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank.");

                var StatusHistoryMapper = _mapper.Map<StatusHistory>(request);
                StatusHistoryMapper.StatusTime = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

                var result = await _statusHistoryService.CreateStatusHistoryAsync(StatusHistoryMapper);

                if (!result)
                    return BadRequest<string>("Added Operation Failed.");

                return Success("Added Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<BaseResponse<string>> Handle(EditStatusHistoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank.");

                var isExist = await _statusHistoryService.IsStatusHistoryExistByIdAsync(request.Id);

                if (!isExist)
                    return NotFound<string>("status history with this id not found!");

                var StatusHistoryMapper = _mapper.Map<StatusHistory>(request);
                StatusHistoryMapper.StatusTime = new DateOnly(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);

                var result = await _statusHistoryService.EditStatusHistoryAsync(StatusHistoryMapper);

                if (!result)
                    return BadRequest<string>("Updated Operation Failed.");

                return Success("Updated Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<BaseResponse<string>> Handle(DeleteStatusHistoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank.");

                var isExist = await _statusHistoryService.GetStatusHistoryByIdAsync(request.Id);

                if (isExist == null)
                    return NotFound<string>("status history with this id not found!");


                var result = await _statusHistoryService.DeleteStatusHistoryAsync(isExist);

                if (!result)
                    return BadRequest<string>("Deleted Operation Failed.");

                return Success("Deleted Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }


        #endregion

    }
}
