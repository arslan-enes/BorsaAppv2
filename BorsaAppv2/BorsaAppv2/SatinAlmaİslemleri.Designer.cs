namespace BorsaAppv2
{
    partial class SatinAlmaİslemleri
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
            this.UrunAd_txtbox = new System.Windows.Forms.TextBox();
            this.miktar_txtbox = new System.Windows.Forms.TextBox();
            this.fiyat_txtbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // UrunAd_txtbox
            // 
            this.UrunAd_txtbox.Location = new System.Drawing.Point(326, 88);
            this.UrunAd_txtbox.Name = "UrunAd_txtbox";
            this.UrunAd_txtbox.Size = new System.Drawing.Size(100, 22);
            this.UrunAd_txtbox.TabIndex = 8;
            // 
            // miktar_txtbox
            // 
            this.miktar_txtbox.Location = new System.Drawing.Point(326, 131);
            this.miktar_txtbox.Name = "miktar_txtbox";
            this.miktar_txtbox.Size = new System.Drawing.Size(100, 22);
            this.miktar_txtbox.TabIndex = 9;
            // 
            // fiyat_txtbox
            // 
            this.fiyat_txtbox.Location = new System.Drawing.Point(326, 176);
            this.fiyat_txtbox.Name = "fiyat_txtbox";
            this.fiyat_txtbox.Size = new System.Drawing.Size(100, 22);
            this.fiyat_txtbox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ürün Adı: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Alınacak Miktar: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Alınacak Fiyat Birim:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(242, 49);
            this.button1.TabIndex = 3;
            this.button1.Text = "Satın Al";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SatinAlmaİslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 458);
            this.Controls.Add(this.UrunAd_txtbox);
            this.Controls.Add(this.miktar_txtbox);
            this.Controls.Add(this.fiyat_txtbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Name = "SatinAlmaİslemleri";
            this.Text = "SatinAlmaİslemleri";
            this.Load += new System.EventHandler(this.SatinAlmaİslemleri_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UrunAd_txtbox;
        private System.Windows.Forms.TextBox miktar_txtbox;
        private System.Windows.Forms.TextBox fiyat_txtbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}