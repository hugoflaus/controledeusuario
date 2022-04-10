using GestaoAcesso.Core.Entity.Base;

namespace GestaoAcesso.Core.Entity
{
    public class Usuario
    {
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
    }
}