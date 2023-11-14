namespace QuanLyBanHang.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        public int MaSP { get; set; }

        public int MaLoai { get; set; }

        [Required]
        [StringLength(200)]
        public string TenSP { get; set; }

        public int SoLuong { get; set; }

        public double GiaNhap { get; set; }

        public double GiaBan { get; set; }

        [Required]
        [StringLength(200)]
        public string Hinh { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }
    }
}
