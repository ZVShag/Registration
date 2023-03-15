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
    /// Логика взаимодействия для newemail.xaml
    /// </summary>
    public partial class newemail : Window
    {
        public newemail()
        {
            InitializeComponent();
        }

        private async void EmailButton_Click(object sender, RoutedEventArgs e)
        {
            User user1 = new User();
            string login = nemail.Text;
            string password = pas.Password;
            if (login.Length < 6)
            {
                nemail.ToolTip = "Неверно указан логин!";
                nemail.Background = Brushes.Red;
            }
            else
            if (password.Length < 6)
            {
                pas.ToolTip = "Неверно указан пароль!";
                pas.Background = Brushes.Red;
            }
            else
            {
                nemail.ToolTip = "";
                nemail.Background = Brushes.Transparent;
                pas.ToolTip = "";
                pas.Background = Brushes.Transparent;

                List<string> list = new List<string>();
                User user = new User();
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
                    
                    string[] us = line.Split(' ');
                    if ((us[2] == password))
                    {
                        user.Login = us[0];
                        user.Email = us[1];
                        user.Password = password;
                        t = true;

                    }
                }
                if (t)
                {
                    MessageBox.Show("Email успешно изменен!");
                    user.write_user_onfile();
                }
            }
        }
    }
}
