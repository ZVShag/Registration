﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User() { }
        public User(string login, string email, string password)
        {
           
            Login = login;
            Email = email;
            Password = password;
        }
    }
}
