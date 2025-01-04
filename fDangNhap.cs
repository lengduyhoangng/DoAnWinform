using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnWinform.Data;


namespace DoAnWinform
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text.Trim(); // Lấy tên đăng nhập từ TextBox
            string password = txbPassWord.Text.Trim(); // Lấy mật khẩu từ TextBox

            // Kiểm tra nếu chưa nhập đầy đủ thông tin
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Thông báo");
                return; // Dừng phương thức nếu chưa nhập đủ thông tin
            }

            // Nếu đã nhập đủ, thực hiện kiểm tra đăng nhập
            if (Login(userName, password))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                this.Hide(); // Ẩn form đăng nhập
                fMain f = new fMain(); // Chuyển đến form chính (ví dụ: fMain)
                f.ShowDialog();
                this.Show(); // Hiện lại form đăng nhập khi form chính đóng
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi đăng nhập");
            }
        }
        private bool Login(string userName, string password)
        {
            // Kết nối đến cơ sở dữ liệu
            using (Model1 db = new Model1())
            {
                // Kiểm tra xem tài khoản có tồn tại hay không
                var account = db.Account.SingleOrDefault(acc => acc.User_Name == userName && acc.PassWord == password);

                return account != null; // Trả về true nếu tài khoản tồn tại
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
         
            // Hiển thị hộp thoại xác nhận trước khi thoát
            DialogResult result = MessageBox.Show(
                "Bạn thật sự có muốn thoát không?", // Nội dung thông báo
                "Xác nhận thoát",                  // Tiêu đề hộp thoại
                MessageBoxButtons.YesNo,           // Hiển thị nút Yes và No
                MessageBoxIcon.Question            // Biểu tượng dấu hỏi
            );

            // Nếu người dùng chọn Yes, thoát ứng dụng
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        
        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void fDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
