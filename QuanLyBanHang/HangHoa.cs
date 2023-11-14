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
    public partial class ucHangHoa : UserControl
    {
        QLBanHangDBContext db = new QLBanHangDBContext();
        SanPhamDAO spDAO = new SanPhamDAO();
        //LoaiHangDAO lDAO = new LoaiHangDAO();
        private string fileAddress = null;
        private string fileName = null;
        private string fileSavePath = null;
        private string checkFileName = null;
        public ucHangHoa()
        {
            InitializeComponent();
        }

        private void btnMoHinh_Click(object sender, EventArgs e)
        {
            moHinh();
        }
        private void pcbSanPham_Click(object sender, EventArgs e)
        {
            moHinh();
        }

        private void HangHoa_Load(object sender, EventArgs e)
        {
            loadSP();
            setValue(false, true);
            loadLoaiSP();
        }
        private void loadLoaiSP()
        {
            cbLoai.DataSource = db.LoaiHangs.ToList();
            cbLoai.ValueMember = "MaLoai";
            cbLoai.DisplayMember = "TenLoai";
        }
        private void loadSP()
        {
            dgvDanhSach.DataSource = db.SanPhams.ToList();
            setValue(false, true);
            loadGridView();
        }
        private void loadGridView()
        {
            dgvDanhSach.Columns[0].HeaderText = "Mã SP";
            dgvDanhSach.Columns[1].HeaderText = "Mã loại";
            dgvDanhSach.Columns[2].HeaderText = "Tên sản phẩm";
            dgvDanhSach.Columns[3].HeaderText = "Số lượng";
            dgvDanhSach.Columns[4].HeaderText = "Giá nhập";
            dgvDanhSach.Columns[5].HeaderText = "Giá bán";
            dgvDanhSach.Columns[6].HeaderText = "Hình";
            dgvDanhSach.Columns[7].HeaderText = "Ghi chú";
           
            dgvDanhSach.Columns[0].DividerWidth = 1;
            dgvDanhSach.Columns[1].DividerWidth = 1;
            dgvDanhSach.Columns[2].DividerWidth = 2;
            dgvDanhSach.Columns[3].DividerWidth = 1;
            dgvDanhSach.Columns[4].DividerWidth = 2;
            dgvDanhSach.Columns[5].DividerWidth = 2;
            dgvDanhSach.Columns[6].DividerWidth = 2;
            dgvDanhSach.Columns[7].DividerWidth = 2;
        }
        private void btnTimKiemHH_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                if (spDAO.TimKiem(txtTimKiem.Text) != null)
                {
                    dgvDanhSach.DataSource = spDAO.TimKiem(txtTimKiem.Text);
                }
                else
                    msgBox("Không tìm thấy kết quả!");
            }
            else
                msgBox("Vui lòng nhập tên sản phẩm cần tìm!");
        }
        private void setValue(bool param, bool isLoad = false)
        {

            txtMaHang.Text = null;
            txtMaHang.Enabled = !param;

            txtTenHang.Text = null;
            txtSoLuong.Text = null;
            txtDonGiaBan.Text = null;
            txtDonGiaNhap.Text = null;
            txtHinh.Text = null;
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
        private Image cloneImage(string path)
        {
            Image result;
            using (Bitmap original = new Bitmap(path))
            {
                result = (Bitmap)original.Clone();

            };

            return result;
        }
        private void moHinh()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|PNG(*.png)|*.png|GIF(.gif)|*.gif|All files(*.*)|*.*";
            open.FilterIndex = 2;
            open.Title = "Chọn ảnh cho sản phẩm";
            if (open.ShowDialog() == DialogResult.OK)
            {
                fileAddress = open.FileName;
                //pcbSanPham.Image = new Bitmap(fileAddress);
                pcbSanPham.Image = cloneImage(fileAddress);
                fileName = Path.GetFileName(fileAddress);
                string saveDirectory = Application.StartupPath;
                fileSavePath = saveDirectory + @"\Images\" + fileName;
                txtHinh.Text = fileName;
            }
        }
        private void dgvHangHoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhSach.Rows.Count)
            {
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                string Directory = Application.StartupPath;

                txtMaHang.ReadOnly = true;

                txtMaHang.Text = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                cbMaLoai.Text = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                txtTenHang.Text = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                txtSoLuong.Text = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                txtDonGiaNhap.Text = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                txtDonGiaBan.Text = dgvDanhSach.CurrentRow.Cells[5].Value.ToString();
                checkFileName = dgvDanhSach.CurrentRow.Cells[6].Value.ToString();
                txtHinh.Text = checkFileName;
                pcbSanPham.Image = cloneImage(Directory + @"\Images\" + checkFileName);
                txtGhiChu.Text = dgvDanhSach.CurrentRow.Cells[7].Value.ToString();
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // check number 
            int sl;
            double giaban, gianhap;
            if (txtTenHang.Text.Length < 2)
            {
                msgBox("Tên sản phẩm không hợp lệ", true);
            }
            else if (!int.TryParse(txtSoLuong.Text.Trim(), out sl))
            {
                msgBox("Số lượng không hợp lệ", true);
            }
            else if(!double.TryParse(txtDonGiaBan.Text.Trim(), out giaban))
            {
                msgBox("Giá bán không hợp lệ", true);
            }
            else if(!double.TryParse(txtDonGiaNhap.Text.Trim(), out gianhap))
            {
                msgBox("Giá nhập không hợp lệ", true);
            }
            else if(txtHinh.Text.Length == 0)
            {
                msgBox("Bạn chưa chọn hình", true);
            }
            else
            {
                SanPham sp = new SanPham();
                sp.MaLoai = Convert.ToInt16(cbLoai.SelectedValue);
                sp.TenSP = txtTenHang.Text;
                sp.SoLuong = sl;
                sp.GiaBan = giaban;
                sp.GiaNhap = gianhap;
                sp.GhiChu = txtGhiChu.Text;
                if (fileName == null)
                {
                    sp.Hinh = txtHinh.Text;
                }
                else
                {
                    sp.Hinh = fileName;
                }
                //spDAO.Insert(sp);
                //loadSP();
                if (spDAO.Insert(sp))
                {
                    loadSP();
                    if (fileName != null)
                    {
                        if (File.Exists(fileSavePath))
                        {
                            pcbSanPham.Image.Dispose();
                            pcbSanPham.Image = null;
                            File.Delete(fileSavePath);
                        }
                        File.Copy(fileAddress, fileSavePath);
                    }

                    msgBox("Thêm thành công");
                }
                else
                {
                    msgBox("Thêm thất bại", true);
                }
                pcbSanPham.Image = null;
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

                if (txtTenHang.Text.Length < 2)
                {
                    msgBox("Tên sản phẩm không hợp lệ", true);
                }
                else if (!int.TryParse(txtSoLuong.Text.Trim(), out sl))
                {
                    msgBox("Số lượng không hợp lệ", true);
                }
                else if (!double.TryParse(txtDonGiaBan.Text.Trim(), out giaban))
                {
                    msgBox("Giá bán không hợp lệ", true);
                }
                else if (!double.TryParse(txtDonGiaNhap.Text.Trim(), out gianhap))
                {
                    msgBox("Giá nhập không hợp lệ", true);
                }
                else if (txtTenHang.Text.Length == 0)
                {
                    msgBox("Bạn chưa chọn hình", true);
                }
                else
                {
                    int masp = Convert.ToInt16(txtMaHang.Text);
                    SanPham sp = spDAO.getRow(masp);
                    sp.MaLoai = Convert.ToInt16(cbLoai.SelectedValue);
                    sp.TenSP = txtTenHang.Text;
                    sp.SoLuong = sl;
                    sp.GiaBan = giaban;
                    sp.GiaNhap = gianhap;
                    sp.GhiChu = txtGhiChu.Text;
                    if (fileName == null)
                    {
                        sp.Hinh = txtHinh.Text;
                    }
                    else
                    {
                        sp.Hinh = fileName;
                    }
                    if (spDAO.Update(sp))
                    {
                        loadSP();
                        if (fileName != null)
                        {
                            if (File.Exists(fileSavePath))
                            {
                                pcbSanPham.Image.Dispose();
                                pcbSanPham.Image = null;
                                File.Delete(fileSavePath);
                            }
                            File.Copy(fileAddress, fileSavePath);
                        }
                        msgBox("Sửa thành công!");
                    }
                    else
                    {
                        msgBox("Sửa  thất bại", true);
                    }
                }
                //pcbSanPham.Image.Dispose();
                pcbSanPham.Image = null;
            }
        }
        private void btnShowAll_Click(object sender, EventArgs e)
        {
            loadSP();
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            setValue(false, true);
            //pcbSanPham.Image.Dispose();
            pcbSanPham.Image = null;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int masp = Convert.ToInt16(txtMaHang.Text);
                SanPham sp = spDAO.getRow(masp);
                if (spDAO.Delete(sp))
                {
                    loadSP();
                    msgBox("Xóa thành công");
                }
                else
                    msgBox("Xóa không thành công!");
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            int maloai = int.Parse(cbLoai.SelectedValue.ToString());
            if(spDAO.getList(maloai) != null)
            {
                dgvDanhSach.DataSource = spDAO.getList(maloai);
            }
            else
                msgBox("Không có sản phẩm thuộc mã loại này!");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn thoát không?", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
