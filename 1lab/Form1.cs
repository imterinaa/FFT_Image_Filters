using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Numerics;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {         
            Program.f1 = this;
            this.WindowState = FormWindowState.Maximized;

            InitializeComponent();
        }     
        public int width, height; //ширина и высота изображения  
        public int newHeight, newWidth;
        public int Radius;
        bool b = false;
        private void message()
        {
            MessageBox.Show(
         "Вы не открыли изображение",
         "Ошибка!!!",
          MessageBoxButtons.OK,
          MessageBoxIcon.Information,
          MessageBoxDefaultButton.Button1);
        }      
        private void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png";
            openFileDialog1.Title = "Выберите файл изображения";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {               
                pictureBox1.Image = Image.FromFile(@openFileDialog1.FileName);
                pictureBox2.Image=null;
                if (pictureBox1.Image.Width > pictureBox1.Image.Height)
                {
                    Radius = pictureBox1.Image.Width / 2;
                }
                else
                {
                    Radius = pictureBox1.Image.Height / 2;
                }
            }

        }        
        private void saveFile_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null) // если изображение в pictureBox2 имеется
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Сохранить картинку как...";
                sfd.OverwritePrompt = true; // показывать ли "Перезаписать файл" если пользователь указывает имя файла, который уже существует
                sfd.CheckPathExists = true; // отображает ли диалоговое окно предупреждение, если пользователь указывает путь, который не существует
                                            // фильтр форматов файлов
                sfd.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";        
                                     // если в диалоге была нажата кнопка ОК
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // сохраняем изображение
                        pictureBox2.Image.Save(sfd.FileName);
                    }
                    catch // в случае ошибки выводим MessageBox
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }             
        private static Complex w(int k, int N)
        {
            if (k % N == 0) return 1;
            double arg = -2 * Math.PI * k / N;
            return new Complex(Math.Cos(arg), Math.Sin(arg));
        }
        public Complex[] FFT1D(Complex[] x1,int option)
        {
            Complex[] X;
            int N = x1.Length;
            if (N == 2)
            {
                X = new Complex[2];
                X[0] = x1[0] + x1[1];
                X[1] = x1[0] - x1[1];
            }
            else
            {
                Complex[] x_even = new Complex[N / 2];
                Complex[] x_odd = new Complex[N / 2];
                for (int i = 0; i < N / 2; i++)
                {
                    x_even[i] = x1[2 * i];
                    x_odd[i] = x1[2 * i + 1];
                }
                Complex[] X_even = FFT1D(x_even,option);
                Complex[] X_odd = FFT1D(x_odd,option);
                X = new Complex[N];
                for (int i = 0; i < N / 2; i++)
                {
                    X[i] = X_even[i] + w(i*option, N) * X_odd[i];
                    X[i + N / 2] = X_even[i] - w(i*option, N) * X_odd[i];
                }
            }
            return X;
        }
        public Complex[,] FFT2D(Complex[,] x, int option)
        {
            Complex[,] result = new Complex[width, height];
            // строки
            Complex[] x1 = new Complex[width];
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    x1[i] = x[i, j];

                }
                Complex[] X = FFT1D(x1, option);
                for (int i = 0; i < width; i++)
                {
                    result[i, j] = X[i];

                }
            }
            // столбцы
            x1 = new Complex[height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    x1[j] = result[i, j];

                }
                Complex[] X = FFT1D(x1, option);
                for (int k = 0; k < height; k++)
                {
                    result[i, k] = X[k];

                }
            }
            return result;
        }        
        public void FFTInvers(Complex [,] Arr)
        {
            var originalpicture = new Bitmap(pictureBox1.Image);
            Arr = FFT2D(Arr, -1);
            Bitmap rendered = new Bitmap(originalpicture.Width, originalpicture.Height);
            int C;
            int MN = width * height;         
                for (int x = 0; x < originalpicture.Width; x++)
                {
                    for (int y = 0; y < originalpicture.Height; y++)
                    {

                        C = (int)((Arr[x, y].Real / MN) * Math.Pow(-1, x + y));
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
               pictureBox2.Image = rendered;          
        }
        public int Ideal;
        private void lowfrequencyIdeal_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (b == true)
                {
                    pictureBox1.Image = pictureBox2.Image;
                    b = false;
                }
                Ideal = 0;
                Ideal I = new Ideal();
                this.Enabled = false;
                I.Show();
            }
            else
            {
                message();
            }
        }
        private void IdealHight_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (b == true)
                {
                    pictureBox1.Image = pictureBox2.Image;
                    b = false;
                }
                Ideal = 1;
                Ideal I = new Ideal();
                this.Enabled = false;
                I.Show();
            }
            else
            {
                message();
            }
        }
        public int butt;
        private void LowFrButt_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (b == true)
                {
                    pictureBox1.Image = pictureBox2.Image;
                    b = false;
                }
                butt = 0;
                Butterwort LB = new Butterwort();
                this.Enabled = false;
                LB.Show();
            }
            else
            {
                message();
            }
        }

        private void hightFrButt_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (b == true)
                {
                    pictureBox1.Image = pictureBox2.Image;
                    b = false;
                }
                butt = 1;
                Butterwort LB = new Butterwort();
                this.Enabled = false;
                LB.Show();
            }
            else
            {
                message();
            }
        }
        public int gauss;
        private void GausLow_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (b == true)
                {
                    pictureBox1.Image = pictureBox2.Image;
                    b = false;
                }
                gauss = 0;
                gaus Lg = new gaus();
                this.Enabled = false;
                Lg.Show();
            }
            else
            {
                message();
            }
        }
        private void laplas_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                laplas laplas = new laplas();
                this.Enabled = false;
                laplas.Show();
            }
            else
            {
                message();
            }
        }
       
        private void gaussNoise_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                b = true;
                name = "Шум Гаусса";
                Noises2 n = new Noises2();
                this.Enabled = false;
                n.Show();
            }
            else
            {
                message();
            }
        }
        public string name = "";
        private void RaleyNoise_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                b = true;
                name = "Шум Рэлея";
                Noises1 n = new Noises1();
                this.Enabled = false;
                n.Show();
            }
            else
            {
                message();
            }
        }

        private void ErlangNoise_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                b = true;
                name = "Шум Эрланга";
                Noises1 n = new Noises1();
                this.Enabled = false;
                n.Show();
            }
            else
            {
                message();
            }
        }

        private void ExpNoise_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                b = true;
                name = "Экспоненциальный шум";
                Noises2 n = new Noises2();
                this.Enabled = false;
                n.Show();
            }
            else
            {
                message();
            }
        }

        private void UniformNoise_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                b = true;
                name = "Равномерный шум";
                Noises1 n = new Noises1();
                this.Enabled = false;
                n.Show();
            }
            else
            {
                message();
            }
        }

        private void ImpulsNoise_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                b = true;
                name = "Импульсный шум";
                Noises1 n = new Noises1();
                this.Enabled = false;
                n.Show();
            }
            else
            {
                message();
            }
        }

        private void Smoothing_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (b == true)
                {
                    pictureBox1.Image = pictureBox2.Image;
                    b = false;
                }
                name = "Сглаживание";
                Recovery r = new Recovery();
                this.Enabled = false;
                r.Show();
            }
            else
            {
                message();
            }
        }

        private void PoryadStat_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (b == true)
                {
                    pictureBox1.Image = pictureBox2.Image;
                    b = false;
                }
                name = "Порядковые статистики";
                Recovery r = new Recovery();
                this.Enabled = false;
                r.Show();
            }
            else
            {
                message();
            }
        }

        private void GaussHight_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                if (b == true)
                {
                    pictureBox1.Image = pictureBox2.Image;
                    b = false;
                }

                gauss = 1;
                gaus Lg = new gaus();
                this.Enabled = false;
                Lg.Show();
            }
            else
            {
                message();
            }
        }
        public Complex[,] FFT(ref Bitmap original)
        {           
            width = original.Width;
            height = original.Height;
            int powerW = (int)Math.Ceiling(Math.Log((double)width, 2));         
            int powerH = (int)Math.Ceiling(Math.Log((double)height, 2));           
            height = (int)Math.Pow(2,powerH);
            width = (int)Math.Pow(2, powerW);
            Complex[,] x = new Complex[width, height];
            for (int i = 0;i<width; i++)
            {
                for(int j = 0; j <height; j++){
                    if(i<original.Width && j<original.Height)
                    {
                        x[i, j] = original.GetPixel(i, j).R*Math.Pow(-1,i+j);
                    }
                    else
                    {
                        x[i, j] = 0;
                    }          
                }
            }
            Complex[,] res =FFT2D(x,1);
            return res;
        }           
        }   
}
