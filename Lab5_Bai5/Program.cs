using Lab5_Bai5;
using System;
using System.Windows.Forms;


namespace HomNayAnGi
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}