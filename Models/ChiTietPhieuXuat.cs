namespace QuanLyVatTu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietPhieuXuat")]
    public partial class ChiTietPhieuXuat
    {
        [Key]
        public int mactpx { get; set; }

        public int maphieuxuat { get; set; }

        public int mataisan { get; set; }

        public int dongia { get; set; }

        public int soluong { get; set; }

        public virtual PhieuXuat PhieuXuat { get; set; }

        public virtual TaiSan TaiSan { get; set; }
    }
}
