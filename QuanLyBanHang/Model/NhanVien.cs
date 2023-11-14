namespace QuanLyBanHang.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        public int MaNV { get; set; }

        [Required]
        [StringLength(200)]
        public string TenNV { get; set; }

        [Required]
        [StringLength(11)]
        public string DienThoai { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [Required]
        [StringLength(200)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(200)]
        public string Hinh { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(10)]
        public string VaiTro { get; set; }

        public int? TinhTrang { get; set; }

        [StringLength(100)]
        public string MatKhau { get; set; }
    }
}
