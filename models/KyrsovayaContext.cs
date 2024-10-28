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

    public virtual DbSet<Заказы> Заказыs { get; set; }

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
            entity.HasKey(e => e.Idrole).HasName("PK__Roles__8A8B0B9AD67706F5");

            entity.Property(e => e.Idrole).ValueGeneratedNever();
            entity.Property(e => e.Role1)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Iduser).HasName("PK__Users__778B89210A07A801");

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

            entity.HasOne(d => d.IdroleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.Idrole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        modelBuilder.Entity<Заказы>(entity =>
        {
            entity.HasKey(e => e.Idзаказа).HasName("PK__Заказы__EC34FC456BB31667");

            entity.ToTable("Заказы");

            entity.Property(e => e.Idзаказа).HasColumnName("IDЗаказа");
            entity.Property(e => e.Idкомплектующего).HasColumnName("IDКомплектующего");
            entity.Property(e => e.Idсклада).HasColumnName("IDСклада");
            entity.Property(e => e.ДатаЗаказа).HasColumnType("datetime");

            entity.HasOne(d => d.IduserNavigation).WithMany(p => p.Заказыs)
                .HasForeignKey(d => d.Iduser)
                .HasConstraintName("FK__Заказы__Iduser__17F790F9");

            entity.HasOne(d => d.IdкомплектующегоNavigation).WithMany(p => p.Заказыs)
                .HasForeignKey(d => d.Idкомплектующего)
                .HasConstraintName("FK__Заказы__IDКомпле__160F4887");

            entity.HasOne(d => d.IdскладаNavigation).WithMany(p => p.Заказыs)
                .HasForeignKey(d => d.Idсклада)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Заказы__IDСклада__17036CC0");
        });

        modelBuilder.Entity<Комплектующие>(entity =>
        {
            entity.HasKey(e => e.Idкомплектующего).HasName("PK__Комплект__A8C5759FA59ABCD2");

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
                .HasConstraintName("FK__Комплекту__IDПро__07C12930");

            entity.HasOne(d => d.IdскладаNavigation).WithMany(p => p.Комплектующиеs)
                .HasForeignKey(d => d.Idсклада)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Комплекту__IDСкл__08B54D69");

            entity.HasOne(d => d.IdтипаКомплектующегоNavigation).WithMany(p => p.Комплектующиеs)
                .HasForeignKey(d => d.IdтипаКомплектующего)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Комплекту__IDТИп__09A971A2");
        });

        modelBuilder.Entity<Отгрузки>(entity =>
        {
            entity.HasKey(e => e.Idотгрузки).HasName("PK__Отгрузки__E00E5E609018C593");

            entity.ToTable("Отгрузки");

            entity.Property(e => e.Idотгрузки).HasColumnName("IDОтгрузки");
            entity.Property(e => e.Idкомплектующего).HasColumnName("IDКомплектующего");
            entity.Property(e => e.Idсклада).HasColumnName("IDСклада");

            entity.HasOne(d => d.IdкомплектующегоNavigation).WithMany(p => p.Отгрузкиs)
                .HasForeignKey(d => d.Idкомплектующего)
                .HasConstraintName("FK__Отгрузки__IDКомп__0A9D95DB");

            entity.HasOne(d => d.IdскладаNavigation).WithMany(p => p.Отгрузкиs)
                .HasForeignKey(d => d.Idсклада)
                .HasConstraintName("FK__Отгрузки__IDСкла__0B91BA14");
        });

        modelBuilder.Entity<Приемка>(entity =>
        {
            entity.HasKey(e => e.Idприемки).HasName("PK__Приемка__4484E328C2376F99");

            entity.ToTable("Приемка");

            entity.Property(e => e.Idприемки).HasColumnName("IDПриемки");
            entity.Property(e => e.Idкомплектующего).HasColumnName("IDКомплектующего");
            entity.Property(e => e.Idсклада).HasColumnName("IDСклада");

            entity.HasOne(d => d.IdкомплектующегоNavigation).WithMany(p => p.Приемкаs)
                .HasForeignKey(d => d.Idкомплектующего)
                .HasConstraintName("FK__Приемка__IDКомпл__0C85DE4D");

            entity.HasOne(d => d.IdскладаNavigation).WithMany(p => p.Приемкаs)
                .HasForeignKey(d => d.Idсклада)
                .HasConstraintName("FK__Приемка__IDСклад__0D7A0286");
        });

        modelBuilder.Entity<Производители>(entity =>
        {
            entity.HasKey(e => e.Idпроизводителя).HasName("PK__Производ__B421E25FA345C66B");

            entity.ToTable("Производители");

            entity.Property(e => e.Idпроизводителя).HasColumnName("IDПроизводителя");
            entity.Property(e => e.НазваниеПроизводителя)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Склад>(entity =>
        {
            entity.HasKey(e => e.Idсклада).HasName("PK__Склад__E998C2AE21E09B06");

            entity.ToTable("Склад");

            entity.Property(e => e.Idсклада).HasColumnName("IDСклада");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ТипыКомплектующего>(entity =>
        {
            entity.HasKey(e => e.IdтипаКомплектующего).HasName("PK__ТипыКомп__00FCE7F4D99CC08E");

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
