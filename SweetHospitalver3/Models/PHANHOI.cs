namespace SweetHospitalver3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHANHOI")]
    public partial class PHANHOI
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }
        [Required]
        public int Sdt { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string NoiDung { get; set; }

        [Column(TypeName = "ntext")]
        public string TraLoi { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }
    }
}
