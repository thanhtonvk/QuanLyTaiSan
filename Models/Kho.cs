namespace QuanLyVatTu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kho")]
    public partial class Kho
    {
        [Key]
        [DisplayName("Mã kho")]
        public int makho { get; set; }
        [DisplayName("Tên kho")]

        public string tenkho { get; set; }
        [DisplayName("Địa chỉ")]

        public string diachi { get; set; }

        public override string ToString()
        {
            return tenkho;
        }
    }
}
