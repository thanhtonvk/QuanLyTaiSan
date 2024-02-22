using QuanLyVatTu.DAO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuanLyVatTu.Models;
using System.IO;
using System.Linq;
using System.Drawing.Printing;

namespace QuanLyVatTu.UI.TraCuuUI
{
    public partial class CtrlTraCuuVatTu : UserControl
    {
        private TaiSanDAO _taiSanDao = new TaiSanDAO();
        private NganhDAO _nganhDao = new NganhDAO();
        private LoaiTaiSanDAO _loaiTaiSanDao = new LoaiTaiSanDAO();
        private List<Nganh> dsNganhs;
        private List<LoaiTaiSan> dsLoaiTS;
        private List<string> dsTenNganhs = new List<string>();
        private List<string> dsTenLoaiTSs = new List<string>();
        private string imagePath = "";
        private int id = -1;

        public CtrlTraCuuVatTu()
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
            foreach (Nganh nganh in dsNganhs)
            {
                dsTenNganhs.Add(nganh.tennganh);
            }

            foreach (LoaiTaiSan loaiTaiSan in dsLoaiTS)
            {
                dsTenLoaiTSs.Add(loaiTaiSan.tenloai);
            }
            



        }
        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                id = int.Parse(row.Cells[0].Value.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tukhoa = tbTimKiem.Text.Trim();
            loadDs(tukhoa);
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