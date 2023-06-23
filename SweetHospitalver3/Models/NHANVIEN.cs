namespace SweetHospitalver3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [Key]
        [StringLength(10)]
        public string MaNV { get; set; }

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
        public string Ha { get; set; }

        [Required]
        [StringLength(50)]
        public string TK { get; set; }

        [Required]
        [StringLength(80)]
        public string ViTri { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayBD { get; set; }

        public int Lương { get; set; }

        [Required]
        [StringLength(50)]
        public string TrangThai { get; set; }

        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
