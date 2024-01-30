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
    public partial class CtrlQuanLyTaiSan : UserControl
    {
        private TaiSanDAO _taiSanDao = new TaiSanDAO();
        private NganhDAO _nganhDao = new NganhDAO();
        private LoaiTaiSanDAO _loaiTaiSanDao = new LoaiTaiSanDAO();
        private List<Nganh> dsNganhs;
        private List<LoaiTaiSan> dsLoaiTS;
        private List<string> dsTenNganhs;
        private List<string> dsTenLoaiTSs;

        public CtrlQuanLyTaiSan()
        {
            InitializeComponent();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            loadDs("");
        }

        private void loadDs(string tuKhoa)
        {
            var list = _taiSanDao.DsTaiSan(tuKhoa);
            dataGridView1.DataSource = list;
            dsNganhs = _nganhDao.DsNganh("");
            dsLoaiTS = _loaiTaiSanDao.DsLoaiTaiSan("");

         
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}