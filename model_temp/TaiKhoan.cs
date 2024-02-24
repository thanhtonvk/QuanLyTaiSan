namespace QuanLyVatTu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        [StringLength(30)]
        [DisplayName("Tên tài khoản")]
        public string tentk { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Mật khẩu")]
        public string matkhau { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Họ tên")]
        public string hoten { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Email")]
        public string email { get; set; }

        [StringLength(200)]
        [DisplayName("Địa chỉ")]
        public string diachi { get; set; }

        [StringLength(20)]
        [DisplayName("SĐT")]
        public string sdt { get; set; }
        [DisplayName("Loại tài khoản")]
        [StringLength(100)]
        public string loaitaikhoan { get; set; }
    }
}
