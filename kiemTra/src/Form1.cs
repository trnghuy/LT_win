using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using baikiemtra.models;

namespace baikiemtra
{
    public partial class Form1 : Form
    {



        // tao đối tượng đại diện database
        Model1  modelSV = new Model1 ();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fillDgvSV();
            fillcbbLop();
        }

        private void fillcbbLop()
        {
            // lấy ds lớp
            List<Lop> listLop = modelSV.Lops.ToList ();

            cbbLopHoc.DataSource = listLop;
            cbbLopHoc.DisplayMember = "TenLop";
            cbbLopHoc.ValueMember = "MaLop";
        }

        private void fillDgvSV()
        {
            dgvSV.Rows.Clear ();
            List<Sinhvien> listSV = modelSV.Sinhviens.ToList ();

            foreach (Sinhvien sv in listSV)
            {
                int newRow = dgvSV.Rows.Add();

                dgvSV.Rows[newRow].Cells[0].Value = sv.MaSV;
                dgvSV.Rows[newRow].Cells[1].Value = sv.HoTenSV;
                dgvSV.Rows[newRow].Cells[2].Value = sv.NgaySinh;
                dgvSV.Rows[newRow].Cells[3].Value = sv.Lop.TenLop;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn "Yes", đóng form
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các điều khiển trên form
                string maSV = txtMaSV.Text.Trim();
                string hoTenSV = txtHoTen.Text.Trim();
                DateTime ngaySinh;
                if (!DateTime.TryParse(dtNgaysinh.Text, out ngaySinh))
                {
                    MessageBox.Show("Vui lòng nhập ngày sinh hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string maLop = cbbLopHoc.SelectedValue.ToString();

                // Kiểm tra mã sinh viên đã tồn tại chưa
                if (modelSV.Sinhviens.Any(sv => sv.MaSV == maSV))
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo đối tượng Sinhvien mới
                Sinhvien newSV = new Sinhvien
                {
                    MaSV = maSV,
                    HoTenSV = hoTenSV,
                    NgaySinh = ngaySinh,
                    MaLop = maLop
                };

                // Thêm vào database
                modelSV.Sinhviens.Add(newSV);
                modelSV.SaveChanges();

                // Cập nhật DataGridView
                fillDgvSV();

                // Xóa các trường nhập sau khi thêm
                txtMaSV.Clear();
                txtHoTen.Clear();
                dtNgaysinh.Value = DateTime.Now;
                cbbLopHoc.SelectedIndex = 0;

                MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã Sinh Viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tìm sinh viên theo MaSV
            string maSV = txtMaSV.Text.Trim();
            Sinhvien sv = modelSV.Sinhviens.FirstOrDefault(s => s.MaSV == maSV);

            if (sv == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cập nhật thông tin sinh viên
            sv.HoTenSV = txtHoTen.Text.Trim();
            sv.NgaySinh = dtNgaysinh.Value;
            sv.MaLop = cbbLopHoc.SelectedValue?.ToString();

            try
            {
                // Lưu thay đổi vào database
                modelSV.SaveChanges();
                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại DataGridView
                fillDgvSV();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSV.Rows.Count)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = dgvSV.Rows[e.RowIndex];

                // Gán dữ liệu từ hàng được chọn vào các điều khiển trên form
                txtMaSV.Text = selectedRow.Cells[0].Value?.ToString();
                txtHoTen.Text = selectedRow.Cells[1].Value?.ToString();
                if (DateTime.TryParse(selectedRow.Cells[2].Value?.ToString(), out DateTime ngaySinh))
                {
                    dtNgaysinh.Value = ngaySinh;
                }
                cbbLopHoc.Text = selectedRow.Cells[3].Value?.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tìm sinh viên theo MaSV
            string maSV = txtMaSV.Text.Trim();
            Sinhvien sv = modelSV.Sinhviens.FirstOrDefault(s => s.MaSV == maSV);

            if (sv == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị hộp thoại xác nhận
            DialogResult confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên có Mã SV: {maSV} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    // Xóa sinh viên khỏi database
                    modelSV.Sinhviens.Remove(sv);
                    modelSV.SaveChanges();

                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Làm mới danh sách trên DataGridView
                    fillDgvSV();

                    // Xóa thông tin trên các điều khiển
                    txtMaSV.Clear();
                    txtHoTen.Clear();
                    dtNgaysinh.Value = DateTime.Now;
                    cbbLopHoc.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Đã xảy ra lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimSV_Click(object sender, EventArgs e)
        {
            // Lấy mã sinh viên cần tìm từ TextBox
            string tenSV = txttTimSV.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenSV))
            {
                MessageBox.Show("Vui lòng nhập Tên SV để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tìm kiếm sinh viên trong database
            Sinhvien sv = modelSV.Sinhviens.FirstOrDefault(s => s.HoTenSV == tenSV);

            if (sv == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Hiển thị thông tin sinh viên tìm được trên các TextBox
            txtMaSV.Text = sv.MaSV;
            txtHoTen.Text = sv.HoTenSV;
            dtNgaysinh.Value = sv.NgaySinh ?? DateTime.Now;
            cbbLopHoc.SelectedValue = sv.MaLop;

            // Tìm và tô đậm dòng tương ứng trong DataGridView
            foreach (DataGridViewRow row in dgvSV.Rows)
            {
                if (row.Cells[1].Value?.ToString() == tenSV) // So sánh Mã SV
                {
                    // Chọn dòng
                    row.Selected = true;

                    // Cuộn đến dòng được chọn
                    dgvSV.FirstDisplayedScrollingRowIndex = row.Index;

                    // Tô đậm dòng bằng cách thay đổi màu nền
                    row.DefaultCellStyle.BackColor = Color.Blue;
                    row.DefaultCellStyle.ForeColor = Color.Black;

                    MessageBox.Show("Đã tìm thấy sinh viên và hiển thị trên danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // Trường hợp không tìm thấy (lý do: DataGridView chưa cập nhật)
            MessageBox.Show("Không tìm thấy sinh viên trong danh sách hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnKluu_Click(object sender, EventArgs e)
        {
           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
        }
    }
}
