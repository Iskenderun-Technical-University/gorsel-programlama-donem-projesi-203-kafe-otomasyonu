﻿namespace Kafe_Otomasyonu
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.texBox_eskisifre = new System.Windows.Forms.TextBox();
            this.textBox_yenisifre = new System.Windows.Forms.TextBox();
            this.textBox_yenisifretekrar = new System.Windows.Forms.TextBox();
            this.textBox_captcha = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.Label_captcha = new System.Windows.Forms.Label();
            this.Label_mesaj = new System.Windows.Forms.Label();
            this.Label_sifreDegistir = new System.Windows.Forms.Label();
            this.Label_iptal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // texBox_eskisifre
            // 
            this.texBox_eskisifre.Location = new System.Drawing.Point(275, 191);
            this.texBox_eskisifre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.texBox_eskisifre.Name = "texBox_eskisifre";
            this.texBox_eskisifre.Size = new System.Drawing.Size(208, 22);
            this.texBox_eskisifre.TabIndex = 0;
            // 
            // textBox_yenisifre
            // 
            this.textBox_yenisifre.Location = new System.Drawing.Point(275, 244);
            this.textBox_yenisifre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_yenisifre.Name = "textBox_yenisifre";
            this.textBox_yenisifre.Size = new System.Drawing.Size(208, 22);
            this.textBox_yenisifre.TabIndex = 1;
            // 
            // textBox_yenisifretekrar
            // 
            this.textBox_yenisifretekrar.Location = new System.Drawing.Point(275, 300);
            this.textBox_yenisifretekrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_yenisifretekrar.Name = "textBox_yenisifretekrar";
            this.textBox_yenisifretekrar.Size = new System.Drawing.Size(208, 22);
            this.textBox_yenisifretekrar.TabIndex = 2;
            // 
            // textBox_captcha
            // 
            this.textBox_captcha.Location = new System.Drawing.Point(387, 354);
            this.textBox_captcha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_captcha.Name = "textBox_captcha";
            this.textBox_captcha.Size = new System.Drawing.Size(96, 22);
            this.textBox_captcha.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(597, 48);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(35, 33);
            this.button3.TabIndex = 6;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Label_captcha
            // 
            this.Label_captcha.AutoSize = true;
            this.Label_captcha.Location = new System.Drawing.Point(305, 363);
            this.Label_captcha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_captcha.Name = "Label_captcha";
            this.Label_captcha.Size = new System.Drawing.Size(44, 16);
            this.Label_captcha.TabIndex = 7;
            this.Label_captcha.Text = "label1";
            this.Label_captcha.Click += new System.EventHandler(this.Label_captcha_Click);
            // 
            // Label_mesaj
            // 
            this.Label_mesaj.AutoSize = true;
            this.Label_mesaj.BackColor = System.Drawing.Color.Bisque;
            this.Label_mesaj.Location = new System.Drawing.Point(460, 417);
            this.Label_mesaj.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_mesaj.Name = "Label_mesaj";
            this.Label_mesaj.Size = new System.Drawing.Size(44, 16);
            this.Label_mesaj.TabIndex = 8;
            this.Label_mesaj.Text = "label2";
            // 
            // Label_sifreDegistir
            // 
            this.Label_sifreDegistir.AutoSize = true;
            this.Label_sifreDegistir.BackColor = System.Drawing.Color.Transparent;
            this.Label_sifreDegistir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label_sifreDegistir.Location = new System.Drawing.Point(305, 417);
            this.Label_sifreDegistir.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_sifreDegistir.Name = "Label_sifreDegistir";
            this.Label_sifreDegistir.Size = new System.Drawing.Size(112, 16);
            this.Label_sifreDegistir.TabIndex = 9;
            this.Label_sifreDegistir.Text = "ŞİFRE DEĞİŞTİR";
            this.Label_sifreDegistir.Click += new System.EventHandler(this.label1_Click);
            // 
            // Label_iptal
            // 
            this.Label_iptal.AutoSize = true;
            this.Label_iptal.BackColor = System.Drawing.Color.Transparent;
            this.Label_iptal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label_iptal.Location = new System.Drawing.Point(344, 470);
            this.Label_iptal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label_iptal.Name = "Label_iptal";
            this.Label_iptal.Size = new System.Drawing.Size(44, 16);
            this.Label_iptal.TabIndex = 10;
            this.Label_iptal.Text = "İPTAL";
            this.Label_iptal.Click += new System.EventHandler(this.Label_iptal_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.BackgroundImage = global::Kafe_Otomasyonu.Properties.Resources.WhatsApp_Image_2022_12_12_at_23_49_10;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(711, 645);
            this.Controls.Add(this.Label_iptal);
            this.Controls.Add(this.Label_sifreDegistir);
            this.Controls.Add(this.Label_mesaj);
            this.Controls.Add(this.Label_captcha);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox_captcha);
            this.Controls.Add(this.textBox_yenisifretekrar);
            this.Controls.Add(this.textBox_yenisifre);
            this.Controls.Add(this.texBox_eskisifre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox texBox_eskisifre;
        private System.Windows.Forms.TextBox textBox_yenisifre;
        private System.Windows.Forms.TextBox textBox_yenisifretekrar;
        private System.Windows.Forms.TextBox textBox_captcha;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label Label_captcha;
        private System.Windows.Forms.Label Label_mesaj;
        private System.Windows.Forms.Label Label_sifreDegistir;
        private System.Windows.Forms.Label Label_iptal;
    }
}