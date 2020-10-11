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
    public partial class Noises1 : Form
    {
        public Noises1()
        {
            InitializeComponent();
            this.Text = Program.f1.name;
            if(this.Text== "Импульсный шум")
            {
                trackBar3.Visible = true;
                label10.Visible = true;
                label8.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
            }
        }
        public int Random(double p, int pixel,int change)
        {
            p *= 100;
            bool[] rand = new bool[100];
            for (int i = 0; i < 100; i++)
            {
                if (i < p)
                {
                    rand[i] = true;
                }
                else
                {
                    rand[i] = false;
                }
            }
            Random r = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 99; i >= 1; i--)
            {
                int j = r.Next(i + 1);
                bool tmp = rand[j];
                rand[j] = rand[i];
                rand[i] = tmp;
            }
            bool b = rand[r.Next(0, 100)];
            if (b == true)
            {
               
                pixel = change;
            }
            return pixel;
        }
        private void RaleyNoise_FormClosing(object sender, FormClosingEventArgs e)
        {
             Program.f1.Enabled = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }

        private void addNoise_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if(this.Text== "Шум Рэлея")
            {
                ReleyNoise();
            }
            if(this.Text=="Шум Эрланга")
            {
                ErlangNoise();
            }
            if(this.Text== "Равномерный шум")
            {
                UniformNoise();
            }
            if (this.Text == "Импульсный шум")
            {
                ImpulsNoise();
            }
            Cursor.Current = Cursors.Default;
        }
        public void ReleyNoise()
        {
            var originalpicture = new Bitmap(Program.f1.pictureBox1.Image);
            BufferedBitmap original = new BufferedBitmap(originalpicture);
            original.Lock();
            int width = original.Width;
            int height = original.Height;
            Bitmap rendered = new Bitmap(width, height);
            double a = trackBar1.Value;
            double b1 = 2 / (double)trackBar2.Value;
            double b2 = trackBar2.Value;
            int pixel;
            double p = 0;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    pixel = original.GetPixel(x, y).R;
                    if (pixel >= a)
                    {
                        p = b1 * (pixel - a) * Math.Exp(-Math.Pow((pixel - a), 2) / b2);
                        pixel = Random(p, pixel, 255);
                    }
                    Color newColor = Color.FromArgb(pixel, pixel, pixel);
                    rendered.SetPixel(x, y, newColor);
                }
            }
            original.Unlock();
            Program.f1.pictureBox2.Image = rendered;
        }
        static int Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }
        public void ErlangNoise()
        {
            var originalpicture = new Bitmap(Program.f1.pictureBox1.Image);
            BufferedBitmap original = new BufferedBitmap(originalpicture);
            original.Lock();
            int width = original.Width;
            int height = original.Height;
            Bitmap rendered = new Bitmap(width, height);
            double a = trackBar1.Value;
            double b = trackBar2.Value;
            double bFact = Factorial(trackBar2.Value-1);
            int pixel;
            double p = 0;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    pixel = original.GetPixel(x, y).R;
                    p = (Math.Pow(a, b) * Math.Pow(pixel, b - 1) * Math.Exp(-a * pixel)) / bFact;
                    if (p != 0)
                    {
                        pixel = Random(p, pixel, 255);
                    }
                    Color newColor = Color.FromArgb(pixel, pixel, pixel);
                    rendered.SetPixel(x, y, newColor);
                }
            }
            original.Unlock();
            Program.f1.pictureBox2.Image = rendered;
        }
        public void UniformNoise()
        {
            var originalpicture = new Bitmap(Program.f1.pictureBox1.Image);
            BufferedBitmap original = new BufferedBitmap(originalpicture);
            original.Lock();
            int width = original.Width;
            int height = original.Height;
            Bitmap rendered = new Bitmap(width, height);
            double ab = 1/(double)(trackBar2.Value-trackBar1.Value);
            int a = trackBar1.Value;
            int b = trackBar2.Value;
            int pixel;
            double p = 0;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    pixel = original.GetPixel(x, y).R;
                    if(pixel>=a && pixel <= b)
                    {
                        p = ab;
                        pixel = Random(p, pixel, 255);
                    }
                    Color newColor = Color.FromArgb(pixel, pixel, pixel);
                    rendered.SetPixel(x, y, newColor);
                }
            }
            original.Unlock();
            Program.f1.pictureBox2.Image = rendered;
        }
        public void ImpulsNoise()
        {
            var originalpicture = new Bitmap(Program.f1.pictureBox1.Image);
            BufferedBitmap original = new BufferedBitmap(originalpicture);
            original.Lock();
            int width = original.Width;
            int height = original.Height;
            Bitmap rendered = new Bitmap(width, height);
            int a = trackBar1.Value;
            int b = trackBar2.Value;
            double Pa = (double)trackBar3.Value / 100;
            double p = 0;
            int pixel;
            int change=0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    pixel = original.GetPixel(x, y).R;
                    if (pixel == a)
                    {
                        p = Pa;
                        Random r = new Random(Guid.NewGuid().GetHashCode());
                        if (r.Next(0, 100) > 50)
                        {
                            change = 255;
                        }
                        else
                        {
                            change = 0;
                        }
                        pixel = Random(p, pixel, change);

                    }
                    else if (pixel == b)
                    {
                        p = 1 - Pa;
                        Random r = new Random(Guid.NewGuid().GetHashCode());
                        if (r.Next(0, 100) > 50)
                        {
                            change = 255;
                        }
                        else
                        {
                            change = 0;
                        }
                        pixel = Random(p, pixel, change);
                    }                 
                    Color newColor = Color.FromArgb(pixel, pixel, pixel);
                    rendered.SetPixel(x, y, newColor);
                }
            }
            original.Unlock();
            Program.f1.pictureBox2.Image = rendered;
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label6.Text = trackBar2.Value.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label11.Text = ((double)trackBar3.Value/100).ToString();
        }
    }
}
