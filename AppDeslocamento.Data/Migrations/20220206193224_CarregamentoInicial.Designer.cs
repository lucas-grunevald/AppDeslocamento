﻿// <auto-generated />
using System;
using AppDeslocamento.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppDeslocamento.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220206193224_CarregamentoInicial")]
    partial class CarregamentoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppDeslocamento.Domain.Entities.Carro", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descricao");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Placa");

                    b.HasKey("Id");

                    b.ToTable("Carro", (string)null);
                });

            modelBuilder.Entity("AppDeslocamento.Domain.Entities.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Cpf");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("AppDeslocamento.Domain.Entities.Condutor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Condutor", (string)null);
                });

            modelBuilder.Entity("AppDeslocamento.Domain.Entities.Deslocamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("CarroId")
                        .HasColumnType("bigint");

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<long>("CondutorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataHoraFim")
                        .HasColumnType("datetime")
                        .HasColumnName("DataHoraFim");

                    b.Property<DateTime>("DataHoraInicio")
                        .HasColumnType("datetime")
                        .HasColumnName("DataHoraInicio");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Observacao");

                    b.Property<long>("QuilometragemFinal")
                        .HasColumnType("bigint")
                        .HasColumnName("QuilometragemFinal");

                    b.Property<long>("QuilometragemInicial")
                        .HasColumnType("bigint")
                        .HasColumnName("QuilometragemInicial");

                    b.HasKey("Id");

                    b.HasIndex("CarroId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("CondutorId");

                    b.ToTable("Deslocamento", (string)null);
                });

            modelBuilder.Entity("AppDeslocamento.Domain.Entities.Deslocamento", b =>
                {
                    b.HasOne("AppDeslocamento.Domain.Entities.Carro", "Carro")
                        .WithMany("Deslocamentos")
                        .HasForeignKey("CarroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Carro_Deslocamento_CarroId");

                    b.HasOne("AppDeslocamento.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Deslocamentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Cliente_Deslocamento_ClienteId");

                    b.HasOne("AppDeslocamento.Domain.Entities.Condutor", "Condutor")
                        .WithMany("Deslocamentos")
                        .HasForeignKey("CondutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Condutor_Deslocamento_CondutorId");

                    b.Navigation("Carro");

                    b.Navigation("Cliente");

                    b.Navigation("Condutor");
                });

            modelBuilder.Entity("AppDeslocamento.Domain.Entities.Carro", b =>
                {
                    b.Navigation("Deslocamentos");
                });

            modelBuilder.Entity("AppDeslocamento.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Deslocamentos");
                });

            modelBuilder.Entity("AppDeslocamento.Domain.Entities.Condutor", b =>
                {
                    b.Navigation("Deslocamentos");
                });
#pragma warning restore 612, 618
        }
    }
}