using System;
using System.Collections.Generic;
using System.Text;
using Tarefas.Application.Abstractions.Tarefas;
using Tarefas.Domain.Tarefas;
using Tarefas.Infrastructure.Data.Persistence;

namespace Tarefas.Infrastructure.Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<Tarefa> AdicionarTarefaAsync(Tarefa tarefa, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Tarefa?> GetTarefaByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tarefa>> GetTarefasAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tarefa>> GetTarefasByUsuarioIdAsync(string usuarioId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoverTarefaAsync(Tarefa tarefa, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
