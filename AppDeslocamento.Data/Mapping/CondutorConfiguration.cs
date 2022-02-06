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
    public class CondutorConfiguration : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Condutor");

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("Nome");

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnName("Email");
                
        }
    }
}
