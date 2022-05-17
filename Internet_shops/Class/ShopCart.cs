using System;
using Internet_shops;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Internet_Shop;

namespace Internet_shops
{
    /// <summary>
    /// Класс корзины пользователя
    /// </summary>
    public class ShopCart
    {
        public string Id { get; set; }
        /// <summary>
        /// Все продукты пользователя помещенные в корзину
        /// </summary>
        public List<Product> Products { get; set; }
        /// <summary>
        /// Полнвя цена всех продуктов в корзине
        /// </summary>
        public decimal AllPrice { get; set; } = 0;
        /// <summary>
        /// Количество всех продуктов
        /// </summary>
        public byte CountProducts { get; set; } = 0;
        /// <summary>
        /// Костыль для красивого вывода продуктов
        /// </summary>
        private string ProductString = "";
        public string ClientId { get; set; }
        [Required]
        public virtual Client Client { get; set; }
        public void AddClient(Client client)
        {
            Client = client;
            ClientId = client.Id;
            AddShopCartInDataBase();
        }
        public ShopCart(List<Product> products = null)
        {
            Id = Guid.NewGuid().ToString();
        }
        public void AddProductInCart(Product product)
        {
            //Products.Add(product);
        }
        public override string ToString()
        {
            string b = $"ID - {Id}, Products - {ProductString}, AllPrice - {AllPrice}, CountProducts - {CountProducts}";
            if (AllPrice >= 5000)
            {
                b += "\n" + "Поздравляю вы стали постоянным покупателем! В следующий раз будет скидка 2%";
            }
            return b;
        }
        async public void AddShopCartInDataBase()
        {
            using (var context = new Context())
            {
                //await context.Database.ExecuteSqlCommandAsync($"INSERT INTO ShopCarts (Id,AllPrice,CountProducts,ClientId) VALUES ('{Id}',{AllPrice},{CountProducts},'{Client.Id}')");
            }
        }
        public void Logic(List<Product> products)
        {
            StringBuilder sb = new StringBuilder();
            //Расчет общей цены и количества
            foreach (var item in products)
            {
                AllPrice += item.Price;
                CountProducts++;
                sb.Append(item.Name + " ");
            }
            using (var context = new Context())
            {
                var cl = context.Client.SqlQuery($"SELECT * FROM Clients WHERE Id='{Client.Id}'");
                //Проверка на постоянного клиента
                foreach (var item in cl)
                {
                    if (item.IsRegular)
                    {
                        AllPrice -= (AllPrice * 0.02M);
                    }
                }
                context.Database.ExecuteSqlCommand($"UPDATE ShopCarts SET AllPrice={AllPrice}, WHERE Id='{Id}'");
            }
        }
        public static void Regular(ShopCart shopCart)
        {
            using (var context = new Context()) 
            { 
                if (shopCart.AllPrice >= 5000)
                {
                    //тут по идее должно быть проверка на событие купил ли пользователь то что в корзине, но будем предствалять идеальную ситуацию 
                    context.Database.ExecuteSqlCommand($"UPDATE Client SET IsRegular=true, WHERE Id='{shopCart.Client.Id}'");
                }
            }
        }
    }
}
