namespace QuanLyVatTu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiSan")]
    public partial class TaiSan
    {
        public TaiSan()
        {
        }

        [Key]
        [DisplayName("Mã vật tư")]
        public int mataisan { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tên vật tư")]
        public string tentaisan { get; set; }
        [DisplayName("Mã ngành")]

        public int manganh { get; set; }
        [DisplayName("Hình ảnh")]

        public string hinhanh { get; set; }
        [DisplayName("Số lượng")]

        public int? soluong { get; set; }
        [DisplayName("Đơn vị tính")]

        public string ghichu { get; set; }
        [DisplayName("Mã loại")]

        public int maloai { get; set; }

    }
}
