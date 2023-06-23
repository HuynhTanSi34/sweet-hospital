namespace SweetHospitalver3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DSKHOA")]
    public partial class DSKHOA
    {
        [Required]
        [StringLength(20)]
        public string MaKhoa { get; set; }

        [Key]
        [StringLength(80)]
        public string Khoa { get; set; }
    }
}
