using Tarefas.Domain.Tarefas;

namespace Tarefas.Application.DTOs.Tarefas
{
    public class TarefaResponseDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public bool Concluida { get; set; }
        public DateTime DataCriacao { get; set; }

        public TarefaResponseDto(Tarefa tarefa)
        {
            Id = tarefa.Id;
            Concluida = tarefa.Concluida;
            DataCriacao = tarefa.DataCriacao;
            Titulo = tarefa.Titulo;
        }
    }
}
