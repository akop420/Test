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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        //переход на форму тестирования для неавторизованых полльзователей
        private void label3_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Hide();
            Form2 MyForm2 = new Form2();
            MyForm2.ShowDialog();
            Close();
        }

        // авторизация пользователя
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection("Data Source=LAPTOP-9474C6KT\\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            string query = "SELECT * FROM Prep WHERE login = '" + textBox1.Text + "' AND password= '" + textBox2.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlconn);
            DataTable dbt1 = new DataTable();
            sda.Fill(dbt1);
            if (dbt1.Rows.Count == 1)
            {
                Form1.ActiveForm.Hide();
                Form3 MyForm3 = new Form3();
                MyForm3.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Проверьте введенные данные", "Ошибка авторизации" , MessageBoxButtons.OK ,MessageBoxIcon.Error );
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
