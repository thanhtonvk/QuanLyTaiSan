namespace QuanLyVatTu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietPhieuNhap")]
    public partial class ChiTietPhieuNhap
    {
        [Key]
        [DisplayName("Mã chi tiết phiếu  nhập")]
        public int mactpn { get; set; }
        [DisplayName("Mã phiếu nhập")]

        public int maphieunhap { get; set; }
        [DisplayName("Mã tài sản")]

        public int mataisan { get; set; }
        [DisplayName("Đơn giá")]

        public int dongia { get; set; }
        [DisplayName("Số lượng")]

        public int soluong { get; set; }
        [DisplayName("Thành tiền")]
        public int thanhtien()
        {
            return dongia * soluong;
        }

    }
}
