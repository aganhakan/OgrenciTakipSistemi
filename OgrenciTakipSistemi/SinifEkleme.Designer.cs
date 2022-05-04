namespace OgrenciTakipSistemi
{
    partial class SinifEkleme
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbSube = new System.Windows.Forms.ComboBox();
            this.CmbSinif = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgwSiniflar = new System.Windows.Forms.DataGridView();
            this.btnSil = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwSiniflar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSil);
            this.groupBox1.Controls.Add(this.btnEkle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CmbSube);
            this.groupBox1.Controls.Add(this.CmbSinif);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 133);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sınıf Ekleme";
            // 
            // btnEkle
            // 
            this.btnEkle.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEkle.FlatAppearance.BorderSize = 3;
            this.btnEkle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnEkle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnEkle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEkle.Location = new System.Drawing.Point(377, 46);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(105, 49);
            this.btnEkle.TabIndex = 5;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Şube:";
            // 
            // CmbSube
            // 
            this.CmbSube.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSube.FormattingEnabled = true;
            this.CmbSube.Location = new System.Drawing.Point(188, 72);
            this.CmbSube.Name = "CmbSube";
            this.CmbSube.Size = new System.Drawing.Size(149, 28);
            this.CmbSube.TabIndex = 3;
            // 
            // CmbSinif
            // 
            this.CmbSinif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSinif.FormattingEnabled = true;
            this.CmbSinif.Location = new System.Drawing.Point(188, 38);
            this.CmbSinif.Name = "CmbSinif";
            this.CmbSinif.Size = new System.Drawing.Size(149, 28);
            this.CmbSinif.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sınıf:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgwSiniflar);
            this.groupBox2.Location = new System.Drawing.Point(12, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(646, 308);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sınıflar";
            // 
            // dgwSiniflar
            // 
            this.dgwSiniflar.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgwSiniflar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwSiniflar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwSiniflar.Location = new System.Drawing.Point(3, 22);
            this.dgwSiniflar.Name = "dgwSiniflar";
            this.dgwSiniflar.ReadOnly = true;
            this.dgwSiniflar.RowHeadersWidth = 51;
            this.dgwSiniflar.RowTemplate.Height = 24;
            this.dgwSiniflar.Size = new System.Drawing.Size(640, 283);
            this.dgwSiniflar.TabIndex = 0;
            // 
            // btnSil
            // 
            this.btnSil.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSil.FlatAppearance.BorderSize = 3;
            this.btnSil.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSil.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSil.Location = new System.Drawing.Point(517, 46);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(105, 49);
            this.btnSil.TabIndex = 6;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // SinifEkleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(670, 471);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SinifEkleme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sınıf Ekleme";
            this.Load += new System.EventHandler(this.SinifEkleme_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwSiniflar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbSube;
        private System.Windows.Forms.ComboBox CmbSinif;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgwSiniflar;
        private System.Windows.Forms.Button btnSil;
    }
}