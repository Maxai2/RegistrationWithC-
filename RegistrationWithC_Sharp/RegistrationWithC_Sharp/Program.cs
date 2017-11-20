﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//-----------------------------------------------------------------------------------------------------
namespace RegistrationWithC_Sharp
{
	class Program
	{
		static List<User> users = new List<User>();
		static List<Message> message = new List<Message>();

		static string UsersPath = "Logs\\Users.txt";
		static string MessagePath = "Logs\\Messages.txt";

		static string SecretWord = "Qwerty";

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
					string tempCheck = Console.ReadLine();
					if (tempCheck == "exit")
						return false;
					else
						user.Name = tempCheck;
					File.AppendAllText(UsersPath, user.Name);    

					Console.Write("Enter your surname:\t\t");
					user.Surname = Console.ReadLine();
					File.AppendAllText(UsersPath, user.Surname);

					Console.Write("Enter your age:\t\t\t");
					user.Age = Convert.ToInt32(Console.ReadLine());
					File.AppendAllText(UsersPath, user.Age.ToString());
					//int.TryParse(Console.ReadLine(), out user.Age);
					//Console.Write("Enter secret word for password:\t");
					//user.SecretWord = Console.ReadLine();

					Line();
					//Console.WriteLine("------------------------------------------------------------------------------------\n");
					Console.Write("\n\nYour username is:\t");

					if (user.Name.Length > 4)
						user.Username = user.Name.Remove(4).ToUpper() + '_';
					else
						user.Username = user.Name.ToUpper() + '_';

					user.Username += user.Surname.ToLower().Remove(2) + '_' + user.Age;

					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine(user.Username);
					Console.ForegroundColor = ConsoleColor.Gray;
					File.AppendAllText(UsersPath, user.Username);

					Console.Write("Your password is:\t");
					user.Password = GeneratePassword();
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine(user.Password);
					Console.ForegroundColor = ConsoleColor.Gray;
					
					char[] temp = user.Password.ToCharArray();

					for (int i = 0; i < user.Password.Length; i++)
						temp[i] ^= SecretWord[i % SecretWord.Length];

					user.Password = "";

					for (int j = 0; j < temp.Length; j++)
						user.Password += temp[j];

					//Console.WriteLine(user.Password);
					File.AppendAllText(UsersPath, user.Username);
					users.Add(user);
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

				@switch = Convert.ToBoolean(NL.Next(-1, 1));


				if (@switch)
					temp += (char)NL.Next(48, 57);
				else
					temp += (char)NL.Next(97, 122);

			}

			return temp;
		}
//-----------------------------------------------------------------------------------------------------
		static void LogIn()
		{
			Console.Clear();
			Console.Write("Log In\nEnter username:\t\t");
			string TempUsername = Console.ReadLine();
			Console.Write("Enter password:\t\t");
			string TempPassword = Console.ReadLine();
			//Console.Write("Enter secret word:\t");
			//string TempSecretWord = Console.ReadLine();

			Line();
			//Console.WriteLine("------------------------------------------------------------------------------------\n");
			//char[] temp = Convert.ToString(OneUser[UserCount].Password).ToCharArray();

			for (int i = 0; i < users.Count; i++)
			{
				if (users[i].Username == TempUsername)
				{
					char[] stemp = users[i].Password.ToCharArray();

					for (int j = 0; j < users[i].Password.Length; j++)
						stemp[j] ^= SecretWord[j % SecretWord.Length];

					User temp = users[i];
					temp.Password = "";
					for (int j = 0; j < stemp.Length; j++)
					{
						temp.Password += stemp[j];
					}
					users[i] = temp;

					if (users[i].Password == TempPassword)
					{
						Console.ForegroundColor = ConsoleColor.Green;
						Console.WriteLine($"\n\nWelcome, {users[i].Name} {users[i].Surname}!");
						Console.ForegroundColor = ConsoleColor.Gray;
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("\n\nWrong username or password!");
						Console.ForegroundColor = ConsoleColor.Gray;
					}
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("\n\nWrong username or password!");
					Console.ForegroundColor = ConsoleColor.Gray;
				}
			}
		}
//-----------------------------------------------------------------------------------------------------
		static void Line()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			for (int i = 0; i < 85; i++)
				Console.Write('-');
			Console.ForegroundColor = ConsoleColor.Gray;
		}
