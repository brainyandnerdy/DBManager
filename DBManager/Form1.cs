using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBManager
{
    public partial class Form1 : Form
    {
        string server = "localhost";
        string database = "mydb";
        string userId = "root";
        string password = "root";
        string connection;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            /*
            DBConnect link = new DBConnect();
            link.Initialize();
            */
            server = textBox1.Text;
            userId = textBox2.Text;
            password = textBox4.Text;
            database = textBox3.Text;
            connection = "Server=" + server + ";Database=" + database + ";Uid=" + userId + ";Pwd=" + password;
            
            try
            {

                MySqlConnection dbcon = new MySqlConnection(connection);
                dbcon.Open();
                DataSet ds = new DataSet();
                MessageBox.Show("Connected");
                openTableButton.Enabled = true;
                dbcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void button2_Click(object sender, EventArgs e)
        {
            //only open .txt files
            ofd.Filter = "GPD|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = ofd.FileName;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void openTableButton_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection dbcon = new MySqlConnection(connection);
                dbcon.Open();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                MySqlCommand cmd;
                cmd = dbcon.CreateCommand();
                cmd.CommandText = "SELECT * FROM movies";
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                dbcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
