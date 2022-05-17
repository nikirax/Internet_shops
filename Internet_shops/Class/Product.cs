using Internet_shops;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Internet_Shop
{
    /// <summary>
    /// Продукты доступные в магазине
    /// </summary>
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// Единица измерения (литр метр и т.д)
        /// </summary>
        public string UnitMeasurement { get; set; }
        /// <summary>
        /// Количество на складе
        /// </summary>
        public int Count { get; set; }
        public static List<Product> Products = new List<Product>();
        public int localcount { get; set; } = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Название продукта</param>
        /// <param name="price">Цена за 1 шт/кг/л</param>
        /// <param name="unitMeasurment">Единица измерения (литр метр и т.д)</param>
        /// <param name="valueUnit">Само значения единицы измернеия</param>
        /// <param name="count">Количество на складе</param>
        public Product(string name,decimal price, string unitMeasurment, int count)
        {
            try
            {
                Id = Guid.NewGuid().ToString();
                Name = name;
                Price = price;
                UnitMeasurement = unitMeasurment;
                Count = count;
                Products.Add(this);
            }
            catch(Exception e)
            {
                MessageBox.Show($"Ошибка при вводе: {e}");
            }
            AddProductInDataBase();
        }
        public Product()
        {

        }
        public override string ToString()
        {
            return $"Name - {Name}, Price - {Price}, {UnitMeasurement}, On storage - {Count}";
        }
        async public void AddProductInDataBase()
        {
            using (var context = new Context())
            {
                await context.Database.ExecuteSqlCommandAsync($"INSERT INTO Products (Id,Name,Price,UnitMeasurement,Count) VALUES ('{Id}','{Name}',{Price},'{UnitMeasurement}',{Count})");
            }
        }
    }
}
