using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для new_login.xaml
    /// </summary>
    public partial class new_login : Window
    {
        public new_login()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            User user1 = new User();
            string login = newpas.Text;
            string password = passwordbox.Password;
            if (login.Length < 6)
            {
                newpas.ToolTip = "Неверно указан логин!";
                newpas.Background = Brushes.Red;
            }
            else
            if (password.Length < 6)
            {
                passwordbox.ToolTip = "Неверно указан пароль!";
                passwordbox.Background = Brushes.Red;
            }
            else
            {
                newpas.ToolTip = "";
                newpas.Background = Brushes.Transparent;
                passwordbox.ToolTip = "";
                passwordbox.Background = Brushes.Transparent;

                List<string> list = new List<string>();

                bool t = false;
                using (StreamReader reader = new StreamReader(user1.path))
                {
                    string? line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        list.Add(line);
                    }
                }
                foreach (string line in list)
                {
                    User user = new User();
                    string[] us = line.Split(' ');
                    if ((us[0] == login) && (us[2] == password))
                    {
                        user.Login = login;
                        user.Email = us[1];
                        user.Password = us[2];

                    }
                    else
                    {
                        user.Login = us[0];
                        user.Email = us[1];
                        user.Password = us[2];
                    }
                    user.write_user_onfile();
                }




            }
        }
    }
}
