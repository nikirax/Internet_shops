using Internet_shops;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Internet_Shop
{
    /// <summary>
    /// Класс городов компании в которых доступен самовывоз
    /// </summary>
    public class Cities
    {
        public string Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Все адресса в данном городе
        /// </summary>
        public Cities(string name)
        {
            try
            {
                Id = Guid.NewGuid().ToString();
                Name = name;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка при вводе: {e}");
            }
            AddCitiesInDataBase();
        }
        public override string ToString()
        {
            return $"ID - {Id}, Name - {Name}";
        }
        async public void AddCitiesInDataBase()
        {
            using (var context = new Context())
            {
                await context.Database.ExecuteSqlCommandAsync($"INSERT INTO Cities (Id,Name) VALUES ('{Id}','{Name}')");
            }
        }
    }
}
