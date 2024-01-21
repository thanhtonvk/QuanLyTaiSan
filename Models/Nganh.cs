namespace QuanLyVatTu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nganh")]
    public partial class Nganh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nganh()
        {
            TaiSans = new HashSet<TaiSan>();
        }

        [Key]
        public int manganh { get; set; }

        [Required]
        [StringLength(200)]
        public string tennganh { get; set; }

        [StringLength(20)]
        public string sdt { get; set; }

        public string ghichu { get; set; }

        public int makhoa { get; set; }

        public virtual Khoa Khoa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiSan> TaiSans { get; set; }
    }
}
