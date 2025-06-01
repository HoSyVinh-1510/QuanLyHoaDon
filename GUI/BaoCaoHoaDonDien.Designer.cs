namespace QuanLyHoaDon.GUI
{
    partial class BaoCaoHoaDonDien
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
            this.reportViewerDien = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerDien
            // 
            this.reportViewerDien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerDien.Location = new System.Drawing.Point(0, 0);
            this.reportViewerDien.Name = "reportViewerDien";
            this.reportViewerDien.ServerReport.BearerToken = null;
            this.reportViewerDien.Size = new System.Drawing.Size(1882, 922);
            this.reportViewerDien.TabIndex = 0;
            // 
            // BaoCaoHoaDonDien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1882, 922);
            this.Controls.Add(this.reportViewerDien);
            this.Name = "BaoCaoHoaDonDien";
            this.Text = "BaoCaoHoaDon";
            this.Load += new System.EventHandler(this.BaoCaoHoaDon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerDien;
    }
}