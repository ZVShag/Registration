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
                List<User> Userlist=new List<User>();
                User user = new User();
                bool t = false;
                using (StreamReader reader = new StreamReader(user.path))
                {
                    string? line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        string[] us = line.Split();
                        user.Login = us[0];
                        user.Password = us[2];
                        user.Email = us[1];
                        if ((user.Password == password))
                        {
                            user.Login = login;
                            t = true;
                        }
                        Userlist.Add(user);

                    }
                    reader.Close();
                }
                
                if (t)
                       
                {
                    MessageBox.Show("Логин успешно изменен!");
                    user.rewrite_user_onfile(Userlist);
                }
                




            }
        }
    }
}
