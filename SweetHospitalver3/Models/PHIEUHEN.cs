namespace SweetHospitalver3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUHEN")]
    public partial class PHIEUHEN
    {
        [Key]
        [StringLength(10)]
        public string MaPhieu { get; set; }

        [Required]
        [StringLength(10)]
        public string MaHS { get; set; }

        [Required]
        [StringLength(50)]
        public string MaDK { get; set; }

        [Required]
        [StringLength(50)]
        public string TrangThai { get; set; }

        public virtual HOSO HOSO { get; set; }

        public virtual THOIGIANBS THOIGIANBS { get; set; }
    }
}
