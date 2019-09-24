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
using System.Diagnostics;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //тестирование программы
        private void button1_Click(object sender, EventArgs e)
        {
            string result;
            string r1 = null;

            for (int i = 0; i < 5; i++)
            {
                Random r = new Random();
                int x1 = r.Next(50);
                int x2 = r.Next(30);
                String value = x1.ToString();
                String value1 = x2.ToString();
                ProcessStartInfo psiOpt = new ProcessStartInfo();
                psiOpt.FileName = textBox6.Text;
                psiOpt.Arguments = value + " " + value1;
                // скрываем окно запущенного процесса
                psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
                psiOpt.RedirectStandardOutput = true;
                psiOpt.UseShellExecute = false;
                psiOpt.CreateNoWindow = true;
                // запускаем процесс
                Process procCommand = Process.Start(psiOpt);
                // получаем ответ запущенного процесса
                StreamReader srIncoming = procCommand.StandardOutput;
                // выводим результат
                result = srIncoming.ReadToEnd();
                r1 = r1 + result;
                // закрываем процесс
                procCommand.WaitForExit();
            }
            

            SqlConnection sqlconn = new SqlConnection("Data Source=LAPTOP-9474C6KT\\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            sqlconn.Open();
            string query = "INSERT INTO Result  (famstud , nmstud , otstud , cdgroup , razdel , result) VALUES ('" + textBox1.Text + "' , '" + textBox2.Text + "' , '" + textBox3.Text + "' , '" + textBox4.Text + "' ,  '" + textBox5.Text + "' , '" + r1 + "')";
            try
            {
                
                SqlCommand cp = new SqlCommand(query, sqlconn);
                cp.ExecuteNonQuery();
                MessageBox.Show("Результат успешно сохранен", "Добавление результатов", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
                textBox4.Text = null;
                textBox5.Text = null;
                textBox6.Text = null;
            }
            catch(Exception )
            {
                MessageBox.Show("Добавить не удалось!" , "Ошибка добавления" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }

        // загрузка программы для тестирования
        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            textBox6.Text = openFileDialog1.FileName;
        }

        // возврат на предыдущую форму
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form3.ActiveForm.Hide();
            Form1 MyForm1 = new Form1();
            MyForm1.ShowDialog();
            Close();
        }

        // переход на форму результатов
        private void button2_Click(object sender, EventArgs e)
        {
            Form3.ActiveForm.Hide();
            Form4 MyForm4 = new Form4();
            MyForm4.ShowDialog();
            Close();
        }
    }
}
