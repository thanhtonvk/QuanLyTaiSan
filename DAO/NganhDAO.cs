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
            try
            {
                dBContext.Nganhs.Add(Nganh);
                int result = dBContext.SaveChanges();
                return result;
            }
            catch
            {
            }
            return 0;

        }

        public int DeleteNganh(int maNganh)
        {
            try
            {
                Nganh Nganh = dBContext.Nganhs.FirstOrDefault(x => x.manganh == maNganh);
                if (Nganh != null) dBContext.Nganhs.Remove(Nganh);
                int result = dBContext.SaveChanges();
                return result;
            }
            catch
            {
            }
            return 0;

        }

        public int UpdateNganh(Nganh Nganh)
        {
            try
            {
                dBContext.Nganhs.AddOrUpdate(Nganh);
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