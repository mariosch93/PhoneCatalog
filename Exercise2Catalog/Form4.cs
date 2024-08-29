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
    public partial class Form4 : Form
    {
        String connectionString = "Data source=phonecatalog.db;Version=3;";
        SQLiteConnection connection;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            connection = new SQLiteConnection(connectionString);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();

            string selectSQL = $"Select * from phonecatalog Where name = '{textBox1.Text}' ";
            SQLiteCommand command = new SQLiteCommand(selectSQL, connection);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    richTextBox1.AppendText("-> Unique id: ");
                    richTextBox1.AppendText(reader.GetInt32(0).ToString());
                    richTextBox1.AppendText(", Name: ");
                    richTextBox1.AppendText(reader.GetString(1));
                    richTextBox1.AppendText(", Phonenunmber: ");
                    richTextBox1.AppendText(reader.GetString(2));
                    richTextBox1.AppendText(", Address: ");
                    richTextBox1.AppendText(reader.GetString(3));
                    richTextBox1.AppendText(", Email: ");
                    richTextBox1.AppendText(reader.GetString(4));
                    richTextBox1.AppendText(", Birthdate: ");
                    richTextBox1.AppendText(reader.GetString(5));
                    richTextBox1.AppendText("\n");
                }
            }
            else
            {
                MessageBox.Show($"Entry with Name: '{textBox1.Text}' doesn't exist");
            }
            reader.Close();
            command.Dispose();
            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            connection.Open();

            String selectSQL = $"Update phonecatalog set Name = '{textBox6.Text}', Phonenumber = '{textBox3.Text}',Address = '{textBox2.Text}',Email = '{textBox4.Text}',Birthdate='{textBox5.Text}'  Where Name = '{textBox1.Text}' ";
            SQLiteCommand command = new SQLiteCommand(selectSQL, connection);

            if (command.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Catalog successfully updated!");
            }
            else 
            {
                MessageBox.Show("Update Failed! Reason: can't find entry with the chosen Name");
            }
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox5.Clear(); textBox6.Clear();
            command.Dispose();
            connection.Close();
        }
    }
}
