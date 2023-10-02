using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Refill
{
    /// <summary>
    /// Логика взаимодействия для PasswordWindow.xaml
    /// </summary>
    public partial class PasswordWindow : Window
    {
        private string nameValue;
        private string passwordValue;
        private SqlConnection conn = null;
        private SqlDataAdapter da = null;
        private DataSet set = null;
        private SqlCommandBuilder cmd = null;
        private string connStr = "Data Source=DESKTOP-0BAGMG4\\SQLEXPRESS;Initial Catalog=RefillAndMiniCafe;Integrated Security=True;";
        private string query = "SELECT Name FROM Users";
        public PasswordWindow()
        {

            InitializeComponent();
           //Заполнение кассиров в GroupBox "nameBox"
           conn = new SqlConnection();
            try
            {
                conn = new SqlConnection(connStr);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    nameBox.Items.Add(reader.GetString("name"));
                }
                nameBox.SelectedIndex = 0;
            }
            catch
            {

            }
            finally { conn.Close(); }

        }
        /// <summary>
        /// Сохранение имени выбранного пользователя в GroupBox "nameBox" через событие "SelectionChanged""
        /// </summary>
        private void peopleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            nameBox.SelectedItem = nameValue;
        }

        /// <summary>
        /// Сравнение введённых данных в поля name и password с данными хранящимися в таблице Users 
        /// </summary>
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (nameBox.SelectedIndex > -1)// проверяем введён ли логин
            {
                if (passwordBox.Password.Length > 0)
                {// ищем в базе данных пользователя с такими данными
                    DataTable dt_user = PasswordModel.Select("SELECT * FROM Users WHERE  name = '" + nameBox.SelectedItem + "' AND passwd = '" + passwordBox.Password + "'");
                    foreach (DataRow row in dt_user.Rows)
                    {
                        PasswordModel.statusBool = Convert.ToInt32(row["Status"]);
                    }
                    if (dt_user.Rows.Count > 0)//если такая запись существует
                    {
                        this.Owner.Title = $"Заправочный комплекс Лукойл (работает кассир: {nameBox.SelectedItem})";
                        PasswordModel.Cashier = nameBox.SelectedItem.ToString()!;

                        this.DialogResult = true;
                    }
                    else MessageBox.Show("Неверный логин или пароль");
                }
                else MessageBox.Show("Введите пароль");
            }
            else MessageBox.Show("Выберите имя");
        }
    }
}
