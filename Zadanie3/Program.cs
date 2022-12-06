using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie3
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3());
        }
    }
    public class ConncetToDB
    {
        static string connect = "server=chuc.caseum.ru; port=33333; database=is_2_20_st21_KURS; user=st_2_20_21; password=92621887";
        public static string RetStr()
        {
            return connect;
        }
        public static void Print(DataGridView datagrid, MySqlConnection conn)
        {
            string load = $"select * from Main left join t_manufacturer on Main.manufacurer_id=t_manufacturer.id";
            MySqlCommand cmd = new MySqlCommand(load, conn);
            MySqlDataReader read = cmd.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (read.Read())
            {
                data.Add(new string[7]);
                data[data.Count - 1][0] = read[0].ToString();
                data[data.Count - 1][1] = read[1].ToString();
                data[data.Count - 1][2] = read[2].ToString();
                data[data.Count - 1][3] = read[3].ToString();
                data[data.Count - 1][4] = read[4].ToString();
                data[data.Count - 1][5] = read[5].ToString();
            }
            foreach (string[] s in data)
                datagrid.Rows.Add(s);

            read.Close();
        }
    }
}
