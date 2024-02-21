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
        public int updateSoLuongTaiSan(int maTaiSan, int soLuong)
        {
            try
            {
                TaiSan taiSan = dbContext.TaiSans.FirstOrDefault(x => x.mataisan == maTaiSan);
                taiSan.soluong += soLuong;
                if (taiSan.soluong >= 0)
                {
                    dbContext.TaiSans.AddOrUpdate(taiSan);
                    int result = dbContext.SaveChanges();
                    return result;
                }

            }
            catch
            {

            }

            return 0;

        }
        public List<ChiTietPhieuXuat> DSCTPhieuXuat(int maPhieuXuat)
        {
            List<ChiTietPhieuXuat> chiTietPhieuXuats =
                dbContext.ChiTietPhieuXuats.Where(x => x.maphieuxuat == maPhieuXuat).ToList();
            return chiTietPhieuXuats;
        }

        public int ThemPhieuXuat(ChiTietPhieuXuat chiTietPhieuXuat)
        {
            try
            {
                int rs = updateSoLuongTaiSan(chiTietPhieuXuat.mataisan, -chiTietPhieuXuat.soluong);
                if (rs > 0)
                {
                    dbContext.ChiTietPhieuXuats.Add(chiTietPhieuXuat);
                    int result = dbContext.SaveChanges();
                    return result;

                }
            }
            catch
            {
            }

            return 0;
        }

        public int CapNhatPhieuXuat(ChiTietPhieuXuat chiTietPhieuXuat)
        {
            try
            {
                int rs = updateSoLuongTaiSan(chiTietPhieuXuat.mataisan, -chiTietPhieuXuat.soluong);
                if (rs > 0)
                {
                    dbContext.ChiTietPhieuXuats.AddOrUpdate(chiTietPhieuXuat);
                    int result = dbContext.SaveChanges();
                    return result;

                }
            }
            catch
            {
            }

            return 0;
        }

        public int XoaPhieuXuat(int maCTPX)
        {
            try
            {
                ChiTietPhieuXuat chiTietPhieuXuat = dbContext.ChiTietPhieuXuats.FirstOrDefault(x => x.mactpx == maCTPX);
                dbContext.ChiTietPhieuXuats.Remove(chiTietPhieuXuat);
                int result = dbContext.SaveChanges();
                return result;
            }
            catch
            {
            }
            return 0;
        }
    }
}