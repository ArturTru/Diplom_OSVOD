using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Net.Sockets; // для передачи на сервер
using System.Net;         // для передачи на сервер
//using System.Threading.Tasks;








namespace Diplom_OSVOD
{



    public partial class Test : Form
    {
        class Player
        {
            public int ID { get; private set; } // индификатор отличия от других
            public string Surname { get; set; } // положение
            public string First_name { get; set; } // положение
            public string Place_of_work { get; set; } // Место работы
            public string Skill { get; set; } //квалификация qualification
            public string Result { get; set; }
            public int ResultX { get; set; }


            //Конструктор передаём параметры для всех свойств
            public Player(int id, string surname, string f_n, string p_o_w, string skill, string result, int resultX)
            {
                ID = id;
                Surname = surname;
                First_name = f_n;
                Place_of_work = p_o_w;
                Skill = skill;
                Result = result;
                ResultX = resultX;


            }

            public void Draw() //Действие 3: создадим метод для отображения игрока
            {//курсор ставиться на место где стоит игрок и ресуеться его спрайт
                //Console.WriteLine(" зашли в метод ++DRAW++ ");




            }//=============== 3 ===============================
        }

       //Внешние переменные:
        int СчётВопросов;//счёт вопросов
        int ПравилОтветов;//Количество правильных ответов
        int НеПравилОтветов;//Количество неправильных ответов
        int Мин,Сек;
        int Таймер2;
        //Массив вопросов,на которые даны неправильные ответы:
        String[] НеПравилОтветы; //Размерность этого массива задади позже
        int НомерПравОтвета; //Номер правильного ответа;
        int ВыбранОтвет;//Номер ответа, выбранный студентом
        System.IO.StreamReader Читатель;
        int ВыводПравНеправ;

        // для передачи на сервер
        //Действие 5: для обмена с сервером данными создадим сокет
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //==============================================

        // для действия 12: создадим хранилище( запишем 0 и отправим на сервер)
        static MemoryStream ms = new MemoryStream(new byte[256], 0, 256, true, true);
        //===============  12 ===============================
        static BinaryWriter writer = new BinaryWriter(ms);// что бы записывать данные
        static BinaryReader reader = new BinaryReader(ms);//для действия 14 считывание запроса из memorystream

        //создадим список типа плеер
        static List<Player> players = new List<Player>();

        static Random random = new Random();

        // static Player player;
        // перечисление для 12 действия
        enum PacketInfo
        {
            ID, Position
        }


        static public string strF = Статический_класс.Фамилия;
        static public string strN = Статический_класс.Имя;
        static public string strM = Статический_класс.Место_работы;
        static public string strK = Статический_класс.Класификация;
        
        public Test()
        {
            InitializeComponent();
        }
   

        private void button1_Click(object sender, EventArgs e)
        {
            
           Application.Restart();
           this.Dispose();
           // Hide();
           // menu Form = new menu();
           // Form.ShowDialog();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
                 }

