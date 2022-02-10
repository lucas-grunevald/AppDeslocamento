using AppDeslocamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppDeslocamento.Data.Mapping
{
    public class DeslocamentoConfiguration : IEntityTypeConfiguration<Deslocamento>
    {
        public void Configure(EntityTypeBuilder<Deslocamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Deslocamento");

            builder.HasOne(p => p.Carro)
                .WithMany(d => d.Deslocamentos)
                .HasForeignKey(e => e.CarroId)
                .HasConstraintName("FK_Carro_Deslocamento_CarroId");

            builder.HasOne(p => p.Cliente)
                .WithMany(d => d.Deslocamentos)
                .HasForeignKey(e => e.ClienteId)
                .HasConstraintName("FK_Cliente_Deslocamento_ClienteId");

            builder.HasOne(p => p.Condutor)
                .WithMany(d => d.Deslocamentos)
                .HasForeignKey(e => e.CondutorId)
                .HasConstraintName("FK_Condutor_Deslocamento_CondutorId");

            builder.Property(p => p.DataHoraInicio)
                .IsRequired()
                .HasColumnName("DataHoraInicio")
                .HasColumnType("datetime");

            builder.Property(p => p.QuilometragemInicial)
                .IsRequired()
                .HasColumnName("QuilometragemInicial");

            builder.Property(p => p.DataHoraFim)
                .IsRequired(false)
                .HasColumnName("DataHoraFim")
                .HasColumnType("datetime");

            builder.Property(p => p.QuilometragemFinal)
                .IsRequired(false)
                .HasColumnName("QuilometragemFinal");

            builder.Property(p => p.Observacao)
                .IsRequired()
                .HasColumnName("Observacao");

        }
    }
}