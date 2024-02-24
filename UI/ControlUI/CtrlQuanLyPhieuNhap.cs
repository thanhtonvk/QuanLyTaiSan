using QuanLyVatTu.DAO;
using QuanLyVatTu.Models;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyVatTu.UI.ControlUI
{
    public partial class CtrlQuanLyPhieuNhap : UserControl
    {
        PhieuNhapDAO phieuNhapDAO = new PhieuNhapDAO();
        int id = 0;
        List<PhieuNhap> phieuNhapList;

        KhoDAO khoDAO = new KhoDAO();
        NhaCungCapDAO nhaCungCapDAO = new NhaCungCapDAO();
        HinhThucThanhToanDAO hinhThucThanhToanDAO = new HinhThucThanhToanDAO();
        List<Kho> khoList;
        List<NhaCungCap> nhaCungCapList;
        List<HinhThucThanhToan> hinhThucThanhToanList;
        public CtrlQuanLyPhieuNhap()
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
            khoList = khoDAO.DsKho("");
            nhaCungCapList = nhaCungCapDAO.DsNhaCungCap("");
            hinhThucThanhToanList = hinhThucThanhToanDAO.DsHinhThucThanhToan("");
            cbKho.DataSource = khoList;
            cbNCC.DataSource = nhaCungCapList;
            cbThanhToan.DataSource = hinhThucThanhToanList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PhieuNhap phieuNhap = new PhieuNhap();
            phieuNhap.maphieunhap = id;
            phieuNhap.ngaynhap = DateTime.Now;
            phieuNhap.ghichu = tbGhiChu.Text.Trim();
            phieuNhap.nguoinhap = tbNguoiNhap.Text.Trim();
            int kq = phieuNhapDAO.UpdatePhieuNhap(phieuNhap);
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
            PhieuNhap phieuNhap = new PhieuNhap();
            phieuNhap.ngaynhap = DateTime.Now;
            phieuNhap.ghichu = tbGhiChu.Text.Trim();
            phieuNhap.nguoinhap = tbNguoiNhap.Text.Trim();
            phieuNhap.makho = khoList[cbKho.SelectedIndex].makho;
            phieuNhap.manhancc= nhaCungCapList[cbNCC.SelectedIndex].mancc;
            phieuNhap.matt = hinhThucThanhToanList[cbThanhToan.SelectedIndex].maht;
            int kq = phieuNhapDAO.ThemPhieuNhap(phieuNhap);
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
            int kq = phieuNhapDAO.DeletePhieuNhap(id);
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
                txtid.Text = id.ToString();
                tbNguoiNhap.Text = row.Cells[2].Value.ToString();
                tbGhiChu.Text = row.Cells[3].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (id != 0)
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

        private void CtrlQuanLyPhieuNhap_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tuKhoa = tbTimKiem.Text.Trim();
            loadDs(tuKhoa);
        }
    }
}
