using Internet_shops;
using System;
using System.Text;
using System.Windows.Forms;
namespace Internet_Shop
{
    /// <summary>
    /// Банковская карта пользователя
    /// </summary>
    public class CardClient
    {
        public string Id { get; set; }
        public string Number { get; set; }
        /// <summary>
        /// Короткая дата типа 03/2020
        /// </summary>
        public string Date { get; set; }
        public int CVV { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number">номер</param>
        /// <param name="date">дата окончания</param>
        /// <param name="cvv">3 цифры</param>
        public CardClient(long number, DateTime date, int cvv)
        {
            try
            {
                Id = Guid.NewGuid().ToString();
                Number = number.ToString();
                StringBuilder sb = new StringBuilder(date.Month.ToString() + "/" + date.Year.ToString());
                Date = sb.ToString();
                CVV = cvv;
            }
            catch(Exception e)
            {
                MessageBox.Show($"Ошибка при вводе: {e}");
            }
            AddCardClientInDataBase();
        }
        async public void AddCardClientInDataBase()
        {
            using (var context = new Context())
            {
                await context.Database.ExecuteSqlCommandAsync($"INSERT INTO Products (Id,Number,Date,CVV) VALUES ('{Id}',{Number},{Date},{CVV})");
            }
        }
        public override string ToString()
        {
            return $"ID - {Id}, Number - {Number}, Date - {Date}, CVV - {CVV}";
        }
    }
}
