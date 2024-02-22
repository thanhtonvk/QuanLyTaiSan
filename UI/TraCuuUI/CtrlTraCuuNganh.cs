using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using QuanLyVatTu;
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