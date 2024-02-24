using ArrayToExcel;
using QuanLyVatTu.DAO;
using QuanLyVatTu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVatTu.UI.ControlUI
{
    public partial class CtrlQuanLyKho : UserControl
    {

        KhoDAO KhoDAO = new KhoDAO();
        int maKho;
        public CtrlQuanLyKho()
        {
            InitializeComponent();

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            loadDs("");
        }
        public void loadDs(string tuKho)
        {
            var listKho = KhoDAO.DsKho(tuKho);
            dataGridView1.DataSource = listKho;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kho Kho = new Kho();
            Kho.diachi = tbDiachi.Text.Trim();
            Kho.tenkho = tbTenKhoa.Text.Trim();
            int kq = KhoDAO.ThemKho(Kho);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                maKho = int.Parse(row.Cells[0].Value.ToString());
                txtId.Text = maKho.ToString();
                tbTenKhoa.Text = row.Cells[1].Value.ToString();
                tbDiachi.Text = row.Cells[2].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kho Kho = new Kho();
            Kho.diachi = tbDiachi.Text.Trim();
            Kho.tenkho = tbTenKhoa.Text.Trim();
            int kq = KhoDAO.UpdateKho(Kho);
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
            int kq = KhoDAO.DeleteKho(maKho);
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

        private void button5_Click(object sender, EventArgs e)
        {
            string tuKho = tbTimKiem.Text.Trim();
            loadDs(tuKho);
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            //start excel
            var excel = KhoDAO.DsKho("").ToExcel();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ("Excel File|*.xlsx");
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog.FileName, excel);
            }
        }
    }
}
