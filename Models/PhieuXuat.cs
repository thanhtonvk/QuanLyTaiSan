namespace QuanLyVatTu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuXuat")]
    public partial class PhieuXuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuXuat()
        {
        }

        [Key]
        [DisplayName("Mã phiếu xuất")]
        public int maphieuxuat { get; set; }
        [DisplayName("Ngày xuất")]

        public DateTime? ngayxuat { get; set; }
        [DisplayName("Đơn vị nhận")]

        [StringLength(100)]
        public string nguoinhap { get; set; }
        [DisplayName("Ghi chú")]

        public string ghichu { get; set; }
    }
}
