using iClinic.Application.Features.Authorizations.Queries.Responses;
using iClinic.Domain.Entities.Identities;

namespace iClinic.Application.Mapping.Authorizations
{
    public partial class AuthorizationProfile
    {
        public void GetRoleListMapping()
        {
            CreateMap<Role, GetRoleListResponse>()
                .ForMember(dest => dest.roleName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
