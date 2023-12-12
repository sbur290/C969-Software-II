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

namespace C969_Project_Assessment_Spencer_Burkett.Forms.Modify_Or_Delete
{
   public partial class ModifyAppointmentForm : Form
   {
      User currentUser;
      Appointment currentAppointment;
      public ModifyAppointmentForm(User user, Appointment appointment)
      {
         InitializeComponent();

         currentUser = user;
         currentAppointment = appointment;
      }

      private void ModifyAppointmentForm_Load(object sender, EventArgs e)
      {
         DBConnection.OpenConnection();

         modifyAppointmentIDTxtBx.Text = currentAppointment.ID.ToString();

         List<User> users = DBConnection.GetUsers();
         List<Customer> customers = DBConnection.GetCustomers();

         foreach (var user in users)
         {
            modifyAppointmentUserIDCmb.Items.Add(user.ID);
         }

         foreach (var customer in customers)
         {
            modifyAppointmentCustomerIDCmb.Items.Add(customer.CustomerID);
         }

         foreach (var type in Settings.AppointmentTypes)
         {
            modifyAppointmentTypeCmb.Items.Add(type);
         }

         modifyAppointmentTitleTxtBx.Text = currentAppointment.Title;
         newAppointmentDescriptionTxtBx.Text = currentAppointment.Description;
         modifyAppointmentLocationTxtBx.Text = currentAppointment.Location;
         modifyAppointmentContactTxtBx.Text = currentAppointment.Contact;
         modifyAppointmentURLTxtBx.Text = currentAppointment.Url;

         modifyAppointmentStartDtp.Value = currentAppointment.StartDate.ToLocalTime();
         modifyAppointmentEndDtp.Value = currentAppointment.EndDate.ToLocalTime();

         modifyAppointmentTypeCmb.SelectedItem = currentAppointment.Type;
         modifyAppointmentCustomerIDCmb.SelectedItem = currentAppointment.CustomerID;
         modifyAppointmentUserIDCmb.SelectedItem = currentAppointment.UserID;

         DBConnection.CloseConnection();
      }
      private bool IsFormValid()
      {
         bool valid = false;
         if (!Validator.IsNullOrWhitespace(modifyAppointmentTitleTxtBx) &&
            !Validator.IsNullOrWhitespace(newAppointmentDescriptionTxtBx) &&
            !Validator.IsNullOrWhitespace(modifyAppointmentLocationTxtBx) &&
            !Validator.IsNullOrWhitespace(modifyAppointmentContactTxtBx) &&
            !Validator.HasInvalidCharacters(modifyAppointmentContactTxtBx) &&
            !Validator.IsNullOrWhitespace(modifyAppointmentURLTxtBx))
         {
            valid = true;
         }
         return valid;
      }

