namespace lab1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.file = new System.Windows.Forms.ToolStripDropDownButton();
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.filt = new System.Windows.Forms.ToolStripDropDownButton();
            this.Furie = new System.Windows.Forms.ToolStripMenuItem();
            this.LF = new System.Windows.Forms.ToolStripMenuItem();
            this.lowfrequencyIdeal = new System.Windows.Forms.ToolStripMenuItem();
            this.LowFrButt = new System.Windows.Forms.ToolStripMenuItem();
            this.GausLow = new System.Windows.Forms.ToolStripMenuItem();
            this.HightFr = new System.Windows.Forms.ToolStripMenuItem();
            this.IdealHight = new System.Windows.Forms.ToolStripMenuItem();
            this.hightFrButt = new System.Windows.Forms.ToolStripMenuItem();
            this.GaussHight = new System.Windows.Forms.ToolStripMenuItem();
            this.laplas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.gaussNoise = new System.Windows.Forms.ToolStripMenuItem();
            this.RaleyNoise = new System.Windows.Forms.ToolStripMenuItem();
            this.ErlangNoise = new System.Windows.Forms.ToolStripMenuItem();
            this.ExpNoise = new System.Windows.Forms.ToolStripMenuItem();
            this.UniformNoise = new System.Windows.Forms.ToolStripMenuItem();
            this.Global_equalization = new System.Windows.Forms.ToolStripMenuItem();
            this.localEqualization = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.ImpulsNoise = new System.Windows.Forms.ToolStripMenuItem();
            this.Smoothing = new System.Windows.Forms.ToolStripMenuItem();
            this.PoryadStat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file,
            this.filt,
            this.toolStripDropDownButton1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(784, 22);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // file
            // 
            this.file.BackColor = System.Drawing.SystemColors.Control;
            this.file.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile,
            this.saveFile});
            this.file.Image = ((System.Drawing.Image)(resources.GetObject("file.Image")));
            this.file.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(49, 19);
            this.file.Text = "Файл";
            this.file.ToolTipText = "File";
            // 
            // openFile
            // 
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(162, 22);
            this.openFile.Text = "Открыть файл...";
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // saveFile
            // 
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(162, 22);
            this.saveFile.Text = "Сохранить как...";
            this.saveFile.Click += new System.EventHandler(this.saveFile_Click);
            // 
            // filt
            // 
            this.filt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.filt.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Furie,
            this.Smoothing,
            this.PoryadStat});
            this.filt.Image = ((System.Drawing.Image)(resources.GetObject("filt.Image")));
            this.filt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.filt.Name = "filt";
            this.filt.Size = new System.Drawing.Size(70, 19);
            this.filt.Text = "Фильтры";
            this.filt.ToolTipText = "filt";
            // 
            // Furie
            // 
            this.Furie.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LF,
            this.HightFr,
            this.laplas});
            this.Furie.Name = "Furie";
            this.Furie.Size = new System.Drawing.Size(206, 22);
            this.Furie.Text = "FFT";
            // 
            // LF
            // 
            this.LF.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lowfrequencyIdeal,
            this.LowFrButt,
            this.GausLow});
            this.LF.Name = "LF";
            this.LF.Size = new System.Drawing.Size(180, 22);
            this.LF.Text = "Низкие частоты";
            // 
            // lowfrequencyIdeal
            // 
            this.lowfrequencyIdeal.Name = "lowfrequencyIdeal";
            this.lowfrequencyIdeal.Size = new System.Drawing.Size(181, 22);
            this.lowfrequencyIdeal.Text = "Идеальный фильтр";
            this.lowfrequencyIdeal.Click += new System.EventHandler(this.lowfrequencyIdeal_Click);
            // 
            // LowFrButt
            // 
            this.LowFrButt.Name = "LowFrButt";
            this.LowFrButt.Size = new System.Drawing.Size(181, 22);
            this.LowFrButt.Text = "Баттерворт";
            this.LowFrButt.Click += new System.EventHandler(this.LowFrButt_Click);
            // 
            // GausLow
            // 
            this.GausLow.Name = "GausLow";
            this.GausLow.Size = new System.Drawing.Size(181, 22);
            this.GausLow.Text = "Гаусс";
            this.GausLow.Click += new System.EventHandler(this.GausLow_Click);
            // 
            // HightFr
            // 
            this.HightFr.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IdealHight,
            this.hightFrButt,
            this.GaussHight});
            this.HightFr.Name = "HightFr";
            this.HightFr.Size = new System.Drawing.Size(180, 22);
            this.HightFr.Text = "Высокие частоты";
            // 
            // IdealHight
            // 
            this.IdealHight.Name = "IdealHight";
            this.IdealHight.Size = new System.Drawing.Size(137, 22);
            this.IdealHight.Text = "Идеальный";
            this.IdealHight.Click += new System.EventHandler(this.IdealHight_Click);
            // 
            // hightFrButt
            // 
            this.hightFrButt.Name = "hightFrButt";
            this.hightFrButt.Size = new System.Drawing.Size(137, 22);
            this.hightFrButt.Text = "Баттерворт";
            this.hightFrButt.Click += new System.EventHandler(this.hightFrButt_Click);
            // 
            // GaussHight
            // 
            this.GaussHight.Name = "GaussHight";
            this.GaussHight.Size = new System.Drawing.Size(137, 22);
            this.GaussHight.Text = "Гаусс";
            this.GaussHight.Click += new System.EventHandler(this.GaussHight_Click);
            // 
            // laplas
            // 
            this.laplas.Name = "laplas";
            this.laplas.Size = new System.Drawing.Size(180, 22);
            this.laplas.Text = "Лапласиан";
            this.laplas.Click += new System.EventHandler(this.laplas_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gaussNoise,
            this.RaleyNoise,
            this.ErlangNoise,
            this.ExpNoise,
            this.UniformNoise,
            this.ImpulsNoise});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(55, 19);
            this.toolStripDropDownButton1.Text = "Шумы";
            // 
            // gaussNoise
            // 
            this.gaussNoise.Name = "gaussNoise";
            this.gaussNoise.Size = new System.Drawing.Size(212, 22);
            this.gaussNoise.Text = "Гауссов шум";
            this.gaussNoise.Click += new System.EventHandler(this.gaussNoise_Click);
            // 
            // RaleyNoise
            // 
            this.RaleyNoise.Name = "RaleyNoise";
            this.RaleyNoise.Size = new System.Drawing.Size(212, 22);
            this.RaleyNoise.Text = "Шум Рэлея";
            this.RaleyNoise.Click += new System.EventHandler(this.RaleyNoise_Click);
            // 
            // ErlangNoise
            // 
            this.ErlangNoise.Name = "ErlangNoise";
            this.ErlangNoise.Size = new System.Drawing.Size(212, 22);
            this.ErlangNoise.Text = "Шум Эрланга";
            this.ErlangNoise.Click += new System.EventHandler(this.ErlangNoise_Click);
            // 
            // ExpNoise
            // 
            this.ExpNoise.Name = "ExpNoise";
            this.ExpNoise.Size = new System.Drawing.Size(212, 22);
            this.ExpNoise.Text = "Экспоненциальный шум";
            this.ExpNoise.Click += new System.EventHandler(this.ExpNoise_Click);
            // 
            // UniformNoise
            // 
            this.UniformNoise.Name = "UniformNoise";
            this.UniformNoise.Size = new System.Drawing.Size(212, 22);
            this.UniformNoise.Text = "Равномерный шум";
            this.UniformNoise.Click += new System.EventHandler(this.UniformNoise_Click);
            // 
            // Global_equalization
            // 
            this.Global_equalization.Name = "Global_equalization";
            this.Global_equalization.Size = new System.Drawing.Size(32, 19);
            // 
            // localEqualization
            // 
            this.localEqualization.Name = "localEqualization";
            this.localEqualization.Size = new System.Drawing.Size(32, 19);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(386, 534);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 22);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(770, 515);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 540);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(395, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(386, 534);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "";
            // 
            // ImpulsNoise
            // 
            this.ImpulsNoise.Name = "ImpulsNoise";
            this.ImpulsNoise.Size = new System.Drawing.Size(212, 22);
            this.ImpulsNoise.Text = "Импульсный шум";
            this.ImpulsNoise.Click += new System.EventHandler(this.ImpulsNoise_Click);
            // 
            // Smoothing
            // 
            this.Smoothing.Name = "Smoothing";
            this.Smoothing.Size = new System.Drawing.Size(206, 22);
            this.Smoothing.Text = "Сглаживание";
            this.Smoothing.Click += new System.EventHandler(this.Smoothing_Click);
            // 
            // PoryadStat
            // 
            this.PoryadStat.Name = "PoryadStat";
            this.PoryadStat.Size = new System.Drawing.Size(206, 22);
            this.PoryadStat.Text = "Порядковые статистики";
            this.PoryadStat.Click += new System.EventHandler(this.PoryadStat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Обработка изображений";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton file;
        private System.Windows.Forms.ToolStripMenuItem openFile;
        private System.Windows.Forms.ToolStripMenuItem saveFile;
        private System.Windows.Forms.ToolStripDropDownButton filt;
        public System.Windows.Forms.ToolStripMenuItem Global_equalization;
        public System.Windows.Forms.ToolStripMenuItem localEqualization;
        private System.Windows.Forms.ToolStripMenuItem Furie;
        private System.Windows.Forms.ToolStripMenuItem LF;
        private System.Windows.Forms.ToolStripMenuItem lowfrequencyIdeal;
        private System.Windows.Forms.ToolStripMenuItem LowFrButt;
        private System.Windows.Forms.ToolStripMenuItem HightFr;
        private System.Windows.Forms.ToolStripMenuItem hightFrButt;
        private System.Windows.Forms.ToolStripMenuItem GausLow;
        private System.Windows.Forms.ToolStripMenuItem GaussHight;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem IdealHight;
        private System.Windows.Forms.ToolStripMenuItem laplas;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem gaussNoise;
        private System.Windows.Forms.ToolStripMenuItem RaleyNoise;
        private System.Windows.Forms.ToolStripMenuItem ErlangNoise;
        private System.Windows.Forms.ToolStripMenuItem ExpNoise;
        private System.Windows.Forms.ToolStripMenuItem UniformNoise;
        private System.Windows.Forms.ToolStripMenuItem ImpulsNoise;
        private System.Windows.Forms.ToolStripMenuItem Smoothing;
        private System.Windows.Forms.ToolStripMenuItem PoryadStat;
    }
}

