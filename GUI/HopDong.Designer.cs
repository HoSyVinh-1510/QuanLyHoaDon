namespace QuanLyHoaDon.GUI
{
    partial class HopDong
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewHopDong = new System.Windows.Forms.DataGridView();
            this.cbBoxPhong = new System.Windows.Forms.ComboBox();
            this.btnLocHopDong = new System.Windows.Forms.Button();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cbBoxTrangThai = new System.Windows.Forms.ComboBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHopDong)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(424, 71);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker1.ShowCheckBox = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(330, 30);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Checked = false;
            this.dateTimePicker2.Cursor = System.Windows.Forms.Cursors.Default;
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(842, 71);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker2.ShowCheckBox = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(330, 30);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(327, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "FROM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(783, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "TO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(455, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "LỌC HỢP ĐỒNG";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(783, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(361, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "(Không chọn cả 2 ) hoặc ( Chỉ chọn  From)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewHopDong
            // 
            this.dataGridViewHopDong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHopDong.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewHopDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHopDong.Location = new System.Drawing.Point(331, 140);
            this.dataGridViewHopDong.Name = "dataGridViewHopDong";
            this.dataGridViewHopDong.ReadOnly = true;
            this.dataGridViewHopDong.RowHeadersWidth = 51;
            this.dataGridViewHopDong.RowTemplate.Height = 24;
            this.dataGridViewHopDong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHopDong.Size = new System.Drawing.Size(841, 369);
            this.dataGridViewHopDong.StandardTab = true;
            this.dataGridViewHopDong.TabIndex = 6;
            // 
            // cbBoxPhong
            // 
            this.cbBoxPhong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBoxPhong.FormattingEnabled = true;
            this.cbBoxPhong.Location = new System.Drawing.Point(175, 140);
            this.cbBoxPhong.MaxDropDownItems = 20;
            this.cbBoxPhong.Name = "cbBoxPhong";
            this.cbBoxPhong.Size = new System.Drawing.Size(150, 24);
            this.cbBoxPhong.Sorted = true;
            this.cbBoxPhong.TabIndex = 7;
            this.cbBoxPhong.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // btnLocHopDong
            // 
            this.btnLocHopDong.BackColor = System.Drawing.Color.Red;
            this.btnLocHopDong.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnLocHopDong.Location = new System.Drawing.Point(226, 220);
            this.btnLocHopDong.Name = "btnLocHopDong";
            this.btnLocHopDong.Size = new System.Drawing.Size(99, 45);
            this.btnLocHopDong.TabIndex = 8;
            this.btnLocHopDong.Text = "SHOW";
            this.btnLocHopDong.UseVisualStyleBackColor = false;
            this.btnLocHopDong.UseWaitCursor = true;
            this.btnLocHopDong.Click += new System.EventHandler(this.btnLocHopDong_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(76, 162);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(0, 16);
            this.labelControl1.TabIndex = 9;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(84, 141);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 23);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Phòng";
            // 
            // cbBoxTrangThai
            // 
            this.cbBoxTrangThai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBoxTrangThai.FormattingEnabled = true;
            this.cbBoxTrangThai.Items.AddRange(new object[] {
            "Đang Thuê",
            "Hết Hạn",
            "Tất Cả"});
            this.cbBoxTrangThai.Location = new System.Drawing.Point(175, 178);
            this.cbBoxTrangThai.Name = "cbBoxTrangThai";
            this.cbBoxTrangThai.Size = new System.Drawing.Size(150, 24);
            this.cbBoxTrangThai.Sorted = true;
            this.cbBoxTrangThai.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(64, 178);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(5);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(93, 23);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Trạng Thái";
            // 
            // HopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 559);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cbBoxTrangThai);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnLocHopDong);
            this.Controls.Add(this.cbBoxPhong);
            this.Controls.Add(this.dataGridViewHopDong);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "HopDong";
            this.Text = "HopDong";
            this.Load += new System.EventHandler(this.HopDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHopDong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewHopDong;
        private System.Windows.Forms.ComboBox cbBoxPhong;
        private System.Windows.Forms.Button btnLocHopDong;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.ComboBox cbBoxTrangThai;
    }
}