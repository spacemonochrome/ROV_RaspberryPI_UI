﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROV_UI
{
    public partial class textbox_form : Form
    {
        public string _dosya_yolu;
        public Main AnaForm;
        public string tag;

        public textbox_form(Main BazForm, string tage, string adress)
        {
            InitializeComponent();
            AnaForm = BazForm;
            tag = tage;
            _dosya_yolu = adress;
            textBox1.Text = adress;            
        }

        private void Onaylama_Click(object sender, EventArgs e)
        {
            _dosya_yolu = textBox1.Text;
            AnaForm.bilgi_geri_al(_dosya_yolu, tag);
            this.Close();
        }
    }
}
