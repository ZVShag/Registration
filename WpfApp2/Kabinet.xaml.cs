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
    /// Логика взаимодействия для Kabinet.xaml
    /// </summary>
    public partial class Kabinet : Window
    {
        User kab_user= new User();
        public Kabinet()
        {
            InitializeComponent();
        }
        public void data_kabinet(User user)
        {
            loginlabel.Content=user.Login;
            emaillabel.Content=user.Email;  
            kab_user.Login=user.Login;
            kab_user.Email=user.Email;
            kab_user.Password=user.Password;
        }
        private void edit_user_name_Click(object sender, RoutedEventArgs e)
        {
            new_login new_Login = new new_login();
            new_Login.Show();
            this.Hide();
        }

        private void edit_user_email_Click(object sender, RoutedEventArgs e)
        {

        }

        private void edit_user_password_Click(object sender, RoutedEventArgs e)
        {
            newpassword npass = new newpassword();
            npass.Show();
            this.Hide();

        }
    }
}
