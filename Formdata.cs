﻿using System;
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
    public partial class Formdata : Form
    {
        OOP_projectEntities p = new OOP_projectEntities();
        public Formdata()
        {
            InitializeComponent();
        }

        private void Formdata_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = p.OOP_project.ToList();
            dataGridView1.RowHeadersVisible = false;
        }
    }
}
