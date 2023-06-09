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
   

    public partial class authorization : Form
    {
            


        public authorization()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
           this.WindowState = FormWindowState.Maximized;

 

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }
        

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Hide();
            DownloadForm Form = new DownloadForm();
            Form.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
    public static class Статический_класс
    {
        public static string Статическая_переменная;
        public static string Фамилия;
        public static string Имя;
        public static string Место_работы;
        public static string Класификация;
        public static string Время;
        public static string Резльтат;
        public static int Счётчик_Подключения;
    }

   

}
