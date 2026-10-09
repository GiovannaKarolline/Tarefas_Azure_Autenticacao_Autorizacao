namespace Tarefas.Application.Abstractions.Usuario
{
    public interface ICurrentUser
    {
        public string? Id { get; }
        public bool AcessoTotal { get; }
    }
}
