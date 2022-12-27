using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace lab1
{
    public partial class Ideal : Form
    {      
        public Ideal()
        {           
            InitializeComponent();
            trackBar1.Maximum = Program.f1.Radius;
            label9.Text = trackBar1.Maximum.ToString();
        }
        private void Ideal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.f1.Enabled = true;
        }     
        private void trackBar1_Scroll(object sender, EventArgs e)
        {         
            label2.Text = trackBar1.Value.ToString();           
        }        
        private void IdealLowFr_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var originalpicture = new Bitmap(Program.f1.pictureBox1.Image);
            Complex[,] FFT = Program.f1.FFT(ref originalpicture);
            int width = Program.f1.width;
            int height = Program.f1.height;
            int P = width / 2;
            int Q = height / 2;           
            double D;
            int D0= trackBar1.Value;
            int option = Program.f1.Ideal;
            for (int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    D = Math.Sqrt(Math.Pow(i-P,2)+Math.Pow(j-Q,2));                  
                    if (D > D0 && option==0)
                    {
                        FFT[i, j]= 0;                       
                    } 
                    else if(D<=D0 && option == 1)
                    {
                        FFT[i, j] = 0;
                    }
                }               
            }           
            Program.f1.FFTInvers(FFT);
            Cursor.Current = Cursors.Default;          
        }

        private void Ideal_Load(object sender, EventArgs e)
        {

        }
    }
}
