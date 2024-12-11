using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.Authorizations.Queries.Responses;
using iClinic.Domain.Entities.Identities;
using iClinic.Domain.Helpers;
using iClinic.Application.Abstracts.Presistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using iClinic.Application.Features.Authorizations.Queries.Handlers.GetRoleById;
using iClinic.Application.Features.Authorizations.Queries.Handlers.GetRoleList;
using iClinic.Application.Abstracts.Logger;

namespace iClinic.Application.Features.Authorizations.Queries.Handlers.ManageUserRoles
{
    public class ManageUserRolesQueryHandler : BaseResponseHandler,IQueryHandler<ManageUserRolesQuery, BaseResponse<ManageUserRolesResponse>>
    {
        #region Fileds
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly ILoggerManager _logger;
        #endregion

        #region Constructors
        public ManageUserRolesQueryHandler(IAuthorizationService authorizationService,IMapper mapper, UserManager<User> userManager,  ILoggerManager logger)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
            _userManager = userManager;
            _logger = logger;   
        }
        #endregion

        #region Functions
        public async Task<BaseResponse<ManageUserRolesResponse>> Handle(ManageUserRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(request.Id.ToString());
                if (user == null)
                    return NotFound<ManageUserRolesResponse>("user with this Id not Found!");

                var result = await _authorizationService.GetManagerUsersRolesData(user);
                return Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return ServerError<ManageUserRolesResponse>(ex.Message);
            }
        }
        #endregion
    }
}