//-----------------------------------------------------------------------------------------------------
		static void Pause()
		{
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
//-----------------------------------------------------------------------------------------------------
        static string[] menuList = {"Sign Up", "Log In", "Exit" };

        static void Menu(int select)
        {
            for (int i = 0; i < menuList.Length; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("          ");
                Console.SetCursorPosition(0, i);
                if (i == select)
                    Console.ForegroundColor = ConsoleColor.Cyan;
                else
                    Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine(menuList[i]);
            }
        }
//-----------------------------------------------------------------------------------------------------
        static void Main(string[] args)
		{
            int select = 0;
			//bool registered = false;

            Console.CursorVisible = false;
            while (true)
			{
                Menu(select);
                //Pause();
				//Console.WriteLine("1. Sign Up\n2. Log In\n3. Exit");

                //Console.WriteLine("------------------------------------------------------------------------------------\n");

                var key = Console.ReadKey(true).Key;
                //select = Console.ReadKey(true).KeyChar;
				switch (key)
				{
                    case ConsoleKey.DownArrow: // 1 49 ConsoleKey.DownArrow
						if (select < menuList.Length - 1)
							select++;
                        break;
                    case ConsoleKey.UpArrow: // 2 50 ConsoleKey.UpArrow
						if (select > 0)
							select--;
						break;
                    case ConsoleKey.Enter: // 3 51 ConsoleKey.RightArrow
						{ 
							Console.Clear();
							Console.CursorVisible = true;
							if (select == 0)
							{
								Registration();
								Pause();
								Console.Clear();
							}
							else if (select == 1)
							{
								if (users.Count != 0)
									LogIn();
								else
								{
									Console.CursorVisible = false;
									Console.WriteLine("No user!\nU want to create?");
									if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
									{
										Console.CursorVisible = true;
										Registration();
									}
								}
								Pause();
								Console.Clear();
							}
							else
							{ 
								Console.ForegroundColor = ConsoleColor.Gray;
								Environment.Exit(0);
							}
							break;
						}
				}
				Console.CursorVisible = false;
                        //case 49: // 1 49 ConsoleKey.DownArrow
                        //	//registered = Registration(registered);
                        //	Registration();
                        //	Pause();
                        //	Console.Clear();
                        //	break;
                        //case 50: // 2 50 ConsoleKey.UpArrow
                        //	LogIn();
                        //	Pause();
                        //	Console.Clear();
                        //	break;
                        //case 51: // 3 51 ConsoleKey.RightArrow
                        //	Environment.Exit(0);
                        //	break;
			}
		}
	}
}
//-----------------------------------------------------------------------------------------------------
  //      static string GenerateUserName()
		//{
  //          int index = UserCount;

  //          string temp;
  //          string buffer;

		//	if (OneUser[index].Name.Length > 4)
		//		temp = OneUser[index].Name.Remove(4);

  //          temp = temp.ToUpper() + '_';

		//	Buffer = OneUser[index].Surname.ToLower();
		//	temp += Buffer.Remove(2) + '_' + OneUser[index].Age;

		//	return temp; 
		//}
//-----------------------------------------------------------------------------------------------------
		//static string Encoder()
		//{
		//    //char[] temp = Convert.ToString(OneUser[UserCount].Password).ToCharArray();
		//    char[] temp = OneUser[UserCount].Password.ToCharArray();

		//    for (int i = 0; i < OneUser[UserCount].Password.Length; i++)
		//        temp[i] ^= OneUser[UserCount].SecretWord[i / OneUser[UserCount].SecretWord.Length];

		//    string newPas = Convert.ToString(temp);

		//    return newPas;
		//}
		//-----------------------------------------------------------------------------------------------------
		//static string Decoder()
		//{
		//    //char[] temp = Convert.ToString(OneUser[UserCount].Password).ToCharArray();
		//    char[] temp = OneUser[UserCount].Password.ToCharArray();

		//    for (int i = 0; i < OneUser[UserCount].Password.Length; i++)
		//        temp[i] ^= OneUser[UserCount].SecretWord[i / OneUser[UserCount].SecretWord.Length];

		//    string oldPas = Convert.ToString(temp);

		//    return oldPas;
		//}
//-----------------------------------------------------------------------------------------------------