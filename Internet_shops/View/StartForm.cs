using Internet_shops.View;
using System.Windows.Forms;

namespace Internet_shops
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void Seller_Click(object sender, System.EventArgs e)
        {
            Form seller = new Seller();
            seller.Show();
            this.Hide();
        }

        private void Shopper_Click(object sender, System.EventArgs e)
        {
            Form shopper = new ShoperSignUp();
            shopper.Show();
            this.Hide();
        }
    }
}
