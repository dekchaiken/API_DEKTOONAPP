using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Dektoon.Entities
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdmManageCartoon> AdmManageCartoons { get; set; } = null!;
        public virtual DbSet<AdmManageNovel> AdmManageNovels { get; set; } = null!;
        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Cartoon> Cartoons { get; set; } = null!;
        public virtual DbSet<CartoonEp> CartoonEps { get; set; } = null!;
        public virtual DbSet<CartoonPicture> CartoonPictures { get; set; } = null!;
        public virtual DbSet<Novel> Novels { get; set; } = null!;
        public virtual DbSet<NovelEp> NovelEps { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=dektoon.czuatuouc8a1.ap-northeast-1.rds.amazonaws.com,1433;Initial Catalog=Dektoon;User ID=admin;Password=admin1234;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdmManageCartoon>(entity =>
            {
                entity.HasKey(e => new { e.AdminId, e.CartoonId });

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.AdmManageCartoons)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdmManageCartoon_Admin");

                entity.HasOne(d => d.Cartoon)
                    .WithMany(p => p.AdmManageCartoons)
                    .HasForeignKey(d => d.CartoonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdmManageCartoon_Cartoon");
            });

            modelBuilder.Entity<AdmManageNovel>(entity =>
            {
                entity.HasKey(e => new { e.AdminId, e.NovelId });

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.AdmManageNovels)
                    .HasForeignKey(d => d.AdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdmManageNovel_Admin");

                entity.HasOne(d => d.Novel)
                    .WithMany(p => p.AdmManageNovels)
                    .HasForeignKey(d => d.NovelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdmManageNovel_Novel");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Cartoon>(entity =>
            {
                entity.Property(e => e.CartoonId).ValueGeneratedNever();

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Cartoons)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Cartoon_Type");
            });

            modelBuilder.Entity<CartoonEp>(entity =>
            {
                entity.Property(e => e.CartoonEpId).ValueGeneratedNever();

                entity.HasOne(d => d.Cartoon)
                    .WithMany(p => p.CartoonEps)
                    .HasForeignKey(d => d.CartoonId)
                    .HasConstraintName("FK_CartoonEP_Cartoon");
            });

            modelBuilder.Entity<CartoonPicture>(entity =>
            {
                entity.Property(e => e.CartoonPicId).ValueGeneratedNever();

                entity.HasOne(d => d.CartoonEp)
                    .WithMany(p => p.CartoonPictures)
                    .HasForeignKey(d => d.CartoonEpId)
                    .HasConstraintName("FK_CartoonPicture_CartoonEP");
            });

            modelBuilder.Entity<Novel>(entity =>
            {
                entity.Property(e => e.NovelId).ValueGeneratedNever();

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Novels)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Novel_Type");
            });

            modelBuilder.Entity<NovelEp>(entity =>
            {
                entity.Property(e => e.NovelEpId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.TypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK_User_Admin");

                entity.HasMany(d => d.Types)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "FavType",
                        l => l.HasOne<Type>().WithMany().HasForeignKey("TypeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_FavType_Type"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_FavType_User"),
                        j =>
                        {
                            j.HasKey("UserId", "TypeId");

                            j.ToTable("FavType");

                            j.IndexerProperty<int>("UserId").HasColumnName("userId");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
