using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyVatTu;
using QuanLyVatTu.DAO;
using QuanLyVatTu.Models;
using QuanLyVatTu.UI;

namespace TraCuuVatTu.UI.ControlUI
{
    public partial class CtrlTraCuuPhieuXuat : UserControl
    {
        PhieuXuatDAO phieuXuatDAO = new PhieuXuatDAO();
        int id = 0;
        List<PhieuXuat> phieuXuatList;
        public CtrlTraCuuPhieuXuat()
        {
            InitializeComponent();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            loadDs("");
        }
        private void loadDs(string tuKhoa)
        {
            phieuXuatList = phieuXuatDAO.DsPhieuXuat(tuKhoa);
            dataGridView1.DataSource = phieuXuatList;
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
                id = int.Parse(row.Cells[0].Value.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                Constants.id = id;
                FrmChiTietPhieuXuat frm = new FrmChiTietPhieuXuat();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 hóa đơn nhập");
            }
        }

        private void CtrlTraCuuPhieuXuat_Load(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
