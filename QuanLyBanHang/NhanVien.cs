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
    public partial class ucNhanVien : UserControl
    {
        QLBanHangDBContext db = new QLBanHangDBContext();
        NhanVienDAO nvDAO = new NhanVienDAO();
        private string fileAddress = null;
        private string fileName = null;
        private string fileSavePath = null;
        private string checkFileName = null;
        public ucNhanVien()
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

        private void ucNhanVien_Load(object sender, EventArgs e)
        {
            loadSP();
            setValue(false, true);
        }
        private void loadSP()
        {
            dgvDanhSach.DataSource = db.NhanViens.Select(p => new { p.MaNV, p.TenNV, p.DienThoai, p.Email, p.DiaChi, p.Hinh,p.TinhTrang }).ToList();
            setValue(false, true);
            loadGridView();
        }
        private void loadGridView()
        {
            dgvDanhSach.Columns[0].HeaderText = "Mã nhân viên";
            dgvDanhSach.Columns[1].HeaderText = "Tên nhân viên";
            dgvDanhSach.Columns[2].HeaderText = "Số điện thoại";
            dgvDanhSach.Columns[3].HeaderText = "Email";
            dgvDanhSach.Columns[4].HeaderText = "Địa chỉ";
            dgvDanhSach.Columns[5].HeaderText = "Hình";
            dgvDanhSach.Columns[6].HeaderText = "Tình trạng";

            dgvDanhSach.Columns[0].DividerWidth = 1;
            dgvDanhSach.Columns[1].DividerWidth = 2;
            dgvDanhSach.Columns[2].DividerWidth = 2;
            dgvDanhSach.Columns[3].DividerWidth = 2;
            dgvDanhSach.Columns[4].DividerWidth = 2;
            dgvDanhSach.Columns[5].DividerWidth = 2;
            dgvDanhSach.Columns[6].DividerWidth = 1;
        }
        private void btnTimKiemHH_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text != "")
            {
                if (nvDAO.TimKiem(txtTimKiem.Text) != null)
                {
                    dgvDanhSach.DataSource = nvDAO.TimKiem(txtTimKiem.Text);
                }
                else
                    msgBox("Không tìm thấy kết quả!");
            }
            else
                msgBox("Vui lòng nhập tên sản phẩm cần tìm!");
        }
        private void setValue(bool param, bool isLoad = false)
        {

            txtMaNV.Text = null;
            txtMaNV.Enabled = !param;

            txtTenNV.Text = null;
            mtxtSDT.Text = null;
            txtEmail.Text = null;
            txtDiaChi.Text = null;
            txtHinh.Text = null;
            rdoHoatDong.Enabled = param;
            rdoNgungHoatDong.Enabled = param;
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
            open.Title = "Chọn ảnh cho nhân viên";
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
        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhSach.Rows.Count)
            {
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                rdoNgungHoatDong.Enabled = true;
                rdoHoatDong.Enabled = true;
                string Directory = Application.StartupPath;

                txtMaNV.ReadOnly = true;
                txtMaNV.Text = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                txtTenNV.Text = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                mtxtSDT.Text = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                txtEmail.Text = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                txtDiaChi.Text = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                checkFileName = dgvDanhSach.CurrentRow.Cells[5].Value.ToString();
                txtHinh.Text = checkFileName;
                pcbSanPham.Image = cloneImage(Directory + @"\Images\" + checkFileName);
                int tinhtrang = int.Parse(dgvDanhSach.CurrentRow.Cells[6].Value.ToString());
                if (tinhtrang == 1)
                    rdoHoatDong.Checked = true;
                else
                    rdoNgungHoatDong.Checked = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // check number 
            if (txtTenNV.Text.Length < 2)
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
            else if (txtHinh.Text.Length == 0)
            {
                msgBox("Bạn chưa chọn hình", true);
            }
            else
            {
                NhanVien sp = new NhanVien();
                sp.TenNV = txtTenNV.Text;
                sp.DienThoai = mtxtSDT.Text;
                sp.Email = txtEmail.Text;
                sp.DiaChi = txtDiaChi.Text;
                sp.Hinh = fileName;
                int tinhtrang = (rdoHoatDong.Checked) ? 1 : 0;
                sp.TinhTrang = tinhtrang;
                sp.MatKhau = MaHoa.ToShA1("111");
                //nvDAO.Insert(sp);
                //loadSP();
                if (nvDAO.Insert(sp))
                {
                    loadSP();
                    if (File.Exists(fileSavePath))
                        File.Delete(fileSavePath);

                    File.Copy(fileAddress, fileSavePath);

                    msgBox("Thêm thành công");
                }
                else
                {
                    msgBox("Thêm thất bại", true);
                }
                pcbSanPham.Image = null;
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
                if (txtTenNV.Text.Length < 2)
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
                else if (txtHinh.Text.Length == 0)
                {
                    msgBox("Bạn chưa chọn hình", true);
                }
                else
                {
                    int masp = Convert.ToInt16(txtMaNV.Text);
                    NhanVien sp = nvDAO.getRow(masp);
                    sp.TenNV = txtTenNV.Text;
                    sp.DienThoai = mtxtSDT.Text;
                    sp.Email = txtEmail.Text;
                    sp.DiaChi = txtDiaChi.Text;
                    if(fileName == null)
                    {
                        sp.Hinh = txtHinh.Text;
                    }
                    else
                    {
                        sp.Hinh = fileName;
                    }
                    int tinhtrang = (rdoHoatDong.Checked) ? 1 : 0;
                    sp.TinhTrang = tinhtrang;
                    if (nvDAO.Update(sp))
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
                int masp = Convert.ToInt16(txtMaNV.Text);
                NhanVien sp = nvDAO.getRow(masp);
                if (nvDAO.Delete(sp))
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
