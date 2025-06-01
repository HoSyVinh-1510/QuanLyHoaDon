namespace QuanLyHoaDon.GUI
{
    partial class BillNuoc
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
            this.reportViewerNuoc = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewerNuoc
            // 
            this.reportViewerNuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerNuoc.Location = new System.Drawing.Point(0, 0);
            this.reportViewerNuoc.Name = "reportViewerNuoc";
            this.reportViewerNuoc.ServerReport.BearerToken = null;
            this.reportViewerNuoc.Size = new System.Drawing.Size(1677, 904);
            this.reportViewerNuoc.TabIndex = 0;
            this.reportViewerNuoc.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // BillNuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1677, 904);
            this.Controls.Add(this.reportViewerNuoc);
            this.Name = "BillNuoc";
            this.Text = "BillNuoc";
            this.Load += new System.EventHandler(this.BillNuoc_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewerNuoc;
    }
}