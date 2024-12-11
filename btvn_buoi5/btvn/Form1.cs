using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace btvn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "Tahoma";
            toolStripComboBox2.Text = "14";
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
            }
            List<int> listSize = new List<int> { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (var s in listSize)
            {
                toolStripComboBox2.Items.Add(s);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        { 
        
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ FontStyle.Bold; // Toggle Bold
                richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
            }
        
    }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ FontStyle.Italic; // Toggle Italic
                richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newFontStyle = currentFont.Style ^ FontStyle.Underline; // Toggle Underline
                richTextBox1.SelectionFont = new Font(currentFont, newFontStyle);
            }
        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có văn bản nào được chọn không
            if (richTextBox1.SelectionLength > 0)
            {
                // Lấy cỡ chữ từ ComboBox và lưu lại FontStyle hiện tại
                float newSize = float.Parse(toolStripComboBox2.SelectedItem.ToString());
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle currentStyle = currentFont.Style;  // Lưu lại kiểu chữ hiện tại

                // Áp dụng cỡ chữ mới nhưng giữ nguyên FontStyle
                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, newSize, currentStyle);
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                // Lấy kiểu chữ từ ComboBox và lưu lại FontStyle hiện tại
                string selectedFont = toolStripComboBox1.SelectedItem.ToString();
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle currentStyle = currentFont.Style;  // Lưu lại kiểu chữ hiện tại

                // Áp dụng kiểu chữ mới nhưng giữ nguyên FontStyle
                richTextBox1.SelectionFont = new Font(selectedFont, currentFont.Size, currentStyle);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripBtn_save_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Rich Text Format (*.rtf)|*.rtf|Plain Text (*.txt)|*.txt";
                saveFileDialog.DefaultExt = "rtf";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Lưu nội dung RichTextBox dưới định dạng được chọn
                        if (saveFileDialog.FilterIndex == 1) // RTF
                        {
                            richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                        }
                        else // TXT
                        {
                            richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                        }

                        MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi khi lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void toolStripBtn_taomoi_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
        "Bạn có chắc chắn muốn tạo mới? Nội dung hiện tại sẽ bị xóa.",
        "Xác nhận",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning
    );

            if (result == DialogResult.Yes)
            {
                // Xóa nội dung của RichTextBox
                richTextBox1.Clear();
            }
        }
    }
}
