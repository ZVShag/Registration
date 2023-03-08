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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Singin.xaml
    /// </summary>
    public partial class Singin : Window
    {
        public Singin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login=loginbox.Text;
            string password = passwordbox.Password;
            if (login.Length < 6)
            {
                loginbox.ToolTip = "Неверно указан логин!";
                loginbox.Background = Brushes.Red;
            }
            else
                if (password.Length < 6)
            {
                passwordbox.ToolTip = "Неверно указан пароль!";
                passwordbox.Background = Brushes.Red;
            }
            else
            {
                loginbox.ToolTip = "";
                loginbox.Background = Brushes.Transparent;
                passwordbox.ToolTip = "";
                passwordbox.Background = Brushes.Transparent;

            }
        }
    }
}
