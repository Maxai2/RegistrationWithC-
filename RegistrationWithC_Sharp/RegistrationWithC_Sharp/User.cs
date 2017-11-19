using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//-----------------------------------------------------------------------------------------------------
namespace RegistrationWithC_Sharp
{
    class User
    {
        string name;
        string surname;
        int age;
        string username;
        string password;

        //public StringBuilder Password;
        //public string Password;
        //public string SecretWord;
        //public StringBuilder SetPassword { set { Password = value; } }

        public string Name { get { return name; } set { name = value; } }
        public string Surname { get { return surname; } set { surname = value; } }
        public int Age { get { return age; } set { age = value; } }
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
    }
}
//-----------------------------------------------------------------------------------------------------