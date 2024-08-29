using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise2Catalog
{
    public partial class Form2 : Form
    {
        String connectionString = "Data source=phonecatalog.db;Version=3;";
        SQLiteConnection connection;
        Random rnd = new Random();

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            connection = new SQLiteConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            
            String InsertSQL = "Insert into phonecatalog values(@id, @Name, @Address, @Phonenumber, @Email, @Birthdate)";
            SQLiteCommand command = new SQLiteCommand(InsertSQL,connection);
            command.Parameters.AddWithValue("@id", rnd.Next(10, 999)*rnd.Next(10,99));
            command.Parameters.AddWithValue("@Name", textBox1.Text);
            command.Parameters.AddWithValue("@Address", textBox2.Text);
            command.Parameters.AddWithValue("@Phonenumber", textBox3.Text);
            command.Parameters.AddWithValue("@Email", textBox4.Text);
            command.Parameters.AddWithValue("@Birthdate", textBox5.Text);

            command.ExecuteNonQuery();
            MessageBox.Show("Phone catalog successfully updated!");
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear();
            command.Dispose();
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
