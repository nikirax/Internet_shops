using Internet_shops;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Internet_Shop
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class Client
    {
        public Guid Id { get; set; }
        public string FIO { get; set; }
        public byte Age { get; set; }
        /// <summary>
        /// Все банковские карточки пользователя
        /// </summary>
        public List<CardClient> Carts { get; set; }
        /// <summary>
        /// Корзина пользователя
        /// </summary>
        public Guid ShopCartId { get; set; }
        public virtual ShopCart ShopCart { get; set; }
        /// <summary>
        /// Город в котором он живет
        /// </summary>
        public Cities TownClient { get; set; }
        /// <summary>
        /// Постоянный ли он покупатель
        /// </summary>
        public bool IsRegular { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fio"></param>
        /// <param name="age"></param>
        /// <param name="carts">Все карты клиента</param>
        /// <param name="shopсart">Его корзина</param>
        /// <param name="townClient">Город в котором он живет</param>
        public Client(string fio, byte age, List<CardClient> carts, ShopCart shopсart, Cities townClient)
        {
            try
            {
                Id = Guid.NewGuid();
                FIO = fio;
                Age = age;
                Carts = carts;
                ShopCart = shopсart;
                TownClient = townClient;
            }
            catch(Exception e)
            {
                MessageBox.Show($"Ошибка при вводе: {e}");
            }
            AddClientInDataBase();
        }
        public override string ToString()
        {
            return $"FIO - {FIO}, Age - {Age}, Town - {TownClient.Name}";
        }
        async public void AddClientInDataBase()
        {
            using (var context = new Context())
            {
                context.Client.Add(this);
                await context.SaveChangesAsync();
            }
        }
    }
}
