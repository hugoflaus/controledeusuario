using System.Linq;
using System.Threading.Tasks;
using FluentResults;
using GestaoAcesso.Core.Entity;
using GestaoAcesso.Core.Repositories.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GestaoAcesso.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserManager<IdentityUser<int>> _userManager;

        public UserRepository(UserManager<IdentityUser<int>> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> ActiveUser(IdentityUser<int> usuarioIdentity, string CodigoAtivacao)
        {
            return await _userManager.ConfirmEmailAsync(usuarioIdentity, CodigoAtivacao);
        }

        public async Task<IdentityResult> CreateUserAsync(IdentityUser<int> usuarioIdentity, string password)
        {
            var resultIdentity = await _userManager.CreateAsync(usuarioIdentity, password);
            return resultIdentity;
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(IdentityUser<int> usuarioIdentity)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity);
        }

        public async Task<string> GenerateResetToken(IdentityUser<int> usuarioIdentity)
        {
            return await _userManager.GeneratePasswordResetTokenAsync(usuarioIdentity);
        }

        public async Task<IdentityUser<int>> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user;
        }


        public async Task<IdentityUser<int>> GetUserByIdAsync(int id)
        {
            var identityUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);

            return identityUser;
        }

        public async Task<IdentityResult> ResetPassword(IdentityUser<int> usuarioIdentity, string token, string password)
        {
            return await _userManager.ResetPasswordAsync(usuarioIdentity, token, password);
        }
    }
}