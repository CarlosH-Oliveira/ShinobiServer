using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using ShinobiServer.Models;

namespace ShinobiServer.Data;

public partial class ShinobiflawlessiiContext : DbContext
{
    private IConfiguration configuration;
    public ShinobiflawlessiiContext(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public ShinobiflawlessiiContext(DbContextOptions<ShinobiflawlessiiContext> options, IConfiguration configuration)
        : base(options)
    {
        this.configuration = configuration;
    }

    public virtual DbSet<Cla> Clas { get; set; }

    public virtual DbSet<Conto> Contos { get; set; }

    public virtual DbSet<Habilidade> Habilidades { get; set; }

    public virtual DbSet<Imagem> Imagems { get; set; }

    public virtual DbSet<Monstro> Monstros { get; set; }

    public virtual DbSet<Personagem> Personagems { get; set; }

    public virtual DbSet<Territorio> Territorios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(configuration.GetConnectionString("Shinobi"), ServerVersion.Parse("8.0.22-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cla>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cla");

            entity.HasIndex(e => e.IdImagem, "Id_Imagem");

            entity.HasIndex(e => e.IdTerritorio, "Id_Territorio");

            entity.Property(e => e.Historia).HasColumnType("text");
            entity.Property(e => e.IdImagem).HasColumnName("Id_Imagem");
            entity.Property(e => e.IdTerritorio).HasColumnName("Id_Territorio");
            entity.Property(e => e.Nome).HasMaxLength(100);

            entity.HasOne(d => d.IdImagemNavigation).WithMany(p => p.Clas)
                .HasForeignKey(d => d.IdImagem)
                .HasConstraintName("cla_ibfk_2");

            entity.HasOne(d => d.IdTerritorioNavigation).WithMany(p => p.Clas)
                .HasForeignKey(d => d.IdTerritorio)
                .HasConstraintName("cla_ibfk_1");
        });

        modelBuilder.Entity<Conto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("conto");

            entity.HasIndex(e => e.IdHabilidade, "Id_Habilidade");

            entity.HasIndex(e => e.IdPersonagem, "Id_Personagem");

            entity.HasIndex(e => e.IdTerritorio, "Id_Territorio");

            entity.Property(e => e.Conteudo).HasColumnType("text");
            entity.Property(e => e.DataPostagem)
                .HasColumnType("date")
                .HasColumnName("Data_Postagem");
            entity.Property(e => e.IdHabilidade).HasColumnName("Id_Habilidade");
            entity.Property(e => e.IdPersonagem).HasColumnName("Id_Personagem");
            entity.Property(e => e.IdTerritorio).HasColumnName("Id_Territorio");
            entity.Property(e => e.Titulo).HasMaxLength(200);

            entity.HasOne(d => d.IdHabilidadeNavigation).WithMany(p => p.Contos)
                .HasForeignKey(d => d.IdHabilidade)
                .HasConstraintName("conto_ibfk_2");

            entity.HasOne(d => d.IdPersonagemNavigation).WithMany(p => p.Contos)
                .HasForeignKey(d => d.IdPersonagem)
                .HasConstraintName("conto_ibfk_3");

