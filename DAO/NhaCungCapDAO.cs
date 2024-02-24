using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using QuanLyVatTu.Models;

namespace QuanLyVatTu.DAO
{
    public class NhaCungCapDAO
    {
        DBContext dBContext;

        public NhaCungCapDAO()
        {
            dBContext = new DBContext();
        }

        public List<NhaCungCap> DsNhaCungCap(string tuNhaCungCap)
        {
            List<NhaCungCap> NhaCungCaps = dBContext.NhaCungCaps.Where(x =>
                x.tenncc.Contains(tuNhaCungCap) || x.mancc.ToString().Contains(tuNhaCungCap)).ToList();
            return NhaCungCaps;
        }

        public int ThemNhaCungCap(NhaCungCap NhaCungCap)
        {
            try
            {
                dBContext.NhaCungCaps.Add(NhaCungCap);
                int result = dBContext.SaveChanges();
                return result;
            }
            catch
            {
            }
            return 0;

        }

        public int DeleteNhaCungCap(int maNhaCungCap)
        {
            try
            {
                NhaCungCap NhaCungCap = dBContext.NhaCungCaps.FirstOrDefault(x => x.mancc == maNhaCungCap);
                if (NhaCungCap != null) dBContext.NhaCungCaps.Remove(NhaCungCap);
                int result = dBContext.SaveChanges();
                return result;
            }
            catch
            {
            }
            return 0;

        }

        public int UpdateNhaCungCap(NhaCungCap NhaCungCap)
        {
            try
            {
                dBContext.NhaCungCaps.AddOrUpdate(NhaCungCap);
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