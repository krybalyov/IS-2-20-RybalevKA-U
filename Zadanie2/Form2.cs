using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Zadanie2
{
    public partial class Form2 : Form
    {
        string connectStr = "server=chuc.caseum.ru;port=33333;database=uchebka;user=uchebka;password=uchebka;";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(Connect.ReturnStr(connectStr));
            conn.Open();
            conn.Close();
            MessageBox.Show(Connect.ReturnStr(connectStr),"Строка подключения: ");
        }
    }
}
