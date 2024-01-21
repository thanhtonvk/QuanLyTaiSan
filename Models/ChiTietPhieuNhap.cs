namespace QuanLyVatTu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietPhieuNhap")]
    public partial class ChiTietPhieuNhap
    {
        [Key]
        public int mactpn { get; set; }

        public int maphieunhap { get; set; }

        public int mataisan { get; set; }

        public int dongia { get; set; }

        public int soluong { get; set; }

        public virtual PhieuNhap PhieuNhap { get; set; }

        public virtual TaiSan TaiSan { get; set; }
    }
}
