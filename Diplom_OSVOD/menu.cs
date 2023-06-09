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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

      


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
            //groupBox1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void menu_Load(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Maximized;

        }

        private void button6_Click(object sender, EventArgs e)
        {
           

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // Статический_класс.Статическая_переменная = @"\Глава 1.txt";
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Статический_класс.Статическая_переменная = @"\Глава 2.txt";
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Hide();
            FormForReading Form = new FormForReading();
            Form.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Hide();
            LoginForm Form = new LoginForm();
            Form.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Hide();
            authorization Form = new authorization();
            Form.ShowDialog();
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.Visible = true;
            pictureBox6.Visible = false;
            pictureBox7.Visible = false;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.Visible = false;
            pictureBox6.Visible = true;
            pictureBox7.Visible = false;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox7.Visible = true;
        }
    }
}
