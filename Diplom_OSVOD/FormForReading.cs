using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Diplom_OSVOD
{
    public partial class FormForReading : Form
    {
        System.IO.StreamReader Читатель;
        
        public FormForReading()
        {
            
            InitializeComponent();
        }

        private void FormForReading_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Hide();
            menu Form = new menu();
            Form.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            var Кодировка = System.Text.Encoding.GetEncoding(1251);
            string str1 = @"\Раздел 1.txt"; ;
            Читатель = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + str1, Кодировка);

            while (Читатель.EndOfStream != true)
            {
                richTextBox1.AppendText(Читатель.ReadLine()); 
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            var Кодировка = System.Text.Encoding.GetEncoding(1251);
            string str1 = @"\Раздел 2.txt"; ;
            Читатель = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + str1, Кодировка);

            while (Читатель.EndOfStream != true)
            {
                richTextBox1.AppendText(Читатель.ReadLine());
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            var Кодировка = System.Text.Encoding.GetEncoding(1251);
            string str1 = @"\Раздел 3.txt"; ;
            Читатель = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + str1, Кодировка);

            while (Читатель.EndOfStream != true)
            {
                richTextBox1.AppendText(Читатель.ReadLine());
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            var Кодировка = System.Text.Encoding.GetEncoding(1251);
            string str1 = @"\Раздел 4.txt"; ;
            Читатель = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + str1, Кодировка);

            while (Читатель.EndOfStream != true)
            {
                richTextBox1.AppendText(Читатель.ReadLine());
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            var Кодировка = System.Text.Encoding.GetEncoding(1251);
            string str1 = @"\Раздел 5.txt"; ;
            Читатель = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + str1, Кодировка);

            while (Читатель.EndOfStream != true)
            {
                richTextBox1.AppendText(Читатель.ReadLine());
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            var Кодировка = System.Text.Encoding.GetEncoding(1251);
            string str1 = @"\Раздел 6.txt"; ;
            Читатель = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + str1, Кодировка);

            while (Читатель.EndOfStream != true)
            {
                richTextBox1.AppendText(Читатель.ReadLine());
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            var Кодировка = System.Text.Encoding.GetEncoding(1251);
            string str1 = @"\Раздел 7.txt"; ;
            Читатель = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + str1, Кодировка);

            while (Читатель.EndOfStream != true)
            {
                richTextBox1.AppendText(Читатель.ReadLine());
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            var Кодировка = System.Text.Encoding.GetEncoding(1251);
            string str1 = @"\Раздел 8.txt"; ;
            Читатель = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + str1, Кодировка);

            while (Читатель.EndOfStream != true)
            {
                richTextBox1.AppendText(Читатель.ReadLine());
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            var Кодировка = System.Text.Encoding.GetEncoding(1251);
            string str1 = @"\Раздел 9.txt"; ;
            Читатель = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + str1, Кодировка);

            while (Читатель.EndOfStream != true)
            {
                richTextBox1.AppendText(Читатель.ReadLine());
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            var Кодировка = System.Text.Encoding.GetEncoding(1251);
            string str1 = @"\Раздел 10.txt"; ;
            Читатель = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + str1, Кодировка);

            while (Читатель.EndOfStream != true)
            {
                richTextBox1.AppendText(Читатель.ReadLine());
            }
        }

        }
}
