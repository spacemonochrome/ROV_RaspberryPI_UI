using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ROV_UI
{
    public partial class Main : Form
    {

        public string host;
        public string username;
        public string password;
        public string command;
        public SshClient RaspiSSHClient;
        public SftpClient RaspiSFTPClient;

        public Configuration_Form Konfigurasyon_Formu;
        public textbox_form yol_degis;

        public string raspi_dosya_yolu;

        public Main()
        {
            InitializeComponent();

            string dosya_dizini = AppDomain.CurrentDomain.BaseDirectory.ToString() + "rov_log/login.txt";

            if (File.Exists(dosya_dizini) == true)
            {
                string login_String = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "rov_log/login.txt");
                string[] log_Split = login_String.Split('&');
                ipadress_label.Text = log_Split[1];
                username_label.Text = log_Split[2];
                password_label.Text = log_Split[3];
            }
            else
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "rov_log");
                string dosya_yolu = AppDomain.CurrentDomain.BaseDirectory + "rov_log/login.txt";
                var ab = File.Create(dosya_yolu);
                ab.Close();
            }

            dosya_dizini = AppDomain.CurrentDomain.BaseDirectory.ToString() + "rov_log/dosya_dizin.txt";
            if (File.Exists(dosya_dizini) == true)
            {
                string login_String = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "rov_log/dosya_dizin.txt");
                string[] log_Split = login_String.Split('&');
                raspi_dosya_yolu = log_Split[1];
            }
            else
            {
                string dosya_yolu = AppDomain.CurrentDomain.BaseDirectory + "rov_log/dosya_dizin.txt";
                var ab = File.Create(dosya_yolu);
                ab.Close();
                string deger = "&" + "/home/raspberrypi/Desktop";
                File.WriteAllText(dosya_yolu, deger);
            }
        }

        private void baglan_Click(object sender, EventArgs e)
        {
            try
            {
                host = ipadress_label.Text;
                username = username_label.Text;
                password = password_label.Text;

                RaspiSSHClient = new SshClient(host, username, password);
                RaspiSFTPClient = new SftpClient(host, username, password);

                RaspiSSHClient.ConnectionInfo.Timeout = TimeSpan.FromSeconds(1);
                RaspiSFTPClient.ConnectionInfo.Timeout = TimeSpan.FromSeconds(1);

                RaspiSSHClient.Connect();
                RaspiSFTPClient.Connect();

                if (RaspiSSHClient.IsConnected && RaspiSSHClient.IsConnected)
                {
                    pictureBox2.Image = global::ROV_UI.Properties.Resources.greentick;
                }
                else
                {
                    MessageBox.Show("Bağlanamadı! \n");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bağlanamadı! \n");
            }
        }

        private void baglantiyi_kes_Click(object sender, EventArgs e)
        {
            RaspiSSHClient.Disconnect();
            RaspiSFTPClient.Disconnect();
            pictureBox2.Image = global::ROV_UI.Properties.Resources.rederror;
        }

        private void dosya_gonder_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = true;
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                dialog.RestoreDirectory = true;
                dialog.Multiselect = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (String file in dialog.FileNames)
                    {
                        using (FileStream fs = new FileStream(file, FileMode.Open))
                        {
                            RaspiSFTPClient.ChangeDirectory(raspi_dosya_yolu);RaspiSFTPClient.UploadFile(fs, Path.GetFileName(file));
                            terminal.Text += file + " yüklendi." + Environment.NewLine;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }

        private void config_button_Click(object sender, EventArgs e)
        {
            Konfigurasyon_Formu = new Configuration_Form(this);
            Konfigurasyon_Formu.ShowDialog();
        }

        private void komutu_calistir_Click(object sender, EventArgs e)
        {
            try
            {
                command = komut_satiri.Text;
                var commandResult = RaspiSSHClient.RunCommand(command);
                terminal.Text += Convert.ToString(commandResult.Result) + Environment.NewLine;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }

        private void ipadress_label_TextChanged(object sender, EventArgs e)
        {
            log_kayit();
        }

        private void username_label_TextChanged(object sender, EventArgs e)
        {
            log_kayit();
        }

        private void password_label_TextChanged(object sender, EventArgs e)
        {
            log_kayit();
        }

        public void log_kayit()
        {
            string deger = "&" + ipadress_label.Text + "&" + username_label.Text + "&" + password_label.Text;
            string dosya_yolu = AppDomain.CurrentDomain.BaseDirectory + "rov_log/login.txt";
            File.WriteAllText(dosya_yolu, deger);
        }

        private void dosya_yolu_degistir_Click(object sender, EventArgs e)
        {
            yol_degis = new textbox_form(raspi_dosya_yolu, this);
            yol_degis.ShowDialog();
        }

        public void bilgi_geri_al(string _dosya_yolu)
        {
            raspi_dosya_yolu = _dosya_yolu;

            string dosya_yolu = AppDomain.CurrentDomain.BaseDirectory + "rov_log/dosya_dizin.txt";
            var ab = File.Create(dosya_yolu);
            ab.Close();
            string deger = "&" + raspi_dosya_yolu;
            File.WriteAllText(dosya_yolu, deger);

            yol_degis.Close();
        }

        private void desktop_listesi_Click(object sender, EventArgs e)
        {
            var commandResult = RaspiSSHClient.RunCommand("ls -l Desktop");
            terminal.Text += Convert.ToString(commandResult.Result) + Environment.NewLine;
        }
    }
}
