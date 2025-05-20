namespace QuanLyHoaDon.GUI
{
    partial class HOME
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnHoaDonDien = new System.Windows.Forms.Button();
            this.btnSoDienNuoc = new System.Windows.Forms.Button();
            this.btnHopDong = new System.Windows.Forms.Button();
            this.btnPhongAndKhachHang = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbLoading = new DevExpress.XtraEditors.LabelControl();
            this.prgrBarHome = new System.Windows.Forms.ProgressBar();
            this.panelHome = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.btnHoaDonDien);
            this.panel1.Controls.Add(this.btnSoDienNuoc);
            this.panel1.Controls.Add(this.btnHopDong);
            this.panel1.Controls.Add(this.btnPhongAndKhachHang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 527);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 65);
            this.button1.TabIndex = 5;
            this.button1.Text = "Lịch Sử Thanh Toán";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.Location = new System.Drawing.Point(0, 269);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(166, 65);
            this.button5.TabIndex = 4;
            this.button5.Text = "Hóa Đơn Nước";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnHoaDonDien
            // 
            this.btnHoaDonDien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHoaDonDien.Location = new System.Drawing.Point(0, 204);
            this.btnHoaDonDien.Name = "btnHoaDonDien";
            this.btnHoaDonDien.Size = new System.Drawing.Size(166, 65);
            this.btnHoaDonDien.TabIndex = 3;
            this.btnHoaDonDien.Text = "Hóa Đơn Điện";
            this.btnHoaDonDien.UseVisualStyleBackColor = true;
            this.btnHoaDonDien.Click += new System.EventHandler(this.btnHoaDonDien_Click);
            // 
            // btnSoDienNuoc
            // 
            this.btnSoDienNuoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSoDienNuoc.Location = new System.Drawing.Point(0, 130);
            this.btnSoDienNuoc.Name = "btnSoDienNuoc";
            this.btnSoDienNuoc.Size = new System.Drawing.Size(166, 74);
            this.btnSoDienNuoc.TabIndex = 2;
            this.btnSoDienNuoc.Text = "Bảng Ghi Điện Nước";
            this.btnSoDienNuoc.UseVisualStyleBackColor = true;
            this.btnSoDienNuoc.Click += new System.EventHandler(this.btnSoDienNuoc_Click_1);
            // 
            // btnHopDong
            // 
            this.btnHopDong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHopDong.Location = new System.Drawing.Point(0, 65);
            this.btnHopDong.Name = "btnHopDong";
            this.btnHopDong.Size = new System.Drawing.Size(166, 65);
            this.btnHopDong.TabIndex = 1;
            this.btnHopDong.Text = "Hợp Đồng";
            this.btnHopDong.UseVisualStyleBackColor = true;
            this.btnHopDong.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnPhongAndKhachHang
            // 
            this.btnPhongAndKhachHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPhongAndKhachHang.Location = new System.Drawing.Point(0, 0);
            this.btnPhongAndKhachHang.Name = "btnPhongAndKhachHang";
            this.btnPhongAndKhachHang.Size = new System.Drawing.Size(166, 65);
            this.btnPhongAndKhachHang.TabIndex = 0;
            this.btnPhongAndKhachHang.Text = "Phòng và Khách Hàng";
            this.btnPhongAndKhachHang.UseVisualStyleBackColor = true;
            this.btnPhongAndKhachHang.Click += new System.EventHandler(this.btnPhongAndKhachHang_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1409, 79);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.AutoScroll = true;
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel4.Location = new System.Drawing.Point(166, 46);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1240, 33);
            this.panel4.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbLoading);
            this.panel3.Controls.Add(this.prgrBarHome);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 606);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1409, 68);
            this.panel3.TabIndex = 2;
            // 
            // lbLoading
            // 
            this.lbLoading.Appearance.BackColor = System.Drawing.Color.Lime;
            this.lbLoading.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoading.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.lbLoading.Appearance.Options.UseBackColor = true;
            this.lbLoading.Appearance.Options.UseFont = true;
            this.lbLoading.Appearance.Options.UseForeColor = true;
            this.lbLoading.Location = new System.Drawing.Point(30, 27);
            this.lbLoading.Margin = new System.Windows.Forms.Padding(4);
            this.lbLoading.Name = "lbLoading";
            this.lbLoading.Size = new System.Drawing.Size(67, 19);
            this.lbLoading.TabIndex = 1;
            this.lbLoading.Text = "Loading:";
            // 
            // prgrBarHome
            // 
            this.prgrBarHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prgrBarHome.BackColor = System.Drawing.Color.Lime;
            this.prgrBarHome.ForeColor = System.Drawing.Color.Cyan;
            this.prgrBarHome.Location = new System.Drawing.Point(12, 15);
            this.prgrBarHome.Name = "prgrBarHome";
            this.prgrBarHome.Size = new System.Drawing.Size(154, 41);
            this.prgrBarHome.Step = 20;
            this.prgrBarHome.TabIndex = 0;
            // 
            // panelHome
            // 
            this.panelHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHome.Location = new System.Drawing.Point(166, 79);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(1243, 527);
            this.panelHome.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 4;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // HOME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 674);
            this.Controls.Add(this.panelHome);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.IsMdiContainer = true;
            this.Name = "HOME";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HOME";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HOME_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnHoaDonDien;
        private System.Windows.Forms.Button btnSoDienNuoc;
        private System.Windows.Forms.Button btnHopDong;
        private System.Windows.Forms.Button btnPhongAndKhachHang;
        private System.Windows.Forms.ProgressBar prgrBarHome;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.LabelControl lbLoading;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Panel panelHome;
        private System.Windows.Forms.Button button1;
    }
}