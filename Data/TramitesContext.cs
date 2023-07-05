using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TramitesAPI.Models;

namespace TramitesAPI.Data;

public partial class TramitesContext : DbContext
{
    public TramitesContext(DbContextOptions<TramitesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Documentsfortramite> Documentsfortramites { get; set; }

    public virtual DbSet<Documettipe> Documettipes { get; set; }

    public virtual DbSet<Tramite> Tramites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.DocumetTipeId }).HasName("PRIMARY");

            entity.ToTable("documents");

            entity.HasIndex(e => e.DocumetTipeId, "fk_Documents_DocumetTipe1_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.DocumetTipeId).HasColumnName("DocumetTipe_id");
            entity.Property(e => e.Auditoria).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.DocumetTipe).WithMany(p => p.Documents)
                .HasForeignKey(d => d.DocumetTipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Documents_DocumetTipe1");
        });

        modelBuilder.Entity<Documentsfortramite>(entity =>
        {
            entity.HasKey(e => new { e.DocumentsId, e.TramitesId }).HasName("PRIMARY");

            entity.ToTable("documentsfortramites");

            entity.HasIndex(e => e.DocumentsId, "fk_Documents_has_Tramites_Documents1_idx");

            entity.HasIndex(e => e.TramitesId, "fk_Documents_has_Tramites_Tramites1_idx");

            entity.Property(e => e.DocumentsId).HasColumnName("Documents_id");
            entity.Property(e => e.TramitesId).HasColumnName("Tramites_id");

            entity.HasOne(d => d.Tramites).WithMany(p => p.Documentsfortramites)
                .HasForeignKey(d => d.TramitesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Documents_has_Tramites_Tramites1");
        });

        modelBuilder.Entity<Documettipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("documettipe");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Auditoria).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<Tramite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tramites");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Auditoria).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
