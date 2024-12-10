using iClinic.Application.Features.Users.Queries.Responses;
using iClinic.Domain.Entities.Identities;

namespace iClinic.Application.Mapping.Users
{
    public partial class UserProfile
    {
        public void GetUserPaginatedListMapping()
        {
            CreateMap<User, GetUserPaginatedListResponse>();
        }
    }
}
