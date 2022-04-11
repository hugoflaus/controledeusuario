using System.Threading.Tasks;
using GestaoAcesso.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace GestaoAcesso.Core.Services
{
    public interface IAuthService
    {
        Token CreateToken(IdentityUser<int> usuario);
    }
}