using AutoMapper;
using iClinic.Application.Base;
using iClinic.Domain.Entities.Identities;
using iClinic.Domain.Helpers;
using iClinic.Presistence.Contract;
using MediatR;
using Microsoft.AspNetCore.Identity;
using iClinic.Application.Features.Authentications.Commands.Handlers.RefreshToken;
using iClinic.Application.Features.Authentications.Commands.Handlers.SignIn;

namespace iClinic.Application.Features.Authentications.Commands.Handlers
{
    public class RefreshTokenCommandHandler : BaseResponseHandler,ICommandHandler<RefreshTokenCommand, BaseResponse<JwtAuthResponse>>
    {
        #region Fileds
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationService _cusAuthenticationService;
        #endregion

        #region Constructors
        public RefreshTokenCommandHandler(UserManager<User> userManager,IAuthenticationService cusAuthenticationService)
        {
            _userManager = userManager;
            _cusAuthenticationService = cusAuthenticationService;
        }
        #endregion

        #region Functions
        public async Task<BaseResponse<JwtAuthResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var jwtToken = _cusAuthenticationService.ReadJwtToken(request.AccessToken);
                var userIdAndExpiryDate = await _cusAuthenticationService.ValidateDetails(jwtToken,
                    request.AccessToken, request.RefreshToken);

                switch (userIdAndExpiryDate)
                {
                    case ("AlgorithmIsWrong", null):
                        return Unauthorized<JwtAuthResponse>("Algorithm is wrong.");

                    case ("TokenIsRunning", null):
                        return Unauthorized<JwtAuthResponse>("Toekn is not expired.");

                    case ("RefreshTokenNotFound", null):
                        return Unauthorized<JwtAuthResponse>("Refresh token not found.");

                    case ("RefreshTokenIsExpired", null):
                        return Unauthorized<JwtAuthResponse>("Refresh token is expired.");
                }

                var (userId, ExpiryDate) = userIdAndExpiryDate;

                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    return NotFound<JwtAuthResponse>("User not found!");

                var result = await _cusAuthenticationService.GetRefreshToken(user, jwtToken, ExpiryDate, request.RefreshToken);
                return Success(result);
            }
            catch (Exception ex)
            {
                return ServerError<JwtAuthResponse>(ex.Message);
            }
        }
        #endregion


    }
}
