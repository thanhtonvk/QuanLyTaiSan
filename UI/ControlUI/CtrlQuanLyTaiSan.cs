using QuanLyVatTu.DAO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuanLyVatTu.Models;
using System.IO;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;

namespace QuanLyVatTu.UI.ControlUI
{
    public partial class CtrlQuanLyTaiSan : UserControl
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

        public CtrlQuanLyTaiSan()
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
            comboBox1.DataSource = dsTenNganhs;
            comboBox2.DataSource = dsTenLoaiTSs;



        }

        private void button1_Click(object sender, EventArgs e)
        {

            TaiSan taiSan = new TaiSan();
            taiSan.mataisan = id;
            taiSan.soluong = 0;
            taiSan.hinhanh = imagePath;
            taiSan.ghichu = tbGhiChu.Text.Trim();
            taiSan.tentaisan = tbTaiSan.Text.Trim();
            int idxNganh = comboBox1.SelectedIndex;
            int idxLoai = comboBox2.SelectedIndex;
            taiSan.manganh = dsNganhs[idxNganh].manganh;
            taiSan.maloai = dsLoaiTS[idxLoai].maloai;
            int result = _taiSanDao.ThemTaiSan(taiSan);
            if (result > 0)
            {
                MessageBox.Show("Thành công");
                loadDs("");
            }
            else
            {
                MessageBox.Show("Thất bại");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TaiSan taiSan = new TaiSan();
            taiSan.soluong = 0;
            taiSan.hinhanh = imagePath;
            taiSan.ghichu = tbGhiChu.Text.Trim();
            taiSan.tentaisan = tbTaiSan.Text.Trim();
            int idxNganh = comboBox1.SelectedIndex;
            int idxLoai = comboBox2.SelectedIndex;
            taiSan.manganh = dsNganhs[idxNganh].manganh;
            taiSan.maloai = dsLoaiTS[idxLoai].maloai;
            int result = _taiSanDao.UpdateTaiSan(taiSan);
            if (result > 0)
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
            int result = _taiSanDao.DeleteTaiSan(id);
            if (result > 0)
            {
                MessageBox.Show("Thành công");
                loadDs("");
            }
            else
            {
                MessageBox.Show("Bạn không thể xóa vì có liên kết khóa ngoại");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tuKhoa = tbTimKiem.Text.Trim();
            loadDs(tuKhoa);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Tệp PNG (*.png)|*.png|Tệp JPG (*.jpg)|*.jpg|Tất cả các tệp (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;

                string extension = Path.GetExtension(selectedFilePath).ToLower();

                if (extension == ".png" || extension == ".jpg")
                {
                    imagePath = selectedFilePath;
                    pictureBox2.Image = new Bitmap(selectedFilePath);
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một tệp PNG hoặc JPG hợp lệ.", "Loại Tệp Không Hợp Lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                id = int.Parse(row.Cells[0].Value.ToString());
                txtId.Text = id.ToString();
                tbTaiSan.Text = row.Cells[1].Value.ToString();
                int maNganh = int.Parse(row.Cells[2].Value.ToString());
                Nganh nganh = dsNganhs.FirstOrDefault(x=>x.manganh == maNganh);
                comboBox1.Text = nganh.tennganh;

                imagePath = row.Cells[3].Value.ToString();
                pictureBox2.Image = new Bitmap(imagePath);

                tbGhiChu.Text = row.Cells[5].Value.ToString();
                int maLoai = int.Parse(row.Cells[6].Value.ToString());
                LoaiTaiSan loaiTaiSan = dsLoaiTS.FirstOrDefault(x=>x.maloai == maLoai);
                comboBox2.Text = loaiTaiSan.tenloai;
            }
        }
    }
}