using System;
using System.Windows.Forms;


namespace KompasToExcel
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

        public static void exit()
        {
            Environment.Exit(0);
            Application.Exit();
        }

    }
}
