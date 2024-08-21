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
    public partial class LogGosterici : Form
    {
        public LogGosterici(string gelen)
        {
            InitializeComponent();
            textBox1.Text = gelen;
        }

        private void LogGosterici_Load(object sender, EventArgs e)
        {

        }
    }
}
