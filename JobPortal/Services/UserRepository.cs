using System.Collections.Generic;
using System.Linq;
using JobPortal.Data;
using Microsoft.AspNetCore.Identity;

namespace JobPortal.Services
{
    public class UserRepository: IUserRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public UserRepository(
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context)
        {
            _context = context;
            _roleManager = roleManager;
        }
        public string GetRoleId(string roleName)
        {
            return _roleManager.Roles.Where(x => x.Name == roleName).Select(y => y.Id).ToList()[0];
        }

        public List<string> GetUserIds(string roleId)
        {
            return _context.UserRoles.Where(x => x.RoleId != roleId).Select(y => y.UserId).ToList();
        }

        public List<IdentityUser> GetUsers(List<string> userIds)
        {
            return _context.Users.Where(a => userIds.Any(c => c == a.Id)).ToList();
        }
    }
}