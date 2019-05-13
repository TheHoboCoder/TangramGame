using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Tangram.Data.DataModels
{
    public class User:BaseEntity
    {

        public enum UserTypes
        {
            VOSP,
            MET
        }

        public UserTypes UserType { get; private set; }

        public string Login { get; private set; }
        public string Name { get; private set; }
        public string Fam { get; private set; }
        public string Otch { get; private set; }
        public string Phone { get; private set; }
        public string Password { get; private set; }

        public string Initials
        {
            get
            {
                return Fam + " " + Name.Substring(0, 1).ToUpper() + "." + Otch.Substring(0, 1).ToUpper();
            }
        }

        public static string getHash(string password)
        {
            using (MD5 cipher = MD5.Create())
            {
                byte[] data = cipher.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();

            }
        }

        public User(int Id, UserTypes userType, string login, string name, string fam, string otch,string phone, string password)
        {
            this.Id = Id;
            UserType = userType;
            Login = login;
            Name = name;
            Fam = fam;
            Otch = otch;
            Phone = phone;
            Password = password;
        }

    }
}
