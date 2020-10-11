using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
namespace lab1
{
    public partial class gaus : Form
    {
        public gaus()
        {
            InitializeComponent();
            trackBar1.Maximum = Program.f1.Radius;
            label9.Text = trackBar1.Maximum.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }

        private void gaus_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.f1.Enabled = true;
        }
        private void Gauss_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var originalpicture = new Bitmap(Program.f1.pictureBox1.Image);
            Complex[,] FFT = Program.f1.FFT(ref originalpicture);
            int width = Program.f1.width;
            int height = Program.f1.height;
            int P = width / 2;
            int Q = height / 2;
            double D;
            int D0 = 2*trackBar1.Value* trackBar1.Value;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                   
                    D =-(Math.Pow(i - P, 2) + Math.Pow(j - Q, 2));
                    if (Program.f1.gauss == 0)
                    {
                        FFT[i, j] *= Math.Exp(D/D0);
                    }
                    else
                    {
                        FFT[i, j] *= 1 - Math.Exp(D/D0);
                    }
                }

            }
            Program.f1.FFTInvers(FFT);
            Cursor.Current = Cursors.Default;
        }
    }
}
