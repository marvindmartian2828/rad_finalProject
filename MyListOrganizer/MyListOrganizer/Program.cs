using System;
using System.Windows.Forms;

namespace MyListOrganizer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainDashboard());
        }
    }
}
