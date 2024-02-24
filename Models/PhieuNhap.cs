namespace QuanLyVatTu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuNhap")]
    public partial class PhieuNhap
    {

        public PhieuNhap()
        {
        }

        [Key]
        [DisplayName("Mã phiếu nhập")]
        public int maphieunhap { get; set; }
        [DisplayName("Ngày nhập")]

        public DateTime? ngaynhap { get; set; }
        [DisplayName("Người nhập")]

        [StringLength(100)]
        public string nguoinhap { get; set; }
        [DisplayName("Ghi chú")]

        public string ghichu { get; set; }
        [DisplayName("Mã kho")]
        public int makho { get; set; }
        [DisplayName("Mã NCC")]
        public int manhancc { get; set; }
        [DisplayName("Mã hình thức thanh toán")]
        public int matt { get; set; }
    }
}
