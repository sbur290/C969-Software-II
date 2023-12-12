using C969_Project_Assessment_Spencer_Burkett.Database;
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
   public partial class NewCountryForm : Form
   {
      User currentUser;
      public NewCountryForm(User user)
      {
         InitializeComponent();
         currentUser = user;
      }

      private void NewCountryForm_Load(object sender, EventArgs e)
      {
         newCountryIDTxtBx.Text = DBConnection.GenerateID("country", "countryId").ToString();
         newCountryNameTxtBx.Text = "";
      }

      private void newCountrySaveBtn_Click(object sender, EventArgs e)
      {
         if(Validator.IsNullOrWhitespace(newCountryNameTxtBx) || Validator.HasInvalidCharacters(newCountryNameTxtBx))
         {
            MessageBox.Show("Invalid Country Name");
            return;
         }

         Country newCountry = new Country(int.Parse(newCountryIDTxtBx.Text), newCountryNameTxtBx.Text, DateTime.Now, currentUser.Username, DateTime.Now, currentUser.Username);
         string insertValues = $"{newCountry.ID}, \"{newCountry.Name}\", \"{newCountry.DateCreated:yyyy-MM-dd HH:mm:ss}\", \"{newCountry.CreatedBy}\", \"{newCountry.DateLastUpdated:yyyy-MM-dd HH:mm:ss}\", \"{newCountry.LastUpdatedBy}\"";

         int rowsAdded = DBConnection.InsertNewRecord("country", insertValues);

         if (rowsAdded > 0)
         {
            MessageBox.Show("Saved new Country.");
            Close();
         }
         else
         {
            MessageBox.Show("An error ocurred. Country not saved.");
         }
      }

      private void newCountryCancelBtn_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
