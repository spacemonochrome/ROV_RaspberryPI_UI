using System;
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
        public textbox_form(string raspi_dosya_yolu, Main BazForm)
        {
            InitializeComponent();
            AnaForm = BazForm;
            _dosya_yolu = raspi_dosya_yolu;
            textBox1.Text = raspi_dosya_yolu;            
        }

        private void Onaylama_Click(object sender, EventArgs e)
        {
            _dosya_yolu = textBox1.Text;
            AnaForm.bilgi_geri_al(_dosya_yolu);
            //AnaForm.raspi_dosya_yolu = _dosya_yolu;
            this.Close();
        }
    }
}
