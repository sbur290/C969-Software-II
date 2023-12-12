using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Project_Assessment_Spencer_Burkett
{
   public class Appointment
   {
      private int appointmentId;
      private int customerId;
      private int userID;
      private string title;
      private string description;
      private string location;
      private string contact;
      private string type;
      private string url;
      private DateTime start;
      private DateTime end;
      private DateTime createDate;
      private string createdBy;
      private DateTime lastUpdate;
      private string lastUpdatedBy;

      public int ID
      {
         get { return appointmentId; }
      }

      public int CustomerID
      {
         get { return customerId; }
      }

      public int UserID
      {
         get { return userID; }
      }

      public string Title

      {
         get { return title; }
         set { title = value; }
      }
      public string Description
      {
         get { return description; }
         set { description = value; }
      }

      public string Location
      {
         get { return location; }
         set { location = value; }
      }

      public string Contact
      {
         get { return contact; }
         set { contact = value; }
      }

      public string Type
      {
         get { return type; }
         set { type = value; }
      }
      public string Url
      {
         get { return url; }
         set { url = value; }
      }

      public DateTime StartDate
      {
         get { return start; }
         set { start = value; }
      }

      public DateTime EndDate
      {
         get { return end; }
         set { end = value; }
      }

      public DateTime CreateDate
      {
         get { return createDate; }
         set { createDate = value; }
      }

      public string CreatedBy
      {
         get { return createdBy;}
      }

      public DateTime LastUpdate
      {
         get { return lastUpdate; }
         set { lastUpdate = value; }
      }

      public string LastUpdatedBy
      {
         get { return lastUpdatedBy;}
         set { lastUpdatedBy = value; }
      }

      public Appointment(int appointmentId, int customerId, int userID, string title, string description, string location, string contact, string type, string url, DateTime start, DateTime end, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdatedBy)
      {
         this.appointmentId = appointmentId;
         this.customerId = customerId;
         this.userID = userID;
         Title = title;
         Description = description;
         Location = location;
         Contact = contact;
         Type = type;
         Url = url;
         this.start = start;
         this.end = end;
         CreateDate = createDate;
         this.createdBy = createdBy;
         LastUpdate = lastUpdate;
         LastUpdatedBy = lastUpdatedBy;
      }
   }
}
