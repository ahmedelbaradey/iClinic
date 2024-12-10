﻿using iClinic.Domain.Entities.Identities;
using iClinic.Domain.Helpers;

namespace  iClinic.Application.Abstracts.Presistence
{
    public interface IAuthorizationService
    {
        public Task<bool> AddRoleAsync(string roleName);
        public Task<bool> EditRoleById(int Id, string roleName);
        public Task<bool> DeleteRoleById(Role role);
        public Task<bool> IsRoleNameExist(string rolename);
        public Task<Role> GetRoleByID(int Id);
        public Task<List<Role>> GetRoleListAsync();
        public Task<ManagerUserRolesResponse> GetManagerUsersRolesData(User user);
        public Task<string> UpdateUserRoles(EditUserRolesRequest request);
    }
}