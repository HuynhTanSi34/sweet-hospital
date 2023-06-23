namespace SweetHospitalver3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class THOIGIANBS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THOIGIANBS()
        {
            PHIEUHEN = new HashSet<PHIEUHEN>();
        }

        [Key]
        [StringLength(50)]
        public string MaDK { get; set; }

        [Required]
        [StringLength(10)]
        public string MaBS { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngay { get; set; }

        public TimeSpan Gio { get; set; }

        [Required]
        [StringLength(50)]
        public string TrangThai { get; set; }

        public virtual BACSI BACSI { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUHEN> PHIEUHEN { get; set; }
    }
}
