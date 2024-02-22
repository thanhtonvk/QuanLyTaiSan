using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyVatTu;
using QuanLyVatTu.DAO;
using QuanLyVatTu.Models;
using QuanLyVatTu.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TraCuuVatTu.UI.ControlUI
{
    public partial class CtrlTraCuuPhieuNhap : UserControl
    {
        PhieuNhapDAO phieuNhapDAO = new PhieuNhapDAO();
        int id = 0;
        List<PhieuNhap> phieuNhapList;
        public CtrlTraCuuPhieuNhap()
        {
            InitializeComponent();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            loadDs("");
        }
        private void loadDs(string tuKhoa)
        {
            phieuNhapList = phieuNhapDAO.DsPhieuNhap(tuKhoa);
            dataGridView1.DataSource = phieuNhapList;
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
            if(id!=0)
            {
                Constants.id = id;
                FrmChiTietPhieuNhap frm = new FrmChiTietPhieuNhap();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 hóa đơn nhập");
            }
        }
    }
}
