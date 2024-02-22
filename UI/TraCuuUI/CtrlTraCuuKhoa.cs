using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using QuanLyVatTu;
using QuanLyVatTu.DAO;
using QuanLyVatTu.Models;
using static System.Net.Mime.MediaTypeNames;
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

        private void captureScreen()
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
