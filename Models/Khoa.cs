namespace QuanLyVatTu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Khoa")]
    public partial class Khoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Khoa()
        {
            Nganhs = new HashSet<Nganh>();
        }

        [Key]
        [DisplayName("Mã khoa")]
        public int makhoa { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Tên khoa")]
        public string tenkhoa { get; set; }

        [StringLength(200)]
        [DisplayName("Địa chỉ")]
        public string diachi { get; set; }

        [StringLength(20)]
        [DisplayName("SĐT")]
        public string sdt { get; set; }
        [DisplayName("Ghi chú")]

        public string ghichu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [DisplayName(" ")]
        public virtual ICollection<Nganh> Nganhs { get; set; }
    }
}
