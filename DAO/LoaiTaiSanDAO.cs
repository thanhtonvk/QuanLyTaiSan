using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using QuanLyVatTu.Models;

namespace QuanLyVatTu.DAO
{
    public class LoaiTaiSanDAO
    {
        DBContext dBContext;

        public LoaiTaiSanDAO()
        {
            dBContext = new DBContext();
        }

        public List<LoaiTaiSan> DsLoaiTaiSan(string tuLoaiTaiSan)
        {
            List<LoaiTaiSan> LoaiTaiSans = dBContext.LoaiTaiSans.Where(x =>
                x.tenloai.Contains(tuLoaiTaiSan) || x.ghichu.Contains(tuLoaiTaiSan)).ToList();
            return LoaiTaiSans;
        }

        public int ThemLoaiTaiSan(LoaiTaiSan LoaiTaiSan)
        {
            try
            {
            dBContext.LoaiTaiSans.Add(LoaiTaiSan);
            int result = dBContext.SaveChanges();
            return result;
            }
            catch
            {
            }
            return 0;

        }

        public int DeleteLoaiTaiSan(int maLoaiTaiSan)
        {
            try
            {
            LoaiTaiSan LoaiTaiSan = dBContext.LoaiTaiSans.FirstOrDefault(x => x.maloai == maLoaiTaiSan);
            if (LoaiTaiSan != null) dBContext.LoaiTaiSans.Remove(LoaiTaiSan);
            int result = dBContext.SaveChanges();
            return result;
            }
            catch
            {
            }
            return 0;

        }

        public int UpdateLoaiTaiSan(LoaiTaiSan LoaiTaiSan)
        {
            try
            {
            dBContext.LoaiTaiSans.AddOrUpdate(LoaiTaiSan);
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