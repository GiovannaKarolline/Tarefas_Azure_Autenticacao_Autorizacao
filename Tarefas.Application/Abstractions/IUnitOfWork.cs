namespace Tarefas.Application.Abstractions
{
    public interface IUnitOfWork
    {
        public Task<bool> CommitAsync();
    }
}
