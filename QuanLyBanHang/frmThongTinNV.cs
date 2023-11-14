using QuanLyBanHang.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyBanHang
{
    public partial class frmThongTinNV : Form
    {
        NhanVien NV = null;
        public frmThongTinNV(NhanVien nv)
        {
            InitializeComponent();
            lblEmail.Text =  nv.Email;
            NV = nv;
        }
        private void frmThongTinNV_Load(object sender, EventArgs e)
        {
            //int vaiTro;
            int tinhTrang;
            lblmaNV.Text = NV.MaNV.ToString();
            lblTenNV.Text = NV.TenNV.ToString();
            lblDiaChi.Text = NV.DiaChi.ToString();
            //vaiTro = int.Parse(table.Rows[0][5].ToString());
            tinhTrang = int.Parse(NV.TinhTrang.ToString());
            lblEmail.Text = "HỒ SƠ NHÂN VIÊN CỦA \n" + lblEmail.Text;
            //lblVaiTro.Text = (vaiTro == 1) ? "Quản trị" : "Nhân viên";
            lblTinhTrang.Text = (tinhTrang == 1) ? "Đang hoạt động" : "Dừng hoạt động";
        }

    }
}
