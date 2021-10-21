using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2ex2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            a.Clear();
            b.Clear();
            result.Clear();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            a.Text = Properties.Settings.Default.a_save;
            b.Text = Properties.Settings.Default.b_save;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.a_save = a.Text;
            Properties.Settings.Default.b_save = b.Text;
            Properties.Settings.Default.Save();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if ((a.Text == "") || (b.Text == ""))
                MessageBox.Show("Некорректный ввод!");
            else
            {
                int detector = 0;
                String a_str = Convert.ToString(a.Text);
                if (Logic.isNumber(a_str) == false)
                {
                    MessageBox.Show("Введено неверное значение!");
                    detector = 1;
                }
                String b_str = Convert.ToString(b.Text);
                if (Logic.isNumber(b_str) == false)
                {
                    MessageBox.Show("Введено неверное значение!");
                    detector = 1;
                }
                if (detector == 0)
                {
                    int a_int = Convert.ToInt32(a.Text);
                    int b_int = Convert.ToInt32(b.Text);
                    if (label4.Text == "Ежемесяч. увелич. вклада")
                        result.Text = Logic.ExerciseA(a_int, b_int);
                    if (label4.Text == "Сумма вклада")
                        result.Text = Logic.ExerciseB(a_int, b_int);
                }
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

            public static string ExerciseA(double a, double b)              //метод, отвечающий за 1ое задание
            {
                double month_up = 0;
                int m_counter = 0;
                string OutMessage = "";

                while (month_up <= b)                                         //цикл, отвечающий за нахождение месяца, в котором выполняется условие задачи
                {
                    month_up = a * 0.02;
                    a = a + month_up;
                    m_counter++;
                }
                if (month_up < b)
                    OutMessage = "Cумма ежемесячного увеличения вклада не превысила " + b;
                else
                {
                    if (m_counter == 1)
                        OutMessage = "Сумма ежемесячного увеличения вклада превысило значение В через 1 месяц";
                    else if ((m_counter <= 4) && (m_counter >= 2))
                        OutMessage = "Сумма ежемесячного увеличения вклада превысило значение В через " + m_counter + " месяца";
                    else
                        OutMessage = "Сумма ежемесячного увеличения вклада превысило значение В через " + m_counter + " месяцев";
                }
                return OutMessage;
            }
            public static string ExerciseB(double a, double c)              //метод, отвечающий за 2ое задание
            {
                string OutMessage = "";
                double month_up = 0;
                int m_counter = 0;

                while (a < c)                                                  //цикл, отвечающий за нахождение месяца, в котором выполняется условие задачи
                {
                    month_up = a * 0.02;
                    a = a + month_up;
                    m_counter++;
                }

                if (a < c)
                    OutMessage = "Размер вклада не превысил " + c;
                else
                {
                    if (m_counter == 1)
                        OutMessage = "Размер вклада превысило значение C через 1 месяц";
                    else if ((m_counter <= 4) && (m_counter >= 2))
                        OutMessage = "Размер вклада превысило значение C через " + m_counter + " месяца";
                    else
                        OutMessage = "Размер вклада превысило значение C через " + m_counter + " месяцев";
                }
                return OutMessage;
            }
        }

        private void a_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                b.Focus();
        }

        private void b_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button2.Focus();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "Ежемесяч. увелич. вклада";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "Сумма вклада";
        }
    }
}
