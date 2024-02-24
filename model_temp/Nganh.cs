namespace QuanLyVatTu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nganh")]
    public partial class Nganh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nganh()
        {
        }

        [Key]
        [DisplayName("Mã ngành")]
        public int manganh { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Tên ngành")]
        public string tennganh { get; set; }

        [StringLength(20)]
        [DisplayName("SĐT")]
        public string sdt { get; set; }
        [DisplayName("Ghi chú")]

        public string ghichu { get; set; }
        [DisplayName("Mã khoa")]

        public int makhoa { get; set; }
    }
}
