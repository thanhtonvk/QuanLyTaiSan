using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using QuanLyVatTu.Models;

namespace QuanLyVatTu.DAO
{
    public class HinhThucThanhToanDAO
    {
        DBContext dBContext;

        public HinhThucThanhToanDAO()
        {
            dBContext = new DBContext();
        }

        public List<HinhThucThanhToan> DsHinhThucThanhToan(string tuHinhThucThanhToan)
        {
            List<HinhThucThanhToan> HinhThucThanhToans = dBContext.HinhThucThanhToans.Where(x =>
                x.tenht.Contains(tuHinhThucThanhToan) || x.maht.ToString().Contains(tuHinhThucThanhToan)).ToList();
            return HinhThucThanhToans;
        }

        public int ThemHinhThucThanhToan(HinhThucThanhToan HinhThucThanhToan)
        {
            try
            {
                dBContext.HinhThucThanhToans.Add(HinhThucThanhToan);
                int result = dBContext.SaveChanges();
                return result;
            }
            catch
            {
            }
            return 0;
        }

        public int DeleteHinhThucThanhToan(int maHinhThucThanhToan)
        {
            try
            {
                HinhThucThanhToan HinhThucThanhToan = dBContext.HinhThucThanhToans.FirstOrDefault(x => x.maht == maHinhThucThanhToan);
                if (HinhThucThanhToan != null) dBContext.HinhThucThanhToans.Remove(HinhThucThanhToan);
                int result = dBContext.SaveChanges();
                return result;
            }
            catch
            {
            }
            return 0;

        }

        public int UpdateHinhThucThanhToan(HinhThucThanhToan HinhThucThanhToan)
        {
            try
            {
                dBContext.HinhThucThanhToans.AddOrUpdate(HinhThucThanhToan);
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