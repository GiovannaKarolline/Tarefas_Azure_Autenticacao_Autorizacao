namespace Tarefas.Application.Abstractions.Usuario
{
    public interface ICurrentUser
    {
        public Guid Id { get; }
        public bool IsAdmin { get; }
    }
}
