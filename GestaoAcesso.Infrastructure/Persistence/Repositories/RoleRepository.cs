using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestaoAcesso.Core.Repositories.Roles;
using Microsoft.AspNetCore.Identity;

namespace GestaoAcesso.Infrastructure.Persistence.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private UserManager<IdentityUser<int>> _userManager;

        public RoleRepository(UserManager<IdentityUser<int>> userManager)
        {
            _userManager = userManager;
        }
        public string GetRolesAsync(IdentityUser<int> usuarioIdentity)
        {
            return _userManager.GetRolesAsync(usuarioIdentity).Result.FirstOrDefault();
        }
    }
}