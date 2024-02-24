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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyVatTu.UI
{
    public partial class FrmQuanLyTaiKhoan : Form
    {
        public FrmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }
        string id="";
        TaiKhoanDAO taiKhoanDAO = new TaiKhoanDAO();
        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id))
            {
                TaiKhoan taiKhoan = taiKhoanDAO.DsTaiKhoan("").FirstOrDefault(x=>x.tentk==id);
                taiKhoan.loaitaikhoan = "Admin";
                int result = taiKhoanDAO.UpdateTaiKhoan(taiKhoan);
                if (result > 0)
                {
                    MessageBox.Show("Cấp quyền thành công");
                }
               
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                id =row.Cells[0].Value.ToString();
            }
        }

        private void FrmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = taiKhoanDAO.DsTaiKhoan("");
        }
    }
}
