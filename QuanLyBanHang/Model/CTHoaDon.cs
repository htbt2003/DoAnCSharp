namespace QuanLyBanHang.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHoaDon")]
    public partial class CTHoaDon
    {
        [Key]
        public int MaCTHD { get; set; }

        [StringLength(10)]
        public string MaHD { get; set; }

        public int MaSP { get; set; }

        public int? SoLuong { get; set; }

        public double DonGia { get; set; }

        [StringLength(200)]
        public string Hinh { get; set; }

        [StringLength(200)]
        public string TenSP { get; set; }
    }
}
