﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationTeste.Data;

#nullable disable

namespace WebApplicationTeste.Migrations
{
    [DbContext(typeof(WebApplicationTesteContext))]
    partial class WebApplicationTesteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebApplicationTeste.Models.CatalogoImovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Cep");

                    b.Property<string>("Complemento")
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Complemento");

                    b.Property<int>("Numero")
                        .HasColumnType("int")
                        .HasColumnName("Numero");

                    b.Property<int>("ProprietarioId")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Rua");

                    b.HasKey("Id");

                    b.HasIndex("ProprietarioId");

                    b.ToTable("CatalogoImovel");
                });

            modelBuilder.Entity("WebApplicationTeste.Models.Proprietario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int?>("Email")
                        .HasColumnType("int")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Nome");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext")
                        .HasColumnName("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Proprietario");
                });

            modelBuilder.Entity("WebApplicationTeste.Models.CatalogoImovel", b =>
                {
                    b.HasOne("WebApplicationTeste.Models.Proprietario", "Proprietario")
                        .WithMany()
                        .HasForeignKey("ProprietarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proprietario");
                });
#pragma warning restore 612, 618
        }
    }
}
