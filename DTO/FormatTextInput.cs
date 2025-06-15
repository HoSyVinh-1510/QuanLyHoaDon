using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
namespace QuanLyHoaDon.DTO
{
    internal class FormatTextInput
    {
        private static FormatTextInput instance;
        public static FormatTextInput Instance
        {
            get
            {
                if (instance == null)
                    instance = new FormatTextInput();
                return instance;
            }
            private set { instance = value; }
        }
        private FormatTextInput() {}

        public  bool KiemTraChuoiText(string str)
            {
                if (string.IsNullOrEmpty(str)) return true;

                    // Các ký tự và từ khóa nguy hiểm thường gặp
                    string[] blocklist = {
                "select", "insert", "update", "delete", "drop",
                "/","//", "--", ";", "'", "\"", "/*", "*/", "@@", "@",
                "char", "nchar", "varchar", "nvarchar","%","-", "+", "=",
                "alter", "begin", "cast", "create", "cursor",
                "declare", "delete", "drop", "exec", "execute",
                "fetch", "insert", "kill", "open", 
                "sys", "sysobjects", "syscolumns", "table", "update"  };

                foreach (string s in blocklist)
                {
                    if (str.Contains(s))
                        return false;
                }
                return true;
            }
        public void InputTextBox(TextBox txt)
        {
            txt.KeyPress += (sender, e) =>
            {
                if (!KiemTraChuoiText(txt.Text+e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("Tên chứa ký tự cấm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true; // Ngăn chặn sự kiện Enter
                    SendKeys.Send("{TAB}"); // Chuyển đến ô nhập tiếp theo
                }
            };
        }
        public  string FormatName(string hoTen)
        {
            if (KiemTraChuoiText(hoTen) == false)
            {
                MessageBox.Show("Tên chứa ký tự cấm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            }
            if (string.IsNullOrWhiteSpace(hoTen))
                return string.Empty;

            // Loại bỏ khoảng trắng ở đầu và cuối
            hoTen = hoTen.Trim();

            // Tách các từ bằng dấu cách
            string[] tu = hoTen.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tu.Length; i++)
            {
                string tuHienTai = tu[i].ToLower();
                if (tuHienTai.Length > 0)
                {
                    tu[i] = char.ToUpper(tuHienTai[0]) + tuHienTai.Substring(1);
                }
            }

            // Ghép lại các từ đã chuẩn hóa
            return string.Join(" ", tu);
        }

        public  void SDT(TextBox textBox)
        {
            textBox.KeyPress += (sender, e) =>
            {
                // Kiểm tra xem ký tự nhập vào có phải là số hay không
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Nếu không phải số, không cho phép nhập
                }
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true; // Ngăn chặn sự kiện Enter
                    SendKeys.Send("{TAB}"); // Chuyển đến ô nhập tiếp theo
                }
                return;
            };
        }

        public void Float(TextBox textBox)
        {
            textBox.KeyPress += (sender, e) =>
            {
                // Kiểm tra xem ký tự nhập vào có phải là số hay không
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                {
                    e.Handled = true; // Nếu không phải số, không cho phép nhập
                }
                if (e.KeyChar == (char)Keys.Enter)
                {
                    e.Handled = true; // Ngăn chặn sự kiện Enter
                    SendKeys.Send("{TAB}"); // Chuyển đến ô nhập tiếp theo
                }
                return;
            };
        }

        public void Interger(TextBox textBox) 
        {
            textBox.KeyPress += (sender, e) =>
            {
                SDT(textBox);                
            };            
        }

    }
}
