﻿// <auto-generated />
using System;
using Api_Eventos.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Api_Eventos.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240717013153_AddEmailandSenhaToParticipante")]
    partial class AddEmailandSenhaToParticipante
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Api_Eventos.Models.Administrador", b =>
                {
                    b.Property<int>("AdministradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AdministradorId"));

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AdministradorId");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("Api_Eventos.Models.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("EventoId"));

                    b.Property<int>("AdministradorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data_Fim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Data_Inicio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Numero_Participantes")
                        .HasColumnType("int");

                    b.Property<string>("ParticipanteIds")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("EventoId");

                    b.HasIndex("AdministradorId");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Api_Eventos.Models.Participante", b =>
                {
                    b.Property<int>("ParticipanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ParticipanteId"));

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ParticipanteId");

                    b.ToTable("Paticipantes");
                });

            modelBuilder.Entity("Api_Eventos.Models.Evento", b =>
                {
                    b.HasOne("Api_Eventos.Models.Administrador", "Administrador")
                        .WithMany("Eventos")
                        .HasForeignKey("AdministradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrador");
                });

            modelBuilder.Entity("Api_Eventos.Models.Administrador", b =>
                {
                    b.Navigation("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}
