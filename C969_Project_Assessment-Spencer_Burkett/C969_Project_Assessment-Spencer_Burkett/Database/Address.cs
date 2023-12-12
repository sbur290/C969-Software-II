using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_Project_Assessment_Spencer_Burkett.Database
{
   public class Address
   {
      private int addressID;
      private string address;
      private string address2;
      private int cityId;
      private string postalCode;
      private string phone;
      private DateTime createDate;
      private string createdBy;
      private DateTime lastUpdate;
      private string lastUpdateBy;

      public int ID
      {
         get { return addressID; }
      }
      public string Address1
      {
         get { return address; }
         set { address = value; }
      }
      public string Address2
      {
         get { return address2; }
         set { address2 = value; }
      }
      public int CityID
      {
         get { return cityId; }
         set { cityId = value; }
      }
      public string PostalCode
      {
         get { return postalCode; }
         set { postalCode = value; }
      }
      public string Phone
      {
         get { return phone; }
         set { phone = value; }
      }
      public DateTime Created
      {
         get { return createDate; }
      }
      public string CreatedBy
      {
         get { return createdBy; }
      }
      public DateTime Updated
      {
         get { return lastUpdate; }
         set { lastUpdate = value; }
      }
      public string UpdatedBy
      {
         get { return lastUpdateBy; }
         set { lastUpdateBy = value; }
      }

      public Address(int addressID, string address, string address2, int cityId, string postalCode, string phone, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
      {
         this.addressID = addressID;
         this.address = address;
         this.address2 = address2;
         this.cityId = cityId;
         this.postalCode = postalCode;
         this.phone = phone;
         this.createDate = createDate;
         this.createdBy = createdBy;
         this.lastUpdate = lastUpdate;
         this.lastUpdateBy = lastUpdateBy;
      }
   }
}
