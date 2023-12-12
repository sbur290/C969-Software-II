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

namespace C969_Project_Assessment_Spencer_Burkett.Forms.Reports
{
   public partial class ReportsByUserAppointment : Form
   {
      public ReportsByUserAppointment()
      {
         InitializeComponent();
      }

      private void appointmentReportsGenerateBtn_Click(object sender, EventArgs e)
      {
         List<Appointment> allAppointments = DBConnection.GetAppointments();

         try 
         {
            IEnumerable<Appointment> sortedAppointments =
               from appointment in allAppointments
               orderby appointment.StartDate ascending
               where appointment.UserID == int.Parse(appointmentReportsUserIDTxtBx.Text)
               select appointment;
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.Append($"Ordered Appointments for User with ID {appointmentReportsUserIDTxtBx.Text}: \r\n");
            foreach (var appointment in sortedAppointments)
            {
               reportBuilder.Append($"Appointment ID: [{appointment.ID}] Appointment Title: [{appointment.Title}] Contact: [{appointment.Contact}] Start: [{appointment.StartDate.ToString("MMM dd yyyy HH:mm tt")}] \r\n");
            }
            MessageBox.Show(reportBuilder.ToString());
         }
         catch
         {
            MessageBox.Show("Invalid ID Entered");
         }

         

      }

      private void customerReportsCancelBtn_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
