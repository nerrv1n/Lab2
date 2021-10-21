using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2ex1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a.Clear();
            b.Clear();
            c.Clear();
            d.Clear();
            n.Clear();
            m.Clear();
            resultBox.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            a.Text = Properties.Settings.Default.a_save;
            b.Text = Properties.Settings.Default.b_save;
            c.Text = Properties.Settings.Default.c_save;
            d.Text = Properties.Settings.Default.d_save;
            n.Text = Properties.Settings.Default.n_save;
            m.Text = Properties.Settings.Default.m_save;
        }

        private void button1_Click(object sender, EventArgs e)              //кнопка "Рассчитать" 
        {
            int detector = 0;
            int a_int=0, b_int=0, c_int=0, d_int=0, n_int=0, m_int = 0;
            if ((a.Text == "") || (b.Text == "") || (c.Text == "") || (d.Text == "") || (n.Text == "") || (m.Text == ""))
                MessageBox.Show("Введите значение!");
            else
            {
                if (Logic.isNumber(Convert.ToString(a.Text)) == false)
                {
                    MessageBox.Show("Введите числовое значение!");
                    detector = 1;
                }
                else
                {
                    a_int = Convert.ToInt32(a.Text);
                    if ((a_int > 23) || (a_int < 0))
                    {
                        MessageBox.Show("Внимание! Неверно задано число!");
                        detector = 1;
                    }
                }

                if (Logic.isNumber(Convert.ToString(b.Text)) == false)
                {
                    MessageBox.Show("Введите числовое значение!");
                    detector = 1;
                }
                else
                {
                    b_int = Convert.ToInt32(b.Text);
                    if ((b_int > 59) || (b_int < 0))
                    {
                        MessageBox.Show("Внимание! Неверно задано число!");
                        detector = 1;
                    }
                }

                if (Logic.isNumber(Convert.ToString(c.Text)) == false)
                {
                    MessageBox.Show("Введите числовое значение!");
                    detector = 1;
                }
                else
                {
                    c_int = Convert.ToInt32(c.Text);
                    if ((c_int > 23) || (c_int < 0))
                    {
                        MessageBox.Show("Внимание! Неверно задано число!");
                        detector = 1;
                    }
                }

                if (Logic.isNumber(Convert.ToString(d.Text)) == false)
                {
                    MessageBox.Show("Введите числовое значение!");
                    detector = 1;
                }
                else
                {
                    d_int = Convert.ToInt32(d.Text);
                    if ((d_int > 59) || (d_int < 0))
                    {
                        MessageBox.Show("Внимание! Неверно задано число!");
                        detector = 1;
                    }
                }

                if (Logic.isNumber(Convert.ToString(n.Text)) == false)
                {
                    MessageBox.Show("Введите числовое значение!");
                    detector = 1;
                }
                else
                {
                    n_int = Convert.ToInt32(n.Text);
                    if ((n_int > 23) || (n_int < 0))
                    {
                        MessageBox.Show("Внимание! Неверно задано число!");
                        detector = 1;
                    }
                }

                if (Logic.isNumber(Convert.ToString(m.Text)) == false)
                {
                    MessageBox.Show("Введите числовое значение!");
                    detector = 1;
                }
                else
                {
                    m_int = Convert.ToInt32(m.Text);
                    if ((m_int > 59) || (m_int < 0))
                    {
                        MessageBox.Show("Внимание! Неверно задано число!");
                        detector = 1;
                    }
                }
                if (Logic.MoreThanHour(a_int, b_int, c_int, d_int) == true)
                {
                    MessageBox.Show("Поезд не может стоять более одного часа! Повторите ввод.");
                    detector = 1;
                }
                if (Logic.LowThanOne(a_int, b_int, c_int, d_int) == true)
                {
                    MessageBox.Show("Поезд не может стоять менее минуты! Повторите ввод.");
                    detector = 1;
                }
                if (detector == 0)
                {
                    var OutMessage = Logic.Compare(a_int, b_int, c_int, d_int, n_int, m_int);
                    resultBox.Text = OutMessage;
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)         //сохранение
        {
            Properties.Settings.Default.a_save = a.Text;
            Properties.Settings.Default.b_save = b.Text;
            Properties.Settings.Default.c_save = c.Text;
            Properties.Settings.Default.d_save = d.Text;
            Properties.Settings.Default.n_save = n.Text;
            Properties.Settings.Default.m_save = m.Text;
            Properties.Settings.Default.Save();
        }

        private void a_KeyDown(object sender, KeyEventArgs e)           //перенос поля ввода по нажатию enter
        {
            if (e.KeyCode == Keys.Enter)
                b.Focus();
        }

        private void b_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                c.Focus();
        }

        private void c_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                d.Focus();
        }

        private void d_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                n.Focus();
        }

        private void n_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                m.Focus();
        }

        private void m_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.Focus();
        }
    }
    public class Logic
    {
        public static Boolean isNumber(string a)                        //метод, необходимый для корректности ввода пользователя
        {
            int detector = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (((int)a[i] < 48) || ((int)a[i] > 57))               //цикл, проверяющий каждый элемент, вводимый пользователем
                    detector++;
            }
            if (detector == 0)
                return true;
            return false;
        }

        public static Boolean MoreThanHour(int a, int b, int c, int d)     //методы, необходимые для проверки времени остановки поезда
        {
            int minutes_ab = minutes(a, b);
            int minutes_cd = minutes(c, d);

            if (minutes_cd-minutes_ab>=60)
                return true;
            return false;
        }

        public static int minutes(int h, int m)
        {
            return h * 60 + m;
        }

        public static Boolean LowThanOne(int a, int b, int c, int d)
        {
            if (((c - a == 0) && (d - b == 0)))
                return true;
            return false;
        }

        public static string Compare(int a, int b, int c, int d, int n, int m) //метод, отвечающий за основную логику программы
        {

            int minutes_ab = minutes(a, b);
            int minutes_cd = minutes(c, d);
            int minutes_nm = minutes(n, m);
            string OutMessage = "";
            if (minutes_ab <= minutes_nm && minutes_nm <= minutes_cd)
                OutMessage = "Поезд на станции!";
            else
                OutMessage = "Поезд не на станции!";
            return OutMessage;
        }
    }
}
