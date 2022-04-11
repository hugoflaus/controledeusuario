using System.Threading.Tasks;
using GestaoAcesso.Core.Repositories.Login;
using Microsoft.AspNetCore.Identity;

namespace GestaoAcesso.Infrastructure.Persistence.Repositories
{
    public class LoginUserRepository : ILoginUserRepository
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LoginUserRepository(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }
        public async Task<SignInResult> LoginUserAsync(string email, string password)
        {
            var resultadoIdentity = await _signInManager
                .PasswordSignInAsync(email, password, false, false);

            return resultadoIdentity;
        }
    }
}