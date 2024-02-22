using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyVatTu.DAO;
using QuanLyVatTu.Models;

namespace QuanLyVatTu.UI.ControlUI
{
    public partial class CtrlQuanLyLoaiTaiSan : UserControl
    {
        private LoaiTaiSanDAO _loaiTaiSanDao = new LoaiTaiSanDAO();
        private int maLoaiTS;
        public CtrlQuanLyLoaiTaiSan()
        {
            InitializeComponent();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            loadDs("");
        }

        private void loadDs(string tuKhoa)
        {
            var listLoaiTs = _loaiTaiSanDao.DsLoaiTaiSan(tuKhoa);
            dataGridView1.DataSource = listLoaiTs;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoaiTaiSan loaiTaiSan = new LoaiTaiSan();
            loaiTaiSan.maloai = maLoaiTS;
            loaiTaiSan.tenloai = tbTenLoai.Text.Trim();
            loaiTaiSan.ghichu = tbGhiChu.Text.Trim();
            int result = _loaiTaiSanDao.UpdateLoaiTaiSan(loaiTaiSan);
            if (result > 0)
            {
                MessageBox.Show("Thành công");
                loadDs("");
            }
            else
            {
                MessageBox.Show("Không thành công");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoaiTaiSan loaiTaiSan = new LoaiTaiSan();
            loaiTaiSan.tenloai = tbTenLoai.Text.Trim();
            loaiTaiSan.ghichu = tbGhiChu.Text.Trim();
            int result = _loaiTaiSanDao.ThemLoaiTaiSan(loaiTaiSan);
            if (result > 0)
            {
                MessageBox.Show("Thành công");
                loadDs("");
            }
            else
            {
                MessageBox.Show("Không thành công");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int result = _loaiTaiSanDao.DeleteLoaiTaiSan(maLoaiTS);
            if (result > 0)
            {
                MessageBox.Show("Thành công");
                loadDs("");
            }
            else
            {
                MessageBox.Show("Bạn không thể xóa vì có liên kết khóa ngoại");
            }
        }
        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                maLoaiTS = int.Parse(row.Cells[0].Value.ToString());
                txtId.Text = maLoaiTS.ToString();
                tbTenLoai.Text = row.Cells[1].Value.ToString();
                tbGhiChu.Text = row.Cells[2].Value.ToString();
            }
        }
    }
}
