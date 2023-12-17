using C969_Project_Assessment_Spencer_Burkett.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Project_Assessment_Spencer_Burkett.Forms.Entry_Addition
{
   public partial class NewAppointmentForm : Form
   {
      int maxID;
      User currentUser;
      public NewAppointmentForm(User user)
      {
         InitializeComponent();
         
         currentUser = user;
      }

      private void NewAppointmentForm_Load(object sender, EventArgs e)
      {
         DBConnection.OpenConnection();
         string query = $"SELECT MAX(appointmentId) FROM appointment";
         MySqlCommand selectCommand = new MySqlCommand(query, DBConnection.conn);
         MySqlDataReader reader = selectCommand.ExecuteReader();
         while (reader.Read()) 
         {
            maxID = reader.GetInt32(0);
         }
         newAppointmentIDTxtBx.Text = (maxID + 1).ToString();

         List<User> users = DBConnection.GetUsers();
         List<Customer> customers = DBConnection.GetCustomers();

         foreach(var user in users)
         {
            newAppointmentUserIDCmb.Items.Add(user.ID);
         }

         foreach(var customer in customers)
         {
            newAppointmentCustomerIDCmb.Items.Add(customer.CustomerID);
         }   

         foreach(var type in Settings.AppointmentTypes)
         {
            newAppointmentTypeCmb.Items.Add(type);
         }
         DBConnection.CloseConnection();

         newAppointmentUserIDCmb.SelectedIndex = 0;
         newAppointmentCustomerIDCmb.SelectedIndex = 0;
         newAppointmentTypeCmb.SelectedIndex = 0;

      }

      private bool IsFormValid()
      {
         bool valid = true;
         StringBuilder stringBuilder = new StringBuilder();
         if(Validator.IsNullOrWhitespace(newAppointmentTitleTxtBx))
         {
            stringBuilder.Append("Invalid Title\r\n");
            valid = false;
         }
         if (Validator.IsNullOrWhitespace(newAppointmentDescriptionTxtBx))
         {
            stringBuilder.Append("Invalid Description\r\n");
            valid = false;
         }
         if (Validator.IsNullOrWhitespace(newAppointmentLocationTxtBx))
         {
            stringBuilder.Append("Invalid Title\r\n");
            valid = false;
         }
         if (Validator.IsNullOrWhitespace(newAppointmentContactTxtBx) ||
             Validator.HasInvalidCharacters(newAppointmentContactTxtBx) )
         {
            stringBuilder.Append("Invalid Contact\r\n");
            valid = false;
         }
         if (Validator.IsNullOrWhitespace(newAppointmentURLTxtBx))
         {
            stringBuilder.Append("Invalid URL\r\n");
         }
         MessageBox.Show(stringBuilder.ToString());
         return valid;
      }
      private void newAppointmentSaveBtn_Click(object sender, EventArgs e)
      {
         try
         {
            DBConnection.OpenConnection();
            int userID = int.Parse(newAppointmentUserIDCmb.SelectedItem.ToString());
            List<Appointment> allAppointments = DBConnection.GetAppointments();

            DateTime enteredStartTime = newAppointmentStartDtp.Value;
            DateTime enteredEndTime = newAppointmentEndDtp.Value;

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
               where (appointment.StartDate.ToLocalTime().Date == enteredStartTime.ToLocalTime().Date && appointment.UserID == userID) || (appointment.EndDate.ToLocalTime().Date == enteredEndTime.ToLocalTime().Date && appointment.UserID == userID)
               select appointment;

            foreach(var appointment in userAppointments)
            {
               DateTime appointmentStart = appointment.StartDate.ToLocalTime();
               DateTime appointmentEnd = appointment.EndDate.ToLocalTime();

               if ((enteredStartTime >= appointmentStart && enteredStartTime < appointmentEnd) ||
                   (enteredEndTime <= appointmentEnd && enteredEndTime > appointmentStart)     ||
                   (appointmentEnd <= enteredEndTime && appointmentEnd > enteredStartTime)     ||
                   (appointmentStart >= enteredStartTime && appointmentStart < enteredEndTime)  )
               {
                  MessageBox.Show("Appointment overlaps with existing appointment");
                  return;
               }
            }

            if(!IsFormValid())
            {
               MessageBox.Show("One or more forms has invalid data.");
               return;
            }
            #endregion ValidateEnd

            #region Save
            int appointmentID = int.Parse(newAppointmentIDTxtBx.Text);
            int customerID = int.Parse(newAppointmentCustomerIDCmb.SelectedItem.ToString());
            string title = newAppointmentTitleTxtBx.Text;
            string description = newAppointmentDescriptionTxtBx.Text;
            string location = newAppointmentLocationTxtBx.Text;
            string contact = newAppointmentContactTxtBx.Text;
            string type = newAppointmentTypeCmb.SelectedItem.ToString();
            string url = newAppointmentURLTxtBx.Text;
            DateTime start = newAppointmentStartDtp.Value.ToUniversalTime();
            DateTime end = newAppointmentEndDtp.Value.ToUniversalTime();
            DateTime created = DateTime.Now.ToUniversalTime();
            string createdBy = currentUser.Username;
            DateTime updated = DateTime.Now.ToUniversalTime();
            string updatedBy = currentUser.Username;


            Appointment newAppointment = new Appointment(appointmentID, customerID, userID, title, description, location, contact, type, url, start, end, created, createdBy, updated, updatedBy);
            string insertValues = $"{appointmentID}, {customerID}, {userID}, \"{title}\", \"{description}\", \"{location}\", \"{contact}\", \"{type}\", \"{url}\", \"{start:yyyy-MM-dd HH:mm:ss}\", \"{end:yyyy-MM-dd HH:mm:ss}\", \"{created:yyyy-MM-dd HH:mm:ss}\", \"{createdBy}\", \"{updated:yyyy-MM-dd HH:mm:ss}\", \"{updatedBy}\" ";

            int rowsAffected = DBConnection.InsertNewRecord("appointment", insertValues);

            if(rowsAffected > 0 )
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

      private void newAppointmentCancelBtn_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void newAppointmentCustomerIDCmb_SelectedIndexChanged(object sender, EventArgs e)
      {
         DBConnection.OpenConnection();
         string query = $"SELECT * FROM customer WHERE customerId = {int.Parse(newAppointmentCustomerIDCmb.SelectedItem.ToString())}";
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
         catch(MySqlException ex)
         {
            MessageBox.Show(ex.ToString());
         }
         finally 
         { 
            DBConnection.CloseConnection(); 
         }
         newAppointmentCustomerNameLbl.Text = $"Customer Name: {selectedCustomer.CustomerName}";
      }

      private void newAppointmentUserIDCmb_SelectedIndexChanged(object sender, EventArgs e)
      {
         DBConnection.OpenConnection();
         string query = $"SELECT * FROM user WHERE userId = {int.Parse(newAppointmentUserIDCmb.SelectedItem.ToString())}";
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
         newAppointmentUsernameLbl.Text = $"Username: {selectedUser.Username}";
      }
   }
}
