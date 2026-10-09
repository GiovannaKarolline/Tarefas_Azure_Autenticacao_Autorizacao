namespace Tarefas.Domain.Tarefas
{
    public class Tarefa
    {
        public Guid Id { get; private set; }

        public string Titulo { get; private set; }

        public bool Concluida { get; private set; }
        public string DonoId { get; private set; }
        public DateTime DataCriacao { get; private set; }

        private Tarefa() { }

        public Tarefa(string titulo, string donoId)
        {
            titulo = titulo.Trim();

            if (string.IsNullOrWhiteSpace(titulo) || string.IsNullOrEmpty(titulo))
            {
                throw new DomainException("O título precisa ser preenchido.");
            }

            if(titulo.Length > 200)
            {
                throw new DomainException("O título não pode ultrapassar os 200 caracteres.");
            }

            if(string.IsNullOrWhiteSpace(donoId) || string.IsNullOrEmpty(donoId))
            {
                throw new DomainException("O dono da tarefa precisa ser definido.");
            }

            Id = Guid.NewGuid();
            Titulo = titulo;
            DonoId = donoId;
            Concluida = false;
            DataCriacao = DateTime.UtcNow;

        }

        public void Concluir()
        {
            if(this.Concluida == true)
            {
                throw new DomainException("A tarefa já está concluída, então a mudança não pôde ser aplicada.");
            }

            Concluida = true;
        }

        public bool PertenceAoUsuario(string usuarioId)
        {
            if(DonoId == usuarioId)
            {
                return true;
            }

            return false;
        }
    }
}
