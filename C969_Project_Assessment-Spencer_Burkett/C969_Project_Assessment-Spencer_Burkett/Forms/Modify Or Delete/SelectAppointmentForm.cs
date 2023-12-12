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
   public partial class SelectAppointmentForm : Form
   {
      User currentUser;
      public SelectAppointmentForm(User user)
      {
         InitializeComponent();
         currentUser = user;
      }

      private void SelectAppointmentForm_Load(object sender, EventArgs e)
      {
         LoadForm();
      }

      private void LoadForm() 
      {
         selectAppointmentIDCmb.Items.Clear();

         List<Appointment> allAppointments = DBConnection.GetAppointments();
         foreach (var appointment in allAppointments)
         {
            selectAppointmentIDCmb.Items.Add(appointment.ID);
         }

         selectAppointmentIDCmb.SelectedIndex = 0;
      }

      private void SetAppointmentDetails(Appointment appointment)
      {
         selectAppointmentDetailsTxtBx.Text = "";

         StringBuilder entryBuilder = new StringBuilder();
         entryBuilder.Append($"Appointment ID: {appointment.ID}\r\n");
         entryBuilder.Append($"Customer ID: {appointment.CustomerID}\r\n");
         entryBuilder.Append($"User ID: {appointment.UserID}\r\n");
         entryBuilder.Append($"Title: {appointment.Title}\r\n");
         entryBuilder.Append($"Description: {appointment.Description} \r\n");
         entryBuilder.Append($"Location: {appointment.Location} \r\n");
         entryBuilder.Append($"Contact: {appointment.Contact} \r\n");
         entryBuilder.Append($"Type: {appointment.Type}  \r\n");
         entryBuilder.Append($"URL: {appointment.Url}  \r\n");
         entryBuilder.Append($"Date Created: {appointment.CreateDate}  \r\n");
         entryBuilder.Append($"Created By: {appointment.CreatedBy}  \r\n");
         entryBuilder.Append($"Date Last Updated: {appointment.LastUpdate}  \r\n");
         entryBuilder.Append($"Last Updated By: {appointment.LastUpdatedBy}");

         selectAppointmentDetailsTxtBx.Text = entryBuilder.ToString();
      }

      private void selectAppointmentIDCmb_SelectedIndexChanged(object sender, EventArgs e)
      {
         DBConnection.OpenConnection();
         string query = $"SELECT * FROM appointment WHERE appointmentId = {int.Parse(selectAppointmentIDCmb.SelectedItem.ToString())}";
         MySqlCommand command = new MySqlCommand(query, DBConnection.conn);

         MySqlDataReader reader = command.ExecuteReader();
         Appointment selectedAppointment = null;

         while(reader.Read()) 
         {
            selectedAppointment = new Appointment(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), 
                                                  reader.GetString(6),reader.GetString(7), reader.GetString(8), reader.GetDateTime(9), reader.GetDateTime(10),
                                                  reader.GetDateTime(11), reader.GetString(12), reader.GetDateTime(13), reader.GetString(14));

         }
         SetAppointmentDetails(selectedAppointment);

         DBConnection.CloseConnection();

      }

      private void selectAppointmentsModifyBtn_Click(object sender, EventArgs e)
      {
         int appointmentID = int.Parse(selectAppointmentIDCmb.SelectedItem.ToString());

         DBConnection.OpenConnection();
         string query = $"SELECT * FROM appointment WHERE appointmentId = {appointmentID};";
         MySqlCommand selectAppointment = new MySqlCommand (query, DBConnection.conn);
         MySqlDataReader reader = selectAppointment.ExecuteReader();
         Appointment selectedAppointment = null;
         
         while(reader.Read())
         {
            selectedAppointment = new Appointment(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetString(5),
                                                   reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetDateTime(9), reader.GetDateTime(10),
                                                   reader.GetDateTime(11), reader.GetString(12), reader.GetDateTime(13), reader.GetString(14));
         }

         if(selectedAppointment != null)
         {
            ModifyAppointmentForm modifyAppointmentForm = new ModifyAppointmentForm(currentUser, selectedAppointment);
            this.Visible = false;
            modifyAppointmentForm.ShowDialog();
         }
         else 
         {
            MessageBox.Show("Error loading appointment.");
         }
      }

      private void selectAppointmentDeleteBtn_Click(object sender, EventArgs e)
      {
         DialogResult confirmMessage = MessageBox.Show("Are you sure you want to delete this Appointment?","This action is permanent." ,MessageBoxButtons.YesNo);

         if (confirmMessage == DialogResult.Yes) 
         {
            int rowsAffected = DBConnection.DeleteRecord("appointment", $"appointmentId = {int.Parse(selectAppointmentIDCmb.SelectedItem.ToString())}");

            if (rowsAffected > 0 ) 
            {
               MessageBox.Show("Record deleted successfully.");
               LoadForm();
            }
         }
      }

      private void selectAppointmentCancelButton_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
