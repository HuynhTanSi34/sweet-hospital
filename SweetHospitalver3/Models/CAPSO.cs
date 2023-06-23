namespace SweetHospitalver3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CAPSO")]
    public partial class CAPSO
    {
        [Key]
        [StringLength(50)]
        public string STT { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        public int? Sdt { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(80)]
        public string Khoa { get; set; }

        [Column(TypeName = "date")]
        public DateTime ThoiGian { get; set; }

        [Required]
        [StringLength(50)]
        public string TrangThai { get; set; }
    }
}
