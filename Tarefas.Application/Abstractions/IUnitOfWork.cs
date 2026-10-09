namespace Tarefas.Application.Abstractions
{
    public interface IUnitOfWork
    {
        public Task CommitAsync(CancellationToken cancellationToken);
    }
}