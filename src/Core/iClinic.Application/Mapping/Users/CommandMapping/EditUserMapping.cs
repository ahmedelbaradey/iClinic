using iClinic.Application.Features.Users.Commands.Models;
using iClinic.Domain.Entities.Identities;

namespace iClinic.Application.Mapping.Users
{
    public partial class UserProfile
    {
        public void EditUserMapping()
        {
            CreateMap<EditUserCommand, User>();
        }
    }
}
