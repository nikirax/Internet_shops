using System;
using System.Windows.Forms;

namespace Internet_shops.View
{
    public partial class SellerSignUp : Form
    {
        public SellerSignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "123321")
            {
                Form seller = new Seller();
                seller.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неправильный пароль");
            }
        } 
    }
}
