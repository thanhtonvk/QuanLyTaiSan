using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using QuanLyVatTu.Models;

namespace QuanLyVatTu.DAO
{
    public class ChiTietPhieuXuatDAO
    {
        private DBContext dbContext;

        public ChiTietPhieuXuatDAO()
        {
            dbContext = new DBContext();
        }

        public List<ChiTietPhieuXuat> DSCTPhieuXuat(int maPhieuXuat)
        {
            List<ChiTietPhieuXuat> chiTietPhieuXuats =
                dbContext.ChiTietPhieuXuats.Where(x => x.maphieuxuat == maPhieuXuat).ToList();
            return chiTietPhieuXuats;
        }

        public int ThemPhieuXuat(ChiTietPhieuXuat chiTietPhieuXuat)
        {
            dbContext.ChiTietPhieuXuats.Add(chiTietPhieuXuat);
            int result = dbContext.SaveChanges();
            return result;
        }

        public int CapNhatPhieuXuat(ChiTietPhieuXuat chiTietPhieuXuat)
        {
            dbContext.ChiTietPhieuXuats.AddOrUpdate(chiTietPhieuXuat);
            int result = dbContext.SaveChanges();
            return result;
        }

        public int XoaPhieuXuat(int maCTPX)
        {
            ChiTietPhieuXuat chiTietPhieuXuat = dbContext.ChiTietPhieuXuats.FirstOrDefault(x => x.mactpx == maCTPX);
            dbContext.ChiTietPhieuXuats.Remove(chiTietPhieuXuat);
            int result = dbContext.SaveChanges();
            return result;
        }
    }
}