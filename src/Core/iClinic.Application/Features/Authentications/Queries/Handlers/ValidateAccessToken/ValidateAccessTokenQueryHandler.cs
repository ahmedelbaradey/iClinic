using iClinic.Application.Base;
using iClinic.Application.Abstracts.Presistence;
using MediatR;
using iClinic.Application.Abstracts.Logger;

namespace iClinic.Application.Features.Authentications.Queries.Handlers.ValidateAccessToken
{
    public class ValidateAccessTokenQueryHandler : BaseResponseHandler, IQueryHandler<AccessTokenQuery, BaseResponse<string>>
    {
        #region Fields
        private readonly IAuthenticationService _cusAuthenticationService;
        private readonly ILoggerManager _logger;
        #endregion

        #region Constructors
        public ValidateAccessTokenQueryHandler(IAuthenticationService cusAuthenticationService, ILoggerManager logger)
        {
            _cusAuthenticationService = cusAuthenticationService;
            _logger = logger;
        }
        #endregion

        #region Functions
        public async Task<BaseResponse<string>> Handle(AccessTokenQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _cusAuthenticationService.ValidateToken(request.Accesstoken);
                if (result == "NotExpired")
                {
                    return Success("this token is not expired.");
                }

                return Unauthorized<string>("this token is expired.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: in AddAppointmentCommand");
                return ServerError<string>(ex.Message);
            }
        }
        #endregion
    }
}
