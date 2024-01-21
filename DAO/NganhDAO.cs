using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using QuanLyVatTu.Models;

namespace QuanLyVatTu.DAO
{
    public class NganhDAO
    {
        DBContext dBContext;

        public NganhDAO()
        {
            dBContext = new DBContext();
        }

        public List<Nganh> DsNganh(string tuNganh)
        {
            List<Nganh> Nganhs = dBContext.Nganhs.Where(x =>
                x.tennganh.Contains(tuNganh) || x.ghichu.Contains(tuNganh)).ToList();
            return Nganhs;
        }

        public int ThemNganh(Nganh Nganh)
        {
            dBContext.Nganhs.Add(Nganh);
            int result = dBContext.SaveChanges();
            return result;
        }

        public int DeleteNganh(int maNganh)
        {
            Nganh Nganh = dBContext.Nganhs.FirstOrDefault(x => x.manganh == maNganh);
            if (Nganh != null) dBContext.Nganhs.Remove(Nganh);
            int result = dBContext.SaveChanges();
            return result;
        }

        public int UpdateNganh(Nganh Nganh)
        {
            dBContext.Nganhs.AddOrUpdate(Nganh);
            int result = dBContext.SaveChanges();
            return result;
        }
    }
}