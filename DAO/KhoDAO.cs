using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using QuanLyVatTu.Models;

namespace QuanLyVatTu.DAO
{
    public class KhoDAO
    {
        DBContext dBContext;

        public KhoDAO()
        {
            dBContext = new DBContext();
        }

        public List<Kho> DsKho(string tuKho)
        {
            List<Kho> Khoes = dBContext.Khoes.Where(x =>
                x.tenkho.Contains(tuKho) || x.diachi.Contains(tuKho) || x.makho.ToString().Contains(tuKho) ||
                x.diachi.Contains(tuKho)).ToList();
            return Khoes;
        }

        public int ThemKho(Kho Kho)
        {
            try
            {
                dBContext.Khoes.Add(Kho);
                int result = dBContext.SaveChanges();
                return result;
            }
            catch
            {
            }
            return 0;
        }

        public int DeleteKho(int maKho)
        {
            try
            {
                Kho Kho = dBContext.Khoes.FirstOrDefault(x => x.makho == maKho);
                if (Kho != null) dBContext.Khoes.Remove(Kho);
                int result = dBContext.SaveChanges();
                return result;
            }
            catch
            {
            }
            return 0;

        }

        public int UpdateKho(Kho Kho)
        {
            try
            {
                dBContext.Khoes.AddOrUpdate(Kho);
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