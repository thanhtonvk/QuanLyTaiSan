using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using QuanLyVatTu.Models;

namespace QuanLyVatTu.DAO
{
    public class KhoaDAO
    {
        DBContext dBContext;

        public KhoaDAO()
        {
            dBContext = new DBContext();
        }

        public List<Khoa> DsKhoa(string tuKhoa)
        {
            List<Khoa> Khoas = dBContext.Khoas.Where(x =>
                x.tenkhoa.Contains(tuKhoa) || x.diachi.Contains(tuKhoa) || x.sdt.Contains(tuKhoa) ||
                x.diachi.Contains(tuKhoa)).ToList();
            return Khoas;
        }

        public int ThemKhoa(Khoa Khoa)
        {
            dBContext.Khoas.Add(Khoa);
            int result = dBContext.SaveChanges();
            return result;
        }

        public int DeleteKhoa(int maKhoa)
        {
            Khoa Khoa = dBContext.Khoas.FirstOrDefault(x => x.makhoa == maKhoa);
            if (Khoa != null) dBContext.Khoas.Remove(Khoa);
            int result = dBContext.SaveChanges();
            return result;
        }

        public int UpdateKhoa(Khoa Khoa)
        {
            dBContext.Khoas.AddOrUpdate(Khoa);
            int result = dBContext.SaveChanges();
            return result;
        }
    }
}