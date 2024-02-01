using QuanLyVatTu.UI.ControlUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVatTu.UI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            CtrlQuanLyTaiSan ctrl = new CtrlQuanLyTaiSan();
            addUserControl(ctrl);
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel.Controls.Clear();
            panel.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void quảnLýLoạiTàiSảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrlQuanLyLoaiTaiSan ctrl = new CtrlQuanLyLoaiTaiSan();
            addUserControl(ctrl);
        }

        private void quảnLýTàiSảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CtrlQuanLyTaiSan ctrl = new CtrlQuanLyTaiSan();
            addUserControl(ctrl);
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrlQuanLyKhoa ctrl = new CtrlQuanLyKhoa();
            addUserControl(ctrl);
        }

        private void quảnLýChuyênNgànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrlQuanLyNganh ctrl = new CtrlQuanLyNganh();
            addUserControl(ctrl);
        }

        private void quảnLýXuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrlQuanLyPhieuXuat ctrl = new CtrlQuanLyPhieuXuat();
            addUserControl(ctrl);
        }

        private void quảnLýNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrlQuanLyPhieuNhap ctrl = new CtrlQuanLyPhieuNhap();
            addUserControl(ctrl);
        }

        private void thốngKêHàngTồnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrlThongKeHangTon ctrl = new CtrlThongKeHangTon();
            addUserControl(ctrl);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDangNhap frmDangNhap = new FrmDangNhap();
            frmDangNhap.ShowDialog();
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDangKy FrmDangKy = new FrmDangKy();
            FrmDangKy.ShowDialog();
        }
    }
}
