using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Project_Assessment_Spencer_Burkett.Database
{
   public class User
   {
      private int userID;
      private string userName;
      private string password;
      private bool active;
      private DateTime createdDate;
      private string createdBy;
      private DateTime update;
      private string updateBy;

      public int ID
      {
         get { return userID; }
      }
      public string Username
      {
         get { return userName; }
      }
      public string Password
      {
         get { return password; }
      }
      public bool IsActive
      {
         get { return active; }
      }
      public DateTime Datecreatedd
      {
         get { return createdDate; }
      }
      public string CreatedBy
      {
         get { return createdBy; }
      }
      public DateTime Updated
      {
         get { return update; }
      }
      public string UpdatedBy
      {
         get { return updateBy; }
      }

      public User(int userID, string userName, string password, bool active, DateTime createdDate, string createdBy)
      {
         this.userID = userID;
         this.userName = userName;
         this.password = password;
         this.active = active;
         this.createdDate = createdDate;
         this.createdBy = createdBy;

         update = createdDate;
         updateBy = createdBy;
      }

      public User(int userID, string userName, string password, bool active, DateTime createdDate, string createdBy, DateTime update, string updateBy)
      {
         this.userID = userID;
         this.userName = userName;
         this.password = password;
         this.active = active;
         this.createdDate = createdDate;
         this.createdBy = createdBy;
         this.update = update;
         this.updateBy = updateBy;
      }
   }
}
