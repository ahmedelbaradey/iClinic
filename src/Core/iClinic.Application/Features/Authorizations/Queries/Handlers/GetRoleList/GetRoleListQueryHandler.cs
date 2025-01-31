using AutoMapper;
using iClinic.Application.Base;
using iClinic.Application.Features.Authorizations.Queries.Responses;
using iClinic.Domain.Entities.Identities;
using iClinic.Domain.Helpers;
using iClinic.Presistence.Contract;
using MediatR;
using Microsoft.AspNetCore.Identity;
using iClinic.Application.Features.Authorizations.Queries.Handlers.GetRoleById;
using iClinic.Application.Features.Authorizations.Queries.Handlers.GetRoleList;
using iClinic.Application.Features.Authorizations.Queries.Handlers.ManageUserRoles;
using iClinic.Logger.Contract;

namespace iClinic.Application.Features.Authorizations.Queries.Handlers.GetRoleList
{
    public class GetRoleListQueryHandler : BaseResponseHandler,IQueryHandler<GetRoleListQuery, BaseResponse<List<GetRoleListResponse>>>
    {
        #region Fileds
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        #endregion

        #region Constructors
        public GetRoleListQueryHandler(IAuthorizationService authorizationService,IMapper mapper, ILoggerManager logger)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region Functions

        public async Task<BaseResponse<List<GetRoleListResponse>>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var roles = await _authorizationService.GetRoleListAsync();
                if (roles == null)
                {
                    return NotFound<List<GetRoleListResponse>>("Not Found Roles");
                }

                var rolesMapper = _mapper.Map<List<GetRoleListResponse>>(roles);
                return Success(rolesMapper);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return ServerError<List<GetRoleListResponse>>(ex.Message);
            }
        }

        #endregion
    }
}
