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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //On click should take the values from the textboxes and stores them in the variables "username" and "password"
            string username = textBox1.Text;
            string password = textBox2.Text;

            //Connect to the database
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-E3E3BLB3\\SQLEXPRESS;Initial Catalog=SE-Project;Integrated Security=True");

            //Open the connection
            con.Open();

            //Take the arguments in username and password and check if they match the values in the database "userbase" , if they exist close this window and open Form3 else display error message
            SqlCommand cmd = new SqlCommand("SELECT * FROM userbase WHERE username = '" + username + "' AND password = '" + password + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.Hide();
                Form3 f3 = new Form3();
                f3.Show();
            }

            else if (username == "admin" && password == "admin")
            {
                //If the username and password is admin then it should open up Form3.cs and close this form
                Form5 f5 = new Form5();
                f5.Show();
                this.Hide();
            }
            
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //When click should open up Form2.cs and close this form
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}