using System;
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
            catch (Exception e)
            {

            }
            return 0;



        }
        public int ThemPhieuNhap(ChiTietPhieuNhap chiTietPhieuNhap)
        {
            try
            {
                int rs = updateSoLuongTaiSan(chiTietPhieuNhap.mataisan, chiTietPhieuNhap.soluong);
                if (rs > 0)
                {
                    dbContext.ChiTietPhieuNhaps.Add(chiTietPhieuNhap);
                    int result = dbContext.SaveChanges();
                    return result;

                }
            }
            catch (Exception e)
            {

            }

            return 0;



        }
        public int CapNhatPhieuNhap(ChiTietPhieuNhap chiTietPhieuNhap)
        {
            try
            {
                int rs = updateSoLuongTaiSan(chiTietPhieuNhap.mataisan, chiTietPhieuNhap.soluong);
                if (rs > 0)
                {
                    dbContext.ChiTietPhieuNhaps.AddOrUpdate(chiTietPhieuNhap);
                    int result = dbContext.SaveChanges();
                    return result;

                }
            }

            catch (Exception e)
            {

            }
            return 0;
        }
        public int XoaPhieuNhap(int maCTPN)
        {
            try
            {
                ChiTietPhieuNhap chiTietPhieuNhap = dbContext.ChiTietPhieuNhaps.FirstOrDefault(x => x.mactpn == maCTPN);
                int rs = updateSoLuongTaiSan(chiTietPhieuNhap.mataisan, -chiTietPhieuNhap.soluong);
                if (rs > 0)
                {
                    dbContext.ChiTietPhieuNhaps.Remove(chiTietPhieuNhap);
                    int result = dbContext.SaveChanges();
                    return result;
                }
            }


            catch (Exception e)
            {

            }
            return 0;
        }
    }
}