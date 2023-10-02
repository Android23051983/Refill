using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refill
{
    public class PasswordModel
    {
        public static int statusBool = 0;// переменная задающая статус кассира (кассир, старший кассир, администратор)
        public static string Cashier;// переменная хранящая имя текущего кассира для формирования таблицы продаж и записи продажи в Базу Данных
        /// <summary>
        /// Метод читающий базу данных
        /// </summary>
        /// <param name="selectSQL">передаёт в метод запрос к Базе Данных</param>
        /// <returns>возвращает таблицу dataTable типа DataTable</returns>
        public static DataTable  Select(string selectSQL)
        {
            string connectString = "Data Source=DESKTOP-0BAGMG4\\SQLEXPRESS;Initial Catalog=RefillAndMiniCafe;Integrated Security=True;";
            DataTable dataTable = new DataTable("RefillAndMiniCafe");
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = selectSQL;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dataTable); 
            return dataTable;
        }
    }
}
