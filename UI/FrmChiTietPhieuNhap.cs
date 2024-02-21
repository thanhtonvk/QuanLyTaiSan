using QuanLyVatTu.DAO;
using QuanLyVatTu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace QuanLyVatTu.UI
{
    public partial class FrmChiTietPhieuNhap : Form
    {
        ChiTietPhieuNhapDAO ChiTietPhieuNhapDAO = new ChiTietPhieuNhapDAO();
        TaiSanDAO TaiSanDAO = new TaiSanDAO();
        List<TaiSan> TaiSanList = new List<TaiSan>();
        List<string> tenTaiSanList = new List<string>();
        List<ChiTietPhieuNhap> chiTietPhieuNhaps = new List<ChiTietPhieuNhap>();
        int id;
        public FrmChiTietPhieuNhap()
        {
            InitializeComponent();
            loadDS();
        }
        private void loadDS()
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            chiTietPhieuNhaps = ChiTietPhieuNhapDAO.DSCTPhieuNhap(Constants.id);
            TaiSanList = TaiSanDAO.DsTaiSan("");
            foreach(TaiSan taiSan in TaiSanList)
            {
                tenTaiSanList.Add(taiSan.tentaisan);
            }
            comboBox1.DataSource = tenTaiSanList;
            dataGridView1.DataSource = chiTietPhieuNhaps;
        }

        private void FrmChiTietPhieuNhap_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChiTietPhieuNhap chiTietPhieuNhap = new ChiTietPhieuNhap();
            chiTietPhieuNhap.mactpn = id;
            chiTietPhieuNhap.maphieunhap = Constants.id;
            chiTietPhieuNhap.dongia = int.Parse(tbDonGia.Text.Trim());
            chiTietPhieuNhap.soluong = int.Parse(tbSoLuong.Text.Trim());
            int selectedTaiSan = comboBox1.SelectedIndex;
            int idTaiSan = TaiSanList[selectedTaiSan].mataisan;
            chiTietPhieuNhap.mataisan = idTaiSan;
            int result = ChiTietPhieuNhapDAO.CapNhatPhieuNhap(chiTietPhieuNhap);
            if (result > 0)
            {
                MessageBox.Show("Thành công");
                loadDS();
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChiTietPhieuNhap chiTietPhieuNhap = new ChiTietPhieuNhap();
            chiTietPhieuNhap.maphieunhap = Constants.id;
            chiTietPhieuNhap.dongia = int.Parse(tbDonGia.Text.Trim());
            chiTietPhieuNhap.soluong = int.Parse(tbSoLuong.Text.Trim());
            int selectedTaiSan = comboBox1.SelectedIndex;
            int idTaiSan = TaiSanList[selectedTaiSan].mataisan;
            chiTietPhieuNhap.mataisan = idTaiSan;
            int result = ChiTietPhieuNhapDAO.ThemPhieuNhap(chiTietPhieuNhap);
            if (result>0)
            {
                MessageBox.Show("Thành công");
                loadDS();
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int result = ChiTietPhieuNhapDAO.XoaPhieuNhap(id);
            if (result > 0)
            {
                MessageBox.Show("Thành công");
                loadDS();
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
                int maTaiSan = int.Parse(row.Cells[2].Value.ToString());
                TaiSan taiSan = TaiSanList.FirstOrDefault(x=>x.mataisan== maTaiSan);
                comboBox1.Text = taiSan.tentaisan.ToString();
                int donGia = int.Parse(row.Cells[3].Value.ToString());
                int soLuong = int.Parse(row.Cells[4].Value.ToString());
                tbDonGia.Text= donGia.ToString();
                tbSoLuong.Text = soLuong.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                int StartCol = 1;
                int StartRow = 1;
                int j = 0, i = 0;

                //Write Headers
                for (j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dataGridView1.Columns[j].HeaderText;
                }

                StartRow++;

                //Write datagridview content
                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        try
                        {
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;
                        }
                        catch
                        {
                            ;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
