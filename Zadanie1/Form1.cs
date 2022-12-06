using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hard = new HardDisk(Convert.ToDecimal(textBox1.Text), Convert.ToInt16(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text, Convert.ToInt32(textBox5.Text));

        }
        HardDisk hard;
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Жёсткий диск: ");
            hard.Display(listBox1);
        }

        Graphic graphic;
        private void button2_Click(object sender, EventArgs e)
        {
            graphic = new Graphic(Convert.ToDecimal(textBox10.Text), Convert.ToInt16(textBox9.Text), Convert.ToDouble(textBox8.Text), textBox7.Text, Convert.ToInt16(textBox6.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Видеокарта: ");
            graphic.Display(listBox1);
        }
    }
    public abstract class Access<T>
    {
        T Articul;
        internal decimal Price;
        internal short Year;
        public Access(decimal price, short year)
        {
            Price = price;
            Year = year;
        }
        //public Access()
        //{

        //}
        public abstract void Display(ListBox listbox);
    }
    internal class HardDisk : Access<string>
    {
        //Вращения
        private int turns;
        public int Turns_Sv
        {
            get { return turns; }
            set { turns = value; }
        }
        //
        //Интерфейс(поле)
        private string @interface;
        public string Interface_Sv
        {
            get { return @interface; }
            set { @interface = value; }
        }
        //
        //Объём
        private int size;
        public int Size_Sv
        {
            get { return size; }
            set { size = value; }
        }
        //

        public HardDisk(decimal price, short year, int turns, string @interface, int size) : base(price, year)
        {
            Turns_Sv = turns;
            Interface_Sv = @interface;
            Size_Sv = size;
        }

        public override void Display(ListBox listbox)
        {
            listbox.Items.Add(String.Concat(Enumerable.Repeat("=", 20)));
            listbox.Items.Add($"\nЦена: {this.Price} \tГод: {this.Year}");
            listbox.Items.Add($"Вращения: {Turns_Sv}\tИнтерфейс: {Interface_Sv}\tОбъём: {Size_Sv}");
            listbox.Items.Add(String.Concat(Enumerable.Repeat("=", 20)));
        }
    }
    internal class Graphic : Access<string>
    {
        //Частота
        private double gpu_gh;
        public double GPU_Gh
        {
            get { return gpu_gh; }
            set { gpu_gh = value; }
        }
        //

        //Производитель
        private string maker;
        public string Maker
        {
            get { return maker; }
            set { maker = value; }
        }
        //

        //Объём памяти
        private short gpu_memory;
        public short GPU_Memory
        {
            get { return gpu_memory; }
            set { gpu_memory = value; }
        }
        //

        public Graphic(decimal price, short year, double gPU_Gh, string maker, short gPU_Memory) : base(price, year)
        {
            GPU_Gh = gPU_Gh;
            Maker = maker;
            GPU_Memory = gPU_Memory;
        }

        public override void Display(ListBox listbox)
        {
            listbox.Items.Add(String.Concat(Enumerable.Repeat("=", 20)));
            listbox.Items.Add($"\nЦена: {this.Price} \tГод: {this.Year}");
            listbox.Items.Add($"Частота: {GPU_Gh}\tПроизводитель: {Maker}\tОбъём: {GPU_Memory}");
            listbox.Items.Add(String.Concat(Enumerable.Repeat("=", 20)));

        }
    }
}