            entity.HasOne(d => d.IdTerritorioNavigation).WithMany(p => p.Contos)
                .HasForeignKey(d => d.IdTerritorio)
                .HasConstraintName("conto_ibfk_1");
        });

        modelBuilder.Entity<Habilidade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("habilidade");

            entity.HasIndex(e => e.IdImagem, "Id_Imagem");

            entity.Property(e => e.Descricao).HasColumnType("text");
            entity.Property(e => e.IdImagem).HasColumnName("Id_Imagem");
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Tipo).HasMaxLength(100);

            entity.HasOne(d => d.IdImagemNavigation).WithMany(p => p.Habilidades)
                .HasForeignKey(d => d.IdImagem)
                .HasConstraintName("habilidade_ibfk_1");
        });

        modelBuilder.Entity<Imagem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("imagem");

            entity.HasIndex(e => e.IdCla, "Id_Cla");

            entity.HasIndex(e => e.IdHabilidade, "Id_Habilidade");

            entity.HasIndex(e => e.IdMonstro, "Id_Monstro");

            entity.HasIndex(e => e.IdPersonagem, "Id_Personagem");

            entity.HasIndex(e => e.IdTerritorio, "Id_Territorio");

            entity.Property(e => e.Descricao).HasColumnType("text");
            entity.Property(e => e.IdCla).HasColumnName("Id_Cla");
            entity.Property(e => e.IdHabilidade).HasColumnName("Id_Habilidade");
            entity.Property(e => e.IdMonstro).HasColumnName("Id_Monstro");
            entity.Property(e => e.IdPersonagem).HasColumnName("Id_Personagem");
            entity.Property(e => e.IdTerritorio).HasColumnName("Id_Territorio");
            entity.Property(e => e.Link).HasColumnType("text");

            entity.HasOne(d => d.IdClaNavigation).WithMany(p => p.Imagems)
                .HasForeignKey(d => d.IdCla)
                .HasConstraintName("imagem_ibfk_4");

            entity.HasOne(d => d.IdHabilidadeNavigation).WithMany(p => p.Imagems)
                .HasForeignKey(d => d.IdHabilidade)
                .HasConstraintName("imagem_ibfk_2");

            entity.HasOne(d => d.IdMonstroNavigation).WithMany(p => p.Imagems)
                .HasForeignKey(d => d.IdMonstro)
                .HasConstraintName("imagem_ibfk_5");

            entity.HasOne(d => d.IdPersonagemNavigation).WithMany(p => p.Imagems)
                .HasForeignKey(d => d.IdPersonagem)
                .HasConstraintName("imagem_ibfk_3");

            entity.HasOne(d => d.IdTerritorioNavigation).WithMany(p => p.Imagems)
                .HasForeignKey(d => d.IdTerritorio)
                .HasConstraintName("imagem_ibfk_1");
        });

        modelBuilder.Entity<Monstro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("monstro");

            entity.HasIndex(e => e.IdPersonagem, "Id_Personagem");

            entity.HasIndex(e => e.IdTerritorio, "Id_Territorio");

            entity.Property(e => e.Historia).HasColumnType("text");
            entity.Property(e => e.IdPersonagem).HasColumnName("Id_Personagem");
            entity.Property(e => e.IdTerritorio).HasColumnName("Id_Territorio");
            entity.Property(e => e.Nome).HasMaxLength(100);

            entity.HasOne(d => d.IdPersonagemNavigation).WithMany(p => p.Monstros)
                .HasForeignKey(d => d.IdPersonagem)
                .HasConstraintName("monstro_ibfk_2");

            entity.HasOne(d => d.IdTerritorioNavigation).WithMany(p => p.Monstros)
                .HasForeignKey(d => d.IdTerritorio)
                .HasConstraintName("monstro_ibfk_1");
        });

        modelBuilder.Entity<Personagem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("personagem");

            entity.HasIndex(e => e.IdCla, "Id_Cla");

            entity.HasIndex(e => e.IdMonstro, "Id_Monstro");

            entity.HasIndex(e => e.IdTerritorio, "Id_Territorio");

            entity.Property(e => e.Dinheiro).HasMaxLength(100);
            entity.Property(e => e.Historia).HasColumnType("text");
            entity.Property(e => e.IdCla).HasColumnName("Id_Cla");
            entity.Property(e => e.IdMonstro).HasColumnName("Id_Monstro");
            entity.Property(e => e.IdTerritorio).HasColumnName("Id_Territorio");
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Patente).HasMaxLength(100);

            entity.HasOne(d => d.IdClaNavigation).WithMany(p => p.Personagems)
                .HasForeignKey(d => d.IdCla)
                .HasConstraintName("personagem_ibfk_1");

            entity.HasOne(d => d.IdMonstroNavigation).WithMany(p => p.Personagems)
                .HasForeignKey(d => d.IdMonstro)
                .HasConstraintName("personagem_ibfk_3");

            entity.HasOne(d => d.IdTerritorioNavigation).WithMany(p => p.Personagems)
                .HasForeignKey(d => d.IdTerritorio)
                .HasConstraintName("personagem_ibfk_2");
        });

        modelBuilder.Entity<Territorio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("territorio");

            entity.Property(e => e.ClimaTerreno)
                .HasColumnType("text")
                .HasColumnName("Clima_Terreno");
            entity.Property(e => e.Historia).HasColumnType("text");
            entity.Property(e => e.Nome).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
