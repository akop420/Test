using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        //загрузка программы для тестирования
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            textBox1.Text = openFileDialog1.FileName;
        }

        //тестирование программы
        private void button1_Click(object sender, EventArgs e)
        {
            string result;
            string r1 =null;
            
            for(int i=0; i<5; i++) {
                Random r = new Random();
                int x1 = r.Next(50);
                int x2 = r.Next(30);
                String value = x1.ToString();
                String value1 = x2.ToString();

                
                ProcessStartInfo psiOpt = new ProcessStartInfo();
            psiOpt.FileName = textBox1.Text;
            psiOpt.Arguments = value +" " + value1;
            // скрываем окно запущенного процесса
            psiOpt.WindowStyle = ProcessWindowStyle.Normal;
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
            MessageBox.Show( r1 , "Результат тестирования", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //переход на предыдущую форму 
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form2.ActiveForm.Hide();
            Form1 MyForm1 = new Form1();
            MyForm1.ShowDialog();
            Close();
        }
    }
}

