﻿namespace Kafe_Otomasyonu
{
    partial class Form2
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
            this.Sifre = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.KullaniciAdi = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Sifre
            // 
            this.Sifre.Location = new System.Drawing.Point(161, 560);
            this.Sifre.Multiline = true;
            this.Sifre.Name = "Sifre";
            this.Sifre.PasswordChar = '*';
            this.Sifre.Size = new System.Drawing.Size(255, 28);
            this.Sifre.TabIndex = 2;
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(161, 509);
            this.Email.Multiline = true;
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(255, 29);
            this.Email.TabIndex = 5;
            this.Email.TextChanged += new System.EventHandler(this.Email_TextChanged);
            // 
            // KullaniciAdi
            // 
            this.KullaniciAdi.Location = new System.Drawing.Point(161, 455);
            this.KullaniciAdi.Multiline = true;
            this.KullaniciAdi.Name = "KullaniciAdi";
            this.KullaniciAdi.Size = new System.Drawing.Size(255, 32);
            this.KullaniciAdi.TabIndex = 6;
            this.KullaniciAdi.TextChanged += new System.EventHandler(this.KullaniciAdi_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(161, 613);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(255, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(234, 689);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Kayıt Ol";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(509, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 20);
            this.button2.TabIndex = 9;
            this.button2.Text = "x";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Kafe_Otomasyonu.Properties.Resources.login1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(543, 734);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.KullaniciAdi);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.Sifre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Sifre;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.TextBox KullaniciAdi;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}