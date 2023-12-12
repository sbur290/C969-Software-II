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
   public partial class NewCityForm : Form
   {
      User currentUser;
      public NewCityForm(User user)
      {
         InitializeComponent();
         currentUser = user;
      }

      private void NewCityForm_Load(object sender, EventArgs e)
      {
         LoadForm();
      }

      private void LoadForm()
      {
         newCityCountryIDCmb.Items.Clear();

         newCityIDTxtBx.Text = DBConnection.GenerateID("city", "cityId").ToString();

         List<Country> allCountries = DBConnection.GetCountry();
         foreach (var country in allCountries) 
         {
            newCityCountryIDCmb.Items.Add(country.ID);
         }
         newCityCountryIDCmb.SelectedIndex = 0;
      }
      private void newCityCountryIDCmb_SelectedIndexChanged(object sender, EventArgs e)
      {
         DBConnection.OpenConnection();
         string query = $"SELECT * FROM country WHERE countryId = {int.Parse(newCityCountryIDCmb.SelectedItem.ToString())}";
         MySqlCommand select = new MySqlCommand(query, DBConnection.conn);
         Country selectedCountry = null;

         try
         {
            MySqlDataReader reader = select.ExecuteReader();

            while (reader.Read())
            {
               selectedCountry = new Country(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5));
            }
            newCityCountryDataLbl.Text = selectedCountry.Name;
         }
         catch (MySqlException ex)
         {
            MessageBox.Show(ex.Message);
            return;
         }
         finally
         {
            DBConnection.CloseConnection();
         }
      }

      private void newCitySaveBtn_Click(object sender, EventArgs e)
      {
         if (Validator.IsNullOrWhitespace(newCityNameTxtBx) || Validator.HasInvalidCharacters(newCityNameTxtBx))
         {
            MessageBox.Show("Invalid City Name");
            return;
         }
         City newCity = new City(int.Parse(newCityIDTxtBx.Text), newCityNameTxtBx.Text , int.Parse(newCityCountryIDCmb.SelectedItem.ToString()), DateTime.Now, currentUser.Username, DateTime.Now, currentUser.Username);
         string insertValues = $"{newCity.ID}, \"{newCity.Name}\", {newCity.CountryID}, \"{newCity.DateCreated:yyyy-MM-dd HH:mm:ss}\", \"{newCity.CreatedBy}\", \"{newCity.DateLastUpdated:yyyy-MM-dd HH:mm:ss}\", \"{newCity.LastUpdatedBy}\"";

         int rowsAdded = DBConnection.InsertNewRecord("city", insertValues);

         if (rowsAdded > 0)
         {
            MessageBox.Show("Saved new city.");
            Close();
         }
         else
         {
            MessageBox.Show("An error ocurred. City not saved.");
         }
      }

      private void newCityCancelBtn_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void newCityNewCountryBtn_Click(object sender, EventArgs e)
      {
         NewCountryForm newCountryForm = new NewCountryForm(currentUser);
         this.Visible = false;
         newCountryForm.ShowDialog();
         LoadForm();
         this.Visible = true;
      }
   }
}
