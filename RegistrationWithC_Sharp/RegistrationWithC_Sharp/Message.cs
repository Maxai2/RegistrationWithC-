using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//-----------------------------------------------------------------------------------------------------
namespace RegistrationWithC_Sharp
{
    class Message
    {
        User user;
//      DateTime date;
        string text;

        public User UserGetSet { get { return user; } set { user = value; } }
        public string Text { get { return text; } set { text = value; } }

		//public DateTime Date
  //      {
  //          get { return date; }
  //          set { date = value;}
  //      } 		
    }
}
//-----------------------------------------------------------------------------------------------------