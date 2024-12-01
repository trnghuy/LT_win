
using System;
using System.Windows.Forms;
using btvn;


namespace btvn
{
    public partial class NhanVienForm : Form
    {
        public NhanVien NewNhanVien { get; private set; } // Thuộc tính chứa nhân viên được tạo

        public NhanVien EditedNhanVien { get; private set; }

        public NhanVienForm()
        {
            InitializeComponent();
            NewNhanVien = new NhanVien(); // Khởi tạo đối tượng NhanVien mới
        }

        public NhanVienForm(NhanVien nhanVien)
        {
            InitializeComponent();
            NewNhanVien = new NhanVien(); // Khởi tạo đối tượng mới

            // Gán giá trị từ đối tượng NhanVien vào các TextBox
            txtID.Text = nhanVien.EmployeeID;
            txtName.Text = nhanVien.EmployeeName;
            txtLuongCB.Text = nhanVien.Salary.ToString();

        }

        private void NhanVienForm_Load(object sender, EventArgs e)
        {
            // Để trống hoặc dùng để thiết lập ban đầu
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập
            if (string.IsNullOrWhiteSpace(txtID.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtLuongCB.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtLuongCB.Text, out decimal salary))
            {
                MessageBox.Show("Lương phải là số hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gán dữ liệu cho nhân viên mới
            NewNhanVien.EmployeeID = txtID.Text;
            NewNhanVien.EmployeeName = txtName.Text;
            NewNhanVien.Salary = salary;

            // Đóng form và trả về DialogResult.OK
            this.DialogResult = DialogResult.OK;
            this.Close();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
