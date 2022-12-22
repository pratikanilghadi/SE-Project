using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SE_Project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //When click should open up Form1.cs and close this form
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Make a connection to the database
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-E3E3BLB3\\SQLEXPRESS;Initial Catalog=SE-Project;Integrated Security=True");
            con.Open();

            //Store both the arguments recived from the textboxes in the variables "username" and "password"
            string username = textBox1.Text;
            string password = textBox2.Text;

            //if the username or password is empty it should give a error message and shouldn't with this function
            if (username == "" || password == "")
            {
                MessageBox.Show("Please fill in all the fields");
            }
            
            else
            {
                //Insert the values from the textboxes into the database
                SqlCommand comm = new SqlCommand("INSERT INTO userbase (username, password) VALUES ('" + username + "', '" + password + "')", con);
                comm.ExecuteNonQuery();
                MessageBox.Show("Account Created");
                con.Close();
                Form3 f3 = new Form3();
                f3.Show();
                this.Hide();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
