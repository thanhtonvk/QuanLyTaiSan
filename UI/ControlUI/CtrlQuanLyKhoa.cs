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

namespace QuanLyVatTu.UI.ControlUI
{
    public partial class CtrlQuanLyKhoa : UserControl
    {
        KhoaDAO khoaDAO = new KhoaDAO();
        int maKhoa;
        public CtrlQuanLyKhoa()
        {
            InitializeComponent();

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            loadDs("");
        }
        public void loadDs(string tuKhoa)
        {
            var listKhoa = khoaDAO.DsKhoa(tuKhoa);
            dataGridView1.DataSource = listKhoa;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Khoa khoa = new Khoa();
            khoa.diachi = tbDiachi.Text.Trim();
            khoa.ghichu = tbGhiChu.Text.Trim();
            khoa.tenkhoa = tbTenKhoa.Text.Trim();
            khoa.sdt = tbSdt.Text.Trim();
            int kq = khoaDAO.ThemKhoa(khoa);
            if (kq>0)
            {
                MessageBox.Show("Thành công");
                loadDs("");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                maKhoa = int.Parse(row.Cells[0].Value.ToString());
                txtId.Text = maKhoa.ToString();
                tbTenKhoa.Text = row.Cells[1].Value.ToString();
                tbDiachi.Text = row.Cells[2].Value.ToString();
                tbSdt.Text = row.Cells[3].Value.ToString();
                tbGhiChu.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Khoa khoa = new Khoa();
            khoa.makhoa = maKhoa;
            khoa.diachi = tbDiachi.Text.Trim();
            khoa.ghichu = tbGhiChu.Text.Trim();
            khoa.tenkhoa = tbTenKhoa.Text.Trim();
            khoa.sdt = tbSdt.Text.Trim();
            int kq = khoaDAO.UpdateKhoa(khoa);
            if (kq > 0)
            {
                MessageBox.Show("Thành công");
                loadDs("");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int kq = khoaDAO.DeleteKhoa(maKhoa);
            if (kq > 0)
            {
                MessageBox.Show("Thành công");
                loadDs("");
            }
            else
            {
                MessageBox.Show("Bạn không thể xóa vì có liên kết khóa ngoại");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tuKhoa = tbTimKiem.Text.Trim();
            loadDs(tuKhoa);
        }
    }
}
