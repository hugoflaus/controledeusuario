using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GestaoAcesso.Core.Repositories.Roles
{
    public interface IRoleRepository
    {
        string GetRolesAsync(IdentityUser<int> usuarioIdentity);
    }
}