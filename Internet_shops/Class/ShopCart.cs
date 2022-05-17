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
        public Guid Id { get; set; }
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
        public Guid ClientId { get; set; }
        [Required]
        public virtual Client Client { get; set; }
        public ShopCart(List<Product> products, Client client)
        {
            try
            {
                Id = Guid.NewGuid();
                Client = client;
                StringBuilder sb = new StringBuilder();
                Logic(products, sb);
                ProductString = sb.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка при вводе: {e}");
            }
            AddShopCartInDataBase();
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
                context.ShopCart.Add(this);
                await context.SaveChangesAsync();
            }
        }
        private void Logic(List<Product> products, StringBuilder sb)
        {
            //Расчет общей цены и количества
            foreach (var item in products)
            {
                AllPrice += item.Price;
                CountProducts++;
                sb.Append(item.Name + " ");
            }

            //Проверка на постоянного клиента
            if (Client.IsRegular)
            {
                AllPrice -= (AllPrice * 0.02M);
            }

            //Добавление клиенту скидки в следующий раз
            if (AllPrice >= 5000)
            {
                //тут по идее должно быть проверка на событие купил ли пользователь то что в корзине, но будем предствалять идеальную ситуацию 
                Client.IsRegular = true;
            }
        }
    }
}
