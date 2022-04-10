

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GestaoAcesso.Infrastructure.Persistence
{
    public class GestaoAcessoDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public GestaoAcessoDbContext(DbContextOptions<GestaoAcessoDbContext> opt) : base(opt)
        {

        }
    }
}