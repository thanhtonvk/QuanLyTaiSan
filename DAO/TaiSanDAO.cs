using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using QuanLyVatTu.Models;

namespace QuanLyVatTu.DAO
{
    public class TaiSanDAO
    {
        private DBContext dBContext;
        public TaiSanDAO()
        {
            dBContext = new DBContext();
        }

        public List<TaiSan> DsTaiSan(string tuKhoa)
        {
            List<TaiSan> TaiSans = dBContext.TaiSans.Where(x =>
                x.tentaisan.Contains(tuKhoa) || x.ghichu.Contains(tuKhoa)).ToList();
            return TaiSans;
        }

        public int ThemTaiSan(TaiSan TaiSan)
        {
            try
            {
                dBContext.TaiSans.Add(TaiSan);
                int result = dBContext.SaveChanges();
                return result;
            }
            catch
            {
            }
            return 0;

        }

        public int DeleteTaiSan(int maTaiSan)
        {
            try
            {
                TaiSan TaiSan = dBContext.TaiSans.FirstOrDefault(x => x.mataisan == maTaiSan);
                if (TaiSan != null) dBContext.TaiSans.Remove(TaiSan);
                int result = dBContext.SaveChanges();
                return result;
            }
            catch
            {
            }
            return 0;

        }

        public int UpdateTaiSan(TaiSan TaiSan)
        {
            try
            {
                dBContext.TaiSans.AddOrUpdate(TaiSan);
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