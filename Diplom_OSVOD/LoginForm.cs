using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Diplom_OSVOD
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
          
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Статический_класс.Счётчик_Подключения = Статический_класс.Счётчик_Подключения + 1;
            Статический_класс.Фамилия = textBox1.Text;
            Статический_класс.Имя = textBox2.Text;
            Статический_класс.Место_работы = textBox3.Text;
            Статический_класс.Класификация = textBox4.Text;

            Random r = new Random();
            int temp = 0;
            temp = r.Next(6); //задаём число
            Статический_класс.Статическая_переменная = @"\Глава "+temp+".txt";
            Hide();
            Test Form = new Test();
            Form.ShowDialog();

            
        }
    }
}
