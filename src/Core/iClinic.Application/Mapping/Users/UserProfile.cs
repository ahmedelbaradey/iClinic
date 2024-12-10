﻿using AutoMapper;

namespace iClinic.Application.Mapping.Users
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            AddUserMapping();
            EditUserMapping();
            GetUserPaginatedListMapping();
            GetUserByIdMapping();
        }
    }
}
