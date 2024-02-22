using System;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using QuanLyVatTu;
using QuanLyVatTu.DAO;
using QuanLyVatTu.Models;

namespace TraCuuVatTu.UI.ControlUI
{
    public partial class CtrlTraCuuLoaiTaiSan : UserControl
    {
        private LoaiTaiSanDAO _loaiTaiSanDao = new LoaiTaiSanDAO();
        private int maLoaiTS;
        public CtrlTraCuuLoaiTaiSan()
        {
            InitializeComponent();
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            loadDs("");
        }

        private void loadDs(string tuKhoa)
        {
            var listLoaiTs = _loaiTaiSanDao.DsLoaiTaiSan(tuKhoa);
            dataGridView1.DataSource = listLoaiTs;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string tuKhoa = tbTimKiem.Text.Trim();
            loadDs(tuKhoa);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbTimKiem_TextChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        ScreenCapture capScreen = new ScreenCapture();
        Bitmap memoryImage;
        private void button1_Click(object sender, EventArgs e)
        {

            PrintDocument printDocument1 = new PrintDocument();


            try
            {
                // Call the CaptureAndSave method from the ScreenCapture class 
                // And create a temporary file in C:\Temp
                memoryImage = capScreen.Capture(CaptureMode.Window);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.Print();

        }
        private void printDocument1_PrintPage(System.Object sender,
  System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
    }
}
