using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ConnectTODBClassLib;

namespace Zadanie5
{
    public partial class Form5 : Form
    {
        static string connStr = "server=chuc.caseum.ru; port=33333; database=is_2_20_st21_KURS; user=st_2_20_21; password=92621887";
        ConnectClas db = new ConnectClas(connStr);
        MySqlConnection connect = new MySqlConnection(ConnectClas.GetString());
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = $"INSERT t_Uchebka_RYBALYOV(idStud, fioStud, datetimeStud) VALUES({Convert.ToInt32(textBox1.Text)},'{textBox2.Text}','{textBox3.Text}')";

                connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, connect);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Удачно");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connect.Close();
            }
        }
    }
}
