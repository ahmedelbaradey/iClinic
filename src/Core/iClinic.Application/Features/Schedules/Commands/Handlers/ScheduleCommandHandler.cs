﻿using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.Schedules.Commands.Models;
using iClinic.Domain.Entities;
using iClinic.Presistence.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace iClinic.Application.Features.Schedules.Commands.Handlers
{
    public class ScheduleCommandHandler : BaseResponseHandler,
        IRequestHandler<AddScheduleCommand, BaseResponse<string>>,
        IRequestHandler<EditScheduleCommand, BaseResponse<string>>,
        IRequestHandler<DeleteScheduleCommand, BaseResponse<string>>
    {
        private readonly ILogger<AddScheduleCommand> _logger;
        private readonly IScheduleService _scheduleService;
        private readonly IMapper _mapper;
        #region Fileds

        #endregion

        #region Constructors
        public ScheduleCommandHandler(ILogger<AddScheduleCommand> logger,
            IScheduleService scheduleService, IMapper mapper)
        {
            _logger = logger;
            _scheduleService = scheduleService;
            _mapper = mapper;
        }
        #endregion

        #region Functions

        /*
        *  try
                   {

                   }catch(Exception ex)
                   {
        return ServerError<List<GetDoctorsListResponse>>(ex.Message);
                   }
        */

        public async Task<BaseResponse<string>> Handle(AddScheduleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank.");
                var scheduleMapper = _mapper.Map<Schedule>(request);

                var result = await _scheduleService.AddScheduleAsync(scheduleMapper);
                if (!result)
                    return BadRequest<string>("Added Operation Failed.");

                return Success("Added Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<BaseResponse<string>> Handle(EditScheduleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request == null)
                    return BadRequest<string>("the request can't be blank");

                var isExist = await _scheduleService.IsScheduleExistById(request.Id);
                if (!isExist)
                    return NotFound<string>("Schedule with this id not found!");

                var scheduleMapper = _mapper.Map<Schedule>(request);
                var result = await _scheduleService.UpdateScheduleAsync(scheduleMapper);
                if (!result)
                    return BadRequest<string>("Updated Operation Failed.");

                return Success("Updated Operation Successfully.");
            }
            catch (Exception ex)
            {
                return ServerError<string>(ex.Message);
            }
        }

        public async Task<BaseResponse<string>> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var schedule = await _scheduleService.GetScheduleByIdAsync(request.Id);
                if (schedule == null)
                    return NotFound<string>("schedule with this id not found!");

                var result = await _scheduleService.DeleteScheduleAsync(schedule);
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
