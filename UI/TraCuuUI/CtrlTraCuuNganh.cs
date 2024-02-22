using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyVatTu.DAO;
using QuanLyVatTu.Models;

namespace TraCuuVatTu.UI.ControlUI
{
    public partial class CtrlTraCuuNganh : UserControl
    {
        private NganhDAO nganhDAO = new NganhDAO();
        private KhoaDAO khoaDao = new KhoaDAO();
        private List<Khoa> khoaList;
        private List<string> tenKhoaList = new List<string>();
        private int maNganh;

        public CtrlTraCuuNganh()
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
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tuKhoa = tbTimKiem.Text.Trim();
            loadDs(tuKhoa);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}