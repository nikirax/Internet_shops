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
        /// <summary>
        /// Клиент который зарегался
        /// </summary>
        private Client SignClient { get; set; }
        /// <summary>
        /// Список купленных продуктов
        /// </summary>
        private StringBuilder Cart = new StringBuilder();
        /// <summary>
        /// Карта с которой будет оплата
        /// </summary>
        private CardClient Card { get; set; }
        /// <summary>
        /// Личная корзина клиента в которую будут добавляться товары
        /// </summary>
        private ShopCart shopCart { get; set; }
        /// <summary>
        /// Немного переменных для регулировки расположения названий
        /// </summary>
        int locationX = 12;
        const int locationYLable1 = 413;
        const int locationYBable2 = 430;
        int locationYButton = 81;
        int locationYBLable = 54;
        /// <summary>
        /// Основной конструктор
        /// </summary>
        /// <param name="client">Клиент который зарегался</param>
        /// <param name="card">Карта с которой будет оплата</param>
        /// <param name="shopcart">Личная корзина клиента в которую будут добавляться товары</param>
        public Shopper(Client client, CardClient card, ShopCart shopcart)
        {

            SignClient = client;
            Card = card;
            shopCart = shopcart;

            InitializeComponent();
            LoadCatalogProduct();
        }
        /// <summary>
        /// Загрузка каталога + обработка работы корзины
        /// </summary>
        private void LoadCatalogProduct()
        {
            //Создаем каталог
            List<Label> lables = new List<Label>();
            List<Button> buttons = new List<Button>();
            using(var context = new Context())
            {
                var products = context.Database.SqlQuery<Product>("SELECT * FROM Products");
                //добавляем все продукты в лэйблы и баттоны
                foreach (var product in products)
                {
                    lables.Add(new Label() { Location = new Point(locationX, locationYBLable), Text = product.Name });
                    buttons.Add(new Button() { Location = new Point(locationX, locationYButton), Text = "В корзину", Name = product.Id });
                    locationX += 100;
                    if (lables.Count == 8 | buttons.Count == 8)
                    {
                        locationYBLable += 60;
                        locationYButton += 60;
                    }
                }
            }
            //рисуем их
            foreach(var lable in lables)
            {
                Controls.Add(lable);
            }
            foreach(var button in buttons)
            {
                Controls.Add(button);
                locationX = 12;
                //событие клика у каждой кнопки
                button.Click += (object sender, EventArgs e) =>
                {
                    List<Label> lablesup = new List<Label>();
                    List<Label> lablesdown = new List<Label>();
                    label2.Visible = true;
                    int localcount = 100;
                    string productId = "";
                    using (var context = new Context())
                    {   
                        var products = context.Database.SqlQuery<Product>($"SELECT * FROM Products WHERE Id='{button.Name}'");
                        //добавляем подукт по которому нажали на кнопку
                        foreach (Product product in products)
                        {
                            localcount = product.localcount;
                            productId = product.Name;
                            //если 2 раза или более нажмем по тому же продукту то будет добавлять просто количество
                            if (product.localcount == 0)
                            {
                                lablesup.Add(new Label() { Location = new Point(locationX, locationYLable1), Text = product.Name });
                                lablesdown.Add(new Label() { Location = new Point(locationX, locationYBable2), Text = "1", Name = product.Id });
                                locationX += 100;
                            }
                            else
                            {
                                foreach(var lable in lablesdown)
                                {
                                    if (lable.Name == product.Name)
                                    {
                                        lable.Text = Convert.ToInt32(lable.Text + 1).ToString();
                                    }
                                }
                            }
                        }
                        context.Database.ExecuteSqlCommand($"UPDATE Products SET localcount={localcount++} WHERE Id='{productId}'");
                        //отрисовываем их
                        foreach (var lable in lablesup)
                        {
                            Controls.Add(lable);
                        }
                        foreach (var count in lablesdown)
                        {
                            foreach (Product product in products)
                            {
                                if(count.Name == product.Id)
                                {
                                    //добавляем в список продуктов и в класс корзины
                                    Cart.Append(product.Name + " ");
                                    shopCart.AddProductInCart(product);
                                }
                            }
                            Controls.Add(count);
                        }
                    }
                };
            }

        }
        //Событие с покупкой 
        private void button1_Click(object sender, EventArgs e)
        {
            shopCart.AddClient(SignClient);
            //делаем пользователя постоянным если он купит на 5000
            if (Cart.ToString() != "" && Cart.Length > 0)
            {
                ShopCart.Regular(shopCart);
                MessageBox.Show($"Поздравляю {SignClient.FIO} вы купили: {Cart} и оплатили это карточкой: {Card.Number}");
            }
        }
    }
}
