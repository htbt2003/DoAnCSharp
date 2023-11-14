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
    public partial class frmThemHoaDon : Form
    {
        QLBanHangDBContext db = new QLBanHangDBContext();
        KhachHangDAO khDAO = new KhachHangDAO();
        SanPhamDAO spDAO = new SanPhamDAO();
        HoaDonDAO hdDAO = new HoaDonDAO();
        CTHoaDonDAO cthdDAO = new CTHoaDonDAO();
        HoaDon hd = new HoaDon();
        DateTime dt = DateTime.Now;
        
        public frmThemHoaDon(NhanVien nv, string mahd)
        {
            InitializeComponent();
            txtMaHD.Text = mahd;
            txtNV.Text = nv.TenNV.ToString();
            txtNgayBan.Text = dt.ToString();
            setValueForm(false);
        }
        public frmThemHoaDon(HoaDon hd, NhanVien nv)
        {
            InitializeComponent();
            setClick(hd);
            txtNV.Text = nv.TenNV.ToString();
            loadSP();
        }
        private void setClick(HoaDon hd)
        {
            btnLuu.Enabled = false;
            txtMaHD.Enabled = false;
            txtNgayBan.Enabled = false;
            txtNV.Enabled = false;

            txtMaHD.Text = hd.MaHD.ToString();
            txtNgayBan.Text = hd.NgayBan.ToString();
            dtpNgayGiao.Text = hd.NgayGiao.ToString();
            cbKhachHang.Text = hd.MaKH.ToString();
            txtEmail.Text = hd.Email;
            txtDiaChi.Text = hd.DiaChi;
            mtxtSDT.Text = hd.DienThoai;
        }
        private double TongHD()
        {
            double tong = 0;
            List<CTHoaDon> list = cthdDAO.getList(txtMaHD.Text);
            foreach(CTHoaDon sp in list)
            {
                tong += Convert.ToDouble(sp.SoLuong) * sp.DonGia;
            }
            return tong;
        }
        private void frmThemHoaDon_Load(object sender, EventArgs e)
        {
            LoadKH();
            LoadSP();
        }
        private void LoadKH()
        {
            cbKhachHang.DataSource = khDAO.getList();
            cbKhachHang.ValueMember = "MaKH";
            cbKhachHang.DisplayMember = "TenKH";
        }
        private void LoadSP()
        {
            cbMaSP.DataSource = spDAO.getList();
            cbMaSP.ValueMember = "MaSP";
            cbMaSP.DisplayMember = "TenSP";
        }
        private void setValueForm(bool isLuu)
        {
            txtMaHD.Enabled = false;
            txtNgayBan.Enabled = false;
            txtNV.Enabled = false;
            if(isLuu)
            {
                gbTTDH.Enabled = false;
                gbCTDH.Enabled = true;
                btnXuatHD.Enabled = true;
            }
            else
            {
                gbCTDH.Enabled = false;
                btnXuatHD.Enabled = false;
            }    
        }
        private void msgBox(string message, bool isError = false)
        {
            if (isError)
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbKhachHang_Click(object sender, EventArgs e)
        {
            KhachHang kh = khDAO.getRow(Convert.ToInt16(cbKhachHang.SelectedValue));
            txtEmail.Text = kh.Email;
            txtDiaChi.Text = kh.DiaChi;
            mtxtSDT.Text = kh.DienThoai;
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
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (isValidEmail(txtEmail.Text) == false)
            {
                msgBox("Email không hợp lệ", true);
            }
            else if (txtDiaChi.Text.Length < 2)
            {
                msgBox("Địa chỉ không hợp lệ", true);
            }
            else if (mtxtSDT.Text.Length < 10)
            {
                msgBox("Số điện thoại không hợp lệ", true);
            }
            else
            {
                HoaDon hd = new HoaDon();
                hd.MaHD = txtMaHD.Text;
                hd.NgayBan = Convert.ToDateTime(txtNgayBan.Text);
                hd.NgayGiao = Convert.ToDateTime(dtpNgayGiao.Text);
                hd.MaNV = frmMain.nhanvien.MaNV;
                hd.MaKH = Convert.ToInt16(cbKhachHang.SelectedValue);
                hd.Email = txtEmail.Text;
                hd.DiaChi = txtDiaChi.Text;
                hd.DienThoai = mtxtSDT.Text;
                if (hdDAO.Insert(hd))
                {
                    setValueForm(true);
                }
            }
        }
        private void loadSP()
        {
            dgvDanhSach.DataSource = db.CTHoaDons.Where(p => p.MaHD == txtMaHD.Text).Select(p => new { p.MaCTHD, p.MaSP, p.TenSP, p.SoLuong, p.DonGia, p.Hinh }).ToList();
            setValue(false, true);
            loadGridView();
            lblTong.Text = Convert.ToString(TongHD());
        }
        private void loadGridView()
        {
            dgvDanhSach.Columns[0].HeaderText = "STT";
            dgvDanhSach.Columns[1].HeaderText = "Mã SP";
            dgvDanhSach.Columns[2].HeaderText = "Tên sản phẩm";
            dgvDanhSach.Columns[3].HeaderText = "Số lượng";
            dgvDanhSach.Columns[4].HeaderText = "Đơn giá";
            dgvDanhSach.Columns[5].HeaderText = "Hình";

            dgvDanhSach.Columns[0].DividerWidth = 1;
            dgvDanhSach.Columns[1].DividerWidth = 1;
            dgvDanhSach.Columns[2].DividerWidth = 2;
            dgvDanhSach.Columns[3].DividerWidth = 1;
            dgvDanhSach.Columns[4].DividerWidth = 2;
            dgvDanhSach.Columns[5].DividerWidth = 2;
        }
        private void cbMaSP_Click(object sender, EventArgs e)
        {
            SanPham sp = spDAO.getRow(Convert.ToInt16(cbMaSP.SelectedValue));
            txtTenSP.Text = sp.TenSP;
            txtDonGia.Text = Convert.ToString(sp.GiaBan);
            txtHinh.Text = sp.Hinh;
            string Directory = System.Windows.Forms.Application.StartupPath;
            pcbSanPham.Image = cloneImage(Directory + @"\Images\" + sp.Hinh);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            setValue(true, false);
        }
        private void setValue(bool param, bool isLoad = false)
        {

            txtMaCTHD.Text = null;
            txtMaCTHD.Enabled = !param;
            txtHinh.Enabled = false;
            txtTenSP.Text = null;
            txtSoLuong.Text = null;
            txtHinh.Text = null;
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

        private void btnLuuCT_Click(object sender, EventArgs e)
        {
            double giaban;
            int sl;
            if (!double.TryParse(txtDonGia.Text.Trim(), out giaban))
            {
                msgBox("Đơn giá không hợp lệ", true);
            }
            else if (!int.TryParse(txtSoLuong.Text.Trim(), out sl))
            {
                msgBox("Số lượng không hợp lệ", true);
            }
            else
            {
                CTHoaDon cthd = new CTHoaDon();
                cthd.MaHD = txtMaHD.Text;
                cthd.MaSP = Convert.ToInt16(cbMaSP.SelectedValue);
                cthd.TenSP = txtTenSP.Text;
                cthd.DonGia = Convert.ToDouble(txtDonGia.Text);
                cthd.Hinh = txtHinh.Text;
                cthd.SoLuong = Convert.ToInt16(txtSoLuong.Text);
                if(cthdDAO.CheckExit(cthd, txtMaHD.Text.ToString()))
                {
                    if (cthdDAO.Insert(cthd))
                    {
                        loadSP();
                        msgBox("Thêm thành công");
                    }
                    else
                    {
                        msgBox("Thêm thất bại", true);
                    }
                }
                else
                    msgBox("Sản phẩm đã tồn tại", true);

            }
            pcbSanPham.Image = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn sửa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // check number 
                double giaban;
                int sl;
                if (!double.TryParse(txtDonGia.Text.Trim(), out giaban))
                {
                    msgBox("Đơn giá không hợp lệ", true);
                }
                else if (!int.TryParse(txtSoLuong.Text.Trim(), out sl))
                {
                    msgBox("Số lượng không hợp lệ", true);
                }
                else
                {
                    int masp = Convert.ToInt16(txtMaCTHD.Text);
                    CTHoaDon cthd = cthdDAO.getRow(masp);
                    cthd.MaHD = txtMaHD.Text;
                    cthd.MaSP = Convert.ToInt16(cbMaSP.SelectedValue);
                    cthd.TenSP = txtTenSP.Text;
                    cthd.DonGia = Convert.ToDouble(txtDonGia.Text);
                    cthd.Hinh = txtHinh.Text;
                    cthd.SoLuong = Convert.ToInt16(txtSoLuong.Text);
                    if (cthdDAO.Update(cthd))
                    {
                        loadSP();
                        msgBox("Sửa thành công!");
                    }
                    else
                    {
                        msgBox("Sửa  thất bại", true);
                    }
                }
                pcbSanPham.Image = null;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int masp = Convert.ToInt16(txtMaCTHD.Text);
                CTHoaDon sp = cthdDAO.getRow(masp);
                if (cthdDAO.Delete(sp))
                {
                    loadSP();
                    msgBox("Xóa thành công");
                }
                else
                    msgBox("Xóa không thành công!");
            }
        }
        private System.Drawing.Image cloneImage(string path)
        {
            System.Drawing.Image result;
            using (Bitmap original = new Bitmap(path))
            {
                result = (Bitmap)original.Clone();

            };

            return result;
        }
        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhSach.Rows.Count)
            {
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                string Directory = System.Windows.Forms.Application.StartupPath;
                txtMaCTHD.ReadOnly = true;

                dgvDanhSach.Columns[0].HeaderText = "STT";
                dgvDanhSach.Columns[1].HeaderText = "Mã SP";
                dgvDanhSach.Columns[2].HeaderText = "Tên sản phẩm";
                dgvDanhSach.Columns[3].HeaderText = "Số lượng";
                dgvDanhSach.Columns[4].HeaderText = "Đơn giá";
                dgvDanhSach.Columns[5].HeaderText = "Hình";

                txtMaCTHD.Text = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                cbMaSP.Text = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                txtTenSP.Text = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                txtSoLuong.Text = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                txtDonGia.Text = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                string checkFileName = dgvDanhSach.CurrentRow.Cells[5].Value.ToString();
                txtHinh.Text = checkFileName;
                pcbSanPham.Image = cloneImage(Directory + @"\Images\" + checkFileName);
            }
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            string masp = txtMaHD.Text;
            HoaDon hd = hdDAO.getRow(masp);
            hd.NgayBan = dt;
            hd.NgayBan = Convert.ToDateTime(dtpNgayGiao.Text);
            hd.MaNV = frmMain.nhanvien.MaNV;
            hd.MaKH = Convert.ToInt16(cbKhachHang.SelectedValue);
            hd.Email = txtEmail.Text;
            hd.DiaChi = txtDiaChi.Text;
            hd.DienThoai = mtxtSDT.Text;
            hd.Tong = Convert.ToDouble(lblTong.Text);
            if (hdDAO.Update(hd))
            {
                //loadSP();
                //msgBox("Sửa thành công!");
                Close();
            }
            else
            {
                msgBox("Sửa  thất bại", true);
            }
        }

        private void btnHuyDH_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa đơn hàng này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string masp = txtMaHD.Text;
                HoaDon hd = hdDAO.getRow(masp);
                List<CTHoaDon> list = cthdDAO.getList(txtMaHD.Text);
                foreach (CTHoaDon sp in list)
                {
                    cthdDAO.Delete(sp);
                }
                if (hdDAO.Delete(hd))
                {
                    //msgBox("Xóa thành công
                    this.Close();
                }
                else
                    msgBox("Xóa không thành công!");
            }
        }
    }
}
