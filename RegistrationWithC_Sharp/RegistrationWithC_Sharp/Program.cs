using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//-----------------------------------------------------------------------------------------------------
namespace TestC_Sharp
{
    //-----------------------------------------------------------------------------------------------------
    public struct User
    {
        public string Name;
        public string Surname;
        public int Age;
        public string Username;
        //public StringBuilder Password;
        public string Password;
        public string SecretWord;

        //public StringBuilder SetPassword { set { Password = value; } }
        public string SetPassword { set { Password = value; } }
    }
    //-----------------------------------------------------------------------------------------------------
    class Program
	{
        static int UserCount = 0;

        static List<User> OneUser = new List<User>();

		static bool Registration(/*bool reg*/)
		{
			//if (reg)
			//{
			//	Console.Clear();
			//	Console.WriteLine("Sign Up\nYou are aleady ready!");
			//	return reg;
			//}
			//else
			//{
				try
				{
					var user = new User();
					Console.Clear();
					Console.Write("Sign Up\nEnter your name:\t\t");
					user.Name = Console.ReadLine();
					Console.Write("Enter your surname:\t\t");
					user.Surname = Console.ReadLine();
					Console.Write("Enter your age:\t\t\t");
					int.TryParse(Console.ReadLine(), out user.Age);
                    Console.Write("Enter secret word for password:\t");
                    user.SecretWord = Console.ReadLine();

				    Console.WriteLine("------------------------------------------------------------------------------------\n");
				    Console.Write("Your username is:\t");

                    if (user.Name.Length > 4)
                        user.Username = user.Name.Remove(4);
                    else
                        user.Username = user.Name.ToUpper();

                    user.Username = GenerateUserName();
                    Console.WriteLine(user.Username);

                    Console.Write("Your password is:\t");
                    user.Password = GeneratePassword();
                    Console.WriteLine(user.Password);
                    //user.SetPassword(GeneratePassword());
                    //user.Password.Clear();
                    //user.Password = new StringBuilder(Encoder());
                    user.Password = Encoder();
					OneUser.Add(user);
                    UserCount++;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					return false;
				}

				return true;
//			}
		}
//-----------------------------------------------------------------------------------------------------
        static string GenerateUserName()
		{
            int index = UserCount;

            string temp;
            string buffer;

			if (OneUser[index].Name.Length > 4)
				temp = OneUser[index].Name.Remove(4);

            temp = temp.ToUpper() + '_';

			Buffer = OneUser[index].Surname.ToLower();
			temp += Buffer.Remove(2) + '_' + OneUser[index].Age;

			return temp; 
		}
//-----------------------------------------------------------------------------------------------------
        static string GeneratePassword()
		{
			Random NL = new Random();
			//Random LL = new Random();
			bool @switch = false;
            string temp = "";

			for (int i = 0; i < 8; i++)
			{
				//UL = new Random();
				//LL = new Random();

				@switch = Convert.ToBoolean(NL.Next(0, 1));


				if (@switch)
                    temp += (char)NL.Next(48, 57);
				else
                    temp += (char)NL.Next(97, 122);

			}

			return temp;
		}
        //-----------------------------------------------------------------------------------------------------
        static string Encoder()
        {
            //char[] temp = Convert.ToString(OneUser[UserCount].Password).ToCharArray();
            char[] temp = OneUser[UserCount].Password.ToCharArray();

            for (int i = 0; i < OneUser[UserCount].Password.Length; i++)
                temp[i] ^= OneUser[UserCount].SecretWord[i / OneUser[UserCount].SecretWord.Length];

            string newPas = Convert.ToString(temp);

            return newPas;
        }
        //-----------------------------------------------------------------------------------------------------
        static string Decoder()
        {
            //char[] temp = Convert.ToString(OneUser[UserCount].Password).ToCharArray();
            char[] temp = OneUser[UserCount].Password.ToCharArray();

            for (int i = 0; i < OneUser[UserCount].Password.Length; i++)
                temp[i] ^= OneUser[UserCount].SecretWord[i / OneUser[UserCount].SecretWord.Length];

            string oldPas = Convert.ToString(temp);

            return oldPas;
        }
        //-----------------------------------------------------------------------------------------------------
        static void LogIn()
		{
			Console.Clear();
			Console.Write("Log In\nEnter username:\t");
			string TempUsername = Console.ReadLine();
			Console.Write("Enter password:\t");
			string TempPassword = Console.ReadLine();

			Console.WriteLine("------------------------------------------------------------------------------------\n");
            User temp = new User();
            temp = OneUser[UserCount];
            OneUser.Remove(OneUser[UserCount]);
            temp.Password = Decoder();
            OneUser[UserCount] = temp;

            //OneUser[UserCount].Password.Clear();
            //OneUser[UserCount].Password = new StringBuilder(Decoder());

            if (TempPassword == Convert.ToString(OneUser[UserCount].Password) && TempUsername == OneUser[UserCount].Username)
				Console.WriteLine($"Welcome, {OneUser[UserCount].Name} {OneUser[UserCount].Surname}!");
			else
				Console.WriteLine("Wrong username or password!");
		}
//-----------------------------------------------------------------------------------------------------
        static void Pause()
		{
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
//-----------------------------------------------------------------------------------------------------
        static void Main(string[] args)
		{
			int select;
//			bool registered = false;

			while (true)
			{
				Console.Write("1. Sign Up\n2. Log In\n3. Exit\n>");

				//var select = Console.ReadKey(true).Key;
				select = Console.ReadKey(true).KeyChar;

				switch (select)
				{
					case 49: // 1 49 ConsoleKey.DownArrow
						//registered = Registration(registered);
                        Registration();
						Pause();
						Console.Clear();
						break;
					case 50: // 2 50 ConsoleKey.UpArrow
						LogIn();
						Pause();
						Console.Clear();
						break;
					case 51: // 3 51 ConsoleKey.RightArrow
						Environment.Exit(0);
						break;
				}
			}
		}
	}
}
//-----------------------------------------------------------------------------------------------------