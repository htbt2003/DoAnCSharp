using QuanLyBanHang.DAO;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace QuanLyBanHang
{
    public partial class frmDoiMatKhau : Form
    {
        NhanVienDAO nvDAO = new NhanVienDAO();
        NhanVien NV = null;
        private bool isSuccess = false;

        public bool getSuccess
        {
            get { return isSuccess; }
        }
        public frmDoiMatKhau(NhanVien nv)
        {
            InitializeComponent();
            txtEmail.Text = nv.Email;
            NV = nv;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            NhanVien nv = frmMain.nhanvien;
            string mkcu = MaHoa.ToShA1(txtMatKhauCu.Text.Trim());
            if (txtMatKhauCu.Text != "")
            {
                if (txtMatKhauMoi.Text == txtMatKhauMoi2.Text)
                {
                    if (nv.MatKhau.Equals(mkcu))
                    {
                        string mkmoi = MaHoa.ToShA1(txtMatKhauMoi.Text.Trim());
                        nv.MatKhau = mkmoi;
                        nvDAO.Update(nv);
                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else MessageBox.Show("Mật khẩu mới không trùng nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else MessageBox.Show("Vui lòng nhập mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMatKhauCu.PasswordChar = '*';
            txtMatKhauMoi.PasswordChar = '*';
            txtMatKhauMoi2.PasswordChar = '*';
        }
    }
}
