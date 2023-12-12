using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Project_Assessment_Spencer_Burkett.Database
{
   public class Customer
   {
      private int customerID;
      private string customerName;
      private int addressID;
      private bool active;
      private DateTime createDate;
      private string createdBy;
      private DateTime update;
      private string updateBy;

      public int CustomerID
      {
         get { return customerID; }
      }
      public string CustomerName
      {
         get { return customerName; }
         set { customerName = value; }
      }
      public int AddressID
      {
         get { return addressID; }
         set { addressID = value; }
      }
      public bool Active
      {
         get { return active; }
         set { active = value; }
      }
      public DateTime DateCreated
      {
         get { return createDate; }
      }
      public string CreatedBy
      {
         get { return createdBy; }
      }
      public DateTime DateUpdated
      {
         get { return update; }
         set { update = value; }
      }
      public string UpdatedBy
      {
         get { return updateBy; }
         set { updateBy = value; }
      }

      public Customer(int customerID, string customerName, int addressID, bool active, DateTime createDate, string createdBy, DateTime update, string updateBy)
      {
         this.customerID = customerID;
         this.customerName = customerName;
         this.addressID = addressID;
         this.active = active;
         this.createDate = createDate;
         this.createdBy = createdBy;
         this.update = update;
         this.updateBy = updateBy;
      }
   }
}
