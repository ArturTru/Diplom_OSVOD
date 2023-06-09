using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Diplom_OSVOD
{
    public partial class DownloadForm : Form
    {
        int СчётчикЗагрузки = 0;
        System.IO.StreamReader Читатель;
       
        public DownloadForm()
        {
            InitializeComponent();
        }

        private void DownloadForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
            var Кодировка = System.Text.Encoding.GetEncoding(1251);
            Читатель = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + @"\Загрузка.txt", Кодировка);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            СчётчикЗагрузки++;
            if (Читатель.EndOfStream != true){
                
               label1.Text =label1.Text+Читатель.ReadLine(); //по буковке вставляем в лейбл
                     
            }
             if (Читатель.EndOfStream == true)
            {
                Читатель.Close();// закрываем текстовый файл
                timer1.Enabled = false;
                Hide();
                menu Form = new menu();
                Form.ShowDialog();
               
                
               
            }

        }

        private void DownloadForm_Activated(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            
        }
    }
}
