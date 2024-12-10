using AutoMapper;

namespace iClinic.Application.Mapping.Authorizations
{
    public partial class AuthorizationProfile : Profile
    {
        public AuthorizationProfile()
        {
            GetRoleByIdMapping();
            GetRoleListMapping();
        }
    }
}
