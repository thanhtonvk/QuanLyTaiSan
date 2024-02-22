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

namespace TraCuuVatTu.UI.ControlUI
{
    public partial class CtrlTraCuuKhoa : UserControl
    {
        KhoaDAO khoaDAO = new KhoaDAO();
        int maKhoa;
        public CtrlTraCuuKhoa()
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void button4_Click(object sender, EventArgs e)
        {
            string tuKhoa = tbTimKiem.Text.Trim();
            loadDs(tuKhoa);
        }
    }
}
