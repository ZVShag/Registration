using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WpfApp2
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string path = "Users.txt";
        public User() { }
        public User(string login, string email, string password)
        {
           
            Login = login;
            Email = email;
            Password = password;
        }
        public void write_user_onfile()
        {
            string user_info=this.Login+" "+this.Email+ " "+this.Password;
            StreamWriter f=new StreamWriter(this.path,true);
            f.Write(user_info);
            f.Close();
        }
    }
}
