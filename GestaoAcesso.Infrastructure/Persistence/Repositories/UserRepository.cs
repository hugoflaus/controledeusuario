using System.Threading.Tasks;
using FluentResults;
using GestaoAcesso.Core.Entity;
using GestaoAcesso.Core.Repositories.User;
using Microsoft.AspNetCore.Identity;

namespace GestaoAcesso.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserManager<IdentityUser<int>> _userManager;

        public UserRepository(UserManager<IdentityUser<int>> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> CreateUserAsync(IdentityUser<int> usuarioIdentity, string password)
        {
            var resultIdentity = await _userManager.CreateAsync(usuarioIdentity, password);
            return resultIdentity;
        }

        public async Task<IdentityUser<int>> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user;
        }
    }
}