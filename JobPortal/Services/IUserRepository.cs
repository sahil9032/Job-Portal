using System.Collections.Generic;
using JobPortal.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.Services
{
    public interface IUserRepository
    {
        public string GetRoleId(string roleName);
        public List<string> GetUserIds(string roleId);
        public List<IdentityUser> GetUsers(List<string> userIds);
    }
}