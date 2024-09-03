﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;

namespace ROV_UI
{
    public partial class Configuration_Form : Form
    {
        public Main AnaEkran;

        public ComboBox[] ComboBoxlerMotor;
        public ComboBox[] ComboBoxlerYon;
        public Label[] harfler;

        string duzyazi = "";
        public string[] bellek = new string[11];
        public string[] motorYon = new string[10] { "", "", "", "", "", "", "", "", "", "" };
        public string[] motorKonum = new string[7];

        public Configuration_Form(Main MainDB)
        {
            InitializeComponent();
            ComboBoxlerMotor = new ComboBox[] { comboBox_Yon_M1, comboBox_Yon_M2, comboBox_Yon_M3, comboBox_Yon_M4, comboBox_Yon_M5, comboBox_Yon_M6, comboBox_Yon_M7 };
            ComboBoxlerYon = new ComboBox[] { MotorOnSol, MotorOnSag, MotorOrtaSol, MotorOrtaSag, MotorArkaSol, MotorArkaSag, MotorFirlatma };
            harfler = new Label[] { labelA, labelB, labelC, labelD, labelE, labelF, labelG, labelH, labelI, labelJ, };

            AnaEkran = MainDB;

            string dosya_dizini = AppDomain.CurrentDomain.BaseDirectory.ToString() + "rov_log/mpu6050.txt";
            if (File.Exists(dosya_dizini) == true) {
                string login_String = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "rov_log/mpu6050.txt");
                string[] log_Split = login_String.Split('&');
                comboBox_MPU6050_Ref.Text = log_Split[1];
            }
            else {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "rov_log");
                string dosya_yolu = AppDomain.CurrentDomain.BaseDirectory + "rov_log/mpu6050.txt";
                var ab = File.Create(dosya_yolu);
                ab.Close();
            }

