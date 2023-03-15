using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

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
            f.WriteLine(user_info);
            f.Close();
            
        }
        public void rewrite_user_onfile(List <User> values)
        {

            using (StreamWriter f = new StreamWriter(this.path))
            {
                foreach(User value in values)
                {
                    string user_info = value.Login + " " + value.Email + " " + value.Password;
                    f.WriteLine(user_info);
                }
            }
            
            
        }
        public void Shifr()
        {
            using (Aes aes = Aes.Create())
            {
                byte[] salt = new byte[16];
                new RNGCryptoServiceProvider().GetBytes(salt);

                Rfc2898DeriveBytes keyGenerator = new Rfc2898DeriveBytes("password", salt);
                aes.Key = keyGenerator.GetBytes(aes.KeySize / 8);

                aes.IV = GenerateRandomBytes(aes.BlockSize / 8);

                using (FileStream inputFileStream = new FileStream(path, FileMode.Open))
                using (FileStream outputFileStream = new FileStream(path, FileMode.Create))
                using (CryptoStream cryptoStream = new CryptoStream(outputFileStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    outputFileStream.Write(salt, 0, salt.Length);

                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    while ((bytesRead = inputFileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        cryptoStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }

        static byte[] GenerateRandomBytes(int length)
        {
            byte[] bytes = new byte[length];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            return bytes;
        }
    
    }
}
