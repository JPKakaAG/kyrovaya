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

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Комплектующие> Комплектующиеs { get; set; }

    public virtual DbSet<Отгрузки> Отгрузкиs { get; set; }

    public virtual DbSet<Приемка> Приемкаs { get; set; }

    public virtual DbSet<Производители> Производителиs { get; set; }

    public virtual DbSet<Склад> Складs { get; set; }

    public virtual DbSet<ТипыКомплектующего> ТипыКомплектующегоs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress; Database=kyrsovaya; User=исп-41; Password=1234567890; Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Idrole).HasName("PK__Roles__8A8B0B9AF7A8FC0A");

            entity.Property(e => e.Idrole).ValueGeneratedNever();
            entity.Property(e => e.Role1)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PK__Users__778B89210ADED62F");

            entity.Property(e => e.Iduser).ValueGeneratedNever();
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Комплектующие>(entity =>
        {
            entity.HasKey(e => e.Idкомплектующего).HasName("PK__Комплект__A8C5759FDA84DE37");

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
            entity.HasKey(e => e.Idотгрузки).HasName("PK__Отгрузки__E00E5E60E660E4BF");

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
            entity.HasKey(e => e.Idприемки).HasName("PK__Приемка__4484E328781B6713");

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
            entity.HasKey(e => e.Idпроизводителя).HasName("PK__Производ__B421E25F31FD2024");

            entity.ToTable("Производители");

            entity.Property(e => e.Idпроизводителя).HasColumnName("IDПроизводителя");
            entity.Property(e => e.НазваниеПроизводителя)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Склад>(entity =>
        {
            entity.HasKey(e => e.Idсклада).HasName("PK__Склад__E998C2AEC28A10A7");

            entity.ToTable("Склад");

            entity.Property(e => e.Idсклада).HasColumnName("IDСклада");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ТипыКомплектующего>(entity =>
        {
            entity.HasKey(e => e.IdтипаКомплектующего).HasName("PK__ТипыКомп__00FCE7F4470B9DA4");

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
