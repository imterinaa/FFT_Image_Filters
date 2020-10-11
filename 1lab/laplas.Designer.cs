namespace lab1
{
    partial class laplas
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.laplasian = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown1.Location = new System.Drawing.Point(56, 12);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(47, 20);
            this.numericUpDown1.TabIndex = 38;
            // 
            // laplasian
            // 
            this.laplasian.BackColor = System.Drawing.SystemColors.Window;
            this.laplasian.Cursor = System.Windows.Forms.Cursors.Hand;
            this.laplasian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.laplasian.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.laplasian.ForeColor = System.Drawing.SystemColors.Desktop;
            this.laplasian.Location = new System.Drawing.Point(32, 55);
            this.laplasian.Name = "laplasian";
            this.laplasian.Size = new System.Drawing.Size(108, 54);
            this.laplasian.TabIndex = 37;
            this.laplasian.Text = "Применить";
            this.laplasian.UseVisualStyleBackColor = false;
            this.laplasian.Click += new System.EventHandler(this.laplasian_Click);
            // 
            // laplas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 121);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.laplasian);
            this.Name = "laplas";
            this.Text = "laplas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.laplas_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button laplasian;
    }
}