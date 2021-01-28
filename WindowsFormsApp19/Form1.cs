using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp19
{
    public partial class Form1 : Form
    {
        //Счётчик количества экземпляров класса
        int i = 0;
        //Объявляем массив экземпляров классов
        Patient[] plp = new Patient[10];

        public Form1()
        {
            InitializeComponent();
        }

        class Patient
        {
            //Поля класса
            public string fio;
            public string dr;
            public string palata;
            public string data_vipis;

            // Конструкторы класса, принимающие значения  переменных из TextBox
            public Patient(string fn, string ln, string a) { fio = fn; dr = ln; palata = a; data_vipis = "Неопределена"; }
            public Patient(string fn, string ln, string a, string dt_v) { fio = fn; dr = ln; palata = a; data_vipis = ""; data_vipis = dt_v; }



            //Метод класса для вывода информации в listbox
            public void GetInfo(ListBox listbox1)
            {
                listbox1.Items.Add($"ФИО: {fio} Дата рождения {dr} Палата {palata} Дата выписки {data_vipis}");
            }

            //Метод класса для выписки пациентов
            public void Vipis(string new_dt)
            {
                this.data_vipis = new_dt;
            }
        }

        //ВВвод новых экземпляров класса
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //Используя конструктор, вводим данные из textbox в поля экземплярра класса         
            plp[i] = new Patient(textBox1.Text, textBox2.Text, textBox3.Text);
            //Метод вывода добавленного экземпляра класса в ListBox
            plp[i].GetInfo(listBox1);
            //Увеличиваем счётчик на единицу, что бы использовать данную переменную как индекс массива экземпляра классов.
            i++;
        }

        //Метод вывода всех экземпляров класса
        public void GetAllList(ListBox listBox1)
        {
            listBox1.Items.Clear();

            for (int p = 0; p < i; p++)
            {
                plp[p].GetInfo(listBox1);
            }
        }
        //Вызов метода вывода всех экземпляров класса
        private void button2_Click(object sender, EventArgs e)
        {
            GetAllList(listBox1);
        }
        //Вызов метода класса "Выписка"
        private void button3_Click(object sender, EventArgs e)
        {
            int id_select = listBox1.SelectedIndex;
            MessageBox.Show(id_select.ToString());
            plp[id_select].Vipis(textBox4.Text);
            listBox1.Items.Clear();
            GetAllList(listBox1);

        }
    }
}
