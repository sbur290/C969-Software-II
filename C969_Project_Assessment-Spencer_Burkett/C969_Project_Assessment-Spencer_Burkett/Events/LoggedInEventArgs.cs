using C969_Project_Assessment_Spencer_Burkett.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Project_Assessment_Spencer_Burkett.Events
{
   public class LoggedInEventArgs : EventArgs
   {
      private User user;

      public User User 
      { 
         get { return user; } 
      }

      public LoggedInEventArgs(User user) 
      {
         this.user = user;
      }
   }
}
