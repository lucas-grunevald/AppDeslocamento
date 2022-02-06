using AppDeslocamento.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeslocamento.Data.Mapping
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Cliente");

            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasColumnName("Cpf");

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("Nome");

        }
    }
}