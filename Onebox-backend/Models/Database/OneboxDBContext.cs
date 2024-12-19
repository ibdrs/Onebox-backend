using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Onebox_backend.Models.Database;

public partial class OneboxDBContext : DbContext
{
    public OneboxDBContext()
    {
    }

    public OneboxDBContext(DbContextOptions<OneboxDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bezorger> Bezorgers { get; set; }

    public virtual DbSet<Box> Boxes { get; set; }

    public virtual DbSet<Klant> Klants { get; set; }

    public virtual DbSet<Leveringen> Leveringens { get; set; }

    public virtual DbSet<Opsturingsbedrijf> Opsturingsbedrijfs { get; set; }

    public virtual DbSet<Schade> Schades { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=onebox;Trusted_Connection=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bezorger>(entity =>
        {
            entity.HasKey(e => e.BezorgerId).HasName("PK__Bezorger__B3A2368218679EDA");

            entity.Property(e => e.BezorgerId)
                .ValueGeneratedNever()
                .HasColumnName("BezorgerID");
            entity.Property(e => e.Postbezorgbedrijf).HasMaxLength(50);
            entity.Property(e => e.Regio).HasMaxLength(50);
            entity.Property(e => e.Woonadres).HasMaxLength(100);
        });

        modelBuilder.Entity<Box>(entity =>
        {
            entity.ToTable("Box");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.KlantId).HasColumnName("KlantID");
            entity.Property(e => e.State)
                .HasColumnName("State")
                .HasDefaultValue(false);
        });

        modelBuilder.Entity<Klant>(entity =>
        {
            entity.HasKey(e => e.KlantId).HasName("PK__Klant__A2633BE27F6C3BC9");

            entity.ToTable("Klant");

            entity.Property(e => e.KlantId).HasColumnName("KlantID");
            entity.Property(e => e.Adres).HasMaxLength(100);
            entity.Property(e => e.Naam).HasMaxLength(100);
            entity.Property(e => e.Postcode).HasMaxLength(20);
            entity.Property(e => e.Woonplaats).HasMaxLength(100);
        });

        modelBuilder.Entity<Leveringen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Levering__3214EC27FFE0E02A");

            entity.ToTable("Leveringen");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.KlantId).HasColumnName("KlantID");
            entity.Property(e => e.Leveringsituatie)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReactieAanDeur)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TevredenheidKlant)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Vervoersmethode)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Opsturingsbedrijf>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Opsturingsbedrijf");

            entity.Property(e => e.Naam)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.OpsturingsbedrijfId).HasColumnName("OpsturingsbedrijfID");
        });

        modelBuilder.Entity<Schade>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Schade");

            entity.Property(e => e.SchadeId).HasColumnName("SchadeID");
            entity.Property(e => e.Schadetype)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.TypeId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TypeID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
