using Internet_Shop;
using System;
using System.Windows.Forms;

namespace Internet_shops
{
    class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }
    }
}