            dosya_dizini = AppDomain.CurrentDomain.BaseDirectory.ToString() + "rov_log/Motor_Conf.txt";
            if (File.Exists(dosya_dizini) == true) {
                string login_String = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "rov_log/Motor_Conf.txt");
                //string[] log_Split = login_String.Split('&');
                //bilgi çekilecektir. daha kodu yazılmamıştır.
            }
            else {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "rov_log");
                string dosya_yolu = AppDomain.CurrentDomain.BaseDirectory + "rov_log/Motor_Conf.txt";
                var ab = File.Create(dosya_yolu);
                ab.Close();
            }
            for (int j = 0; j < ComboBoxlerMotor.Length; j++) { ComboBoxlerMotor[j].Enabled = false; }
            for (int i = 0; i < ComboBoxlerMotor.Length; i++) { ComboBoxlerMotor[i].SelectedIndex = 0; }
            for (int i = 0; i < ComboBoxlerYon.Length; i++) { ComboBoxlerYon[i].SelectedIndex = 0; }
            for (int i = 0; i < ComboBoxlerYon.Length; i++) { ComboBoxlerYon[i].SelectedIndexChanged += new System.EventHandler(this.MotorKonumSelected); }
            for (int i = 0; i < harfler.Length; i++) { harfler[i].ForeColor = Color.Red; }
            for (int i = 0; i < ComboBoxlerYon.Length; i++) { ComboBoxlerYon[i].SelectedIndexChanged += new System.EventHandler(this.MotorYonSelected); }
            comboBox_Test_Motoru.SelectedIndex = 0;
            comboBox_Hareket_Tanimla.SelectedIndex = 9;
            comboBox_MPU6050_Ref.SelectedIndex = 0;

            if (AnaEkran.RaspiSSHClient != null)
            {
                Test_Buton.Enabled = true;
            }
            else
            {
                Test_Buton.Enabled = false;
            }
        }

        private void Button_Kaydi_Sil(object sender, EventArgs e)
        {
            motorYon[comboBox_Hareket_Tanimla.SelectedIndex] = "";
            harfler[comboBox_Hareket_Tanimla.SelectedIndex].ForeColor = Color.Red;
        }

        private void Configuration_Form_Load(object sender, EventArgs e)
        {

        }

        private void Test_Buton_Click(object sender, EventArgs e)
        {
            Test_Buton.Enabled = false;
            byte[] fileData = global::ROV_UI.Properties.Resources.Test_Gonder;
            using (MemoryStream memoryStream = new MemoryStream(fileData))
            {
                try
                {
                    AnaEkran.RaspiSFTPClient.UploadFile(memoryStream, AnaEkran.raspi_dosya_yolu_Gonder + "/Test_Gonder.py");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Dosya gönderilemedi: {ex.Message}");
                    Test_Buton.Enabled = true;
                }
            }

            try
            {
                fileData = global::ROV_UI.Properties.Resources.TestMotor;
                string tempFilePath = Path.GetTempFileName();
                File.WriteAllBytes(tempFilePath, fileData);
                string textToAdd = "GelenDeger = [" + MotorDeger(comboBox_Test_Motoru.SelectedIndex) + "]"; 
                File.WriteAllText(tempFilePath, textToAdd, Encoding.UTF8);
                using (FileStream fs = new FileStream(tempFilePath, FileMode.Open))
                {
                    AnaEkran.RaspiSFTPClient.UploadFile(fs, AnaEkran.raspi_dosya_yolu_Gonder + "/TestMotor.py");
                }
                File.Delete(tempFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dosya gönderilemedi: {ex.Message}");
                Test_Buton.Enabled = true;
            }

            try
            {
                AnaEkran.shellStream.WriteLine("python " + AnaEkran.raspi_dosya_yolu_Gonder + "/Test_Gonder.py");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
                Test_Buton.Enabled = true;
            }
        }

        private async void StartRealTimeDataStreamMotorTest(string command)
        {
            await Task.Run(() =>
            {
                AnaEkran.shellStream.WriteLine(command);
                string output = AnaEkran.shellStream.ReadLine();
                while (output != "bitti")
                {
                    output = AnaEkran.shellStream.ReadLine();
                    if (!string.IsNullOrEmpty(output))
                    {
                        Invoke(new Action(() =>
                        {
                            AnaEkran.EvrenselTerminal.AppendText(output + Environment.NewLine);
                        }));
                    }
                }
                
            });
            Test_Buton.Enabled = true;
        }

        string MotorDeger(int a)
        {
            switch (a)
            {
                case 0:
                    return "125,125,125,125,125,125,125";
                case 1:
                    return "225,125,125,125,125,125,125";
                case 2:
                    return "125,225,125,125,125,125,125";
                case 3:
                    return "125,125,225,125,125,125,125";
                case 4:
                    return "125,125,125,225,125,125,125";
                case 5:
                    return "125,125,125,125,225,125,125";
                case 6:
                    return "125,125,125,125,125,225,125";
                case 7:
                    return "125,125,125,125,125,125,225";
                default:
                    return "125,125,125,125,125,125,125";
            }
        }

        private void Button_Log_Gonder(object sender, EventArgs e)
        {
            try
            {                
                string Gonderilecek = AppDomain.CurrentDomain.BaseDirectory + "rov_log/Motor_Conf.txt";
                FileStream fs = new FileStream(Gonderilecek, FileMode.Open);
                AnaEkran.RaspiSFTPClient.ChangeDirectory(AnaEkran.raspi_dosya_yolu_Gonder);
                AnaEkran.RaspiSFTPClient.UploadFile(fs, Path.GetFileName(Gonderilecek));
                AnaEkran.EvrenselTerminal.Text += Gonderilecek + " dosyası;" + Environment.NewLine + AnaEkran.raspi_dosya_yolu_Gonder + " adresine yüklendi" + Environment.NewLine;
                MessageBox.Show("Dosya Gonderildi");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }

        private void Conf_Ice_Aktar(object sender, EventArgs e)
        {
            // config dosyasını içe aktaracak
        }

        private void comboBox_Hareket_Tanimla_SelectedIndexChanged(object sender, EventArgs e)
        {
            // secilen harekete göre bilgileri güncelleyecek
        }

        private void comboBox_MPU6050_Ref_SelectedIndexChanged(object sender, EventArgs e)
        {
            string deger = "&" + comboBox_MPU6050_Ref.GetItemText(comboBox_MPU6050_Ref.SelectedItem); ;
            string dosya_yolu = AppDomain.CurrentDomain.BaseDirectory + "rov_log/mpu6050.txt";
            File.WriteAllText(dosya_yolu, deger);
        }

        private void Button_Log_Goster(object sender, EventArgs e)
        {
            string ilksatir = "";
            for (int i = 0; i < motorKonum.Length; i++)
            {
                ilksatir = ilksatir + "&" + motorKonum[i];
            }
            ilksatir = "!" + ilksatir + "&" + "!";
            bellek[0] = ilksatir;
            for (int i = 1; i < bellek.Length; i++)
            {
                bellek[i] = motorYon[i - 1];
            }
            duzyazi = "";
            for (int i = 0; i < bellek.Length; i++)
            {
                duzyazi = duzyazi + bellek[i] + Environment.NewLine;
            }
            LogGosterici gosterici = new LogGosterici(duzyazi);
            gosterici.ShowDialog();
        }

        private void Button_Log_Kaydet(object sender, EventArgs e)
        {
            Log_Gonder.Enabled = true;
            string ilksatir = "";
            for (int i = 0; i < motorKonum.Length; i++)
            {
                ilksatir = ilksatir + "&" + motorKonum[i];
            }
            ilksatir = "!" + ilksatir + "&" + "!";
            bellek[0] = ilksatir;

            for (int i = 1;i < bellek.Length;i++)
            {
                bellek[i] = motorYon[i - 1];
            }
            duzyazi = "";
            for (int i = 0; i < bellek.Length; i++)
            {
                duzyazi = duzyazi + bellek[i] + Environment.NewLine;
            }
            string dosya_yolu = AppDomain.CurrentDomain.BaseDirectory + "rov_log/Motor_Conf.txt";
            File.WriteAllText(dosya_yolu, duzyazi);
        }

        private void button_Yon_Hareket_Kaydet(object sender, EventArgs e)
        {
            string a = "";
            for (int i = 0; i < ComboBoxlerMotor.Length; i++)
            {
                a = a + "%" + ComboBoxlerMotor[i].SelectedIndex;
            }
            string b = comboBox_Hareket_Tanimla.GetItemText(comboBox_Hareket_Tanimla.SelectedItem)[1].ToString();
            a = b + a + "%" + b;
            harfler[comboBox_Hareket_Tanimla.SelectedIndex].ForeColor = Color.Green;
            motorYon[comboBox_Hareket_Tanimla.SelectedIndex] = a;
        }
            
        private void Motor_Konum_Kaydet_Buton(object sender, EventArgs e)
        {
            for (int i = 0; i < ComboBoxlerYon.Length; i++)
            {
                if (ComboBoxlerYon[i].SelectedIndex != 0)
                {
                    int indis = Convert.ToInt32(ComboBoxlerYon[i].GetItemText(ComboBoxlerYon[i].SelectedItem)[1]) - 48 - 1;
                    motorKonum[indis] = ComboBoxlerYon[i].Tag.ToString();
                    for (int j = 0; j < ComboBoxlerMotor.Length; j++) { ComboBoxlerMotor[j].Enabled = true; }
                    pictureBox8.Image = global::ROV_UI.Properties.Resources.greentick;

                    comboBox_Hareket_Tanimla.Enabled = true;
                    Yon_Hareket_Kaydet.Enabled = true;
                    Buton_Kaydi_Sil.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Boşta motor var. Motor yönlerini tekrardan gözden geçirin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Array.Clear(motorKonum, 0, motorKonum.Length);
                    for (int j = 0; j < ComboBoxlerMotor.Length; j++){ComboBoxlerMotor[j].Enabled = false;}
                    pictureBox8.Image = global::ROV_UI.Properties.Resources.rederror;
                    break;
                }
            }
        }

        private void MotorYonSelected(object sender, EventArgs e)
        {
            Motor_Konum_Kaydet.Enabled = true;
            for (int i = 0; i < ComboBoxlerYon.Length; i++)
            {
                if (ComboBoxlerYon[i].SelectedIndex == 0)
                {
                    Motor_Konum_Kaydet.Enabled = false;
                    break;
                }       
            }            
        }

        private void MotorKonumSelected(object sender, EventArgs e)
        {
            ComboBox currentComboBox = sender as ComboBox;
            foreach (ComboBox comboBox in ComboBoxlerYon)
            {
                if (comboBox != currentComboBox && comboBox.SelectedItem == currentComboBox.SelectedItem)
                {
                    if (currentComboBox.GetItemText(currentComboBox.SelectedItem) != "-")
                    {
                        MessageBox.Show($"{currentComboBox.SelectedItem} zaten başka bir ComboBox'ta seçili.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    currentComboBox.SelectedIndex = 0;
                    break;
                }
            }
        }
    }
}
