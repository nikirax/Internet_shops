using Internet_Shop;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Internet_shops.View
{
    public partial class ShoperSignUp : Form
    {
        public ShoperSignUp()
        {
            InitializeComponent();
        }
        /// <summary>
        /// вход пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var card = new CardClient(Convert.ToInt64(textBox4.Text),
                                        new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day),
                                        Convert.ToUInt32(textBox6.Text));
            var city = new Cities(textBox3.Text);
            var client = new Client(textBox1.Text, 
                                    Convert.ToByte(textBox2.Text), 
                                    new List<CardClient> 
                                        { 
                                        card
                                        }, 
                                    city.Name);
            //сохранение в базу данных
            //using (var context = new Context())
            //{
            //    context.Client.Add(client);
            //    context.SaveChanges();
            //}
            
            //открытие формы покупателя с каталогом и корзиной
            Form shopper = new Shopper(client, card);
            shopper.Show();
            this.Hide();
        }
    }
}