      private void modifyAppointmentSaveBtn_Click(object sender, EventArgs e)
      {
         try
         {
            DBConnection.OpenConnection();
            int userID = int.Parse(modifyAppointmentUserIDCmb.SelectedItem.ToString());
            List<Appointment> allAppointments = DBConnection.GetAppointments();

            DateTime enteredStartTime = modifyAppointmentStartDtp.Value;
            DateTime enteredEndTime = modifyAppointmentEndDtp.Value;

            #region Validate 
            if (enteredStartTime > enteredEndTime)
            {
               MessageBox.Show("Appointment can't start after it ends.");
               return;
            }
            if ((enteredStartTime.Hour < 9 || enteredStartTime.Hour > 17) || (enteredStartTime.Hour < 9 || enteredStartTime.Hour > 17))
            {
               MessageBox.Show("Appointment is outside of business hours");
               return;
            }

            IEnumerable<Appointment> userAppointments =
               from appointment in allAppointments
               where (appointment.StartDate.ToLocalTime().Date == enteredStartTime.ToLocalTime().Date && appointment.UserID == userID && appointment.ID != currentAppointment.ID) || (appointment.EndDate.ToLocalTime().Date == enteredEndTime.ToLocalTime().Date && appointment.UserID == userID && appointment.ID != currentAppointment.ID)
               select appointment;

            foreach (var appointment in userAppointments)
            {
               DateTime appointmentStart = appointment.StartDate.ToLocalTime();
               DateTime appointmentEnd = appointment.EndDate.ToLocalTime();

               if ((enteredStartTime >= appointmentStart && enteredStartTime < appointmentEnd) ||
                   (enteredEndTime <= appointmentEnd && enteredEndTime > appointmentStart) ||
                   (appointmentEnd <= enteredEndTime && appointmentEnd > enteredStartTime) ||
                   (appointmentStart >= enteredStartTime && appointmentStart < enteredEndTime))
               {
                  MessageBox.Show("Appointment overlaps with existing appointment");
                  return;
               }
            }

            if (!IsFormValid())
            {
               MessageBox.Show("One or more forms has invalid data.");
               return;
            }
            #endregion ValidateEnd

            #region Save
            int appointmentID = int.Parse(modifyAppointmentIDTxtBx.Text);
            int customerID = int.Parse(modifyAppointmentCustomerIDCmb.SelectedItem.ToString());
            string title = modifyAppointmentTitleTxtBx.Text;
            string description = newAppointmentDescriptionTxtBx.Text;
            string location = modifyAppointmentLocationTxtBx.Text;
            string contact = modifyAppointmentContactTxtBx.Text;
            string type = modifyAppointmentTypeCmb.SelectedItem.ToString();
            string url = modifyAppointmentURLTxtBx.Text;
            DateTime start = modifyAppointmentStartDtp.Value.ToUniversalTime();
            DateTime end = modifyAppointmentEndDtp.Value.ToUniversalTime();
            DateTime created = DateTime.Now.ToUniversalTime();
            string createdBy = currentUser.Username;
            DateTime updated = DateTime.Now.ToUniversalTime();
            string updatedBy = currentUser.Username;


            Appointment newAppointment = new Appointment(appointmentID, customerID, userID, title, description, location, contact, type, url, start, end, created, createdBy, updated, updatedBy);
            string insertValues = $"appointmentId = {appointmentID}, customerId = {customerID}, userId = {userID}, title = \"{title}\", description = \"{description}\", location = \"{location}\", contact = \"{contact}\", type = \"{type}\", url = \"{url}\", start = \"{start:yyyy-MM-dd HH:mm:ss}\", end = \"{end:yyyy-MM-dd HH:mm:ss}\", createDate = \"{created:yyyy-MM-dd HH:mm:ss}\", createdBy = \"{createdBy}\", lastUpdate = \"{updated:yyyy-MM-dd HH:mm:ss}\", lastUpdateBy = \"{updatedBy}\" ";

            int rowsAffected = DBConnection.ModifyRecord("appointment", insertValues, $"appointmentId = {appointmentID}");

            if (rowsAffected > 0)
            {
               MessageBox.Show("Appointment saved.");
               Close();
            }
            else
            {
               MessageBox.Show("Insertion Failed. Appointment has not been saved.");
            }
            #endregion SaveEnd
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void modifyAppointmentCancelBtn_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void modifyAppointmentCustomerIDCmb_SelectedIndexChanged(object sender, EventArgs e)
      {
         DBConnection.OpenConnection();
         string query = $"SELECT * FROM customer WHERE customerId = {int.Parse(modifyAppointmentCustomerIDCmb.SelectedItem.ToString())}";
         MySqlCommand getCustomers = new MySqlCommand(query, DBConnection.conn);

         MySqlDataReader reader = getCustomers.ExecuteReader();
         Customer selectedCustomer = null;
         try
         {
            while (reader.Read())
            {
               selectedCustomer = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetBoolean(3), reader.GetDateTime(4), reader.GetString(5),
                                               reader.GetDateTime(6), reader.GetString(7));
            }
         }
         catch (MySqlException ex)
         {
            MessageBox.Show(ex.ToString());
         }
         finally
         {
            DBConnection.CloseConnection();
         }
         modifyAppointmentCustomerNameLbl.Text = $"Customer Name: {selectedCustomer.CustomerName}";
      }

      private void modifyAppointmentUserIDCmb_SelectedIndexChanged(object sender, EventArgs e)
      {
         DBConnection.OpenConnection();
         string query = $"SELECT * FROM user WHERE userId = {int.Parse(modifyAppointmentUserIDCmb.SelectedItem.ToString())}";
         MySqlCommand getUsers = new MySqlCommand(query, DBConnection.conn);

         MySqlDataReader reader = getUsers.ExecuteReader();
         User selectedUser = null;
         try
         {
            while (reader.Read())
            {
               selectedUser = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3), reader.GetDateTime(4), reader.GetString(5));
            }
         }
         catch (MySqlException ex)
         {
            MessageBox.Show(ex.ToString());
         }
         finally
         {
            DBConnection.CloseConnection();
         }
         modifyAppointmentUsernameLbl.Text = $"Username: {selectedUser.Username}";
      }
   }
}
