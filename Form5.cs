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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //should check if any of the fields are empty
            //if they are, then it should ddisplay a message box saying that the fields cannot be empty
            if (textBox1.Text == "" || textBox3.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Fields cannot be empty");
            }
            else
            {
                //On click should insert the data from the textboxes and combobox into the "get_recipe" database
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-E3E3BLB3\\SQLEXPRESS;Initial Catalog=SE-Project;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO get_recipe (recipe_name, vegornot, number_of_ingredients,link) VALUES ('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Recipe Added Successfully");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Once clicked should delete the data from the textboxes and combobox from the "get_recipe" database
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-E3E3BLB3\\SQLEXPRESS;Initial Catalog=SE-Project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM get_recipe WHERE recipe_name = '" + textBox1.Text + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Recipe Deleted Successfully");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Once opened should open up Form1 and close this tab
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
