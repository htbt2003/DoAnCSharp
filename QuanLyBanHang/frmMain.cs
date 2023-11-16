using QuanLyBanHang.DAO;
using QuanLyBanHang.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLyBanHang
{
    public partial class frmMain : Form
    {
        //htbt@gmail.com
        public static NhanVien nhanvien = null;
        NhanVienDAO nvDAO = new NhanVienDAO();

        public frmMain()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            menuTaiKhoan.Cursor = Cursors.Hand;
            btnDonHang.Visible = false;
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            panelControl.Controls.Clear();
            ucNhanVien fnhanvien = new ucNhanVien();
            fnhanvien.Dock = DockStyle.Fill;
            panelControl.Controls.Add(fnhanvien);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            panelControl.Controls.Clear();
            ucKhachHang fkhachhang = new ucKhachHang();
            fkhachhang.Dock = DockStyle.Fill;
            panelControl.Controls.Add(fkhachhang);
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            panelControl.Controls.Clear();
            ucHangHoa fhang = new ucHangHoa();
            fhang.Dock = DockStyle.Fill;
            panelControl.Controls.Add(fhang);
        }


        private void btnHuongDan_Click(object sender, EventArgs e)
        {
            panelControl.Controls.Clear();
            ucHoaDon fhang = new ucHoaDon(nhanvien);
            fhang.Dock = DockStyle.Fill;
            panelControl.Controls.Add(fhang);
            //this.menuHuongDan.Show(pnMenu, new Point(206, 405));
        }

        //private void btnHuongDan_MouseHover(object sender, EventArgs e)
        //{
        //    this.menuHuongDan.Show(pnMenu, new Point(206, 405));
        //}

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            menuTaiKhoan.Show(pnMenu, new Point(206, 456));
        }

        private void btnTaiKhoan_MouseHover(object sender, EventArgs e)
        {
            menuTaiKhoan.Show(pnMenu, new Point(206, 456));
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (btnLogin.Text == "Đăng nhập")
            {
                using (frmDangNhap flogin = new frmDangNhap())
                {
                    flogin.ShowDialog();
                    if (flogin.getSuccess)
                    {
                        // đã đăng nhập thành công
                        lblEmail.Text = "Chào bạn \n" + nhanvien.TenNV;
                        //email = flogin.getEmail;
                        resetValue();
                        btnLogin.Text = "Đăng xuất";
                        btnLogin.CustomImages.Image = Properties.Resources.logout;
                    }//đăng nhập không thành công thì không làm gì
                }
            }
            else
            {
                panelControl.Controls.Clear();
                frmDangNhap.isSuccess = false;
                nhanvien = null;
                resetValue(false);
                lblEmail.Text = "Đăng nhập để sử dụng";
                btnLogin.Text = "Đăng nhập";
                btnLogin.CustomImages.Image = Properties.Resources.login_64px;
            }
        }
        public void DoiMK()
        {
            panelControl.Controls.Clear();
            frmDangNhap.isSuccess = false;
            nhanvien = null;
            resetValue(false);
            lblEmail.Text = "Đăng nhập để sử dụng";
            btnLogin.Text = "Đăng nhập";
            btnLogin.CustomImages.Image = Properties.Resources.login_64px;
        }
        private void resetValue(bool isVisible = true)
        {
            btnNhanVien.Visible = isVisible;
            btnKhachHang.Visible = isVisible;
            btnSanPham.Visible = isVisible;
            btnThongKe.Visible = isVisible;
            btnTaiKhoan.Visible = isVisible;
            btnDonHang.Visible = isVisible;
            // kiểm tra vai tro | true = quản trị , false = nhân viên thường 
            //if (!busNV.LayVaiTro(email))
            //{
            //    btnNhanVien.Visible = false;
            //    btnThongKe.Visible = false;
            //}
        }

        private void itemDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frmThongTin = new frmDoiMatKhau(nhanvien);
            frmThongTin.ShowDialog();
            //frmThongTinNV frmThongTin = new frmThongTinNV(email);
            //frmThongTin.ShowDialog();
            //using (frmDoiMatKhau fquenmk = new frmDoiMatKhau(email))
            //{
            //    fquenmk.ShowDialog();
            //    if (fquenmk.getSuccess)
            //    {
            //        resetValue(isVisible: false);
            //        btnLogin.Text = "Đăng nhập";
            //        Properties.Settings.Default.Password = "";
            //        Properties.Settings.Default.Save();
            //        btnLogin.PerformClick();
            //    }
            //}

        }

         private void btnThongKe_Click(object sender, EventArgs e)
         {
            panelControl.Controls.Clear();
            ucLoaiHangHoa fhang = new ucLoaiHangHoa();
            fhang.Dock = DockStyle.Fill;
            panelControl.Controls.Add(fhang);
        }

        private void itemThongTinNV_Click(object sender, EventArgs e)
        {
            frmThongTinNV frmThongTin = new frmThongTinNV(nhanvien);
            frmThongTin.ShowDialog();
        }

        private void itemHuongDan_Click(object sender, EventArgs e)
        {
            Process.Start("Huongdan.txt");
        }

        private void itemGioiThieu_Click(object sender, EventArgs e)
        {
            Process.Start("Gioithieu.txt");

        }
    }
}
