using iClinic.Application.Features.Users.Queries.Responses;
using iClinic.Domain.Entities.Identities;

namespace iClinic.Application.Mapping.Users
{
    public partial class UserProfile
    {
        public void GetUserByIdMapping()
        {
            CreateMap<User, GetUserByIdResponse>();
        }
    }
}
