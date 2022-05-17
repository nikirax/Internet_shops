using Internet_shops;
using System;
using System.Windows.Forms;

namespace Internet_Shop
{
    /// <summary>
    /// Продукты доступные в магазине
    /// </summary>
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        /// <summary>
        /// Единица измерения (литр метр и т.д)
        /// </summary>
        public string UnitMeasurement { get; set; }
        /// <summary>
        /// Само значения единицы измернеия
        /// </summary>
        public double ValueUnit { get; set; }
        /// <summary>
        /// Количество на складе
        /// </summary>
        public uint Count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Название продукта</param>
        /// <param name="price">Цена за 1 шт/кг/л</param>
        /// <param name="unitMeasurment">Единица измерения (литр метр и т.д)</param>
        /// <param name="valueUnit">Само значения единицы измернеия</param>
        /// <param name="count">Количество на складе</param>
        public Product(string name,decimal price, string unitMeasurment, double valueUnit, uint count)
        {
            try
            {
                Id = Guid.NewGuid();
                Name = name;
                Price = price;
                UnitMeasurement = unitMeasurment;
                ValueUnit = valueUnit;
                Count = count;
            }
            catch(Exception e)
            {
                MessageBox.Show($"Ошибка при вводе: {e}");
            }
            AddProductInDataBase();
        }
        public override string ToString()
        {
            return $"Name - {Name}, Price - {Price}, {ValueUnit} {UnitMeasurement}, On storage - {Count}";
        }
        async public void AddProductInDataBase()
        {
            using (var context = new Context())
            {
                context.Product.Add(this);
                await context.SaveChangesAsync();
            }
        }
    }
}
