using QuanLyVatTu.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyVatTu.DAO
{
    internal class TaiKhoanDAO
    {
        DBContext dBContext;

        public TaiKhoanDAO()
        {
            dBContext = new DBContext();
        }

        public List<TaiKhoan> DsTaiKhoan(string tuKhoa)
        {
            List<TaiKhoan> taiKhoans = dBContext.TaiKhoans.Where(x =>
                x.tentk.Contains(tuKhoa) || x.diachi.Contains(tuKhoa) || x.sdt.Contains(tuKhoa) ||
                x.loaitaikhoan.Contains(tuKhoa)).ToList();
            return taiKhoans;
        }

        public TaiKhoan DangNhap(string tenTk, string matKhau)
        {
            TaiKhoan taiKhoan = dBContext.TaiKhoans.FirstOrDefault(x => x.tentk == tenTk && x.matkhau == matKhau);
            return taiKhoan;
        }

        public int ThemTaiKhoan(TaiKhoan taiKhoan)
        {
            try
            {
                dBContext.TaiKhoans.Add(taiKhoan);
                int result = dBContext.SaveChanges();
                return result;
            }
            catch
            {
            }
            return 0;

        }

        public int DeleteTaiKhoan(string tenTk)
        {
            try
            {
                TaiKhoan taiKhoan = dBContext.TaiKhoans.FirstOrDefault(x => x.tentk == tenTk);
                if (taiKhoan != null) dBContext.TaiKhoans.Remove(taiKhoan);
                int result = dBContext.SaveChanges();
                return result;
            }
            catch
            {
            }
            return 0;

        }

        public int UpdateTaiKhoan(TaiKhoan taiKhoan)
        {
            try
            {
                dBContext.TaiKhoans.AddOrUpdate(taiKhoan);
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