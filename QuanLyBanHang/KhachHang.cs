using QuanLyBanHang.DAO;
using QuanLyBanHang.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class ucKhachHang : UserControl
    {
        KhachHangDAO khDAO  = new KhachHangDAO();
        public ucKhachHang()
        {
            InitializeComponent();
        }

        private void ucKhachHang_Load(object sender, EventArgs e)
        {
            loadSP();
            setValue(false, true);
        }
        private void loadSP()
        {
            dgvDanhSach.DataSource = khDAO.getList();
            setValue(false, true);
            loadGridView();
        }
        private void loadGridView()
        {
            dgvDanhSach.Columns[0].HeaderText = "Mã KH";
            dgvDanhSach.Columns[1].HeaderText = "Tên khách hàng";
            dgvDanhSach.Columns[2].HeaderText = "Số điện thoại";
            dgvDanhSach.Columns[3].HeaderText = "Email";
            dgvDanhSach.Columns[4].HeaderText = "Địa chỉ";
            dgvDanhSach.Columns[5].HeaderText = "Giới tính";

            dgvDanhSach.Columns[0].DividerWidth = 1;
            dgvDanhSach.Columns[1].DividerWidth = 3;
            dgvDanhSach.Columns[2].DividerWidth = 2;
            dgvDanhSach.Columns[3].DividerWidth = 2;
            dgvDanhSach.Columns[4].DividerWidth = 3;
            dgvDanhSach.Columns[5].DividerWidth = 1;
        }
        private void btnTimKiemHH_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                if (khDAO.TimKiem(txtTimKiem.Text) != null)
                {
                    dgvDanhSach.DataSource = khDAO.TimKiem(txtTimKiem.Text);
                }
                else
                    msgBox("Không tìm thấy kết quả!");
            }
            else
                msgBox("Vui lòng nhập tên sản phẩm cần tìm!");
        }
        private void setValue(bool param, bool isLoad = false)
        {

            txtMaKH.Text = null;
            txtMaKH.Enabled = !param;

            txtTenKH.Text = null;
            k.Text = null;
            txtEmail.Text = null;
            txtDiaChi.Text = null;
            mtxtSDT.Text = null;
            rdoNam.Enabled = param;
            rdoNu.Enabled = param;
            btnThem.Enabled = !param;
            btnLuu.Enabled = param;
            if (isLoad)
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                btnSua.Enabled = !param;
                btnXoa.Enabled = !param;
            }

        }
        private void msgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhSach.Rows.Count)
            {
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                rdoNu.Enabled = true;
                rdoNam.Enabled = true;

                txtMaKH.ReadOnly = true;

                txtMaKH.Text = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                txtTenKH.Text = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                mtxtSDT.Text = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                txtEmail.Text = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                txtDiaChi.Text = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                int tinhtrang = int.Parse(dgvDanhSach.CurrentRow.Cells[5].Value.ToString());
                if (tinhtrang == 1)
                    rdoNam.Checked = true;
                else
                    rdoNu.Checked = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // check number 
            if (txtTenKH.Text.Length < 2)
            {
                msgBox("Tên không hợp lệ", true);
            }
            else if (mtxtSDT.Text.Length < 10)
            {
                msgBox("Số điện thoại không hợp lệ", true);
            }
            else if (isValidEmail(txtEmail.Text) == false)
            {
                msgBox("Email không hợp lệ", true);
            }
            else if (txtDiaChi.Text.Length < 0)
            {
                msgBox("Địa chỉ không hợp lệ", true);
            }
            else
            {
                KhachHang kh = new KhachHang();
                kh.TenKH = txtTenKH.Text;
                kh.DienThoai = mtxtSDT.Text;
                kh.Email = txtEmail.Text;
                kh.DiaChi = txtDiaChi.Text;
                int gt = (rdoNam.Checked) ? 1 : 0;
                kh.GioiTinh = gt;
                //khDAO.Insert(kh);
                //loadSP();
                if (khDAO.Insert(kh))
                {
                    loadSP();
                    msgBox("Thêm thành công");
                }
                else
                {
                    msgBox("Thêm thất bại", true);
                }
            }
        }
        private bool isValidEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            setValue(true, false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // check number 
                if (txtTenKH.Text.Length < 2)
                {
                    msgBox("Tên không hợp lệ", true);
                }
                else if (mtxtSDT.Text.Length < 10)
                {
                    msgBox("Số điện thoại không hợp lệ", true);
                }
                else if (isValidEmail(txtEmail.Text) == false)
                {
                    msgBox("Email không hợp lệ", true);
                }
                else if (txtDiaChi.Text.Length < 0)
                {
                    msgBox("Địa chỉ không hợp lệ", true);
                }
                else
                {
                    int masp = Convert.ToInt16(txtMaKH.Text);
                    KhachHang sp = khDAO.getRow(masp);
                    sp.TenKH = txtTenKH.Text;
                    sp.DienThoai = mtxtSDT.Text;
                    sp.Email = txtEmail.Text;
                    sp.DiaChi = txtDiaChi.Text;
                    int gt = (rdoNam.Checked) ? 1 : 0;
                    sp.GioiTinh = gt;
                    if (khDAO.Update(sp))
                    {
                        loadSP();
                        msgBox("Sửa thành công!");
                    }
                    else
                    {
                        msgBox("Sửa  thất bại", true);
                    }
                }
            }
        }
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            loadSP();
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            setValue(false, true);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int masp = Convert.ToInt16(txtMaKH.Text);
                KhachHang sp = khDAO.getRow(masp);
                if (khDAO.Delete(sp))
                {
                    loadSP();
                    msgBox("Xóa thành công");
                }
                else
                    msgBox("Xóa không thành công!");
            }
        }
    }
}
