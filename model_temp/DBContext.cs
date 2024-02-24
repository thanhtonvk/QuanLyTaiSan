using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyVatTu.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual DbSet<ChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<LoaiTaiSan> LoaiTaiSans { get; set; }
        public virtual DbSet<Nganh> Nganhs { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<PhieuXuat> PhieuXuats { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<TaiSan> TaiSans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Khoa>();

            modelBuilder.Entity<LoaiTaiSan>();

            modelBuilder.Entity<Nganh>();

            modelBuilder.Entity<PhieuNhap>();

            modelBuilder.Entity<PhieuXuat>();

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.tentk)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.matkhau)
                .IsUnicode(false);

            modelBuilder.Entity<TaiSan>();

            modelBuilder.Entity<TaiSan>();
        }
    }
}
