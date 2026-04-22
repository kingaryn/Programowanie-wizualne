using System;
using System.Windows.Forms;
using WinFormsApp1;

namespace ImageEditor
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}