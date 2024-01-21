namespace QuanLyVatTu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        [StringLength(30)]
        public string tentk { get; set; }

        [Required]
        [StringLength(30)]
        public string matkhau { get; set; }

        [Required]
        [StringLength(100)]
        public string hoten { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [StringLength(200)]
        public string diachi { get; set; }

        [StringLength(20)]
        public string sdt { get; set; }

        [StringLength(100)]
        public string loaitaikhoan { get; set; }
    }
}
