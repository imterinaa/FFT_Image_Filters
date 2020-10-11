using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lab1
{
    public partial class Recovery : Form
    {
        public Recovery()
        {
            InitializeComponent();
            this.Text = Program.f1.name;
            if (this.Text == "Сглаживание")
            {
                numericUpDown1.Visible = true;
                label10.Visible = true;
            }
            else
            {
                radioButton1.Text = "Медианный";
                radioButton2.Text = "Минимум";
                radioButton2.Location = new Point(132, 91);
                radioButton3.Text = "Максимум";
                radioButton3.Location = new Point(237, 91);
            }
        }

        private void Smoothing_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.f1.Enabled = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value % 2 == 0)
            {
                trackBar1.Value = trackBar1.Value + 1;
            }
            label2.Text = trackBar1.Value.ToString() + "x" + trackBar1.Value.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            numericUpDown1.Enabled = false;
            numericUpDown1.Value = (decimal)0.1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            numericUpDown1.Enabled = false;
            numericUpDown1.Value = (decimal)0.1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = true;
            button1.Enabled = true;
            numericUpDown1.Value = (decimal)0.1;
        }
        private double[,] mask(double[,] mask, int trackbar)
        {
            int n = (trackbar - 1) / 2;
            mask[0, n] = 2;
            for (int i = 1; i < trackbar; i++)
            {
                if (i <= n)
                {
                    mask[i, n] = mask[i - 1, n] * 2;
                }
                else
                {
                    mask[i, n] = mask[i - 1, n] / 2;
                }
            }
            for (int i = 0; i < trackbar; i++)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    mask[i, j] = Math.Round(mask[i, j + 1] / 2);
                    if (mask[i, j] == 0)
                    {
                        mask[i, j] = 1;
                    }
                }

            }
            for (int i = 0; i < trackbar; i++)
            {
                for (int j = n + 1; j < trackbar; j++)
                {
                    mask[i, j] = Math.Round(mask[i, j - 1] / 2);
                    if (mask[i, j] == 0)
                    {
                        mask[i, j] = 1;
                    }
                }

            }
            return mask;
        }
        private double[,] gauss(double[,] mask, int trackbar, double sigma)
        {
            int N = (trackbar - 1) / 2;
            for (int i = 0; i < trackbar; i++)
            {
                for (int j = 0; j < trackbar; j++)
                {
                    mask[i, j] = Math.Exp(((i - N) * (i - N) + (j - N) * (j - N)) * (-1 / (2 * sigma * sigma)));
                }
            }
            return mask;
        }
        public void choose()
        {
            var originalpicture = new Bitmap(Program.f1.pictureBox1.Image);
            double[,] maska = new double[trackBar1.Value, trackBar1.Value];
            if (this.Text == "Сглаживание")
            {
                if (radioButton1.Checked)
                {
                    for (int i = 0; i < trackBar1.Value; i++)
                    {
                        for (int j = 0; j < trackBar1.Value; j++)
                        {
                            maska[i, j] = 1;
                        }
                    }
                    Program.f1.pictureBox2.Image = smoothing(ref originalpicture, trackBar1.Value, maska);
                }
                if (radioButton2.Checked)
                {
                    maska = mask(maska, trackBar1.Value);
                    Program.f1.pictureBox2.Image = smoothing(ref originalpicture, trackBar1.Value, maska);
                }
                if (radioButton3.Checked)
                {
                    maska = gauss(maska, trackBar1.Value, (double)numericUpDown1.Value);
                    Program.f1.pictureBox2.Image = smoothing(ref originalpicture, trackBar1.Value, maska);
                }
            }
            else
            {
                if (radioButton1.Checked)
                {
                    Program.f1.pictureBox2.Image = poryadStat(ref originalpicture, trackBar1.Value, 1);
                }
                if (radioButton2.Checked)
                {
                    Program.f1.pictureBox2.Image = poryadStat(ref originalpicture, trackBar1.Value, 2);
                }
                if (radioButton3.Checked)
                {
                    Program.f1.pictureBox2.Image = poryadStat(ref originalpicture, trackBar1.Value, 3);
                }
            }
           
        }
        public Bitmap smoothing(ref Bitmap original, int size, double[,] mask)
        {
            double sumMask = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    sumMask += mask[i, j];
                }
            }

            int N = (size - 1) / 2;
            int C = 0;
            int m = 0;
            int n = 0;
            BufferedBitmap Origin = new BufferedBitmap(original);
            Origin.Lock();
            Bitmap renderedImage = new Bitmap(original.Width, original.Height);
            for (int x = N; x < original.Width - N; x++)
            {

                for (int y = N; y < original.Height - N; y++)
                {
                    for (int i = x - N; i <= x + N; i++)
                    {
                        for (int j = y - N; j <= y + N; j++)
                        {
                            var pixel = Origin.GetPixel(i, j);
                            C += (int)(pixel.R * mask[m, n]);
                            n++;
                        }
                        m++;
                        n = 0;
                    }
                    C = (int)(Math.Round(C / sumMask));
                    Color newColor = Color.FromArgb(C, C, C);
                    renderedImage.SetPixel(x, y, newColor);
                    C = 0;
                    m = 0;
                    n = 0;
                }
            }
            Origin.Unlock();
            return renderedImage;
        }
        public Bitmap poryadStat(ref Bitmap original, int size, int choose)
        {
            BufferedBitmap Origin = new BufferedBitmap(original);
            int N = (size - 1) / 2;
            int k = 0;
            int C = 0;
            int[] histogram = new int[256];
            Bitmap renderedImage = new Bitmap(original.Width, original.Height);
            for (int x = N; x < original.Width - N; x++)
            {
                for (int y = N; y < original.Height - N; y++)
                {
                    for (int i = x - N; i <= x + N; i++)
                    {
                        for (int j = y - N; j <= y + N; j++)
                        {
                            var pixel = Origin.GetPixel(i, j);
                            histogram[pixel.R]++;
                        }

                    }
                    for (int i = 0; i <= 255; i++)
                    {
                        k += histogram[i];
                        if (k > (size * size / 2) && choose == 1)
                        {
                            C = i;
                            break;
                        }
                        if (k > 0 && choose == 2)
                        {
                            C = i;
                            break;
                        }
                        if (k == size * size && choose == 3)
                        {
                            C = i;
                            break;
                        }
                    }
                    Color newColor = Color.FromArgb(C, C, C);
                    renderedImage.SetPixel(x, y, newColor);
                    histogram = new int[256];
                    k = 0;
                }
            }
            return renderedImage;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            choose();
        }
    }
}
