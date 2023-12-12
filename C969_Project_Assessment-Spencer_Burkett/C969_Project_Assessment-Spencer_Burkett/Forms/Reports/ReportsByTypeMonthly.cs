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

namespace C969_Project_Assessment_Spencer_Burkett.Forms
{
   public partial class ReportsByTypeMonthly : Form
   {
      public ReportsByTypeMonthly()
      {
         InitializeComponent();
      }

      private void monthlyReportsCancelBtn_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void ReportsByTypeMonthly_Load(object sender, EventArgs e)
      {
         LoadForm();
      }

      private void LoadForm()
      {
         foreach (var type in Settings.AppointmentTypes)
         {
            monthlyReportsTypeCmb.Items.Add(type);
         }

         for (int i = 1; i <= 12; i++) 
         {
            monthlyReportsMonthCmb.Items.Add(new DateTime(DateTime.Now.Year, i, 1).ToString("MMMM"));
         }
      }
      private void monthlyReportsGenerateBtn_Click(object sender, EventArgs e)
      {
         string month = monthlyReportsMonthCmb.SelectedItem.ToString();

         List<Appointment> allApointments = DBConnection.GetAppointments();
         List<Appointment> filteredAppointments = new List<Appointment>();

         foreach(var appointment in allApointments) 
         {
            if(appointment.StartDate.ToString("MMMM") == month &&
               appointment.Type == monthlyReportsTypeCmb.SelectedItem.ToString())
            {
               filteredAppointments.Add(appointment);
            }
         }

         if (filteredAppointments.Count > 0)
         {
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.Append($"Found {filteredAppointments.Count} appointments that match. \r\n");
            reportBuilder.Append("Appointments Found: \r\n");

            foreach (var appointment in filteredAppointments) 
            {
               reportBuilder.Append($"ID: [{appointment.ID}] Title: {appointment.Title} Contact: {appointment.Contact} Start: {appointment.StartDate.ToString("MMM dd yyy HH:mm tt")} \r\n");
            }

            MessageBox.Show(reportBuilder.ToString());
         }
         else
         {
            MessageBox.Show("Invalid selection or no appointment matches selection.");
         }
      }
   }
}
