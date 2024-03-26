using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagedList;

namespace project_OOP_demo
{
    public partial class Xuathoadon : Form
    {
        OOP_projectEntities db = new OOP_projectEntities();
        public Xuathoadon()
        {
            InitializeComponent();
        }
        string[] Nameofdata = new string[7] { "INDEX", "ID", "Name", "Price", "Quantites", "Total", "Time" };
        
        int CurrentPage = 1;
        int pagesize = 10;
        private void Xuathoadon_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 12);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font= new Font("Tahoma", 12,FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            db.Hoadons.RemoveRange(db.Hoadons.ToList());
            decimal thanhtien = 0;
            foreach(var item in FormMain.hoadons)
            {
                if(item.STT>0)
                {
                    Hoadon hd = new Hoadon();
                    hd.ID = item.Masp;
                    hd.INDEX = item.STT;
                    hd.NAME = item.Tensp;
                    hd.PRICE = item.Dongia;
                    hd.QUANTITES = item.SL;
                    hd.TOTAL = item.Tongtien;
                    hd.TIME = item.Time;
                    thanhtien += item.Tongtien;
                    db.Hoadons.Add(hd);
                }
                
            }
            Hoadon hd1 = new Hoadon();
            hd1.ID = null;
            hd1.INDEX = FormMain.hoadons.Count();
            hd1.NAME = null;
            hd1.PRICE = null;
            hd1.QUANTITES = null;
            hd1.TOTAL = thanhtien;
            hd1.TIME =null;
            db.Hoadons.Add(hd1);
            db.SaveChanges();
            
            IPagedList<Hoadon> list = db.Hoadons.OrderBy(n=>n.INDEX).ToPagedList(CurrentPage, pagesize);
            btnNext.Enabled = list.IsFirstPage;
            btnPrevious.Enabled = list.IsLastPage;
            label1.Text = string.Format("Page {0}/{1}", list.PageNumber, list.PageCount);
            dataGridView1.DataSource = db.Hoadons.ToList();
            dataGridView1[0, FormMain.hoadons.Count - 1].Style.ForeColor = Color.Transparent;


        }
        Bitmap bmp;
        private void button3_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            dataGridView1.Height = height;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(btnNext.Enabled)
            {
                CurrentPage++;
                IPagedList<Hoadon> list = db.Hoadons.ToPagedList(CurrentPage, pagesize);
                btnNext.Enabled = list.IsFirstPage;
                btnPrevious.Enabled = list.IsLastPage;
                label1.Text = string.Format("Page {0}/{1}", list.PageNumber, list.PageCount);
                dataGridView1.DataSource = db.Hoadons.ToList();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (btnPrevious.Enabled)
            {
                CurrentPage--;
                IPagedList<Hoadon> list = db.Hoadons.ToPagedList(CurrentPage, pagesize);
                btnNext.Enabled = list.IsFirstPage;
                btnPrevious.Enabled = list.IsLastPage;
                label1.Text = string.Format("Page {0}/{1}", list.PageNumber, list.PageCount);
                dataGridView1.DataSource = db.Hoadons.ToList();
            }
        }

       
    }
}
