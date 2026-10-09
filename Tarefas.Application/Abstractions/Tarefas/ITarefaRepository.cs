using Tarefas.Domain.Tarefas;

namespace Tarefas.Application.Abstractions.Tarefas
{
    public interface ITarefaRepository
    {
        public Task<Tarefa?> GetTarefaByIdAsync(Guid id, CancellationToken cancellationToken);

        public Task<IEnumerable<Tarefa>> GetTarefasAsync(CancellationToken cancellationToken);

        public Task<IEnumerable<Tarefa>> GetTarefasByUsuarioIdAsync(string usuarioId, CancellationToken cancellationToken);

        public Task<Tarefa> AdicionarTarefaAsync(Tarefa tarefa, CancellationToken cancellationToken);

        public Task RemoverTarefaAsync(Tarefa tarefa, CancellationToken cancellationToken);
    }
}