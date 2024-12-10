using iClinic.Application.Features.Authorizations.Queries.Responses;
using iClinic.Domain.Entities.Identities;

namespace iClinic.Application.Mapping.Authorizations
{
    public partial class AuthorizationProfile
    {
        public void GetRoleByIdMapping()
        {
            CreateMap<Role, GetRoleByIdResponse>()
                .ForMember(dest => dest.roleName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
