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
    
    public partial class Form1 : Form
    {
        List<account> listtaikhoan = accountlist.Instance.Listtaikhoan;
        bool thoat = true;
        public Form1()
        {
            
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckSignIn(textBox1.Text,textBox2.Text))
            {
                FormMain f = new FormMain();
                // chi mo cua so cua formChing
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid information about username or password"," Warning");
                textBox2.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(thoat)
            Application.Exit();
        }
        bool CheckSignIn(string username1, string password1 ) 
        {
           for(int i =0;i< listtaikhoan.Count; i++)
            {
                if(username1 == listtaikhoan[i].Tentaikhoan && password1==listtaikhoan[i].Matkhau)
                {
                    return true;
                }
            }

            return false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thoat)
            {
                if (MessageBox.Show("Do you really want to exit the program", "Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }   
        }
    }
}
