using QuanLyVatTu.DAO;
using QuanLyVatTu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVatTu.UI
{
    public partial class FrmDangKy : Form
    {
        public FrmDangKy()
        {
            InitializeComponent();
        }
        TaiKhoanDAO TaiKhoanDAO = new TaiKhoanDAO();
        private void button1_Click(object sender, EventArgs e)
        {
            TaiKhoan taiKhoan = new TaiKhoan();
            taiKhoan.tentk = txtUsername.Text.Trim();
            taiKhoan.matkhau = txtPassword.Text.Trim();
            taiKhoan.email = txtEmail.Text.Trim();
            taiKhoan.sdt = txtSDT.Text.Trim();
            taiKhoan.diachi = txtDiaChi.Text.Trim();
            taiKhoan.hoten = txtHoten.Text.Trim();
            taiKhoan.loaitaikhoan = "Người dùng";
            int result = TaiKhoanDAO.ThemTaiKhoan(taiKhoan);
            if (result > 0)
            {
                MessageBox.Show("Thành công");
            }
            else
            {
                MessageBox.Show("Đăng ký không thành công");
            }
        }
    }
}
