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
using System.IO;

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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string login=newpas.Text;
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


                User user = new User();
                bool t = false;
                using (StreamReader reader = new StreamReader(user.path))
                {
                    string? line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        string[] us = line.Split();
                        if ((us[0] == login) && (us[2] == password))
                        {
                            user.Login = us[0];
                            user.Password = us[2];
                            user.Email = us[1];
                            t = true;
                        }


                    }
                    reader.Close();
                    if (t)
                    {
                        Kabinet kabinet = new Kabinet();
                        kabinet.Show();
                        kabinet.data_kabinet(user);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Такой пользователь не зарегистрирован!");
                    }
                }
            }
        }
    }
}
