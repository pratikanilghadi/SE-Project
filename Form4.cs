using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SE_Project
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //should display all the search results from the "get_recipe" database in the dadtaGridView1
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-E3E3BLB3\\SQLEXPRESS;Initial Catalog=SE-Project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM get_recipe", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Once click should open up the Form3 and close this
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //once clicked should store the arguments from the textbox and combobox in the variables "search" and "category"
            string search = textBox1.Text;
            string category = comboBox1.Text;

            //should display by search the results from the "get_recipe" database in the dadtaGridView1
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-E3E3BLB3\\SQLEXPRESS;Initial Catalog=SE-Project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT recipe_name,vegornot,number_of_ingredients FROM get_recipe WHERE recipe_name LIKE '%" + search + "%' AND vegornot LIKE '%" + category + "%'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Check if any of the textboxes and combobox are empty
            if (textBox1.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Search For Your Recipe First");
            }
            else
            {
                //once clicked should store the arguments from the textbox and combobox in the variables "search" and "category"
                string search = textBox1.Text;
                string category = comboBox1.Text;

                //should display by search the results from the "get_recipe" database in the dadtaGridView1
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-E3E3BLB3\\SQLEXPRESS;Initial Catalog=SE-Project;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT link FROM get_recipe WHERE recipe_name LIKE '%" + search + "%' AND vegornot LIKE '%" + category + "%'", con);
                //From the link in the database should open the link in the browser
                string link = cmd.ExecuteScalar().ToString();
                if (link == null)
                {
                    MessageBox.Show("No Link Found");
                }
                ProcessStartInfo psInfo = new ProcessStartInfo
                {
                    FileName = link,
                    UseShellExecute = true
                };
                Process.Start(psInfo);

                con.Close();
            }
        }
    }
}
