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
   public partial class NewAddressForm : Form
   {
      User currentUser;
      public NewAddressForm(User user)
      {
         InitializeComponent();
         currentUser = user;
      }

      private void NewAddressForm_Load(object sender, EventArgs e)
      {
         LoadForm();
      }
      private bool IsValid()
      {
         if (!Validator.IsNullOrWhitespace(newAddressTxtBx)              &&
             !Validator.IsNullOrWhitespace(newAddressPhoneTxtBx)         &&
             Validator.PhoneValid(newAddressPhoneTxtBx)                  &&
             !Validator.IsNullOrWhitespace(newAddressPostalCodeTxtBx)    &&
             Validator.PostCodeValid(newAddressPostalCodeTxtBx)           )
         {
            return true;
         }
         return false;
      }

      private void LoadForm() 
      {
         newAddressIDTxtBx.Text = DBConnection.GenerateID("address", "addressId").ToString();
         newAddressTxtBx.Text = "";
         newAddress2TxtBx.Text = "";
         newAddressPhoneTxtBx.Text = "";
         newAddressPostalCodeTxtBx.Text = "";

         newAddressCityIDCmb.Items.Clear();

         List<City> allCities = DBConnection.GetCities();
         foreach (City city in allCities) 
         {
            newAddressCityIDCmb.Items.Add(city.ID);
         }

         newAddressCityIDCmb.SelectedIndex = 0;
      }

      private void newAddressCityIDCmb_SelectedIndexChanged(object sender, EventArgs e)
      {
         int cityID = int.Parse(newAddressCityIDCmb.SelectedItem.ToString());
         DBConnection.OpenConnection();
         string query = $"SELECT * FROM city WHERE cityId = {cityID}";
         MySqlCommand select = new MySqlCommand(query, DBConnection.conn);
         City selectedCity = null;

         try
         {
            MySqlDataReader reader = select.ExecuteReader();

            while (reader.Read()) 
            {
               selectedCity = new City(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetString(4), reader.GetDateTime(5), 
                                       reader.GetString(6));
            }
         }
         catch (MySqlException ex)
         {
            MessageBox.Show(ex.Message);
         }
         finally 
         { 
            DBConnection.CloseConnection(); 
         }
         newAddressCityNameLbl.Text = selectedCity.Name;
      }

      private void newAddressSaveBtn_Click(object sender, EventArgs e)
      {
         if (!IsValid())
         {
            MessageBox.Show("One or more fields is invalid");
            return;
         }
         int addressID = int.Parse(newAddressIDTxtBx.Text);
         int cityID = int.Parse(newAddressCityIDCmb.SelectedItem.ToString());

         Address newAddress = new Address(addressID, newAddressTxtBx.Text, newAddress2TxtBx.Text, cityID, newAddressPostalCodeTxtBx.Text, newAddressPhoneTxtBx.Text, DateTime.Now, currentUser.Username, DateTime.Now, currentUser.Username);
         string insertValues = $"{newAddress.ID}, \"{newAddress.Address1}\", \"{newAddress.Address2}\", {newAddress.CityID}, \"{newAddress.PostalCode}\" , \"{newAddress.Phone}\", \"{newAddress.Created:yyyy-MM-dd HH:mm:ss}\", \"{newAddress.CreatedBy}\", \" {newAddress.Updated:yyyy-MM-dd HH:mm:ss}\", \"{newAddress.UpdatedBy}\"";

         int rowsAdded = DBConnection.InsertNewRecord("address", insertValues);

         if (rowsAdded > 0)
         {
            // Success!
            MessageBox.Show("New address saved.");
            Close();
         }
         else
         {
            MessageBox.Show("Unable to save address.");
         }
      }

      private void newAddressCancelBtn_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void newAddressNewCityBtn_Click(object sender, EventArgs e)
      {
         NewCityForm newCityForm = new NewCityForm(currentUser);
         this.Visible = false;
         LoadForm();
         newCityForm.ShowDialog();
         this.Visible = true;
      }
   }
}
