using Tarefas.Domain.Tarefa;

namespace Tarefas.Application.Abstractions.Tarefas
{
    public interface ITarefaRepository
    {
        public Task<Tarefa> GetTarefaByIdAsync(Guid id);

        public Task<IEnumerable<Tarefa>> GetTarefasAsync();

        public Task<IEnumerable<Tarefa>> GetTarefasByUsuarioIdAsync(string usuarioId);

        public Task<Tarefa> AdicionarTarefaAsync(Tarefa tarefa);

        public Task<bool> RemoverTarefaByIdAsync(Guid id);
    }
}
