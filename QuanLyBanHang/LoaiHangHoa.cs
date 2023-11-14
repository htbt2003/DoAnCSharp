using QuanLyBanHang.DAO;
using QuanLyBanHang.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class ucLoaiHangHoa : UserControl
    {
        LoaiHangDAO lDAO = new LoaiHangDAO();
        public ucLoaiHangHoa()
        {
            InitializeComponent();
        }
        private void ucLoaiHangHoa_Load(object sender, EventArgs e)
        {
            loadLoailh();
            setValue(false, true);
        }
        private void loadLoailh()
        {
            dgvDanhSach.DataSource = lDAO.getList();
            setValue(false, true);
            loadGridView();
        }
        private void loadGridView()
        {
            dgvDanhSach.Columns[0].HeaderText = "Mã loại";
            dgvDanhSach.Columns[1].HeaderText = "Tên loại";
            dgvDanhSach.Columns[2].HeaderText = "Ghi chú";

            dgvDanhSach.Columns[0].DividerWidth = 2;
            dgvDanhSach.Columns[1].DividerWidth = 2;
            dgvDanhSach.Columns[2].DividerWidth = 2;
        }
        private void btnTimKiemHH_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                if (lDAO.TimKiem(txtTimKiem.Text) != null)
                {
                    dgvDanhSach.DataSource = lDAO.TimKiem(txtTimKiem.Text);
                }
                else
                    msgBox("Không tìm thấy kết quả!");
            }
            else
                msgBox("Vui lòng nhập tên sản phẩm cần tìm!");
        }
        private void setValue(bool param, bool isLoad = false)
        {

            txtMaLoai.Text = null;
            txtMaLoai.Enabled = !param;

            txtTenLoai.Text = null;
            txtGhiChu.Text = null;
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

                txtMaLoai.ReadOnly = true;

                txtMaLoai.Text = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                txtTenLoai.Text = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                txtGhiChu.Text = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // check number 
            int sl;
            double giaban, gianhap;

            if (txtTenLoai.Text.Length < 2)
            {
                msgBox("Tên loại không hợp lệ", true);
            }
            else
            {
                LoaiHang lh = new LoaiHang();
                lh.TenLoai = txtTenLoai.Text;
                lh.GhiChu = txtGhiChu.Text;
                if (lDAO.Insert(lh))
                {
                    loadLoailh();
                    msgBox("Thêm thành công");
                }
                else
                {
                    msgBox("Thêm thất bại", true);
                }
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
                int sl;
                double giaban, gianhap;

                if (txtTenLoai.Text.Length < 2)
                {
                    msgBox("Tên loại không hợp lệ", true);
                }
                else
                {
                    int malh = Convert.ToInt16(txtMaLoai.Text);

                    LoaiHang lh = lDAO.getRow(malh);
                    lh.TenLoai = txtTenLoai.Text;
                    lh.GhiChu = txtGhiChu.Text;
                    if (lDAO.Update(lh))
                    {
                        loadLoailh();
                        msgBox("Sửa thành công!");
                    }
                    else
                    {
                        msgBox("Sửa thất bại", true);
                    }
                }
            }
        }
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            loadLoailh();
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            setValue(false, true);
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int malh = Convert.ToInt16(txtMaLoai.Text);
                LoaiHang lh = lDAO.getRow(malh);
                if (lDAO.Delete(lh))
                {
                    loadLoailh();
                    msgBox("Xóa thành công");
                }
                else
                    msgBox("Xóa không thành công!");
            }
        }

    }
}
