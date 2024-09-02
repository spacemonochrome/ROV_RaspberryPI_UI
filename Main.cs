using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;


namespace ROV_UI
{
    public partial class Main : Form
    {
        public string host;
        public string username;
        public string password;
        public string command;

        public SshClient RaspiSSHClient = null;
        public SftpClient RaspiSFTPClient = null;
        public ShellStream shellStream = null;
        public string currentProcessId;
        private BackgroundWorker _backgroundWorker;
        public Configuration_Form Konfigurasyon_Formu;
        public textbox_form yol_degis;
        public string raspi_dosya_yolu_Gonder;
        public string raspi_dosya_yolu_Al;
        public TextBox EvrenselTerminal;

        public bool devamlilik_Sensor = false;

        public Main()
        {
            InitializeComponent();

            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.WorkerSupportsCancellation = true; // İptal desteği sağla
            _backgroundWorker.DoWork += BackgroundWorker_DoWork;
            _backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;

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
                if (log_Split.Length > 1)
                    raspi_dosya_yolu_Gonder = log_Split[1];
                else
                {
                    string dosya_yolu = AppDomain.CurrentDomain.BaseDirectory + "rov_log/dosya_dizin.txt";
                    var ab = File.Create(dosya_yolu);
                    ab.Close();
                    File.WriteAllText(dosya_yolu, raspi_dosya_yolu_Gonder);
                }
            }
            else
            {                
                string dosya_yolu = AppDomain.CurrentDomain.BaseDirectory + "rov_log/dosya_dizin.txt";
                var ab = File.Create(dosya_yolu);
                ab.Close();
                File.WriteAllText(dosya_yolu, raspi_dosya_yolu_Gonder);
            }
            EvrenselTerminal = terminal;

            desktop_listesi.Enabled = false;
            dosya_gonder.Enabled = false;
            baglantiyi_kes.Enabled = false;
            komutu_calistir.Enabled = false;
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
                    shellStream = RaspiSSHClient.CreateShellStream("xterm", 80, 24, 800, 600, 1024);

                    var cmd = RaspiSSHClient.CreateCommand("echo -n $HOME/Desktop");
                    var result = cmd.Execute();
                    raspi_dosya_yolu_Gonder = result;
                    raspi_dosya_yolu_Al = result;
                    string dosya_yolu = AppDomain.CurrentDomain.BaseDirectory + "rov_log/dosya_dizin.txt";
                    File.WriteAllText(dosya_yolu, "&" + raspi_dosya_yolu_Gonder);

                    pictureBox2.Image = global::ROV_UI.Properties.Resources.greentick;
                    desktop_listesi.Enabled = true;
                    dosya_gonder.Enabled = true;
                    baglantiyi_kes.Enabled = true;
                    komutu_calistir.Enabled = true;
                    alincak.Enabled = true;
                    baglan.Enabled = false;
                    SicaklikOku.Enabled = true;
                    Dosya_Yolu_Degistir.Enabled = true;
                }
                else
                {
                    pictureBox2.Image = global::ROV_UI.Properties.Resources.rederror;
                    desktop_listesi.Enabled = false;
                    dosya_gonder.Enabled = false;
                    baglantiyi_kes.Enabled = false;
                    Dosya_Yolu_Degistir.Enabled = false;
                    MessageBox.Show("Bağlanamadı! \n");
                }

