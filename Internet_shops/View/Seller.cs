using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Internet_shops.View
{
    public partial class Seller : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;
        string connectionString = @"data source=(localdb)\MSSQLLocalDB;Initial Catalog=Internet_Shop;Integrated Security=True;";
        string sql = "SELECT * FROM Products";
        public Seller()
        {
            InitializeComponent();

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);

                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                
            }
        }
        /// <summary>
        /// Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                commandBuilder = new SqlCommandBuilder(adapter);
                adapter.InsertCommand = new SqlCommand("sp_CreateProduct", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 50, "Name"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@price", SqlDbType.Decimal, 0, "Price"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@unit", SqlDbType.NVarChar, 50, "UnitMeasurement"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@count", SqlDbType.Int, 0, "Count"));

                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.NVarChar, 100, "Id");
                parameter.Direction = ParameterDirection.Output;

                adapter.Update(ds);
            }
        }
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow(); // добавляем новую строку в DataTable
            ds.Tables[0].Rows.Add(row);
        }
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }
    }
}
