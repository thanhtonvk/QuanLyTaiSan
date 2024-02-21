using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using QuanLyVatTu.Models;

namespace QuanLyVatTu.DAO
{
    public class PhieuXuatDAO
    {
        DBContext dBContext;

        public PhieuXuatDAO()
        {
            dBContext = new DBContext();
        }

        public List<PhieuXuat> DsPhieuXuat(string tuPhieuXuat)
        {
            List<PhieuXuat> PhieuXuats = dBContext.PhieuXuats.Where(x =>
                x.nguoinhap.Contains(tuPhieuXuat) || x.ghichu.Contains(tuPhieuXuat)).ToList();
            return PhieuXuats;
        }

        public int ThemPhieuXuat(PhieuXuat PhieuXuat)
        {
            try
            {
            dBContext.PhieuXuats.Add(PhieuXuat);
            int result = dBContext.SaveChanges();
            return result;
            }
            catch
            {
            }
            return 0;

        }

        public int DeletePhieuXuat(int maPhieuXuat)
        {
            try
            {
            PhieuXuat PhieuXuat = dBContext.PhieuXuats.FirstOrDefault(x => x.maphieuxuat == maPhieuXuat);
            if (PhieuXuat != null) dBContext.PhieuXuats.Remove(PhieuXuat);
            int result = dBContext.SaveChanges();
            return result;
            }
            catch
            {
            }
            return 0;

        }

        public int UpdatePhieuXuat(PhieuXuat PhieuXuat)
        {
            try
            {
            dBContext.PhieuXuats.AddOrUpdate(PhieuXuat);
            int result = dBContext.SaveChanges();
            return result;
            }
            catch
            {
            }
            return 0;

        }
    }
}