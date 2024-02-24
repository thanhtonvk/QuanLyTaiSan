namespace QuanLyVatTu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiTaiSan")]
    public partial class LoaiTaiSan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiTaiSan()
        {
        }

        [Key]
        [DisplayName("Mã loại")]
        public int maloai { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tên loại")]
        public string tenloai { get; set; }
        [DisplayName("Ghi chú")]

        public string ghichu { get; set; }
    }
}
