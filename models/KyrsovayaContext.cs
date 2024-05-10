using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kyrovaya.models;

public partial class KyrsovayaContext : DbContext
{
    public KyrsovayaContext()
    {
    }

    public KyrsovayaContext(DbContextOptions<KyrsovayaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Комплектующие> Комплектующиеs { get; set; }

    public virtual DbSet<Отгрузки> Отгрузкиs { get; set; }

    public virtual DbSet<Приемка> Приемкаs { get; set; }

    public virtual DbSet<Производители> Производителиs { get; set; }

    public virtual DbSet<Склад> Складs { get; set; }

    public virtual DbSet<ТипыКомплектующего> ТипыКомплектующегоs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress; Database=Kyrsovaya; User=исп-31; Password=1234567890; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Комплектующие>(entity =>
        {
            entity.HasKey(e => e.Idкомплектующего).HasName("PK__Комплект__A8C5759FDEB33010");

            entity.ToTable("Комплектующие");

            entity.Property(e => e.Idкомплектующего).HasColumnName("IDКомплектующего");
            entity.Property(e => e.Idпроизводителя).HasColumnName("IDПроизводителя");
            entity.Property(e => e.Idсклада).HasColumnName("IDСклада");
            entity.Property(e => e.IdтипаКомплектующего).HasColumnName("IDТИпаКомплектующего");
            entity.Property(e => e.НазваниеКомплектующего)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Цена).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdпроизводителяNavigation).WithMany(p => p.Комплектующиеs)
                .HasForeignKey(d => d.Idпроизводителя)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Комплекту__IDПро__2E1BDC42");

            entity.HasOne(d => d.IdскладаNavigation).WithMany(p => p.Комплектующиеs)
                .HasForeignKey(d => d.Idсклада)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Комплекту__IDСкл__2F10007B");

            entity.HasOne(d => d.IdтипаКомплектующегоNavigation).WithMany(p => p.Комплектующиеs)
                .HasForeignKey(d => d.IdтипаКомплектующего)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Комплекту__IDТИп__300424B4");
        });

        modelBuilder.Entity<Отгрузки>(entity =>
        {
            entity.HasKey(e => e.Idотгрузки).HasName("PK__Отгрузки__E00E5E6054C636CF");

            entity.ToTable("Отгрузки");

            entity.Property(e => e.Idотгрузки).HasColumnName("IDОтгрузки");
            entity.Property(e => e.Idкомплектующего).HasColumnName("IDКомплектующего");
            entity.Property(e => e.Idсклада).HasColumnName("IDСклада");

            entity.HasOne(d => d.IdкомплектующегоNavigation).WithMany(p => p.Отгрузкиs)
                .HasForeignKey(d => d.Idкомплектующего)
                .HasConstraintName("FK__Отгрузки__IDКомп__30F848ED");

            entity.HasOne(d => d.IdскладаNavigation).WithMany(p => p.Отгрузкиs)
                .HasForeignKey(d => d.Idсклада)
                .HasConstraintName("FK__Отгрузки__IDСкла__31EC6D26");
        });

        modelBuilder.Entity<Приемка>(entity =>
        {
            entity.HasKey(e => e.Idприемки).HasName("PK__Приемка__4484E32845922A4E");

            entity.ToTable("Приемка");

            entity.Property(e => e.Idприемки).HasColumnName("IDПриемки");
            entity.Property(e => e.Idкомплектующего).HasColumnName("IDКомплектующего");
            entity.Property(e => e.Idсклада).HasColumnName("IDСклада");

            entity.HasOne(d => d.IdкомплектующегоNavigation).WithMany(p => p.Приемкаs)
                .HasForeignKey(d => d.Idкомплектующего)
                .HasConstraintName("FK__Приемка__IDКомпл__32E0915F");

            entity.HasOne(d => d.IdскладаNavigation).WithMany(p => p.Приемкаs)
                .HasForeignKey(d => d.Idсклада)
                .HasConstraintName("FK__Приемка__IDСклад__33D4B598");
        });

        modelBuilder.Entity<Производители>(entity =>
        {
            entity.HasKey(e => e.Idпроизводителя).HasName("PK__Производ__B421E25F899A5DA9");

            entity.ToTable("Производители");

            entity.Property(e => e.Idпроизводителя).HasColumnName("IDПроизводителя");
            entity.Property(e => e.НазваниеПроизводителя)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Склад>(entity =>
        {
            entity.HasKey(e => e.Idсклада).HasName("PK__Склад__E998C2AEFC41AC0D");

            entity.ToTable("Склад");

            entity.Property(e => e.Idсклада).HasColumnName("IDСклада");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ТипыКомплектующего>(entity =>
        {
            entity.HasKey(e => e.IdтипаКомплектующего).HasName("PK__ТипыКомп__00FCE7F4D9045E96");

            entity.ToTable("ТипыКомплектующего");

            entity.Property(e => e.IdтипаКомплектующего).HasColumnName("IDТипаКомплектующего");
            entity.Property(e => e.НазваниеТипаКомплектующего)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
