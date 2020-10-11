using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lab1
{
    static class Program
    {
        public static Form1 f1;
        public static laplas laplas;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
