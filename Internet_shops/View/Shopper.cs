using Internet_Shop;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Internet_shops.View
{
    public partial class Shopper : Form
    {
        private Client SignClient { get; set; }

        private StringBuilder Cart = new StringBuilder();
        private CardClient Card { get; set; }

        int locationX = 12;
        const int locationYLable1 = 413;
        const int locationYBable2 = 430;
        public Shopper(Client client, CardClient card)
        {
            var apple = new Product("Apple", 3500M, "kg", 100);
            var phone = new Product("Phone", 40000M, "шт", 50);

            SignClient = client;
            Card = card;

            InitializeComponent();
            LoadCatalogProduct();
        }
        private void LoadCatalogProduct()
        {
            List<Label> lables = new List<Label>();
            List<Button> buttons = new List<Button>();
            int locationYButton = 81;
            int locationYBLable = 54;
            //Создаем каталог
            foreach (Product product in Product.Products)
            {
                lables.Add(new Label() { Location = new Point(locationX, locationYBLable), Text = product.Name});
                buttons.Add(new Button() { Location = new Point(locationX, locationYButton), Text = "В корзину", Name = product.Name });
                locationX += 100;
                if(lables.Count == 8 | buttons.Count == 8)
                {
                    locationYBLable += 60;
                    locationYButton += 60;
                }
            }
            foreach(var lable in lables)
            {
                Controls.Add(lable);
            }
            //Загружаем продукты в корзину
            foreach(var button in buttons)
            {
                Controls.Add(button);
                locationX = 12;

                button.Click += (object sender, EventArgs e) =>
                {
                    List<Label> lables1 = new List<Label>();
                    List<Label> lables2 = new List<Label>();
                    label2.Visible = true;

                    foreach(Product product in Product.Products)
                    {
                        if(product.Name == button.Name)
                        {
                            Cart.Append(product.Name);
                            lables1.Add(new Label() { Location = new Point(locationX, locationYLable1), Text = product.Name});
                            lables2.Add(new Label() { Location = new Point(locationX, locationYBable2), Text = lables1.Count.ToString()});
                            locationX += 100;
                        }
                    }
                    foreach (var lable in lables1)
                    {
                        Controls.Add(lable);
                    }
                    foreach (var lable in lables2)
                    {
                        Controls.Add(lable);
                    }
                };
            }

        }
        //Событие с покупкой 
        private void button1_Click(object sender, EventArgs e)
        {
            if(Cart.ToString() != "" && Cart.Length > 0)
            MessageBox.Show($"Поздравляю {SignClient.FIO} вы купили: {Cart} и оплатили это карточкой: {Card.Number}");
        }
    }
}
