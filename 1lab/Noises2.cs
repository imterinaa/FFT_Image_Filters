using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace lab1
{
    public partial class Noises2 : Form
    {
        public Noises2()
        {
            InitializeComponent();
            this.Text = Program.f1.name;
            if (this.Text == "Экспоненциальный шум")
            {
                label1.Text = "a = ";
                label2.Location = new Point(33, 9);
            }
        }

        private void laba2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.f1.Enabled = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = trackBar1.Value.ToString();
        }

        public int Random(double p, int pixel)
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
                pixel = 255;
            }
            return pixel;
        }
       
        private void addNoise_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (this.Text == "Шум Гаусса")
            {
                GaussNoise();
            }
            if(this.Text== "Экспоненциальный шум")
            {
                ExpNoise();
            }
            Cursor.Current = Cursors.Default;
        }
        public void GaussNoise()
        {
            var originalpicture = new Bitmap(Program.f1.pictureBox1.Image);
            BufferedBitmap original = new BufferedBitmap(originalpicture);
            original.Lock();
            int width = original.Width;
            int height = original.Height;
            Bitmap rendered = new Bitmap(width, height);
            double z = 127;
            double O2 = 2 * trackBar1.Value;
            double O = 1 / (Math.Sqrt(Math.PI * O2));
            double p = 0;
            int pixel;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    pixel = original.GetPixel(i, j).R;
                    p = O * Math.Exp(-Math.Pow(pixel - z, 2) / O2);
                    if (p != 0)
                    {
                        pixel = Random(p, pixel);
                    }
                    Color newColor = Color.FromArgb(pixel, pixel, pixel);
                    rendered.SetPixel(i, j, newColor);
                }
            }
            original.Unlock();
            Program.f1.pictureBox2.Image = rendered;
        }
        public void ExpNoise()
        {
            var originalpicture = new Bitmap(Program.f1.pictureBox1.Image);
            BufferedBitmap original = new BufferedBitmap(originalpicture);
            original.Lock();
            int width = original.Width;
            int height = original.Height;
            Bitmap rendered = new Bitmap(width, height);
            double a = trackBar1.Value;
            int pixel;
            double p = 0;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    pixel = original.GetPixel(x, y).R;
                    p = a * Math.Exp(-a * pixel);
                    if (p != 0)
                    {
                        pixel = Random(p, pixel);
                    }
                    Color newColor = Color.FromArgb(pixel, pixel, pixel);
                    rendered.SetPixel(x, y, newColor);
                }
            }
            original.Unlock();
            Program.f1.pictureBox2.Image = rendered;
        }
    }
}
//public static class StaticRandom
//{
//    private static int seed;

//    private static ThreadLocal<Random> threadLocal = new ThreadLocal<Random>
//        (() => new Random(Interlocked.Increment(ref seed)));

//    static StaticRandom()
//    {
//        seed = Environment.TickCount;
//    }

//    public static Random Instance { get { return threadLocal.Value; } }
//}
//StaticRandom.Instance.Next(1, 100);
///////////////////////////////////////////////////////////
//Random r = new Random(Guid.NewGuid().GetHashCode());
//int b = r.Next(0, 100);
//if (b < p)
//{
//    pixel = 255;
//}