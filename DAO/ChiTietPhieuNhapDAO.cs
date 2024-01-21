using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using QuanLyVatTu.Models;

namespace QuanLyVatTu.DAO
{
    public class ChiTietPhieuNhapDAO
    {
        private DBContext dbContext;
        public ChiTietPhieuNhapDAO()
        {
            dbContext = new DBContext();
        }

        public List<ChiTietPhieuNhap> DSCTPhieuNhap(int maPhieuNhap)
        {
            List<ChiTietPhieuNhap> chiTietPhieuNhaps =
                dbContext.ChiTietPhieuNhaps.Where(x => x.maphieunhap == maPhieuNhap).ToList();
            return chiTietPhieuNhaps;
        }
        public int ThemPhieuNhap(ChiTietPhieuNhap chiTietPhieuNhap)
        {
            dbContext.ChiTietPhieuNhaps.Add(chiTietPhieuNhap);
            int result = dbContext.SaveChanges();
            return result;
        }
        public int CapNhatPhieuNhap(ChiTietPhieuNhap chiTietPhieuNhap)
        {
            dbContext.ChiTietPhieuNhaps.AddOrUpdate(chiTietPhieuNhap);
            int result = dbContext.SaveChanges();
            return result;
        }
        public int XoaPhieuNhap(int maCTPN)
        {
            ChiTietPhieuNhap chiTietPhieuNhap = dbContext.ChiTietPhieuNhaps.FirstOrDefault(x=>x.mactpn==maCTPN);
            dbContext.ChiTietPhieuNhaps.Remove(chiTietPhieuNhap);
            int result = dbContext.SaveChanges();
            return result;
        }
    }
}