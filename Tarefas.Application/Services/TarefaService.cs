using Tarefas.Application.Abstractions;
using Tarefas.Application.Abstractions.Tarefas;
using Tarefas.Application.Abstractions.Usuario;
using Tarefas.Application.DTOs.Tarefas;
using Tarefas.Domain.Tarefas;

namespace Tarefas.Application.Services
{
    public class TarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly ICurrentUser _usuarioAtual;
        private readonly IUnitOfWork _unitOfWork;

        public TarefaService(ITarefaRepository repository, ICurrentUser usuario, IUnitOfWork unitOfWork)
        {
            _tarefaRepository = repository;
            _usuarioAtual = usuario;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TarefaResponseDto>> GetTarefasAsync(CancellationToken cancellationToken)
        {
            if (_usuarioAtual.AcessoTotal)
            {
                return (await _tarefaRepository
                .GetTarefasAsync(cancellationToken))
                .Select(tarefa => new TarefaResponseDto(tarefa)).ToList();
            }

            return (await _tarefaRepository
                .GetTarefasByUsuarioIdAsync(_usuarioAtual.Id, cancellationToken))
                .Select(tarefa => new TarefaResponseDto(tarefa)).ToList();
        }

        public async Task<TarefaResponseDto?> GetTarefaByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            Tarefa? tarefa = await _tarefaRepository.GetTarefaByIdAsync(id, cancellationToken);

            if(tarefa is null || (!tarefa.PertenceAoUsuario(_usuarioAtual.Id) && _usuarioAtual.AcessoTotal == false))
            {
                return null;
            }

            return new TarefaResponseDto(tarefa);

        }

        public async Task<TarefaResponseDto> CriarTarefaAsync(TarefaRequestDto tarefaDto, CancellationToken cancellationToken)
        {
            Tarefa tarefa = new Tarefa(tarefaDto.Titulo, _usuarioAtual.Id);

            tarefa = await _tarefaRepository.AdicionarTarefaAsync(tarefa, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new TarefaResponseDto(tarefa);
        }

        public async Task<TarefaResponseDto?> ConcluirTarefaAsync(Guid tarefaId, CancellationToken cancellationToken)
        {
            Tarefa? tarefa = await _tarefaRepository.GetTarefaByIdAsync(tarefaId, cancellationToken);

            if(tarefa is null || (!tarefa.PertenceAoUsuario(_usuarioAtual.Id) && !_usuarioAtual.AcessoTotal))
            {
                return null;
            }

            tarefa.Concluir();

            await _unitOfWork.CommitAsync(cancellationToken);

            return new TarefaResponseDto(tarefa);
        }

        public async Task ExcluirTarefaByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            Tarefa? tarefa = await _tarefaRepository.GetTarefaByIdAsync(id, cancellationToken);

            if(tarefa is not null)
            {
                await _tarefaRepository.RemoverTarefaAsync(tarefa, cancellationToken);

                await _unitOfWork.CommitAsync(cancellationToken);
            }

        }
    }
}
