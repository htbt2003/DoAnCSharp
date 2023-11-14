using QuanLyBanHang.DAO;
using QuanLyBanHang.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QuanLyBanHang
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        public static bool isSuccess = false;
        public string getEmail
        {
            get
            {
                return txtEmail.Text;
            }
        }
        public bool getSuccess
        {
            get { return isSuccess; }
        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            if (txtEmail.Text != "" && txtMatKhau.Text != "")
            {
                NhanVienDAO nvDAO = new NhanVienDAO();
                NhanVien nv = nvDAO.Login(txtEmail.Text, txtMatKhau.Text);
                if (nvDAO.Login(txtEmail.Text, txtMatKhau.Text) != null)
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    isSuccess = true;
                    Properties.Settings.Default.isSave = chkGhiNho.Checked;
                    if (chkGhiNho.Checked)
                    {
                        Properties.Settings.Default.Email = txtEmail.Text;
                        Properties.Settings.Default.Password = txtMatKhau.Text;

                    }
                    Properties.Settings.Default.Save();
                    frmMain.nhanvien = nv;
                    Close();

                }
                else
                {
                    MessageBox.Show("Sai email hoặc mật khẩu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isSuccess = false;
                    txtEmail.Text = "";
                    txtMatKhau.Text = "";
                    txtEmail.Focus();
                }
            }
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '*';
            if (Properties.Settings.Default.isSave)
            {
                txtEmail.Text = Properties.Settings.Default.Email;
                txtMatKhau.Text = Properties.Settings.Default.Password;
                chkGhiNho.Checked = true;
                btnDangNhap.Focus();
            }
        }
    }
}
