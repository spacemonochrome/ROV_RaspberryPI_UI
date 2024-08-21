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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            Task.Delay(3000).ContinueWith(t => this.Close(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            
        }
    }
}
