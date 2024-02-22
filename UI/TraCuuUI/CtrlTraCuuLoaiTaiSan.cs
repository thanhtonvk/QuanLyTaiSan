using System;
using System.Windows.Forms;
using QuanLyVatTu.DAO;
using QuanLyVatTu.Models;

namespace TraCuuVatTu.UI.ControlUI
{
    public partial class CtrlTraCuuLoaiTaiSan : UserControl
    {
        private LoaiTaiSanDAO _loaiTaiSanDao = new LoaiTaiSanDAO();
        private int maLoaiTS;
        public CtrlTraCuuLoaiTaiSan()
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


        private void button4_Click(object sender, EventArgs e)
        {
            string tuKhoa = tbTimKiem.Text.Trim();
            loadDs(tuKhoa);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
