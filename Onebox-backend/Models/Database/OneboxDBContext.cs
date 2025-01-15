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

    public virtual DbSet<Klant> Klanten { get; set; }

    public virtual DbSet<Leveringen> Leveringen { get; set; }

    public virtual DbSet<Opsturingsbedrijf> Opsturingsbedrijven { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<Schade> Schades { get; set; }
    public virtual DbSet<Users> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=onebox;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bezorger>(entity =>
        {
            entity.HasKey(e => e.BezorgerId).HasName("PK__Bezorger__B3A23682E1EC7388");

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

            entity.HasOne(d => d.Klant).WithMany(p => p.Boxes)
                .HasForeignKey(d => d.KlantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Box_Klant");
        });

        modelBuilder.Entity<Klant>(entity =>
        {
            entity.HasKey(e => e.KlantId).HasName("PK__Klant__A2633BE2DA66A13B");

            entity.ToTable("Klant");

            entity.Property(e => e.KlantId).HasColumnName("KlantID");
            entity.Property(e => e.Adres).HasMaxLength(100);
            entity.Property(e => e.Naam).HasMaxLength(100);
            entity.Property(e => e.Postcode).HasMaxLength(20);
            entity.Property(e => e.Woonplaats).HasMaxLength(100);
        });

        modelBuilder.Entity<Leveringen>(entity =>
        {
            entity.HasKey(e => e.DeliveryId).HasName("PK__Levering__3214EC2702A467E6");

            entity.ToTable("Leveringen");

            entity.Property(e => e.DeliveryId)
                .ValueGeneratedNever()
                .HasColumnName("DeliveryID");
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

            entity.HasOne(d => d.Klant).WithMany(p => p.Leveringen)
                .HasForeignKey(d => d.KlantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Leveringen_Klant1");
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

        modelBuilder.Entity<Package>(entity =>
        {
            entity.ToTable("Package");

            entity.Property(e => e.PackageId)
                .ValueGeneratedNever()
                .HasColumnName("PackageID");
            entity.Property(e => e.BoxId).HasColumnName("BoxID");
            entity.Property(e => e.PackageSize).HasMaxLength(50);
            entity.Property(e => e.TrackingCode).HasMaxLength(50);
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

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Users");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id");

            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(e => e.KlantID)
                .IsRequired()
                .HasColumnName("KlantID");

            entity.HasOne(d => d.Klant)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.KlantID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Klant");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
