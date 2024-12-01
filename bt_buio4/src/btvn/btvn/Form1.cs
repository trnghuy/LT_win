using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace btvn
{
    public partial class Form1 : Form
    {

        private List<NhanVien> DSNhanVien;

        public Form1()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {




        }

        private void Form1_Load(object sender, EventArgs e)
        {

            DSNhanVien = new List<NhanVien>();
            DSNhanVien.Add(new NhanVien() { EmployeeID = "nv01", EmployeeName = "Nguyen van a",  Salary = 5000});
            dtaNhanVien.DataSource = DSNhanVien;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Hiển thị form thêm nhân viên
            NhanVienForm frm = new NhanVienForm();
            if (frm.ShowDialog() == DialogResult.OK) // Nếu người dùng nhấn Đồng ý
            {
                DSNhanVien.Add(frm.NewNhanVien); // Thêm nhân viên mới vào danh sách
                dtaNhanVien.DataSource = null; // Reset nguồn dữ liệu
                dtaNhanVien.DataSource = DSNhanVien; // Cập nhật lại DataGridView
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dtaNhanVien.SelectedRows.Count > 0)
            {
                // Lấy nhân viên đã chọn
                var selectedRow = dtaNhanVien.SelectedRows[0];
                var selectedNhanVien = selectedRow.DataBoundItem as NhanVien;

                if (selectedNhanVien != null)
                {
                    // Mở form chỉnh sửa nhân viên và truyền thông tin nhân viên 
                    NhanVienForm frm = new NhanVienForm(selectedNhanVien);
                    if (frm.ShowDialog() == DialogResult.OK) // Nếu người dùng nhấn Đồng ý
                    {
                        // Cập nhật lại dữ liệu trong danh sách sau khi chỉnh sửa
                        int index = DSNhanVien.IndexOf(selectedNhanVien);
                        DSNhanVien[index] = frm.NewNhanVien; // Cập nhật nhân viên trong danh sách

                        // Cập nhật lại DataGridView
                        dtaNhanVien.DataSource = null;
                        dtaNhanVien.DataSource = DSNhanVien;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để chỉnh sửa!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtaNhanVien.SelectedRows.Count > 0)
            {
                // Lấy nhân viên đã chọn
                var selectedRow = dtaNhanVien.SelectedRows[0];
                var selectedNhanVien = selectedRow.DataBoundItem as NhanVien;

                if (selectedNhanVien != null)
                {
                    // Hỏi người dùng có chắc chắn muốn xóa không
                    var result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        // Xóa nhân viên khỏi danh sách
                        DSNhanVien.Remove(selectedNhanVien);

                        // Cập nhật lại DataGridView
                        dtaNhanVien.DataSource = null;
                        dtaNhanVien.DataSource = DSNhanVien;


                        MessageBox.Show("Nhan Viên đã được xoá!");

                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

