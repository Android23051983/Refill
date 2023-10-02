using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Refill
{
    /// <summary>
    /// Логика взаимодействия для ServiceWindow.xaml
    /// </summary>
    public partial class ServiceWindow : Window
    {
        private SqlDataReader reader;
        private DataTable table;
        private SqlConnection conn;
        SqlDataAdapter adapter = null;//SqlDataAdapter
        DataSet set = null;
        SqlCommandBuilder builder = null;
        public ServiceWindow()
        {
            InitializeComponent();
            this.Closed += ServiceWindow_Closed;
            conn = new SqlConnection("Data Source=DESKTOP-0BAGMG4\\SQLEXPRESS;Initial Catalog=RefillAndMiniCafe;Integrated Security=True;");
        }

        private async void asyncButton_Click(object sender, RoutedEventArgs e)
        {
            string? tblName = null;
            if(HotDish.IsChecked == true)
            {
                tblName = HotDish.Name;                
            }
            else if(Garnish.IsChecked == true)
            {
                tblName = Garnish.Name;               
            }
            else if (BreadAndSouce.IsChecked == true)
            {
                tblName = BreadAndSouce.Name;                
            }
            else if(Deserts.IsChecked == true)
            {
                tblName = Deserts.Name;                
            }
            else if(Tea.IsChecked == true)
            { 
                tblName = Tea.Name;                
            }
            else if(Coffee.IsChecked == true)
            {
                tblName = Coffee.Name;           
            }
            else if(AdditionsToTeaCoffee.IsChecked == true)
            {
                tblName = AdditionsToTeaCoffee.Name;
            }
            else if (Refill.IsChecked == true)
            {
                tblName = Refill.Name;
            }
            else if(Users.IsChecked == true)
            {
                tblName= Users.Name;
            }
            string connect = $"SELECT * FROM {tblName}";

            try
            {
                
                set = new DataSet();
                adapter = new SqlDataAdapter(connect, conn);
                dataGrid.ItemsSource = null;
                builder = new SqlCommandBuilder(adapter);
                adapter.Fill(set, $"{tblName}");
                dataGrid.ItemsSource = set.Tables[$"{tblName}"].DefaultView;
                dataGrid.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ServiceWindow_Closed(object sender, EventArgs e)
        {
            MainWindow.WindowBool = false;
        }
    }
}
