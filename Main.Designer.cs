﻿namespace ROV_UI
{
    partial class Main
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.baglan = new System.Windows.Forms.Button();
            this.baglantiyi_kes = new System.Windows.Forms.Button();
            this.desktop_listesi = new System.Windows.Forms.Button();
            this.dosya_gonder = new System.Windows.Forms.Button();
            this.config_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ipadress_label = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.username_label = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.TextBox();
            this.terminal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.komutu_calistir = new System.Windows.Forms.Button();
            this.komut_satiri = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.Dosya_Yolu_Degistir = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.SuspendLayout();
            // 
            // baglan
            // 
            this.baglan.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.baglan.Location = new System.Drawing.Point(12, 12);
            this.baglan.Name = "baglan";
            this.baglan.Size = new System.Drawing.Size(90, 28);
            this.baglan.TabIndex = 0;
            this.baglan.Text = "Bağlan";
            this.baglan.UseVisualStyleBackColor = true;
            this.baglan.Click += new System.EventHandler(this.baglan_Click);
            // 
            // baglantiyi_kes
            // 
            this.baglantiyi_kes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.baglantiyi_kes.Location = new System.Drawing.Point(12, 46);
            this.baglantiyi_kes.Name = "baglantiyi_kes";
            this.baglantiyi_kes.Size = new System.Drawing.Size(90, 41);
            this.baglantiyi_kes.TabIndex = 0;
            this.baglantiyi_kes.Text = "Bağlantıyı Kes";
            this.baglantiyi_kes.UseVisualStyleBackColor = true;
            this.baglantiyi_kes.Click += new System.EventHandler(this.baglantiyi_kes_Click);
            // 
            // desktop_listesi
            // 
            this.desktop_listesi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.desktop_listesi.Location = new System.Drawing.Point(12, 93);
            this.desktop_listesi.Name = "desktop_listesi";
            this.desktop_listesi.Size = new System.Drawing.Size(90, 41);
            this.desktop_listesi.TabIndex = 0;
            this.desktop_listesi.Text = "Desktop Listesi";
            this.desktop_listesi.UseVisualStyleBackColor = true;
            this.desktop_listesi.Click += new System.EventHandler(this.desktop_listesi_Click);
            // 
            // dosya_gonder
            // 
            this.dosya_gonder.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dosya_gonder.Location = new System.Drawing.Point(12, 140);
            this.dosya_gonder.Name = "dosya_gonder";
            this.dosya_gonder.Size = new System.Drawing.Size(90, 41);
            this.dosya_gonder.TabIndex = 0;
            this.dosya_gonder.Text = "Dosya Gönder";
            this.dosya_gonder.UseVisualStyleBackColor = true;
            this.dosya_gonder.Click += new System.EventHandler(this.dosya_gonder_Click);
            // 
            // config_button
            // 
            this.config_button.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.config_button.Location = new System.Drawing.Point(12, 187);
            this.config_button.Name = "config_button";
            this.config_button.Size = new System.Drawing.Size(124, 41);
            this.config_button.TabIndex = 0;
            this.config_button.Text = "Konfigürasyon Ekranı";
            this.config_button.UseVisualStyleBackColor = true;
            this.config_button.Click += new System.EventHandler(this.config_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(150, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP Adresi";
            // 
            // ipadress_label
            // 
            this.ipadress_label.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ipadress_label.Location = new System.Drawing.Point(220, 15);
            this.ipadress_label.Name = "ipadress_label";
            this.ipadress_label.Size = new System.Drawing.Size(100, 22);
            this.ipadress_label.TabIndex = 2;
            this.ipadress_label.TextChanged += new System.EventHandler(this.ipadress_label_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(126, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kullanıcı Adı";
            // 
            // username_label
            // 
            this.username_label.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.username_label.Location = new System.Drawing.Point(220, 43);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(100, 22);
            this.username_label.TabIndex = 2;
            this.username_label.TextChanged += new System.EventHandler(this.username_label_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(177, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Şifre";
            // 
            // password_label
            // 
            this.password_label.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.password_label.Location = new System.Drawing.Point(220, 71);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(100, 22);
            this.password_label.TabIndex = 2;
            this.password_label.TextChanged += new System.EventHandler(this.password_label_TextChanged);
            // 
            // terminal
            // 
            this.terminal.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.terminal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.terminal.ForeColor = System.Drawing.Color.Lime;
            this.terminal.Location = new System.Drawing.Point(326, 31);
            this.terminal.Multiline = true;
            this.terminal.Name = "terminal";
            this.terminal.ReadOnly = true;
            this.terminal.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.terminal.Size = new System.Drawing.Size(359, 345);
            this.terminal.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(326, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Terminal";
            // 
            // komutu_calistir
            // 
            this.komutu_calistir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.komutu_calistir.Location = new System.Drawing.Point(326, 410);
            this.komutu_calistir.Name = "komutu_calistir";
            this.komutu_calistir.Size = new System.Drawing.Size(359, 28);
            this.komutu_calistir.TabIndex = 0;
            this.komutu_calistir.Text = "Komutu Çalıştır";
            this.komutu_calistir.UseVisualStyleBackColor = true;
            this.komutu_calistir.Click += new System.EventHandler(this.komutu_calistir_Click);
            // 
            // komut_satiri
            // 
            this.komut_satiri.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.komut_satiri.ForeColor = System.Drawing.Color.Blue;
            this.komut_satiri.Location = new System.Drawing.Point(326, 382);
            this.komut_satiri.Name = "komut_satiri";
            this.komut_satiri.Size = new System.Drawing.Size(359, 22);
            this.komut_satiri.TabIndex = 2;
            this.komut_satiri.Text = "python Desktop/rx.py";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 341);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(154, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(9, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Batarya seviyesi";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(241, 99);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 261);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(154, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(9, 297);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 32);
            this.label6.TabIndex = 1;
            this.label6.Text = "   STM32-RPI \r\nbağlantı durumu";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(129, 294);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 35);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(175, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 32);
            this.label7.TabIndex = 1;
            this.label7.Text = "Bağlantı\r\nDurumu";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(178, 165);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(131, 137);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(170, 387);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(40, 40);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 7;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(216, 387);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(40, 40);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 7;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(262, 387);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(40, 40);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 7;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(170, 341);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(40, 40);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 7;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(216, 341);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(40, 40);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 7;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(262, 341);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(40, 40);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 7;
            this.pictureBox10.TabStop = false;
            // 
            // Dosya_Yolu_Degistir
            // 
            this.Dosya_Yolu_Degistir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Dosya_Yolu_Degistir.Location = new System.Drawing.Point(108, 140);
            this.Dosya_Yolu_Degistir.Name = "Dosya_Yolu_Degistir";
            this.Dosya_Yolu_Degistir.Size = new System.Drawing.Size(28, 41);
            this.Dosya_Yolu_Degistir.TabIndex = 0;
            this.Dosya_Yolu_Degistir.Text = "//";
            this.Dosya_Yolu_Degistir.UseVisualStyleBackColor = true;
            this.Dosya_Yolu_Degistir.Click += new System.EventHandler(this.dosya_yolu_degistir_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(177, 313);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Raspberry Pi °C";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(697, 450);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.terminal);
            this.Controls.Add(this.komut_satiri);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ipadress_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.config_button);
            this.Controls.Add(this.Dosya_Yolu_Degistir);
            this.Controls.Add(this.dosya_gonder);
            this.Controls.Add(this.desktop_listesi);
            this.Controls.Add(this.baglantiyi_kes);
            this.Controls.Add(this.komutu_calistir);
            this.Controls.Add(this.baglan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SÜ MYS PİRİ REİS ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button baglan;
        private System.Windows.Forms.Button baglantiyi_kes;
        private System.Windows.Forms.Button desktop_listesi;
        private System.Windows.Forms.Button dosya_gonder;
        private System.Windows.Forms.Button config_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ipadress_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox username_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox password_label;
        private System.Windows.Forms.TextBox terminal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button komutu_calistir;
        private System.Windows.Forms.TextBox komut_satiri;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Button Dosya_Yolu_Degistir;
        private System.Windows.Forms.Label label8;
    }
}

