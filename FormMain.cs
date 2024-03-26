using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_OOP_demo
{

    public partial class FormMain : Form
    {
        bool thoat = true;
        
        OOP_projectEntities db = new OOP_projectEntities();

        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thoat = false;
            this.Close();
            Form1 f = new Form1();
            f.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        string[] Nameofdata = new string[7] { "INDEX", "ID", "Name", "Price", "Quantites", "Total", "Time" };
        private void FormMain_Load(object sender, EventArgs e)
        {


            var data = db.OOP_project.Select(n => n.ID);
            comboBox1.DataSource = data.ToList(); 
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns.Add("STT", "INDEX");
            dataGridView1.Columns.Add("MaSP", "MaSP");
            dataGridView1.Columns.Add("TenSP", "TenSP");
            dataGridView1.Columns.Add("DonGia", "DonGia");
            dataGridView1.Columns.Add("SoLuong", "SoLuong");
            dataGridView1.Columns.Add("TongTien", "TongTien");
            dataGridView1.Rows.Add(Nameofdata);
            HD hoadon = new HD();
            hoadon.STT = 0;
            hoadon.SL = 0;
            hoadon.Tensp = "";
            hoadon.Tongtien = 0;
            hoadon.Dongia = 0;
            hoadon.Time = DateTime.Now;
            hoadons.Add(hoadon);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (thoat)
            {
                Application.Exit();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thoat)
            {
                if (MessageBox.Show("Do you really want to exit the program", "Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }


       public static List<HD> hoadons = new List<HD>();

        private void button5_Click(object sender, EventArgs e)
        {

            bool kt = false;
            int a = Convert.ToInt32(comboBox1.Text);
            OOP_project sanpham = db.OOP_project.FirstOrDefault(n => n.ID == a);
            foreach (var item in hoadons)
            {
                if (item.Masp == a) { item.SL++; item.Tongtien = item.SL * item.Dongia; kt = true; }
            }
            if (!kt)
            {
                HD hoadon = new HD();
                hoadon.STT = hoadons[hoadons.Count() - 1].STT + 1;
                hoadon.Tensp = sanpham.Name_product;
                hoadon.Dongia = sanpham.Cost.Value;
                hoadon.SL = 1;
                hoadon.Tongtien = hoadon.Dongia * hoadon.SL;
                hoadon.Masp = sanpham.ID;
                hoadon.Time = DateTime.Now;
                hoadons.Add(hoadon);
            }
            loadData();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                int a = Convert.ToInt32(cb.SelectedValue);
                textBox2.Text = db.OOP_project.First(n => n.ID == a).Name_product;
            }


        }
        int m, n;
        void loadData()
        {


            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(Nameofdata);

            foreach (var item in hoadons)
            {
                if (item.STT > 0)
                {
                    dataGridView1.Rows.Add(item.STT, item.Masp, item.Tensp, item.Dongia, item.SL, item.Tongtien);

                }
               
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Xuathoadon f3 = new Xuathoadon();
            f3.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Formdata data = new Formdata();
            data.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            int DanhSTT = 0;
           if(m<hoadons.Count()) hoadons.Remove(hoadons[m]);
            foreach (var item in hoadons)
            {
                item.STT = DanhSTT;
                DanhSTT++;
            }
           loadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            m = e.RowIndex;
            n = e.ColumnIndex;



        }
    }


}

