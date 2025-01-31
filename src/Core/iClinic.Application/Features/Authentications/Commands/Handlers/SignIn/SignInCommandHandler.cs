using AutoMapper;
using iClinic.Application.Base;
using iClinic.Domain.Entities.Identities;
using iClinic.Domain.Helpers;
using iClinic.Presistence.Contract;
using MediatR;
using Microsoft.AspNetCore.Identity;
using iClinic.Application.Features.Authentications.Commands.Handlers.RefreshToken;

namespace iClinic.Application.Features.Authentications.Commands.Handlers.SignIn
{
    public class SignInCommandHandler : BaseResponseHandler,IRequestHandler<SignInCommand, BaseResponse<JwtAuthResponse>>
    {
        #region Fileds
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationService _cusAuthenticationService;
        #endregion

        #region Constructors
        public SignInCommandHandler(UserManager<User> userManager,SignInManager<User> signInManager, IAuthenticationService cusAuthenticationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cusAuthenticationService = cusAuthenticationService;
        }
        #endregion

        #region Functions
        public async Task<BaseResponse<JwtAuthResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(request.UserName);
                if (user == null)
                    return NotFound<JwtAuthResponse>("User with this username not found!");

                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if (!signInResult.Succeeded)
                {
                    return BadRequest<JwtAuthResponse>("Password is't correct.");
                }

                var accessToken = await _cusAuthenticationService.GetJwtToken(user);
                return Success(accessToken);
            }
            catch (Exception ex)
            {
                return ServerError<JwtAuthResponse>(ex.Message);
            }
        }
        #endregion

    }
}
