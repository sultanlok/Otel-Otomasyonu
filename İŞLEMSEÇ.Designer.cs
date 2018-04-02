namespace otel_otomasyonu
{
    partial class İŞLEMSEÇ
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.Location = new System.Drawing.Point(59, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 70);
            this.button1.TabIndex = 0;
            this.button1.Text = "KAYIT/REZERVASYON     İŞLEMLERİ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Silver;
            this.button2.Location = new System.Drawing.Point(59, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 68);
            this.button2.TabIndex = 1;
            this.button2.Text = "GÜNCELLEME/ÇIKIŞ      İŞLEMLERİ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // İŞLEMSEÇ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(327, 284);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "İŞLEMSEÇ";
            this.Text = "İŞLEMSEÇ";
            this.Load += new System.EventHandler(this.İŞLEMSEÇ_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}