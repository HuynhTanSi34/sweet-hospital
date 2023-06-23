using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SweetHospitalver3.Models
{
    public partial class HospitalDbContext : DbContext
    {
        public HospitalDbContext()
            : base("name=HospitalDbContext")
        {
        }

        public virtual DbSet<BACSI> BACSI { get; set; }
        public virtual DbSet<CAPSO> CAPSO { get; set; }
        public virtual DbSet<DSKHOA> DSKHOA { get; set; }
        public virtual DbSet<HOSO> HOSO { get; set; }
        public virtual DbSet<KETQUA> KETQUA { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIEN { get; set; }
        public virtual DbSet<PHANHOI> PHANHOI { get; set; }
        public virtual DbSet<PHIEUHEN> PHIEUHEN { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOAN { get; set; }
        public virtual DbSet<THOIGIANBS> THOIGIANBS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BACSI>()
                .Property(e => e.MaBS)
                .IsUnicode(false);

            modelBuilder.Entity<BACSI>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<BACSI>()
                .Property(e => e.Ha)
                .IsUnicode(false);

            modelBuilder.Entity<BACSI>()
                .Property(e => e.TK)
                .IsUnicode(false);

            modelBuilder.Entity<BACSI>()
                .HasMany(e => e.THOIGIANBS)
                .WithRequired(e => e.BACSI)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CAPSO>()
                .Property(e => e.STT)
                .IsUnicode(false);

            modelBuilder.Entity<CAPSO>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<DSKHOA>()
                .Property(e => e.MaKhoa)
                .IsUnicode(false);

            modelBuilder.Entity<HOSO>()
                .Property(e => e.TK)
                .IsUnicode(false);

            modelBuilder.Entity<HOSO>()
                .Property(e => e.MaHS)
                .IsUnicode(false);

            modelBuilder.Entity<HOSO>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<HOSO>()
                .HasMany(e => e.KETQUA)
                .WithRequired(e => e.HOSO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOSO>()
                .HasMany(e => e.PHIEUHEN)
                .WithRequired(e => e.HOSO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KETQUA>()
                .Property(e => e.MaPhieu)
                .IsUnicode(false);

            modelBuilder.Entity<KETQUA>()
                .Property(e => e.MaHS)
                .IsUnicode(false);

            modelBuilder.Entity<KETQUA>()
                .Property(e => e.Ha1)
                .IsUnicode(false);

            modelBuilder.Entity<KETQUA>()
                .Property(e => e.Ha2)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.Ha)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.TK)
                .IsUnicode(false);

            modelBuilder.Entity<PHANHOI>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUHEN>()
                .Property(e => e.MaPhieu)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUHEN>()
                .Property(e => e.MaHS)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUHEN>()
                .Property(e => e.MaDK)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.TK)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.BACSI)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.HOSO)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.NHANVIEN)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THOIGIANBS>()
                .Property(e => e.MaDK)
                .IsUnicode(false);

            modelBuilder.Entity<THOIGIANBS>()
                .Property(e => e.MaBS)
                .IsUnicode(false);

            modelBuilder.Entity<THOIGIANBS>()
                .HasMany(e => e.PHIEUHEN)
                .WithRequired(e => e.THOIGIANBS)
                .WillCascadeOnDelete(false);
        }
    }
}
