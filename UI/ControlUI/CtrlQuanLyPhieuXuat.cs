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

namespace QuanLyVatTu.UI.ControlUI
{
    public partial class CtrlQuanLyPhieuXuat : UserControl
    {
        PhieuXuatDAO phieuXuatDAO = new PhieuXuatDAO();
        int id = 0;
        List<PhieuXuat> phieuXuatList;
        public CtrlQuanLyPhieuXuat()
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
        private void button2_Click(object sender, EventArgs e)
        {
            PhieuXuat phieuXuat = new PhieuXuat();
            phieuXuat.maphieuxuat = id;
            phieuXuat.ngayxuat = DateTime.Now;
            phieuXuat.ghichu = tbGhiChu.Text.Trim();
            phieuXuat.nguoinhap = tbNguoiXuat.Text.Trim();
            int kq = phieuXuatDAO.UpdatePhieuXuat(phieuXuat);
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

            PhieuXuat phieuXuat = new PhieuXuat();
            phieuXuat.ngayxuat = DateTime.Now;
            phieuXuat.ghichu = tbGhiChu.Text.Trim();
            phieuXuat.nguoinhap = tbNguoiXuat.Text.Trim();
            int kq = phieuXuatDAO.ThemPhieuXuat(phieuXuat);
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
            int kq = phieuXuatDAO.DeletePhieuXuat(id);
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



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                id = int.Parse(row.Cells[0].Value.ToString());
                txtId.Text = id.ToString();
                tbNguoiXuat.Text = row.Cells[2].Value.ToString();
                tbGhiChu.Text = row.Cells[3].Value.ToString();
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

        private void CtrlQuanLyPhieuXuat_Load(object sender, EventArgs e)
        {
         
        }
    }
}
