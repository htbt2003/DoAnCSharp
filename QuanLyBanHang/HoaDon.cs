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

namespace QuanLyBanHang
{
    public partial class ucHoaDon : UserControl
    {
        HoaDonDAO hdDAO = new HoaDonDAO();
        NhanVien nv = null;
        string maHD = null;
        public int GieoSo()
        {
            long ticks = DateTime.Now.Ticks;
            Random random = new Random((int)(ticks & 0xFFFFFF)); // Sử dụng các bit cuối của ticks
            return random.Next(100000, 999999); // Trả về số nguyên có 8 chữ số
        }
        public ucHoaDon(NhanVien nv)
        {
            InitializeComponent();
            this.nv = nv;
        }
        private void ucHoaDon_Load(object sender, EventArgs e)
        {
            loadHD();
        }
        private void loadHD()
        {
            dgvDanhSach.DataSource = hdDAO.getList();
            loadGridView();
        }
        private void loadGridView()
        {
            dgvDanhSach.Columns[0].HeaderText = "Mã HD";
            dgvDanhSach.Columns[1].HeaderText = "Ngày lập";
            dgvDanhSach.Columns[2].HeaderText = "Ngày giao";
            dgvDanhSach.Columns[3].HeaderText = "Mã nhân viên";
            dgvDanhSach.Columns[4].HeaderText = "Mã khách hàng";
            dgvDanhSach.Columns[5].HeaderText = "Địa chỉ";
            dgvDanhSach.Columns[6].HeaderText = "Điện thoại";
            dgvDanhSach.Columns[7].HeaderText = "Email";
            dgvDanhSach.Columns[8].HeaderText = "Tổng";

            dgvDanhSach.Columns[0].DividerWidth = 1;
            dgvDanhSach.Columns[1].DividerWidth = 3;
            dgvDanhSach.Columns[2].DividerWidth = 3;
            dgvDanhSach.Columns[3].DividerWidth = 1;
            dgvDanhSach.Columns[4].DividerWidth = 1;
            dgvDanhSach.Columns[5].DividerWidth = 2;
            dgvDanhSach.Columns[6].DividerWidth = 1;
            dgvDanhSach.Columns[7].DividerWidth = 2;
            dgvDanhSach.Columns[8].DividerWidth = 2;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string mahd = "HD" + Convert.ToString(GieoSo());
            frmThemHoaDon frmThemHoaDon = new frmThemHoaDon(frmMain.nhanvien, mahd);
            frmThemHoaDon.ShowDialog();
        }
        private void dgvDanhSach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhSach.Rows.Count)
            {
                maHD = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                HoaDon hd = hdDAO.getRow(maHD);
                frmThemHoaDon frmThemHoaDon = new frmThemHoaDon(hd, nv);
                frmThemHoaDon.ShowDialog();
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadHD();
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            HoaDon hd = hdDAO.getRow(maHD);
            frmThemHoaDon frmThemHoaDon = new frmThemHoaDon(hd, nv);
            frmThemHoaDon.ShowDialog();
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhSach.Rows.Count)
            {
                maHD = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                txtTimKiem.Text = maHD;
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                if (hdDAO.TimKiem(txtTimKiem.Text) != null)
                {
                    dgvDanhSach.DataSource = hdDAO.TimKiem(txtTimKiem.Text);
                }
                else
                    msgBox("Không tìm thấy kết quả!");
            }
            else
                msgBox("Vui lòng nhập tên sản phẩm cần tìm!");
        }
        private void msgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            loadHD();
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime batdau = Convert.ToDateTime(dtpTuNgay.Text);
            DateTime ketthuc = Convert.ToDateTime(dtpDenNgay.Text);
            if (hdDAO.Loc(batdau, ketthuc) != null)
            {
                dgvDanhSach.DataSource = hdDAO.Loc(batdau, ketthuc);
            }
            else
                msgBox("Không tìm thấy kết quả!");
        }
    }
}
