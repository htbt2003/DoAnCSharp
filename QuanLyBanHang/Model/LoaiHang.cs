namespace QuanLyBanHang.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiHang")]
    public partial class LoaiHang
    {
        [Key]
        public int MaLoai { get; set; }

        [Required]
        [StringLength(200)]
        public string TenLoai { get; set; }

        [Required]
        [StringLength(200)]
        public string GhiChu { get; set; }
    }
}
