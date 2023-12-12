using C969_Project_Assessment_Spencer_Burkett.Database;
using C969_Project_Assessment_Spencer_Burkett.Forms.Entry_Addition;
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

namespace C969_Project_Assessment_Spencer_Burkett.Forms.Modify_Or_Delete
{
   public partial class ModifyCustomerForm : Form
   {
      User currentUser;
      Customer currentCustomer;
      public ModifyCustomerForm(User user, Customer customer)
      {
         InitializeComponent();
         currentUser = user;
         currentCustomer = customer;
      }

      private void ModifyCustomerForm_Load(object sender, EventArgs e)
      {
         LoadForm();
      }

      private void LoadForm()
      {
         modifyCustomerIDTxtBx.Text = currentCustomer.CustomerID.ToString();

         List<Address> allAddresses = DBConnection.GetAddresses();
         foreach (var address in allAddresses)
         {
            modifyCustomerAddressIDCmb.Items.Add(address.ID);
         }

         modifyCustomerNameTxtBx.Text = currentCustomer.CustomerName;
         modifyCustomerActiveChkBx.Checked = currentCustomer.Active;
         modifyCustomerAddressIDCmb.SelectedItem = currentCustomer.AddressID;
      }
      private bool IsFormValid()
      {
         bool valid = false;
         if (!Validator.IsNullOrWhitespace(modifyCustomerNameTxtBx) &&
            !Validator.HasInvalidCharacters(modifyCustomerNameTxtBx))
         {
            valid = true;
         }
         return valid;
      }

      private void modifyCustomerSaveBtn_Click(object sender, EventArgs e)
      {
         if (!IsFormValid())
         {
            MessageBox.Show("One or more fields is invalid");
            return;
         }
         Customer newCustomer = new Customer(int.Parse(modifyCustomerIDTxtBx.Text), modifyCustomerNameTxtBx.Text, int.Parse(modifyCustomerAddressIDCmb.SelectedItem.ToString()),
                                             modifyCustomerActiveChkBx.Checked, DateTime.Now, currentUser.Username, DateTime.Now, currentUser.Username);

         string insertValues = $"customerId = {newCustomer.CustomerID}, customerName = \"{newCustomer.CustomerName}\", addressId = {newCustomer.AddressID}, active = {newCustomer.Active}, createDate = \"{newCustomer.DateCreated:yyyy-MM-dd HH:mm:ss}\", " +
                $"createdBy = \"{newCustomer.CreatedBy}\", lastUpdate = \"{newCustomer.DateUpdated:yyyy-MM-dd HH:mm:ss}\", lastUpdateBy = \"{newCustomer.UpdatedBy}\"";

         int rowsAffected = DBConnection.ModifyRecord("customer", insertValues, $"customerId = {newCustomer.CustomerID}");

         if (rowsAffected > 0)
         {
            MessageBox.Show("Customer saved.");
            Close();
         }
         else
         {
            MessageBox.Show("Insertion failed. Customer has not been saved.");
         }
      }

      private void modifyCustomerCancelBtn_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void modifyCustomerAddressIDCmb_SelectedIndexChanged(object sender, EventArgs e)
      {
         Address modifyAddress = DBConnection.GetAddressById(int.Parse(modifyCustomerAddressIDCmb.SelectedItem.ToString()));

         if (modifyAddress != null)
         {
            StringBuilder fullAddress = new StringBuilder();
            fullAddress.Append($"{modifyAddress.Address1}");
            if (modifyAddress.Address2 != "")
            {
               fullAddress.Append($", {modifyAddress.Address2}\r\n");

            }
            modifyCustomerAddressDataLbl.Text = fullAddress.ToString();
            modifyCustomerPhoneDataLbl.Text = modifyAddress.Phone;

            DBConnection.OpenConnection();
            string cityQuery = $"SELECT * FROM city WHERE cityId = {modifyAddress.CityID}";
            MySqlCommand cityCommand = new MySqlCommand(cityQuery, DBConnection.conn);

            MySqlDataReader reader = cityCommand.ExecuteReader();
            City selectedCity = null;
            while (reader.Read())
            {
               selectedCity = new City(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetString(4), reader.GetDateTime(5),
                                       reader.GetString(6));
            }

            modifyCustomerCityNameDataLbl.Text = selectedCity.Name;

            DBConnection.OpenConnection();
            string countryQuery = $"SELECT * FROM country WHERE countryId = {selectedCity.CountryID}";
            MySqlCommand countryCommand = new MySqlCommand(countryQuery, DBConnection.conn);

            reader = countryCommand.ExecuteReader();
            Country selectedCountry = null;
            while (reader.Read())
            {
               selectedCountry = new Country(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5));
            }

            modifyCustomerCountryNameDataLbl.Text = selectedCountry.Name;
         }



      }

      private void modifyCustomerNewAddressBtn_Click(object sender, EventArgs e)
      {
         NewAddressForm newAddressForm = new NewAddressForm(currentUser);
         this.Visible = false;
         newAddressForm.ShowDialog();
         LoadForm();
         this.Visible = true;
      }
   }
}
