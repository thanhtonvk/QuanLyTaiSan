using QuanLyVatTu.UI.ControlUI;
using System;
using System.Windows.Forms;
using QuanLyVatTu.UI.TraCuuUI;
using TraCuuVatTu.UI.ControlUI;

namespace QuanLyVatTu.UI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            CtrlQuanLyVatTu ctrl = new CtrlQuanLyVatTu();
            addUserControl(ctrl);
        }
        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel.Controls.Clear();
            panel.Controls.Add(userControl);
            userControl.BringToFront();
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

        private void quảnLýLoạiVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrlQuanLyLoaiTaiSan ctrl = new CtrlQuanLyLoaiTaiSan();
            addUserControl(ctrl);
        }

        private void quảnLýVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrlQuanLyVatTu ctrl = new CtrlQuanLyVatTu();
            addUserControl(ctrl);
        }

        private void quảnLýKhoaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CtrlQuanLyKhoa ctrl = new CtrlQuanLyKhoa();
            addUserControl(ctrl);
        }

        private void quảnLýChuyênNgànhToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CtrlQuanLyNganh ctrl = new CtrlQuanLyNganh();
            addUserControl(ctrl);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmQuanLyTaiKhoan frm = new FrmQuanLyTaiKhoan();
            frm.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();

            dialog = MessageBox.Show("Bạn có muốn đóng chương trình không", "Cảnh báo!", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                System.Environment.Exit(1);
            }
        }

        private void traCứuLoạiVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrlTraCuuLoaiTaiSan ctrl = new CtrlTraCuuLoaiTaiSan();
            addUserControl(ctrl);
        }

        private void traCaaPhiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrlTraCuuPhieuNhap ctrl = new CtrlTraCuuPhieuNhap();
            addUserControl(ctrl);
        }

        private void traCứuVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrlTraCuuVatTu ctrl = new CtrlTraCuuVatTu();
            addUserControl(ctrl);
        }

        private void traCứuKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrlTraCuuKhoa ctrl = new CtrlTraCuuKhoa();
            addUserControl(ctrl);
        }

        private void traCứuChuyênNgànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrlTraCuuNganh ctrl = new CtrlTraCuuNganh();
            addUserControl(ctrl);
        }

        private void traCứuPhiếuXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrlTraCuuPhieuXuat ctrl = new CtrlTraCuuPhieuXuat();
            addUserControl(ctrl);
        }

        private void quảnLýXuấtVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrlQuanLyPhieuXuat ctrl = new CtrlQuanLyPhieuXuat();
            addUserControl(ctrl);
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            FrmQuanLyTaiKhoan frm = new FrmQuanLyTaiKhoan();
            frm.ShowDialog();
        }

        private void báoCáoHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrlTraCuuPhieuNhap ctrl = new CtrlTraCuuPhieuNhap();
            addUserControl(ctrl);
        }

        private void báoCáoHóaĐơnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtrlTraCuuPhieuXuat ctrl = new CtrlTraCuuPhieuXuat();
            addUserControl(ctrl);
        }
    }
}
