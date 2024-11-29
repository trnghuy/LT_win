using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void lvNhanVien_ColumnClick(object sender, EventArgs e)
        {
            if (lvBT2.SelectedItems.Count > 0)
            {
                // lấy giá trị của dòng 
                ListViewItem lv1 = lvBT2.SelectedItems[0];
                String STT = lv1.SubItems[0].Text;  
                String ma  = lv1.SubItems[1].Text;
                String ten = lv1.SubItems[2].Text;
                MessageBox.Show(STT+" " +  ma + " " + ten);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // dòng đầu
            ListViewItem item = new ListViewItem(txtSTT.Text);

            // các cột sau
            item.SubItems.Add(txtMa.Text);
            item.SubItems.Add(txtTen.Text);

            lvBT2.Items.Add(item);  
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lvBT2.SelectedItems.Count > 0)
            {
                Console.WriteLine(lvBT2.SelectedItems[0].Index);
                lvBT2.Items.RemoveAt(lvBT2.SelectedItems[0].Index);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvBT2.SelectedItems.Count > 0)
            {
                ListViewItem item = lvBT2.SelectedItems[0];
                item.SubItems[0].Text = txtSTT.Text;
                item.SubItems[1].Text = txtMa.Text;
                item.SubItems[2].Text = txtTen.Text; 
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
