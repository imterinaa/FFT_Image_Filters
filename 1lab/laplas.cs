using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;
namespace lab1
{
    public partial class laplas : Form
    {
        public laplas()
        {
            InitializeComponent();
        }
       
       
        private void laplasian_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var originalpicture = new Bitmap(Program.f1.pictureBox1.Image);
            Complex[,] FFT = Program.f1.FFT(ref originalpicture);
            int width = Program.f1.width;
            int height = Program.f1.height;
            int P = width / 2;
            int Q = height / 2;
          double  k = (double)numericUpDown1.Value;
            double D;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    D = -4*Math.Pow(Math.PI,2)*(Math.Pow(i - P, 2) + Math.Pow(j - Q, 2));
                    FFT[i, j] *= D;                
                }
            }
            Complex[,] Arr = Program.f1.FFT2D(FFT, -1);
            int C;
            double max = -1000;
            double min = 1000;
            int MN = width * height;
            double[,] mass = new double[width, height];
            Bitmap rendered = new Bitmap(originalpicture.Width, originalpicture.Height);
            for (int x = 0; x < originalpicture.Width; x++)
            {
                for (int y = 0; y < originalpicture.Height; y++)
                {                                   
                    mass[x, y] = ((Arr[x, y].Real / MN) * Math.Pow(-1, x + y));
                    if (mass[x, y] > max)
                    {
                        max = mass[x, y];
                    }
                    if (mass[x, y] <min)
                    {
                        min = mass[x, y];
                    }
                }
            }
            max -= min;        
            for (int x = 0; x < originalpicture.Width; x++)
            {             
                for (int y = 0; y < originalpicture.Height; y++)
                {
                    mass[x, y] = Math.Round(((mass[x, y] - min)/max)*255);
                    C = (int)(-k * mass[x, y] + originalpicture.GetPixel(x, y).R);

                    if (C > 255)
                    {
                        C = 255;
                    }
                    if (C < 0)
                    {
                        C = 0;
                    }
                    Color newColor = Color.FromArgb(C, C, C);
                    rendered.SetPixel(x, y, newColor);
                }              
            }
            Program.f1.pictureBox2.Image = rendered;
            Cursor.Current = Cursors.Default;
        }
        private void laplas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.f1.Enabled = true;
        }
    }
}
