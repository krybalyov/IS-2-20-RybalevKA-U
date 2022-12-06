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
using ConnectTODBClassLib;
using MySql.Data.MySqlClient;

namespace Zadanie4
{
    public partial class Form4 : Form
    {
        static string connStr = "server=chuc.caseum.ru; port=33333; database=is_2_20_st21_KURS; user=st_2_20_21; password=92621887";
        MySqlConnection conn;
        ConnectClas db = new ConnectClas(connStr);
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(ConnectClas.GetString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = "SELECT * FROM t_datatime";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int r = dataGridView1.Rows.Add();
                    dataGridView1.Rows[r].Cells[0].Value = reader[0].ToString();
                    dataGridView1.Rows[r].Cells[1].Value = reader[1].ToString();
                    dataGridView1.Rows[r].Cells[2].Value = reader[2].ToString();
                    dataGridView1.Rows[r].Cells[3].Value = reader[3].ToString();

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string id = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();

            try
            {
                conn.Open();
                string sql = $"SELECT photoUrl FROM t_datatime WHERE id = {id}";
                MySqlCommand command = new MySqlCommand(sql, conn);

                string url = command.ExecuteScalar().ToString();

                pictureBox1.ImageLocation = url;

            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
