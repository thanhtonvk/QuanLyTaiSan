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
            dBContext.LoaiTaiSans.Add(LoaiTaiSan);
            int result = dBContext.SaveChanges();
            return result;
        }

        public int DeleteLoaiTaiSan(int maLoaiTaiSan)
        {
            LoaiTaiSan LoaiTaiSan = dBContext.LoaiTaiSans.FirstOrDefault(x => x.maloai == maLoaiTaiSan);
            if (LoaiTaiSan != null) dBContext.LoaiTaiSans.Remove(LoaiTaiSan);
            int result = dBContext.SaveChanges();
            return result;
        }

        public int UpdateLoaiTaiSan(LoaiTaiSan LoaiTaiSan)
        {
            dBContext.LoaiTaiSans.AddOrUpdate(LoaiTaiSan);
            int result = dBContext.SaveChanges();
            return result;
        }
    }
}