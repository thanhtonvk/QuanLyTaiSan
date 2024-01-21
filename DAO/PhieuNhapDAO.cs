using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using QuanLyVatTu.Models;

namespace QuanLyVatTu.DAO
{
    public class PhieuNhapDAO
    {
        DBContext dBContext;

        public PhieuNhapDAO()
        {
            dBContext = new DBContext();
        }

        public List<PhieuNhap> DsPhieuNhap(string tuPhieuNhap)
        {
            List<PhieuNhap> PhieuNhaps = dBContext.PhieuNhaps.Where(x =>
                x.nguoinhap.Contains(tuPhieuNhap) || x.ghichu.Contains(tuPhieuNhap)).ToList();
            return PhieuNhaps;
        }

        public int ThemPhieuNhap(PhieuNhap PhieuNhap)
        {
            dBContext.PhieuNhaps.Add(PhieuNhap);
            int result = dBContext.SaveChanges();
            return result;
        }

        public int DeletePhieuNhap(int maPhieuNhap)
        {
            PhieuNhap PhieuNhap = dBContext.PhieuNhaps.FirstOrDefault(x => x.maphieunhap == maPhieuNhap);
            if (PhieuNhap != null) dBContext.PhieuNhaps.Remove(PhieuNhap);
            int result = dBContext.SaveChanges();
            return result;
        }

        public int UpdatePhieuNhap(PhieuNhap PhieuNhap)
        {
            dBContext.PhieuNhaps.AddOrUpdate(PhieuNhap);
            int result = dBContext.SaveChanges();
            return result;
        }
    }
}