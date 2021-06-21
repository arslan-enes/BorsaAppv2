namespace BorsaAppv2
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fiyat_txtbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.miktar_txtbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UrunAd_txtbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(242, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "Hesaba Ekle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Eklencek Fiyat Birim:";
            // 
            // fiyat_txtbox
            // 
            this.fiyat_txtbox.Location = new System.Drawing.Point(227, 148);
            this.fiyat_txtbox.Name = "fiyat_txtbox";
            this.fiyat_txtbox.Size = new System.Drawing.Size(100, 22);
            this.fiyat_txtbox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Eklenecek Miktar: ";
            // 
            // miktar_txtbox
            // 
            this.miktar_txtbox.Location = new System.Drawing.Point(227, 103);
            this.miktar_txtbox.Name = "miktar_txtbox";
            this.miktar_txtbox.Size = new System.Drawing.Size(100, 22);
            this.miktar_txtbox.TabIndex = 2;
            this.miktar_txtbox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ürün Adı: ";
            // 
            // UrunAd_txtbox
            // 
            this.UrunAd_txtbox.Location = new System.Drawing.Point(227, 60);
            this.UrunAd_txtbox.Name = "UrunAd_txtbox";
            this.UrunAd_txtbox.Size = new System.Drawing.Size(100, 22);
            this.UrunAd_txtbox.TabIndex = 2;
            this.UrunAd_txtbox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 372);
            this.Controls.Add(this.UrunAd_txtbox);
            this.Controls.Add(this.miktar_txtbox);
            this.Controls.Add(this.fiyat_txtbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fiyat_txtbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox miktar_txtbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox UrunAd_txtbox;
    }
}

