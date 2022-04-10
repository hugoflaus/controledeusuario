namespace GestaoAcesso.Core.Entity.Base
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { }
        public int Id { get; private set; }
    }
}