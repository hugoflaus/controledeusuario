using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GestaoAcesso.Core.Repositories.Login
{
    public interface ILoginUserRepository
    {
        Task<SignInResult> LoginUserAsync(string email, string password);
    }
}