                shell_Baglan();
            }
            catch (Exception)
            {
                MessageBox.Show("Bağlanamadı! \n");
            }                       
        }

        private void baglantiyi_kes_Click(object sender, EventArgs e)
        {
            shellStream.Close();
            RaspiSSHClient.Disconnect();
            RaspiSFTPClient.Disconnect();
            pictureBox2.Image = global::ROV_UI.Properties.Resources.rederror;
            RaspiSSHClient = null;
            RaspiSFTPClient = null;
            shellStream = null;

            desktop_listesi.Enabled = false;
            dosya_gonder.Enabled = false;
            baglantiyi_kes.Enabled = false;
            komutu_calistir.Enabled=false;
            alincak.Enabled = false;
            baglan.Enabled = true;
            SicaklikOku.Enabled = false;
            Dosya_Yolu_Degistir.Enabled = false;
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
                            RaspiSFTPClient.ChangeDirectory(raspi_dosya_yolu_Gonder);RaspiSFTPClient.UploadFile(fs, Path.GetFileName(file));
                            terminal.Text += file + " dosyası;" + Environment.NewLine + raspi_dosya_yolu_Gonder + " adresine yüklendi" + Environment.NewLine;
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
            if (komut_satiri.Text.EndsWith(".py*") || komut_satiri.Text.EndsWith(".py & echo $!*"))
            {                
                if (komut_satiri.Text.EndsWith(" & echo $!*"))
                {
                    shellStream.WriteLine(komut_satiri.Text.Substring(0, komut_satiri.Text.Length - 1));
                }
                else
                {
                    shellStream.WriteLine(komut_satiri.Text.Substring(0, komut_satiri.Text.Length - 1) + " & echo $!");
                }
                string output;
                Match match;

                while (true)
                {
                    output = shellStream.ReadLine() + "\n";
                    match = Regex.Match(output, @"%(\d+)%");
                    if (match.Success)
                    {
                        EvrenselTerminal.AppendText("islem kodu" + match.Groups[1].Value + Environment.NewLine);
                        currentProcessId = match.Groups[1].Value;
                        break;
                    }
                }

                islemi_Durdur.Enabled = true;
                komutu_calistir.Enabled = false;
            }
            else
            {
                shellStream.WriteLine(komut_satiri.Text);
            }
        }
        private async void shell_Baglan()
        {
            string output;
            await Task.Run(() =>
            {
                while (RaspiSSHClient != null)
                {
                    output = shellStream.ReadLine() + "\n";
                    if (!string.IsNullOrEmpty(output))
                    {
                        Invoke(new Action(() =>
                        {
                            EvrenselTerminal.AppendText(output + Environment.NewLine);
                            if (output == "%bitti%") { islemi_Durdur.Enabled = false; komutu_calistir.Enabled = true; }
                        }));
                    }
                }
            });
        }
        
        private void islemi_durdur(object sender, EventArgs e)
        {
            //shellStream.WriteLine($"kill -9 {currentProcessId}"); yandaki ya da asagidaki kullanilabilir
            RaspiSSHClient.CreateCommand($"kill -9 {currentProcessId}").Execute();
            islemi_Durdur.Enabled = false;
            komutu_calistir.Enabled = true;
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
            yol_degis = new textbox_form(this, "gonder", raspi_dosya_yolu_Gonder);
            yol_degis.ShowDialog();
        }

        public void bilgi_geri_al(string _dosya_yolu, string tag)
        {
            if (tag == "al")
            {
                raspi_dosya_yolu_Al = _dosya_yolu;
                //string dosya_yolu = AppDomain.CurrentDomain.BaseDirectory + "rov_log/dosya_dizin.txt";
                //var ab = File.Create(dosya_yolu);
                //ab.Close();
                //string deger = "&" + raspi_dosya_yolu_Gonder;
                //File.WriteAllText(dosya_yolu, deger);
                yol_degis.Close();
            }

            if (tag == "gonder")
            {
                raspi_dosya_yolu_Gonder = _dosya_yolu;
                string dosya_yolu = AppDomain.CurrentDomain.BaseDirectory + "rov_log/dosya_dizin.txt";
                var ab = File.Create(dosya_yolu);
                ab.Close();
                string deger = "&" + raspi_dosya_yolu_Gonder;
                File.WriteAllText(dosya_yolu, deger);
                yol_degis.Close();
            }

        }

        private void dosya_al(object sender, EventArgs e)
        {
            yol_degis = new textbox_form(this, "al", raspi_dosya_yolu_Al);
            yol_degis.ShowDialog();
        }

        private void desktop_listesi_Click(object sender, EventArgs e)
        {
            try
            {
                using (var file = File.Create(AppDomain.CurrentDomain.BaseDirectory + "rov_log/" + Path.GetFileName(raspi_dosya_yolu_Al)))
                {
                    RaspiSFTPClient.DownloadFile(raspi_dosya_yolu_Al, file);
                }
                EvrenselTerminal.AppendText(Environment.NewLine + raspi_dosya_yolu_Al + Environment.NewLine + "Adresinden dosya başarı ile alındı ve " + Environment.NewLine + (AppDomain.CurrentDomain.BaseDirectory + "rov_log/" + Path.GetFileName(raspi_dosya_yolu_Al)) + Environment.NewLine + "Adresine kaydedildi " + Environment.NewLine);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }            
        }
        /*
        private void sicaklik_okur()
        {
            while (devamlilik_Sensor)
            {
                var cmd = RaspiSSHClient.CreateCommand("vcgencmd measure_temp | sed \"s/temp=//;s/'C//\" | tr -d '\\n'");
                label8.Text = "Raspberry Pi " + cmd.Execute() + " °C";
                Thread.Sleep(1000);
            }            
        }
        */
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (!worker.CancellationPending)
            {
                // Uzun süren işleminiz burada
                var cmd = RaspiSSHClient.CreateCommand("vcgencmd measure_temp | sed \"s/temp=//;s/'C//\" | tr -d '\\n'");
                UpdateLabel("Raspberry Pi " + cmd.Execute() + " °C");
                Thread.Sleep(1000); // Örnek: her saniye bir işlem yap

                // İşlemin ilerlemesini kontrol edebilir veya bir log atabilirsiniz
            }

            // İptal edildiğinde, metod burada tamamlanacak
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SicaklikOku.ForeColor = Color.Black;
            devamlilik_Sensor = false;
        }

        private void SicaklikOku_Click(object sender, EventArgs e)
        {            
            Button button = sender as Button;
            if (devamlilik_Sensor)
            {
                _backgroundWorker.CancelAsync();
                button.ForeColor = Color.Black;
                devamlilik_Sensor = false;
                label8.Text = "Raspberry Pi °C";
            }
            else
            {
                button.ForeColor = Color.Green;
                devamlilik_Sensor = true;
                _backgroundWorker.RunWorkerAsync();
            }            
        }
        private void UpdateLabel(string text)
        {
            if (label8.InvokeRequired)
            {
                label8.Invoke(new MethodInvoker(() => label8.Text = text));
            }
            else
            {
                label8.Text = text;
            }
        }
    }
}
