namespace GezginSaticiProblemi
{
    partial class Gezgin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gezgin));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tb1 = new System.Windows.Forms.TabPage();
            this.openCityListButton = new System.Windows.Forms.Button();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTekrar = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTur = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSehir = new System.Windows.Forms.ToolStripStatusLabel();
            this.ClearCity = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDurum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.randomSeedTextBox = new System.Windows.Forms.TextBox();
            this.CloseCityOddsTextBox = new System.Windows.Forms.TextBox();
            this.NumberCloseCitiesTextBox = new System.Windows.Forms.TextBox();
            this.maxGenerationTextBox = new System.Windows.Forms.TextBox();
            this.groupSizeTextBox = new System.Windows.Forms.TextBox();
            this.mutationTextBox = new System.Windows.Forms.TextBox();
            this.populationSizeTextBox = new System.Windows.Forms.TextBox();
            this.picture = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tb1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tb1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(973, 494);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Tag = "";
            // 
            // tb1
            // 
            this.tb1.Controls.Add(this.openCityListButton);
            this.tb1.Controls.Add(this.selectFileButton);
            this.tb1.Controls.Add(this.statusStrip1);
            this.tb1.Controls.Add(this.ClearCity);
            this.tb1.Controls.Add(this.Start);
            this.tb1.Controls.Add(this.label7);
            this.tb1.Controls.Add(this.label6);
            this.tb1.Controls.Add(this.label5);
            this.tb1.Controls.Add(this.lblDurum);
            this.tb1.Controls.Add(this.label4);
            this.tb1.Controls.Add(this.label3);
            this.tb1.Controls.Add(this.label2);
            this.tb1.Controls.Add(this.label1);
            this.tb1.Controls.Add(this.randomSeedTextBox);
            this.tb1.Controls.Add(this.CloseCityOddsTextBox);
            this.tb1.Controls.Add(this.NumberCloseCitiesTextBox);
            this.tb1.Controls.Add(this.maxGenerationTextBox);
            this.tb1.Controls.Add(this.groupSizeTextBox);
            this.tb1.Controls.Add(this.mutationTextBox);
            this.tb1.Controls.Add(this.populationSizeTextBox);
            this.tb1.Controls.Add(this.picture);
            this.tb1.Location = new System.Drawing.Point(4, 22);
            this.tb1.Name = "tb1";
            this.tb1.Padding = new System.Windows.Forms.Padding(3);
            this.tb1.Size = new System.Drawing.Size(965, 468);
            this.tb1.TabIndex = 0;
            this.tb1.Text = "Gezgin Satıcı Problemi";
            this.tb1.Click += new System.EventHandler(this.tb1_Click);
            // 
            // openCityListButton
            // 
            this.openCityListButton.Location = new System.Drawing.Point(6, 345);
            this.openCityListButton.Name = "openCityListButton";
            this.openCityListButton.Size = new System.Drawing.Size(120, 23);
            this.openCityListButton.TabIndex = 7;
            this.openCityListButton.Text = "Şehir Listesi Yükle";
            this.openCityListButton.UseVisualStyleBackColor = true;
            this.openCityListButton.Click += new System.EventHandler(this.openCityListButton_Click);
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(6, 316);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(120, 23);
            this.selectFileButton.TabIndex = 6;
            this.selectFileButton.Text = "Arkaplan Yükle";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblTekrar,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2,
            this.lblTur,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5,
            this.lblSehir});
            this.statusStrip1.Location = new System.Drawing.Point(3, 443);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(959, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(103, 17);
            this.toolStripStatusLabel1.Text = "Tekrarlama Sayısı :";
            // 
            // lblTekrar
            // 
            this.lblTekrar.Name = "lblTekrar";
            this.lblTekrar.Size = new System.Drawing.Size(71, 17);
            this.lblTekrar.Text = "Tekrar Sayısı";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabel3.Text = "||";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(108, 17);
            this.toolStripStatusLabel2.Text = "Son Tur Uzunluğu :";
            // 
            // lblTur
            // 
            this.lblTur.Name = "lblTur";
            this.lblTur.Size = new System.Drawing.Size(57, 17);
            this.lblTur.Text = "Tur Sayısı";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(13, 17);
            this.toolStripStatusLabel4.Text = "||";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(111, 17);
            this.toolStripStatusLabel5.Text = "Seçilen Şehir Sayısı :";
            // 
            // lblSehir
            // 
            this.lblSehir.Name = "lblSehir";
            this.lblSehir.Size = new System.Drawing.Size(33, 17);
            this.lblSehir.Text = "Şehir";
            // 
            // ClearCity
            // 
            this.ClearCity.Location = new System.Drawing.Point(6, 412);
            this.ClearCity.Name = "ClearCity";
            this.ClearCity.Size = new System.Drawing.Size(120, 23);
            this.ClearCity.TabIndex = 3;
            this.ClearCity.Text = "Şehirleri Temizle";
            this.ClearCity.UseVisualStyleBackColor = true;
            this.ClearCity.Click += new System.EventHandler(this.ClearCity_Click);
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(6, 383);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(120, 23);
            this.Start.TabIndex = 3;
            this.Start.Text = "Uygulamayı Başlat";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Gezgin_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Rastgele Nesil";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Yakın Şehir Olasılığı %";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Yakın Şehir Sayısı";
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Location = new System.Drawing.Point(151, 431);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(0, 13);
            this.lblDurum.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Maksimum Nesi Sayısı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Grup Büyüklüğü";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mutasyon %";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Populasyon Büyüklüğü";
            // 
            // randomSeedTextBox
            // 
            this.randomSeedTextBox.Location = new System.Drawing.Point(6, 280);
            this.randomSeedTextBox.Name = "randomSeedTextBox";
            this.randomSeedTextBox.Size = new System.Drawing.Size(120, 20);
            this.randomSeedTextBox.TabIndex = 1;
            this.randomSeedTextBox.Text = "0";
            // 
            // CloseCityOddsTextBox
            // 
            this.CloseCityOddsTextBox.Location = new System.Drawing.Point(6, 238);
            this.CloseCityOddsTextBox.Name = "CloseCityOddsTextBox";
            this.CloseCityOddsTextBox.Size = new System.Drawing.Size(120, 20);
            this.CloseCityOddsTextBox.TabIndex = 1;
            this.CloseCityOddsTextBox.Text = "90";
            // 
            // NumberCloseCitiesTextBox
            // 
            this.NumberCloseCitiesTextBox.Location = new System.Drawing.Point(6, 196);
            this.NumberCloseCitiesTextBox.Name = "NumberCloseCitiesTextBox";
            this.NumberCloseCitiesTextBox.Size = new System.Drawing.Size(120, 20);
            this.NumberCloseCitiesTextBox.TabIndex = 1;
            this.NumberCloseCitiesTextBox.Text = "5";
            // 
            // maxGenerationTextBox
            // 
            this.maxGenerationTextBox.Location = new System.Drawing.Point(6, 154);
            this.maxGenerationTextBox.Name = "maxGenerationTextBox";
            this.maxGenerationTextBox.Size = new System.Drawing.Size(120, 20);
            this.maxGenerationTextBox.TabIndex = 1;
            this.maxGenerationTextBox.Text = "10000000";
            // 
            // groupSizeTextBox
            // 
            this.groupSizeTextBox.Location = new System.Drawing.Point(6, 112);
            this.groupSizeTextBox.Name = "groupSizeTextBox";
            this.groupSizeTextBox.Size = new System.Drawing.Size(120, 20);
            this.groupSizeTextBox.TabIndex = 1;
            this.groupSizeTextBox.Text = "5";
            // 
            // mutationTextBox
            // 
            this.mutationTextBox.Location = new System.Drawing.Point(6, 70);
            this.mutationTextBox.Name = "mutationTextBox";
            this.mutationTextBox.Size = new System.Drawing.Size(120, 20);
            this.mutationTextBox.TabIndex = 1;
            this.mutationTextBox.Text = "3";
            // 
            // populationSizeTextBox
            // 
            this.populationSizeTextBox.Location = new System.Drawing.Point(6, 28);
            this.populationSizeTextBox.Name = "populationSizeTextBox";
            this.populationSizeTextBox.Size = new System.Drawing.Size(120, 20);
            this.populationSizeTextBox.TabIndex = 1;
            this.populationSizeTextBox.Text = "10000";
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.Color.Lavender;
            this.picture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picture.Location = new System.Drawing.Point(132, 14);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(811, 414);
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            this.picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
            // 
            // Gezgin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 494);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Gezgin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Genetik Algoritmalar - Gezgin Satıcı Problemi";
            this.Load += new System.EventHandler(this.Gezgin_Load);
            this.tabControl1.ResumeLayout(false);
            this.tb1.ResumeLayout(false);
            this.tb1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tb1;
        private System.Windows.Forms.Button ClearCity;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox randomSeedTextBox;
        private System.Windows.Forms.TextBox CloseCityOddsTextBox;
        private System.Windows.Forms.TextBox NumberCloseCitiesTextBox;
        private System.Windows.Forms.TextBox maxGenerationTextBox;
        private System.Windows.Forms.TextBox groupSizeTextBox;
        private System.Windows.Forms.TextBox mutationTextBox;
        private System.Windows.Forms.TextBox populationSizeTextBox;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblTekrar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblTur;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel lblSehir;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.Button openCityListButton;
        private System.Windows.Forms.Button selectFileButton;
    }
}

