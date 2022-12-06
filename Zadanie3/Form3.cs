using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Zadanie3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        
        MySqlConnection conn = new MySqlConnection(ConncetToDB.RetStr());
        private void Form3_Load(object sender, EventArgs e)
        {
            conn.Open();
            ConncetToDB.Print(dataGridView1, conn);
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ConncetToDB.RetStr());
        }
    }
}
