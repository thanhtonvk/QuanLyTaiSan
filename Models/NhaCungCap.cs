namespace QuanLyVatTu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaCungCap")]
    public partial class NhaCungCap
    {
        [Key]
        [DisplayName("Mã NCC")]
        public int mancc { get; set; }
        [DisplayName("Tên NCC")]
        public string tenncc { get; set; }
        [DisplayName("Địa chỉ")]
        public string diachi { get; set; }
        [DisplayName("SĐT")]

        public string dienthoai { get; set; }
        [DisplayName("Sô tài khoản")]

        public string sotk { get; set; }
        [DisplayName("Fax")]

        public string fax { get; set; }

        public override string ToString()
        {
            return tenncc;
        }
    }
}
