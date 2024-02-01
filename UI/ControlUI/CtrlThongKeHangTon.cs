using QuanLyVatTu.DAO;
using QuanLyVatTu.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyVatTu.UI.ControlUI
{
    public partial class CtrlThongKeHangTon : UserControl
    {
        public CtrlThongKeHangTon()
        {
            InitializeComponent();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private TaiSanDAO _taiSanDao = new TaiSanDAO();
        private void button1_Click(object sender, EventArgs e)
        {
            var list = _taiSanDao.DsTaiSan("").Where(x=>x.soluong>0).ToList();
            dataGridView1.DataSource = list;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var list = _taiSanDao.DsTaiSan("").Where(x => x.soluong == 0).ToList();
            dataGridView1.DataSource = list;
        }
    }
}
