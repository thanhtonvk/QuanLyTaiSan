namespace QuanLyVatTu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietPhieuXuat")]
    public partial class ChiTietPhieuXuat
    {
        [Key]
        [DisplayName("Mã chi tiết phiếu xuất")]
        public int mactpx { get; set; }
        [DisplayName("Mã phiếu xuất")]

        public int maphieuxuat { get; set; }
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
