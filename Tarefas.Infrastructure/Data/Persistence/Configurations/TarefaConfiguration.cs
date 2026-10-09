using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarefas.Domain.Tarefas;

namespace Tarefas.Infrastructure.Data.Persistence.Configurations
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefas");

            builder.HasKey(tarefa => tarefa.Id);

            builder.Property(tarefa => tarefa.Id)
                .ValueGeneratedNever();

            builder.Property(tarefa => tarefa.DonoId)
                .HasMaxLength(36)
                .IsRequired();

            builder.Property(tarefa => tarefa.Titulo)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(tarefa => tarefa.DataCriacao)
                .IsRequired();

            builder.Property(tarefa => tarefa.Concluida)
                .IsRequired();
        }
    }
}
