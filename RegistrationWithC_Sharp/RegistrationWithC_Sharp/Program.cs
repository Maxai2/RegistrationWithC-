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
			string Buffer = Name;
			if (Name.Length > 4)
				Buffer = Name.Remove(4);
			Username = Buffer.ToUpper() + '_';

			Buffer = Surname.ToLower();
			Username += Buffer.Remove(2) + '_' + Age;

			return Username; 
		}
		//---------------------------------------------------------------------
		static string GeneratePassword()
		{
			Random NL = new Random();
			//Random LL = new Random();
			bool @switch = false;

			for (int i = 0; i < 8; i++)
			{
				//UL = new Random();
				//LL = new Random();

				@switch = Convert.ToBoolean(NL.Next(0, 1));


				if (@switch)
					Password += (char)NL.Next(48, 57);
				else
					Password += (char)NL.Next(97, 122);

			}

			return Password;
		}
		//---------------------------------------------------------------------
		static bool Registration(bool reg)
		{
			if (reg)
			{
				Console.Clear();
				Console.WriteLine("Sign Up\nYou are aleady ready!");
				return reg;
			}
			else
			{
				try
				{
					Console.Clear();
					Console.Write("Sign Up\nEnter your name:\t");
					Name = Console.ReadLine();
					Console.Write("Enter your surname:\t");
					Surname = Console.ReadLine();
					Console.Write("Enter your age:\t\t");
					int.TryParse(Console.ReadLine(), out Age);

					Console.WriteLine("------------------------------------------------------------------------------------\n");
					Console.Write("Your username is:\t");
					Console.WriteLine(GenerateUserName());
					Console.Write("Your password is:\t");
					Console.WriteLine(GeneratePassword());
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					return false;
				}

				return true;
			}
		}
		//---------------------------------------------------------------------
		static void LogIn()
		{
			Console.Clear();
			Console.Write("Log In\nEnter username:\t");
			string TempUsername = Console.ReadLine();
			Console.Write("Enter password:\t");
			string TempPassword = Console.ReadLine();

			Console.WriteLine("------------------------------------------------------------------------------------\n");
			if (TempPassword == Password && TempUsername == Username)
				Console.WriteLine($"Welcome, {Name} {Surname}!");
			else
				Console.WriteLine("Wrong username or password!");
		}
		//---------------------------------------------------------------------
		static void Pause()
		{
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		//---------------------------------------------------------------------
		static void Main(string[] args)
		{
			int select;
			bool registered = false;

			while (true)
			{
				Console.Write("1. Sign Up\n2. Log In\n3. Exit\n>");

				//var select = Console.ReadKey(true).Key;
				select = Console.ReadKey(true).KeyChar;

				switch (select)
				{
					case 49: // 1 49 ConsoleKey.DownArrow
						registered = Registration(registered);
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
