using ArrayToExcel;
using QuanLyVatTu.DAO;
using QuanLyVatTu.Models;
using System;
using System.IO;
using System.Windows.Forms;

namespace QuanLyVatTu.UI.ControlUI
{
    public partial class CtrlQuanLyHinhThucThanhToan : UserControl
    {
        HinhThucThanhToanDAO HinhThucThanhToanDAO = new HinhThucThanhToanDAO();
        int maHinhThucThanhToan;
        public CtrlQuanLyHinhThucThanhToan()
        {
            InitializeComponent();

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            loadDs("");
        }
        public void loadDs(string tuHinhThucThanhToan)
        {
            var listHinhThucThanhToan = HinhThucThanhToanDAO.DsHinhThucThanhToan(tuHinhThucThanhToan);
            dataGridView1.DataSource = listHinhThucThanhToan;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HinhThucThanhToan HinhThucThanhToan = new HinhThucThanhToan();
            HinhThucThanhToan.tenht = tbTenKhoa.Text.Trim();
            int kq = HinhThucThanhToanDAO.ThemHinhThucThanhToan(HinhThucThanhToan);
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
                maHinhThucThanhToan = int.Parse(row.Cells[0].Value.ToString());
                txtId.Text = maHinhThucThanhToan.ToString();
                tbTenKhoa.Text = row.Cells[1].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HinhThucThanhToan HinhThucThanhToan = new HinhThucThanhToan();
            HinhThucThanhToan.tenht = tbTenKhoa.Text.Trim();
            int kq = HinhThucThanhToanDAO.UpdateHinhThucThanhToan(HinhThucThanhToan);
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
            int kq = HinhThucThanhToanDAO.DeleteHinhThucThanhToan(maHinhThucThanhToan);
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

    
        private void button4_Click_1(object sender, EventArgs e)
        {
            //start excel
            var excel = HinhThucThanhToanDAO.DsHinhThucThanhToan("").ToExcel();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ("Excel File|*.xlsx");
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog.FileName, excel);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            string tuHinhThucThanhToan = tbTimKiem.Text.Trim();
            loadDs(tuHinhThucThanhToan);
        }
    }
}
