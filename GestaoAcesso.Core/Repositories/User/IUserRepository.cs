using System.Threading.Tasks;
using FluentResults;
using GestaoAcesso.Core.Entity;
using Microsoft.AspNetCore.Identity;

namespace GestaoAcesso.Core.Repositories.User
{
    public interface IUserRepository
    {
        Task<IdentityResult> CreateUserAsync(IdentityUser<int> usuarioIdentity, string password);
        Task<IdentityUser<int>> GetUserByEmailAsync(string email);
        Task<string> GenerateEmailConfirmationTokenAsync(IdentityUser<int> usuarioIdentity);
        Task<IdentityResult> ActiveUser(IdentityUser<int> usuarioIdentity, string CodigoAtivacao);
        Task<IdentityUser<int>> GetUserByIdAsync(int id);
    }
}