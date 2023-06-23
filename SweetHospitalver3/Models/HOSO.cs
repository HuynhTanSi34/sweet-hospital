namespace SweetHospitalver3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOSO")]
    public partial class HOSO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOSO()
        {
            KETQUA = new HashSet<KETQUA>();
            PHIEUHEN = new HashSet<PHIEUHEN>();
        }

        
        [StringLength(50)]
        public string TK { get; set; }

        [Key]
        [StringLength(10)]
        public string MaHS { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        public int Sdt { get; set; }

        public int CCCD { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(150)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(5)]
        public string GioiTinh { get; set; }

        [StringLength(50)]
        public string NgheNghiep { get; set; }

        [Required]
        [StringLength(20)]
        public string DanToc { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KETQUA> KETQUA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUHEN> PHIEUHEN { get; set; }
    }
}
