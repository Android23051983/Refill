using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Refill
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool WindowBool = false;// переменная для записи значения события "this.Closed += ServiceWindow_Closed"
        
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // создание, подключение и вывод нового окна авторизации после загрузки MainWindow
            PasswordWindow passwordWindow = new PasswordWindow();
            passwordWindow.Owner = this;
            passwordWindow.ShowDialog();
          
                        
        }
        /// <summary>
        /// Click на кнопке "Сервисное обслуживание"
        /// </summary>
        private void ServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordModel.statusBool == 3)
            {
                ServiceWindow serviceWindow = new ServiceWindow();
                serviceWindow.Owner = this;
                serviceWindow.ShowDialog();
            }
            else if (PasswordModel.statusBool != 3)
            {
                MessageBox.Show("Смените кассира на Администратора");
            }

            if(WindowBool == false)
            {
                PasswordWindow passwordWindow = new PasswordWindow();
                passwordWindow.Owner = this;
                passwordWindow.ShowDialog();
            }
        }

        /// <summary>
        /// Click на кнопке "Отмена продажи"
        /// </summary>
        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            PasswordWindow passwordWindow = new PasswordWindow();
            passwordWindow.Owner = this;
            passwordWindow.ShowDialog();

            if(PasswordModel.statusBool == 2 || PasswordModel.statusBool == 3)
            {
                MessageBox.Show("Продажа отменена");
            }
            
        }

        /// <summary>
        /// Click на кнопке "Смена кассира  Блокировка ПО"
        /// </summary>
        public void CashierBtn_Click(object sender, RoutedEventArgs e)
        {
            PasswordWindow passwordWindow = new PasswordWindow();
            passwordWindow.Owner = this;
            passwordWindow.ShowDialog();
            WindowBool = true;
        }
    }
}
