
namespace QuanLyBanHang
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.pnMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTaiKhoan = new Guna.UI2.WinForms.Guna2GradientButton();
            this.lblEmail = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.btnLogin = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnDonHang = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnThongKe = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSanPham = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnKhachHang = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnNhanVien = new Guna.UI2.WinForms.Guna2GradientButton();
            this.lbl1 = new System.Windows.Forms.Label();
            this.pcbIcon = new System.Windows.Forms.PictureBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl2 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2DragControl3 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.panelControl = new System.Windows.Forms.Panel();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.menuTaiKhoan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemThongTinNV = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.itemDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2DragControl4 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pnMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbIcon)).BeginInit();
            this.menuTaiKhoan.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.pnMenu.Controls.Add(this.btnTaiKhoan);
            this.pnMenu.Controls.Add(this.lblEmail);
            this.pnMenu.Controls.Add(this.guna2Separator1);
            this.pnMenu.Controls.Add(this.btnLogin);
            this.pnMenu.Controls.Add(this.btnDonHang);
            this.pnMenu.Controls.Add(this.btnThongKe);
            this.pnMenu.Controls.Add(this.btnSanPham);
            this.pnMenu.Controls.Add(this.btnKhachHang);
            this.pnMenu.Controls.Add(this.btnNhanVien);
            this.pnMenu.Controls.Add(this.lbl1);
            this.pnMenu.Controls.Add(this.pcbIcon);
            this.pnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnMenu.Location = new System.Drawing.Point(0, 0);
            this.pnMenu.Margin = new System.Windows.Forms.Padding(4);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Size = new System.Drawing.Size(277, 805);
            this.pnMenu.TabIndex = 0;
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Animated = true;
            this.btnTaiKhoan.BackColor = System.Drawing.Color.Transparent;
            this.btnTaiKhoan.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTaiKhoan.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTaiKhoan.FillColor = System.Drawing.Color.Empty;
            this.btnTaiKhoan.FillColor2 = System.Drawing.Color.Empty;
            this.btnTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnTaiKhoan.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.btnTaiKhoan.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnTaiKhoan.Image = global::QuanLyBanHang.Properties.Resources.taikhoan;
            this.btnTaiKhoan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTaiKhoan.Location = new System.Drawing.Point(2, 557);
            this.btnTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(269, 55);
            this.btnTaiKhoan.TabIndex = 4;
            this.btnTaiKhoan.Text = "Tài Khoản";
            this.btnTaiKhoan.UseTransparentBackground = true;
            this.btnTaiKhoan.Visible = false;
            this.btnTaiKhoan.Click += new System.EventHandler(this.btnTaiKhoan_Click);
            this.btnTaiKhoan.MouseHover += new System.EventHandler(this.btnTaiKhoan_MouseHover);
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lblEmail.Location = new System.Drawing.Point(12, 668);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(255, 73);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Đăng nhập để sử dụng";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.FillColor = System.Drawing.Color.Gray;
            this.guna2Separator1.FillThickness = 2;
            this.guna2Separator1.Location = new System.Drawing.Point(13, 655);
            this.guna2Separator1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(252, 12);
            this.guna2Separator1.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.Animated = true;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.CheckedState.FillColor = System.Drawing.Color.Red;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogin.FillColor = System.Drawing.Color.LightSeaGreen;
            this.btnLogin.FillColor2 = System.Drawing.Color.Empty;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.btnLogin.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnLogin.Image = global::QuanLyBanHang.Properties.Resources.login_64px;
            this.btnLogin.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogin.Location = new System.Drawing.Point(7, 745);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(269, 55);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseTransparentBackground = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnDonHang
            // 
            this.btnDonHang.Animated = true;
            this.btnDonHang.BackColor = System.Drawing.Color.Transparent;
            this.btnDonHang.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnDonHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDonHang.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDonHang.FillColor = System.Drawing.Color.Empty;
            this.btnDonHang.FillColor2 = System.Drawing.Color.Empty;
            this.btnDonHang.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnDonHang.ForeColor = System.Drawing.Color.White;
            this.btnDonHang.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.btnDonHang.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnDonHang.Image = ((System.Drawing.Image)(resources.GetObject("btnDonHang.Image")));
            this.btnDonHang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDonHang.Location = new System.Drawing.Point(2, 494);
            this.btnDonHang.Margin = new System.Windows.Forms.Padding(4);
            this.btnDonHang.Name = "btnDonHang";
            this.btnDonHang.Size = new System.Drawing.Size(269, 55);
            this.btnDonHang.TabIndex = 2;
            this.btnDonHang.Text = "Đơn hàng";
            this.btnDonHang.UseTransparentBackground = true;
            this.btnDonHang.Click += new System.EventHandler(this.btnHuongDan_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Animated = true;
            this.btnThongKe.BackColor = System.Drawing.Color.Transparent;
            this.btnThongKe.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongKe.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThongKe.FillColor = System.Drawing.Color.Empty;
            this.btnThongKe.FillColor2 = System.Drawing.Color.Empty;
            this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.btnThongKe.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnThongKe.Image = global::QuanLyBanHang.Properties.Resources.combo_chart_64px1;
            this.btnThongKe.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnThongKe.Location = new System.Drawing.Point(2, 305);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(4);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(269, 55);
            this.btnThongKe.TabIndex = 2;
            this.btnThongKe.Text = "Loại sản phẩm";
            this.btnThongKe.UseTransparentBackground = true;
            this.btnThongKe.Visible = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnSanPham
            // 
            this.btnSanPham.Animated = true;
            this.btnSanPham.BackColor = System.Drawing.Color.Transparent;
            this.btnSanPham.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnSanPham.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSanPham.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSanPham.FillColor = System.Drawing.Color.Empty;
            this.btnSanPham.FillColor2 = System.Drawing.Color.Empty;
            this.btnSanPham.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnSanPham.ForeColor = System.Drawing.Color.White;
            this.btnSanPham.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.btnSanPham.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnSanPham.Image = global::QuanLyBanHang.Properties.Resources.product_64px;
            this.btnSanPham.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSanPham.Location = new System.Drawing.Point(4, 368);
            this.btnSanPham.Margin = new System.Windows.Forms.Padding(4);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(269, 55);
            this.btnSanPham.TabIndex = 2;
            this.btnSanPham.Text = "Sản Phẩm";
            this.btnSanPham.UseTransparentBackground = true;
            this.btnSanPham.Visible = false;
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Animated = true;
            this.btnKhachHang.BackColor = System.Drawing.Color.Transparent;
            this.btnKhachHang.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnKhachHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKhachHang.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnKhachHang.FillColor = System.Drawing.Color.Empty;
            this.btnKhachHang.FillColor2 = System.Drawing.Color.Empty;
            this.btnKhachHang.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnKhachHang.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.btnKhachHang.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnKhachHang.Image = global::QuanLyBanHang.Properties.Resources.people_working_together_48px;
            this.btnKhachHang.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnKhachHang.Location = new System.Drawing.Point(4, 431);
            this.btnKhachHang.Margin = new System.Windows.Forms.Padding(4);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(269, 55);
            this.btnKhachHang.TabIndex = 2;
            this.btnKhachHang.Text = "Khách Hàng";
            this.btnKhachHang.UseTransparentBackground = true;
            this.btnKhachHang.Visible = false;
            this.btnKhachHang.Click += new System.EventHandler(this.btnKhachHang_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Animated = true;
            this.btnNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.btnNhanVien.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNhanVien.CustomImages.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNhanVien.FillColor = System.Drawing.Color.Empty;
            this.btnNhanVien.FillColor2 = System.Drawing.Color.Empty;
            this.btnNhanVien.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnNhanVien.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.btnNhanVien.HoverState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnNhanVien.Image = global::QuanLyBanHang.Properties.Resources.user_48px;
            this.btnNhanVien.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNhanVien.Location = new System.Drawing.Point(4, 242);
            this.btnNhanVien.Margin = new System.Windows.Forms.Padding(4);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(269, 55);
            this.btnNhanVien.TabIndex = 2;
            this.btnNhanVien.Text = "Nhân Viên";
            this.btnNhanVien.UseTransparentBackground = true;
            this.btnNhanVien.Visible = false;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lbl1.ForeColor = System.Drawing.Color.Yellow;
            this.lbl1.Location = new System.Drawing.Point(8, 159);
            this.lbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(242, 37);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "Quản Lý Bán Hàng";
            // 
            // pcbIcon
            // 
            this.pcbIcon.Image = ((System.Drawing.Image)(resources.GetObject("pcbIcon.Image")));
            this.pcbIcon.Location = new System.Drawing.Point(48, 30);
            this.pcbIcon.Margin = new System.Windows.Forms.Padding(4);
            this.pcbIcon.Name = "pcbIcon";
            this.pcbIcon.Size = new System.Drawing.Size(181, 124);
            this.pcbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbIcon.TabIndex = 2;
            this.pcbIcon.TabStop = false;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2DragControl2
            // 
            this.guna2DragControl2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl2.TargetControl = this.pnMenu;
            this.guna2DragControl2.UseTransparentDrag = true;
            // 
            // guna2DragControl3
            // 
            this.guna2DragControl3.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl3.TargetControl = this.panelControl;
            this.guna2DragControl3.UseTransparentDrag = true;
            // 
            // panelControl
            // 
            this.panelControl.BackgroundImage = global::QuanLyBanHang.Properties.Resources.fpt;
            this.panelControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelControl.Location = new System.Drawing.Point(279, 2);
            this.panelControl.Margin = new System.Windows.Forms.Padding(4);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(1228, 803);
            this.panelControl.TabIndex = 2;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(1443, 0);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(60, 37);
            this.guna2ControlBox1.TabIndex = 36;
            // 
            // menuTaiKhoan
            // 
            this.menuTaiKhoan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.menuTaiKhoan.Font = new System.Drawing.Font("Segoe UI Semilight", 13F);
            this.menuTaiKhoan.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuTaiKhoan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemThongTinNV,
            this.toolStripSeparator2,
            this.itemDoiMatKhau});
            this.menuTaiKhoan.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuTaiKhoan.Name = "contextMenuStrip1";
            this.menuTaiKhoan.Size = new System.Drawing.Size(240, 78);
            // 
            // itemThongTinNV
            // 
            this.itemThongTinNV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.itemThongTinNV.ForeColor = System.Drawing.Color.LightCoral;
            this.itemThongTinNV.Name = "itemThongTinNV";
            this.itemThongTinNV.Size = new System.Drawing.Size(239, 34);
            this.itemThongTinNV.Text = "Hồ sơ nhân viên";
            this.itemThongTinNV.Click += new System.EventHandler(this.itemThongTinNV_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(236, 6);
            // 
            // itemDoiMatKhau
            // 
            this.itemDoiMatKhau.ForeColor = System.Drawing.Color.LightCoral;
            this.itemDoiMatKhau.Name = "itemDoiMatKhau";
            this.itemDoiMatKhau.Size = new System.Drawing.Size(239, 34);
            this.itemDoiMatKhau.Text = "Đổi mật khẩu";
            this.itemDoiMatKhau.Click += new System.EventHandler(this.itemDoiMatKhau_Click);
            // 
            // guna2DragControl4
            // 
            this.guna2DragControl4.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl4.UseTransparentDrag = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(1506, 805);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.pnMenu);
            this.Controls.Add(this.panelControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bán hàng";
            this.Load += new System.EventHandler(this.Main_Load);
            this.pnMenu.ResumeLayout(false);
            this.pnMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbIcon)).EndInit();
            this.menuTaiKhoan.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel pnMenu;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.PictureBox pcbIcon;
        private System.Windows.Forms.Label lbl1;
        private Guna.UI2.WinForms.Guna2GradientButton btnNhanVien;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private Guna.UI2.WinForms.Guna2GradientButton btnThongKe;
        private Guna.UI2.WinForms.Guna2GradientButton btnSanPham;
        private Guna.UI2.WinForms.Guna2GradientButton btnKhachHang;
        private Guna.UI2.WinForms.Guna2GradientButton btnLogin;
        private System.Windows.Forms.Panel panelControl;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl2;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl3;
        private Guna.UI2.WinForms.Guna2GradientButton btnTaiKhoan;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.ContextMenuStrip menuTaiKhoan;
        private System.Windows.Forms.ToolStripMenuItem itemThongTinNV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem itemDoiMatKhau;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl4;
        private Guna.UI2.WinForms.Guna2GradientButton btnDonHang;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
    }
}

