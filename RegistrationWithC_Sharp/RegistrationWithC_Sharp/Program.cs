using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//---------------------------------------------------------------------
namespace TestC_Sharp
{
    class Program
    {
        static string Name;
        static string Surname;
        static int Age;
        static string Username;
        static string Password;
        //---------------------------------------------------------------------
        static string GenerateUserName()
        {

            //Username = Name.ToUpper() +
                return "";

        }
        //---------------------------------------------------------------------
        static void Registration()
        {
            Console.Clear();
            Console.Write(@"\tSignUp:
							Enter your name:\t");
            Name = Console.ReadLine();
            Console.Write("Enter your surname:\t");
            Surname = Console.ReadLine();
            Console.Write("Enter your age:\t");
            Age = Console.Read();
            Console.WriteLine(@"
								Your UserName:\t");


        }
        //---------------------------------------------------------------------
        static void LogUp()
        {

        }
        //---------------------------------------------------------------------
        static string GeneratePassword(int length)
        {
            return "asd";
        }
        //---------------------------------------------------------------------
        static void Main(string[] args)
        {
            int select;
            while (true)
            {
                Console.WriteLine(@"1. Sign Up
									2. Sign In
									3. Exit
									>");

                select = Console.Read();

                switch (select)
                {
                    case 1:
                        Registration();

                        break;
                    default:
                        break;
                }
            }
            //---------------------------------------------------------------------
        }
    }
}
