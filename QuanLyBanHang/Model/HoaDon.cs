namespace QuanLyBanHang.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        [StringLength(10)]
        public string MaHD { get; set; }

        public DateTime NgayBan { get; set; }

        public DateTime? NgayGiao { get; set; }

        public int MaNV { get; set; }

        public int? MaKH { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; }

        [StringLength(11)]
        public string DienThoai { get; set; }

        [StringLength(200)]
        public string Email { get; set; }
        public double Tong { get; set; }
    }
}
