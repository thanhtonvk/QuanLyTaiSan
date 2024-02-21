using QuanLyVatTu.DAO;
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
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }
        TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
        private void button1_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            var result = taiKhoanDAO.DangNhap(taiKhoan, password);
            if (result != null)
            {
                this.Hide();
                Main main = new Main();
                main.ShowDialog();

            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDangKy frmDangKy = new FrmDangKy();
            frmDangKy.ShowDialog();
        }
    }
}
