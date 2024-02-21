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
using QuanLyVatTu.Models;

namespace QuanLyVatTu.UI.ControlUI
{
    public partial class CtrlQuanLyNganh : UserControl
    {
        private NganhDAO nganhDAO = new NganhDAO();
        private KhoaDAO khoaDao = new KhoaDAO();
        private List<Khoa> khoaList;
        private List<string> tenKhoaList = new List<string>();
        private int maNganh;

        public CtrlQuanLyNganh()
        {
            InitializeComponent();

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            loadDs("");
            loadDsKhoa();
        }

        public void loadDs(string tuKhoa)
        {
            var listNganh = nganhDAO.DsNganh(tuKhoa);
            dataGridView1.DataSource = listNganh;
        }

        public void loadDsKhoa()
        {
            khoaList = khoaDao.DsKhoa("");
            foreach (Khoa khoa in khoaList)
            {
                tenKhoaList.Add(khoa.tenkhoa);
            }

            comboBox1.DataSource = tenKhoaList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Nganh nganh = new Nganh();
            nganh.manganh = maNganh;
            nganh.tennganh = tbTenKhoa.Text.Trim();
            nganh.ghichu = tbGhiChu.Text.Trim();
            nganh.sdt = tbSdt.Text.Trim();
            int idxKhoa = comboBox1.SelectedIndex;
            nganh.makhoa = khoaList[idxKhoa].makhoa;
            int kq = nganhDAO.UpdateNganh(nganh);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Nganh nganh = new Nganh();
            nganh.tennganh = tbTenKhoa.Text.Trim();
            nganh.ghichu = tbGhiChu.Text.Trim();
            nganh.sdt = tbSdt.Text.Trim();
            int idxKhoa = comboBox1.SelectedIndex;
            nganh.makhoa = khoaList[idxKhoa].makhoa;
            int kq = nganhDAO.ThemNganh(nganh);
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
            int kq = nganhDAO.DeleteNganh(maNganh);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                maNganh = int.Parse(row.Cells[0].Value.ToString());
                txtId.Text = maNganh.ToString();
                tbTenKhoa.Text = row.Cells[1].Value.ToString();
                tbSdt.Text = row.Cells[2].Value.ToString();
                tbGhiChu.Text = row.Cells[3].Value.ToString();
                int maKhoa = int.Parse(row.Cells[4].Value.ToString());
                Khoa khoa = khoaList.FirstOrDefault(x => x.makhoa == maKhoa);
                comboBox1.Text = khoa.tenkhoa;
            }
        }
    }
}