        private void Test_Load(object sender, EventArgs e)
        {
            radioButton1.Parent = pictureBox2;
            radioButton1.BackColor = Color.Transparent;
            radioButton2.Parent = pictureBox2;
            radioButton2.BackColor = Color.Transparent;
            radioButton3.Parent = pictureBox2;
            radioButton3.BackColor = Color.Transparent;
            radioButton4.Parent = pictureBox2;
            radioButton4.BackColor = Color.Transparent;
            
            label1.Parent = pictureBox2;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox2;
            label2.BackColor = Color.Transparent;
            label3.Parent = pictureBox2;
            label3.BackColor = Color.Transparent;
            label4.Parent = pictureBox2;
            label4.BackColor = Color.Transparent;
            label5.Parent = pictureBox2;
            label5.BackColor = Color.Transparent;

            label6.Parent = pictureBox2;
            label6.BackColor = Color.Transparent;
          
            //настройки формы:
            this.WindowState = FormWindowState.Maximized;
            //настройки элементов формы:
            ВыводПравНеправ = 0;
            button2.Text = "Следующий вопрос";
            button1.Text = "Выход";
            //подписка на событие "изменение состояния
            //переключателей" radiobatton: если нажали на радиобатон выполнять событие...
            radioButton1.CheckedChanged += new EventHandler(ИзмСостПерекл); // создаем событие
            radioButton2.CheckedChanged += new EventHandler(ИзмСостПерекл); // создаем событие 
            radioButton3.CheckedChanged += new EventHandler(ИзмСостПерекл); // создаем событие
            radioButton4.CheckedChanged += new EventHandler(ИзмСостПерекл); // создаем событие
            НачалоТеста();
        }
        void НачалоТеста()
        {
            timer1.Enabled = true;
            Мин = 14;
            Сек = 59;
            label4.Visible = false;
            label5.Visible = false;
            ВыводПравНеправ = 0;
            var Кодировка = System.Text.Encoding.GetEncoding(1251);
            try
            { 
                string str1 = Статический_класс.Статическая_переменная;
                Читатель = new System.IO.StreamReader(System.IO.Directory.GetCurrentDirectory() + str1, Кодировка);
                this.Text = Читатель.ReadLine(); //Название предмета
                //обнуление всех счётчиков:
                СчётВопросов = 0; ПравилОтветов = 0; НеПравилОтветов = 0;
                //Задаём размер массива для НеравилОтветы:
                НеПравилОтветы = new String[100];
            }
            catch (Exception Ситуация)
            {// Отчёт о всех ошибках:
                MessageBox.Show(Ситуация.Message, "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            ЧитатьСледВопрос();
            }

        void ЧитатьСледВопрос()
        {

            label1.Text = Читатель.ReadLine();
            this.label1.MaximumSize = new Size(800, 100);//размер для ответа на ворос

            //Считывание вариантов ответа:
            radioButton1.Text = Читатель.ReadLine();
            radioButton2.Text = Читатель.ReadLine();
            radioButton3.Text = Читатель.ReadLine();
            radioButton4.Text = Читатель.ReadLine();
            //Выясним, какой ответ - правильный:
            НомерПравОтвета = int.Parse(Читатель.ReadLine());
            //Переводим все переключатели в сосотояние "выключено":
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            //Перемешиваем вопросы:
            Random r = new Random();
            int max = 4; //количество переменных
            int[] x = new int[max]; //массив переменных
            for (int i = 0; i < max; i++) //проходим все переменные
            {
                bool contains; 
                int next;
                do
                {
                    next = r.Next(max); //задаём число
                    contains = false;
                    for (int index = 0; index < i; index++) //цикл проверки на истинность
                    {
                        int n = x[index];
                        if (n == next) // если элементы равны
                        {
                            contains = true;
                            break;
                        }
                    }
                } while (contains); //пока истино условиие
                x[i] = next;
            }
                      
                //взависимости от значения меняем положение
                if (x[0] == 0) { radioButton1.Location = new Point(150, 330); }
                if (x[1] == 0) { radioButton2.Location = new Point(150, 330); }
                if (x[2] == 0) { radioButton3.Location = new Point(150, 330); }
                if (x[3] == 0) { radioButton4.Location = new Point(150, 330); }

                if (x[0] == 1) { radioButton1.Location = new Point(150, 363); }
                if (x[1] == 1) { radioButton2.Location = new Point(150, 363); }
                if (x[2] == 1) { radioButton3.Location = new Point(150, 363); }
                if (x[3] == 1) { radioButton4.Location = new Point(150, 363); }

                if (x[0] == 2) { radioButton1.Location = new Point(150, 397); }
                if (x[1] == 2) { radioButton2.Location = new Point(150, 397); }
                if (x[2] == 2) { radioButton3.Location = new Point(150, 397); }
                if (x[3] == 2) { radioButton4.Location = new Point(150, 397); }

                if (x[0] == 3) { radioButton1.Location = new Point(150, 433); }
                if (x[1] == 3) { radioButton2.Location = new Point(150, 433); }
                if (x[2] == 3) { radioButton3.Location = new Point(150, 433); }
                if (x[3] == 3) { radioButton4.Location = new Point(150, 433); }

            //Первую кнопку задаём неактивной, пока пользователь не выберет вариант ответа
            button2.Enabled = false;
            СчётВопросов = СчётВопросов + 1;
            //Проверка,конец ли файла:
            if (Читатель.EndOfStream == true) button2.Text = "Завершить";
        }
        void ИзмСостПерекл(Object sender, EventArgs e) 
        {
        //Кнопка "Следующий вопрос" становиться активной и ей передаём фокус:
            button2.Enabled = true; button2.Focus();
            RadioButton Переключатель = (RadioButton)sender;
            var tmp = Переключатель.Name;
            //Выясняем номер ответа, выбранный студентом:
            ВыбранОтвет = int.Parse(tmp.Substring(11));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ВыводПравНеправ++;
            //Щелчок на кнопке
            //"Следующий вопрос/Завершить/Начать тестирование снач"
            //Счёт правильных ответов:
          
            if ((ВыбранОтвет == НомерПравОтвета) & (ВыводПравНеправ == 1))
            {
                ПравилОтветов = ПравилОтветов + 1;
                  label2.Visible = true;
                  if (СчётВопросов == 1) button3.BackColor = Color.Green;
                  if (СчётВопросов == 2) button4.BackColor = Color.Green;
                  if (СчётВопросов == 3) button5.BackColor = Color.Green;
                  if (СчётВопросов == 4) button6.BackColor = Color.Green;
                  if (СчётВопросов == 5) button7.BackColor = Color.Green;
                  if (СчётВопросов == 6) button8.BackColor = Color.Green;
                  if (СчётВопросов == 7) button9.BackColor = Color.Green;
                  if (СчётВопросов == 8) button10.BackColor = Color.Green;
                  if (СчётВопросов == 9) button11.BackColor = Color.Green;
                  if (СчётВопросов == 10) button12.BackColor = Color.Green;
             }
            if ((ВыбранОтвет != НомерПравОтвета) & (ВыводПравНеправ == 1))
            {
                //Счёт неправильных ответов:
                НеПравилОтветов = НеПравилОтветов + 1;
                //Запоминаем вопросы с неправильными ответами:
                НеПравилОтветы[НеПравилОтветов] = label1.Text;
                label3.Visible = true;
                if (СчётВопросов == 1) button3.BackColor = Color.Red;
                if (СчётВопросов == 2) button4.BackColor = Color.Red;
                if (СчётВопросов == 3) button5.BackColor = Color.Red;
                if (СчётВопросов == 4) button6.BackColor = Color.Red;
                if (СчётВопросов == 5) button7.BackColor = Color.Red;
                if (СчётВопросов == 6) button8.BackColor = Color.Red;
                if (СчётВопросов == 7) button9.BackColor = Color.Red;
                if (СчётВопросов == 8) button10.BackColor = Color.Red;
                if (СчётВопросов == 9) button11.BackColor = Color.Red;
                if (СчётВопросов == 10) button12.BackColor = Color.Red;
                }
            if (button2.Text == "Заново") 
            {
                button2.Text = "Следующий вопрос";
                //переключатели становятся видимыми, доступными для переключения
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                label2.Visible = false;
                label3.Visible = false;
                //Делаем цвет кнопок белым
                button3.BackColor = Color.White;
                button4.BackColor = Color.White;
                button5.BackColor = Color.White;
                button6.BackColor = Color.White;
                button7.BackColor = Color.White;
                button8.BackColor = Color.White;
                button9.BackColor = Color.White;
                button10.BackColor = Color.White;
                button11.BackColor = Color.White;
                button12.BackColor = Color.White;
                
                Application.Restart();
                this.Dispose();
                //переход к начлу файла:
                НачалоТеста(); return;
                                
            }
            if (((button2.Text == "Завершить") & (ВыводПравНеправ == 2)) || (НеПравилОтветов==2))
            {
                string Str = "СПИСОК ВОПРОСОВ, НА КОТОРЫЕ ВЫ ДАЛИ " +
                    "НЕПРАВИЛЬНЫЙ ОТВЕТ:\n\n";
                string Result;
                int ResultX;
                Result = "Не сдал";
                timer2.Enabled = true;
                ResultX=0;
                //закрываем текстовый файл:
                Читатель.Close();
                //переключатели делаем невидимыми:
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                label2.Visible = false;
                label3.Visible = false;

                if (НеПравилОтветов == 2) label4.Visible = true;
                if (ПравилОтветов >= 9)
                {
                    Result = "Сдал";
                    ResultX=1;
                    label5.Visible = true;
                    timer2.Enabled = true;                   
                }
                try
                {
                    socket.Connect("127.0.0.1", 2048);
                    SendPacket(PacketInfo.ID, "", "", "", "", "", "",0);            
                    int id = ReceivePacket();                  
                    label8.Text = id.ToString();
                    string x1, x2, x3, x4, x5, x6;
                    int x7;
                    x1 = strF;
                    x2 = strN;
                    x3 = strM;
                    x4 = strK;
                    x5 = Result;
                    x6 = id.ToString();
                    x7 = ResultX;

                    SendPacket(PacketInfo.Position, x1, x2, x3, x4, x5, x6, x7);
                } 
                catch
                {
                    

                    label1.Text = String.Format("Тестрование завершено.\n" +
                    "Правильных ответов: {0} из {1}.\n" 
                   ,  ПравилОтветов, СчётВопросов);
                    button2.Text = "Начать тестирование сначала";
                    MessageBox.Show("Результаты тестирования на сервер не отправлены ");
                }
                timer1.Enabled = false;
                //формируем оценку за тест:
                label1.Text = String.Format("Тестрование завершено.\n" +
                    "Правильных ответов: {0} из {1}.\n"
                  , ПравилОтветов,
                   СчётВопросов);
                button2.Text = "Начать тестирование сначала";
                //Вывод вопросов, на которые "Вы дали неправильеый ответ":
                
                for (int i = 1; i <= НеПравилОтветов; i++)
                    Str = Str + НеПравилОтветы[i] + "\n";                
                //Если есть неправильные ответы,то вывести через
                //MessageBox список соответствующих вопросов:
                if (НеПравилОтветов != 0) MessageBox.Show(Str, "Тестирование завершено");                
            } //}//конец условия батон текст2 =завершить
            if ((button2.Text == "Следующий вопрос") & (ВыводПравНеправ == 2))
            {
                ЧитатьСледВопрос();
                label2.Visible = false;
                label3.Visible = false;
                ВыводПравНеправ = 0;            
            }            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (Мин == 1) button13.BackColor = Color.Red; ;
            if (Сек != 0) Сек = Сек - 1;
            if ((Сек == 0)&(Мин!=0)) { Мин = Мин - 1; Сек = 59; }
            if ((Сек == 0) & (Мин == 0)) 
            {              
                timer1.Enabled = false;
                label4.Visible = true;
                button2.Enabled = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
            }
            button13.Text = Мин.ToString() + ":" + Сек.ToString();
        }

        static void SendPacket(PacketInfo info, string x1, string x2, string x3, string x4, string x5, string x6,int x7)
        {
            
            ms.Position = 0;
            //структура запроса (пакет/ код запроса/ доп информация)
            //структура запроса на получения информации(Запрос на получение Айди\ кодзапроса:0\ доп информация: нет)

            switch (info)
            {
                case PacketInfo.ID://запишим 0 и отправим на сервер
                    writer.Write(0);
                    socket.Send(ms.GetBuffer());
                    break;
                case PacketInfo.Position:
                    writer.Write(1);
                    writer.Write(x6);
                    writer.Write(x1);
                    writer.Write(x2);
                    writer.Write(x3);
                    writer.Write(x4);
                    writer.Write(x5);
                    writer.Write(x7);
                   try
                    {
                        socket.Send(ms.GetBuffer());
                    }
                    catch
                    {
                        MessageBox.Show(" Ошибка подключения! ");
                    }
                    break;
            }
        }



        static int ReceivePacket()
        {
            //после записи курсор ставиться вперед поэтому ставим курсор в начало
            ms.Position = 0;
          //получать данные будем в буфер потока
            socket.Receive(ms.GetBuffer());
            //Ответный пакет /0. id       
            int code = reader.ReadInt32();
            // После считывания курсора 0. /id
            int id;
            string f;
            string n;
            string m;
            string k;
            string r;
            
            // если пришёл 0 то считываем его и возвращаем
            switch (code)
            {
                case 0: return reader.ReadInt32(); break;
                
            }
            return -1;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Таймер2++;
            if (Таймер2 == 5) {
                Application.Restart();
                this.Dispose();
            }
        }

      

        
    }
}
