using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Exercise2Catalog
{
    public partial class Form1 : Form
    {
        String connectionString = "Data source=phonecatalog.db;Version=3;";
        SQLiteConnection connection;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        connection = new SQLiteConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();

            String selectSQL = "Select * from phonecatalog";
            SQLiteCommand command = new SQLiteCommand(selectSQL,connection);
            SQLiteDataReader reader = command.ExecuteReader();
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
            reader.Close();
            command.Dispose();

            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            connection.Open();

            String InsertSQL = $"Delete from phonecatalog Where Name = '{textBox1.Text}' ";
            SQLiteCommand command = new SQLiteCommand(InsertSQL, connection);
            if (command.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Entry successfully deleted!");
            }
            else
            {
                MessageBox.Show("Delete Failed! Reason: can't find entry with the chosen Name");
            }
            command.Dispose();
            connection.Close ();    
        }
    }
}
