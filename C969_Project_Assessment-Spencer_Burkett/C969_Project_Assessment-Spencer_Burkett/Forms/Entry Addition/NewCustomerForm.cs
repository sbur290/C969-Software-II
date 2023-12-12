using C969_Project_Assessment_Spencer_Burkett.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Project_Assessment_Spencer_Burkett.Forms.Entry_Addition
{
   public partial class NewCustomerForm : Form
   {
      User currentUser;
      public NewCustomerForm(User user)
      {
         InitializeComponent();
         currentUser = user;
      }

      private void NewCustomerForm_Load(object sender, EventArgs e)
      {
         LoadForm();
      }

      private void LoadForm()
      {
         newCustomerIDTxtBx.Text = DBConnection.GenerateID("customer", "customerId").ToString();

         List<Address> allAddresses = DBConnection.GetAddresses();
         foreach (var address in allAddresses)
         {
            newCustomerAddressIDCmb.Items.Add(address.ID);
         }

         newCustomerAddressIDCmb.SelectedIndex = 0;
      }
      private bool IsFormValid()
      {
         bool valid = false;
         if(!Validator.IsNullOrWhitespace(newCustomerNameTxtBx)      &&
            !Validator.HasInvalidCharacters(newCustomerNameTxtBx)       )
         {
            valid = true;
         }
         return valid;
      }

      private void newCustomerSaveBtn_Click(object sender, EventArgs e)
      {
         if (!IsFormValid())
         {
            MessageBox.Show("One or more fields is invalid");
            return;
         }
         Customer newCustomer = new Customer(int.Parse(newCustomerIDTxtBx.Text), newCustomerNameTxtBx.Text, int.Parse(newCustomerAddressIDCmb.SelectedItem.ToString()), 
                                             newCustomerActiveChkBx.Checked, DateTime.Now,  currentUser.Username, DateTime.Now, currentUser.Username);

         string insertValues = $"{newCustomer.CustomerID}, \"{newCustomer.CustomerName}\", {newCustomer.AddressID}, {newCustomer.Active}, \"{newCustomer.DateCreated:yyyy-MM-dd HH:mm:ss}\", " +
                $"\"{newCustomer.CreatedBy}\", \"{newCustomer.DateUpdated:yyyy-MM-dd HH:mm:ss}\", \"{newCustomer.UpdatedBy}\"";

         int rowsAffected = DBConnection.InsertNewRecord("customer", insertValues);

         if(rowsAffected > 0) 
         {
            MessageBox.Show("Customer saved.");
            Close();
         }
         else
         {
            MessageBox.Show("Insertion failed. Customer has not been saved.");
         }
      }

      private void newCustomerCancelBtn_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void newCustomerAddressIDCmb_SelectedIndexChanged(object sender, EventArgs e)
      {
         Address newAddress = DBConnection.GetAddressById(int.Parse(newCustomerAddressIDCmb.SelectedItem.ToString()));
         
         if(newAddress != null) 
         {
            StringBuilder fullAddress = new StringBuilder();
            fullAddress.Append($"{newAddress.Address1}");
            if (newAddress.Address2 != "") 
            { 
               fullAddress.Append($", {newAddress.Address2}\r\n"); 
            
            }
            newCustomerAddressDataLbl.Text = fullAddress.ToString();
            newCustomerPhoneDataLbl.Text = newAddress.Phone;

            DBConnection.OpenConnection();
            string cityQuery = $"SELECT * FROM city WHERE cityId = {newAddress.CityID}";
            MySqlCommand cityCommand = new MySqlCommand(cityQuery, DBConnection.conn);

            MySqlDataReader reader = cityCommand.ExecuteReader();
            City selectedCity = null;
            while(reader.Read())
            {
               selectedCity = new City(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetString(4), reader.GetDateTime(5), 
                                       reader.GetString(6));
            }

            newCustomerCityNameDataLbl.Text = selectedCity.Name;

            DBConnection.OpenConnection();
            string countryQuery = $"SELECT * FROM country WHERE countryId = {selectedCity.CountryID}";
            MySqlCommand countryCommand = new MySqlCommand(countryQuery, DBConnection.conn);

            reader = countryCommand.ExecuteReader();
            Country selectedCountry = null;
            while (reader.Read())
            {
               selectedCountry = new Country (reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5));
            }

            newCustomerCountryNameDataLbl.Text = selectedCountry.Name;
         }



      }

      private void newCustomerNewAddressBtn_Click(object sender, EventArgs e)
      {
         NewAddressForm newAddressForm = new NewAddressForm(currentUser);
         this.Visible = false;
         newAddressForm.ShowDialog();
         LoadForm();
         this.Visible = true;
      }
   }
}
