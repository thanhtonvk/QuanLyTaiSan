using ArrayToExcel;
using QuanLyVatTu.DAO;
using QuanLyVatTu.Models;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyVatTu.UI.ControlUI
{
    public partial class CtrlQuanLyNhaCungCap : UserControl
    {
        NhaCungCapDAO NhaCungCapDAO = new NhaCungCapDAO();
        int maNhaCungCap;
        public CtrlQuanLyNhaCungCap()
        {
            InitializeComponent();

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            loadDs("");
        }
        public void loadDs(string tuNhaCungCap)
        {
            var listNhaCungCap = NhaCungCapDAO.DsNhaCungCap(tuNhaCungCap);
            dataGridView1.DataSource = listNhaCungCap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NhaCungCap NhaCungCap = new NhaCungCap();
            NhaCungCap.tenncc = tbTenKhoa.Text.Trim();
            NhaCungCap.diachi = tbDiachi.Text.Trim();
            NhaCungCap.diachi = tbDiachi.Text.Trim();
            NhaCungCap.dienthoai = tbSdt.Text.Trim();
            NhaCungCap.sotk = TbSTK.Text.Trim();
            NhaCungCap.fax  = tbFax.Text.Trim();
            int kq = NhaCungCapDAO.ThemNhaCungCap(NhaCungCap);
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
                maNhaCungCap = int.Parse(row.Cells[0].Value.ToString());
                txtId.Text = maNhaCungCap.ToString();
                tbTenKhoa.Text = row.Cells[1].Value.ToString();
                tbDiachi.Text = row.Cells[2].Value.ToString();
                tbSdt.Text = row.Cells[3].Value.ToString();
                TbSTK.Text= row.Cells[4].Value.ToString();

                tbFax.Text = row.Cells[5].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NhaCungCap NhaCungCap = new NhaCungCap();
            NhaCungCap.tenncc = tbTenKhoa.Text.Trim();
            NhaCungCap.diachi = tbDiachi.Text.Trim();
            NhaCungCap.diachi = tbDiachi.Text.Trim();
            NhaCungCap.dienthoai = tbSdt.Text.Trim();
            NhaCungCap.sotk = TbSTK.Text.Trim();
            NhaCungCap.fax = tbFax.Text.Trim();
            int kq = NhaCungCapDAO.UpdateNhaCungCap(NhaCungCap);
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
            int kq = NhaCungCapDAO.DeleteNhaCungCap(maNhaCungCap);
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
            string tuNhaCungCap = tbTimKiem.Text.Trim();
            loadDs(tuNhaCungCap);
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            //start excel
            //start excel
            var excel = NhaCungCapDAO.DsNhaCungCap("").ToExcel();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ("Excel File|*.xlsx");
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllBytes(saveFileDialog.FileName, excel);
            }
        }
    }
}
