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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiSan()
        {
        }

        [Key]
        [DisplayName("Mã tài sản")]
        public int mataisan { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tên tài sản")]
        public string tentaisan { get; set; }
        [DisplayName("Mã ngành")]

        public int manganh { get; set; }
        [DisplayName("Hình ảnh")]

        public string hinhanh { get; set; }
        [DisplayName("Số lượng")]

        public int? soluong { get; set; }
        [DisplayName("Ghi chú")]

        public string ghichu { get; set; }
        [DisplayName("Mã loại")]

        public int maloai { get; set; }

    }
}
