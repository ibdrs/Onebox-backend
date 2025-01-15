using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

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

    public virtual DbSet<BoxLogbook> BoxLogbooks { get; set; }

    public virtual DbSet<Klant> Klanten { get; set; }

    public virtual DbSet<Leveringen> Leveringen { get; set; }

    public virtual DbSet<OneBoxReview> OneBoxReviews { get; set; }

    public virtual DbSet<Opsturingsbedrijf> Opsturingsbedrijfs { get; set; }

    public virtual DbSet<Pakket> Pakketen { get; set; }

    public virtual DbSet<Schade> Schades { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=172.16.2.4;database=onebox_live;user=onebox;password=DbSecure1234!", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Bezorger>(entity =>
        {
            entity.HasKey(e => e.BezorgerId).HasName("PRIMARY");

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

        modelBuilder.Entity<BoxLogbook>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("BoxLogbook");

            entity.Property(e => e.AanvraagDicht).HasColumnType("datetime");
            entity.Property(e => e.AanvraagOpen).HasColumnType("datetime");
            entity.Property(e => e.BoxId).HasColumnName("BoxID");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.UitvoeringDicht).HasColumnType("datetime");
            entity.Property(e => e.UitvoeringOpen).HasColumnType("datetime");
        });

        modelBuilder.Entity<Klant>(entity =>
        {
            entity.HasKey(e => e.KlantId).HasName("PRIMARY");

            entity.ToTable("Klant");

            entity.Property(e => e.KlantId).HasColumnName("KlantID");
            entity.Property(e => e.Adres).HasMaxLength(100);
            entity.Property(e => e.Naam).HasMaxLength(100);
            entity.Property(e => e.Postcode).HasMaxLength(20);
            entity.Property(e => e.Woonplaats).HasMaxLength(100);
        });

        modelBuilder.Entity<Leveringen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Leveringen");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Datum).HasColumnType("text");
            entity.Property(e => e.KlantId).HasColumnName("KlantID");
            entity.Property(e => e.Leveringsituatie).HasColumnType("text");
            entity.Property(e => e.PakketId).HasColumnName("PakketID");
            entity.Property(e => e.Pakketintact).HasColumnType("text");
            entity.Property(e => e.ReactieAanDeur).HasColumnType("text");
            entity.Property(e => e.Retourtijd).HasColumnType("text");
            entity.Property(e => e.TevredenheidKlant).HasColumnType("text");
            entity.Property(e => e.Tijd).HasColumnType("text");
            entity.Property(e => e.TrackAndTraceCode)
                .HasMaxLength(255)
                .HasColumnName("track_and_trace_code");
            entity.Property(e => e.Vertrektijd).HasColumnType("text");
            entity.Property(e => e.Vervoersmethode).HasColumnType("text");
        });

        modelBuilder.Entity<OneBoxReview>(entity =>
        {
            entity.HasKey(e => e.KlantId).HasName("PRIMARY");

            entity.ToTable("OneBox_Review");

            entity.Property(e => e.KlantId)
                .ValueGeneratedNever()
                .HasColumnName("KlantID");
            entity.Property(e => e.BetrekkingOp)
                .HasMaxLength(50)
                .HasColumnName("betrekking_op");
            entity.Property(e => e.Cijfer).HasColumnName("cijfer");
            entity.Property(e => e.Datum).HasColumnName("datum");
        });

        modelBuilder.Entity<Opsturingsbedrijf>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Opsturingsbedrijf");

            entity.Property(e => e.Naam).HasMaxLength(6);
            entity.Property(e => e.OpsturingsbedrijfId).HasColumnName("OpsturingsbedrijfID");
        });

        modelBuilder.Entity<Pakket>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Pakket");

            entity.Property(e => e.Gewicht).HasMaxLength(3);
            entity.Property(e => e.Groote).HasMaxLength(19);
            entity.Property(e => e.PakketId).HasColumnName("PakketID");
        });

        modelBuilder.Entity<Schade>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Schade");

            entity.Property(e => e.PakketId).HasColumnName("PakketID");
            entity.Property(e => e.SchadeId).HasColumnName("SchadeID");
            entity.Property(e => e.Schadetype).HasMaxLength(18);
            entity.Property(e => e.TypeId)
                .HasMaxLength(10)
                .HasColumnName("TypeID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.KlantId, "KlantID");

            entity.HasIndex(e => e.Username, "Username").IsUnique();

            entity.Property(e => e.KlantId).HasColumnName("KlantID");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.Klant).WithMany(p => p.Users)
                .HasForeignKey(d => d.KlantId)
                .HasConstraintName("Users_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
