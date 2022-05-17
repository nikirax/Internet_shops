using Internet_Shop;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Internet_shops
{
    class Program
    {
        static void Main()
        {
            //using (Context db = new Context())
            //{
            //    var g = Guid.NewGuid().ToString();
            //    var comps = db.Database.SqlQuery<Product>($"SELECT * FROM Products");
            //        foreach (var item in comps)
            //    Console.WriteLine(item.);
            //}
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }
    }
}
