namespace SweetHospitalver3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KETQUA")]
    public partial class KETQUA
    {
        [Key]
        [StringLength(10)]
        public string MaPhieu { get; set; }

        [Required]
        [StringLength(10)]
        public string MaHS { get; set; }

        [Required]
        [StringLength(80)]
        public string Khoa { get; set; }

        [Column("KetQua", TypeName = "ntext")]
        public string KetQua1 { get; set; }

        [Column(TypeName = "ntext")]
        public string ChuanDoan { get; set; }

        [Column(TypeName = "ntext")]
        public string LoiKhuyen { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayKham { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTK { get; set; }

        [StringLength(50)]
        public string Ha1 { get; set; }

        [StringLength(50)]
        public string Ha2 { get; set; }

        [Required]
        [StringLength(50)]
        public string TrangThai { get; set; }

        public virtual HOSO HOSO { get; set; }
    }
}
