namespace QuanLyVatTu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HinhThucThanhToan")]
    public partial class HinhThucThanhToan
    {
        [Key]
        [DisplayName("Mã hình thức")]
        public int maht { get; set; }
        [DisplayName("Tên hình thức")]

        public string tenht { get; set; }

        public override string ToString()
        {
            return tenht;
        }
    }
}
