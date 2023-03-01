﻿using System;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login=loginbox.Text.ToLower();
            string email=emailbox.Text.ToLower();
            string password=passwordbox.Password;
            if (login.Length<6)
            {
            loginbox.ToolTip = "Недостаточная длина, должна быть не меньше 6";
            loginbox.Background = Brushes.Red;
            }
            else 
            if (password.Length < 6)
            {
             passwordbox.ToolTip = "Недостаточная длина, должна быть не меньше 6";
             passwordbox.Background = Brushes.Red;
            }
            else   
            if (email.Length < 6 || !email.Contains("@") || !email.Contains(".")) 
            {
                emailbox.ToolTip = "Некоректно введен адрес электронной почты!";
                emailbox.Background = Brushes.Red;
            }
            else
            {
                loginbox.ToolTip = "";
                loginbox.Background = Brushes.Transparent;
                passwordbox.ToolTip = "";
                passwordbox.Background = Brushes.Transparent;
                emailbox.ToolTip = "";
                emailbox.Background = Brushes.Transparent;


            }
            

        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}