using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.Users.Queries.Models;
using iClinic.Application.Features.Users.Queries.Responses;
using iClinic.Application.Wappers;
using iClinic.Domain.Entities.Identities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace iClinic.Application.Features.Users.Queries.Handlers
{
    public class UserQueryHandler : BaseResponseHandler,
        IRequestHandler<GetUserPaginatedListQuery, PaginatedResult<GetUserPaginatedListResponse>>,
        IRequestHandler<GetUserByIdQuery, BaseResponse<GetUserByIdResponse>>
    {
        #region Fields
        private readonly ILogger<UserQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        #endregion

        #region Constructors
        public UserQueryHandler(ILogger<UserQueryHandler> logger, IMapper mapper, UserManager<User> userManager)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }
        #endregion

        #region Functions
        public async Task<PaginatedResult<GetUserPaginatedListResponse>> Handle(GetUserPaginatedListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = _userManager.Users.AsQueryable();
                if (!users.Any())
                {
                    return new PaginatedResult<GetUserPaginatedListResponse>(new());
                }

                var paginatedList = await _mapper.ProjectTo<GetUserPaginatedListResponse>(users)
                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);

                return paginatedList;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, "Error in GetUserPaginatedListQuery");
                throw;
            }
        }

        public async Task<BaseResponse<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
                if (user == null)
                    return NotFound<GetUserByIdResponse>($"User with Id: {request.Id} not found!");

                var usermapper = _mapper.Map<GetUserByIdResponse>(user);
                return Success(usermapper);
            }
            catch (Exception ex)
            {

                return ServerError<GetUserByIdResponse>(ex.Message);
            }
        }



        #endregion

    }
}
