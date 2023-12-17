using C969_Project_Assessment_Spencer_Burkett.Database;
using C969_Project_Assessment_Spencer_Burkett.Events;
using C969_Project_Assessment_Spencer_Burkett.Forms.Entry_Addition;
using C969_Project_Assessment_Spencer_Burkett.Forms.Modify_Or_Delete;
using C969_Project_Assessment_Spencer_Burkett.Forms.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Project_Assessment_Spencer_Burkett.Forms
{
   public partial class Home : Form
   {
      private User activeUser;
      private bool scheduleChecked;

      private List<User> allUsers;
      private List<Customer> allCustomers;
      private List<Appointment> allAppointments;
      private List<Address> allAddresses;
      private List<City> allCities;
      private List<Country> allCountries;


      private List<AppointmentListing> userAppointments;

      private DateTime earliestDate;
      private DateTime latestDate;

      public Home()
      {
         InitializeComponent();
         allAddresses = new List<Address>();
         allAppointments = new List<Appointment>();
         allCities = new List<City>();
         allCountries = new List<Country>();
         allCustomers = new List<Customer>();
         allUsers = new List<User>();

         userAppointments = new List<AppointmentListing>();
      }
      private void HomeForm_Load(object sender, EventArgs e)
      {
         Settings.Initialize();

         activeUser = null;
         scheduleChecked = false;

         LoginScreen loginScreen = new LoginScreen();
         loginScreen.LoggedIn += OnUserLoggedIn;
         loginScreen.FormClosing += OnLoginScreenClosed;
         loginScreen.ShowDialog();
      }

      private void CheckSchedule()
      {
         if (userAppointments.Count > 0)
         {
            IEnumerable<AppointmentListing> currentAppointments =
            from appointment in userAppointments
            orderby appointment.StartDate.ToUniversalTime().TimeOfDay ascending
            select appointment;


            AppointmentListing closestListing = currentAppointments.First();

            foreach (var appointment in currentAppointments)
            {
               DateTime appointmentStart = appointment.StartDate.ToUniversalTime();
               DateTime closestAppointmentDate = closestListing.StartDate.ToUniversalTime();
               if (appointmentStart.TimeOfDay < closestAppointmentDate.TimeOfDay && appointmentStart.TimeOfDay > DateTime.Now.ToUniversalTime().TimeOfDay)
               {
                  closestListing = appointment;
               }
            }

            DateTime closestAppointment = closestListing.StartDate.ToUniversalTime();
            DateTime closestTime = closestAppointment;

            if (closestAppointment.Date == DateTime.Now.ToUniversalTime().Date &&
               closestAppointment.Hour - DateTime.Now.ToUniversalTime().Hour == 0 &&
               closestTime.Minute - DateTime.Now.ToUniversalTime().Minute <= 15 &&
               closestTime.Minute - DateTime.Now.ToUniversalTime().Minute >= 0) 
            {
               MessageBox.Show($"You have an appointment in {closestListing.StartDate.Minute - DateTime.Now.Minute} minutes with {closestListing.CustomerName}");
            }
         }
      }
      private void ResetHomeForm()
      {
         #region Destruction
         viewAppointmentsMonthlyRadioBtn.CheckedChanged -= OnDateViewMonthlyChanged;
         viewAppointmentsWeeklyRadioBtn.CheckedChanged -= OnDateViewWeeklyChanged;
         viewTimeZoneUTCRadioBtn.CheckedChanged -= OnTimeViewUTCRadioChanged;
         viewTimeZoneLocalRadioBtn.CheckedChanged -= OnTimeViewLocalRadioChanged;

         customerIDCmb.SelectedIndexChanged -= OnCustomerIDCmbChanged;
         addressIDCmb.SelectedIndexChanged -= OnAddressIDCmbChanged;

         numberOfAppointmentsToolStripMenuItem.Click -= OnMonthlyReportsToolStripSelected;
         customersByCityToolStripMenuItem.Click -= OnCustomerReportsToolStripSelected;
         consultantSchedulesToolStripMenuItem.Click -= OnAppointmentReportsToolStripSelected;
         newAppointmentToolStripMenuItem.Click -= OnNewAppointmentToolStripSelected;
         modifyDeleteAppointmentToolStripMenuItem.Click -= OnModifyDeleteAppointmentToolStripSelected;
         newCustomerToolStripMenuItem.Click -= OnNewCustomerToolStripSelected;
         modifyDeleteCustomerToolStripMenuItem.Click -= OnModifyDeleteCustomerToolStripSelected;

         if (appointmentListDgv.DataSource != null) { appointmentListDgv.DataSource = null; }

         allAppointments.Clear();
         allAddresses.Clear();
         allCities.Clear();
         allCountries.Clear();
         allCustomers.Clear();
         allUsers.Clear();
         userAppointments.Clear();
         customerIDCmb.Items.Clear();
         addressIDCmb.Items.Clear();

         #endregion DestructionEnd

         #region Construction
         var diff = DateTime.Now.DayOfWeek - CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
         if (diff < 0) { diff += 7; }
         earliestDate = new DateTime();
         latestDate = DateTime.Now.AddYears(300);

         allAddresses = DBConnection.GetAddresses();
         allAppointments = DBConnection.GetAppointments();
         allCities = DBConnection.GetCities();
         allCountries = DBConnection.GetCountry();
         allCustomers = DBConnection.GetCustomers();
         allUsers = DBConnection.GetUsers();

         foreach (var customer in allCustomers)
         {
            customerIDCmb.Items.Add(customer.CustomerID.ToString());
         }

         foreach (var address in allAddresses)
         {
            addressIDCmb.Items.Add(address.ID.ToString());
         }
         ReloadCalendar(true);

         currentAppointmentViewRangeLbl.Text = $"Viewing User Appointments from\r\n{earliestDate.ToString("dd MMM yyyy")} to {latestDate.ToString("dd MMM yyyy")}";

         if (!scheduleChecked)
         {
            CheckSchedule();
            scheduleChecked = true;
         }

         viewAppointmentsMonthlyRadioBtn.CheckedChanged += OnDateViewMonthlyChanged;
         viewAppointmentsWeeklyRadioBtn.CheckedChanged += OnDateViewWeeklyChanged;
         viewTimeZoneUTCRadioBtn.CheckedChanged += OnTimeViewUTCRadioChanged;
         viewTimeZoneLocalRadioBtn.CheckedChanged += OnTimeViewLocalRadioChanged;

         customerIDCmb.SelectedIndexChanged += OnCustomerIDCmbChanged;
         addressIDCmb.SelectedIndexChanged += OnAddressIDCmbChanged;

         numberOfAppointmentsToolStripMenuItem.Click += OnMonthlyReportsToolStripSelected;
         customersByCityToolStripMenuItem.Click += OnCustomerReportsToolStripSelected;
         consultantSchedulesToolStripMenuItem.Click += OnAppointmentReportsToolStripSelected;
         newAppointmentToolStripMenuItem.Click += OnNewAppointmentToolStripSelected;
         modifyDeleteAppointmentToolStripMenuItem.Click += OnModifyDeleteAppointmentToolStripSelected;
         newCustomerToolStripMenuItem.Click += OnNewCustomerToolStripSelected;
         modifyDeleteCustomerToolStripMenuItem.Click += OnModifyDeleteCustomerToolStripSelected;
         viewAppointmentAllRadioBtn.Checked = true;

         addressIDCmb.SelectedIndex = 0;
         customerIDCmb.SelectedIndex = 0;
         #endregion ConstructionEnd
      }


      private void ReloadCalendar(bool resetHomeform)
      {
         if (!resetHomeform)
         {
            if (userAppointments.Count > 0)
            {
               userAppointments = new List<AppointmentListing>();
               appointmentListDgv.DataSource = null;
               appointmentListDgv.Rows.Clear();
            }

            if (viewTimeZoneLocalRadioBtn.Checked)
            {
               earliestDate = earliestDate.ToLocalTime();
               latestDate = latestDate.ToLocalTime();
               currentAppointmentViewRangeLbl.Text = $"Viewing User Appointments from\r\n{earliestDate.ToLocalTime():dd MMM yyyy HH:mm:ss} to {latestDate.ToLocalTime():dd MMM yyyy HH:mm:ss}";
            }
            else
            {
               earliestDate = earliestDate.ToUniversalTime();
               latestDate = latestDate.ToUniversalTime();
               currentAppointmentViewRangeLbl.Text = $"Viewing User Appointments from\r\n{earliestDate.ToUniversalTime():dd MMM yyyy HH:mm:ss} to {latestDate.ToUniversalTime():dd MMM yyyy HH:mm:ss}";
            }

         }
         IEnumerable<Appointment> filteredAppointments =
            from appointment in allAppointments
            where appointment.UserID == activeUser.ID
            select appointment;


         foreach (var appointment in filteredAppointments)
         {
            if (appointment.StartDate >= earliestDate && appointment.EndDate <= latestDate)
            {
               string userName = allUsers.Where(name => name.ID == appointment.UserID).Select(name => name.Username).ElementAt(0); //Lambda expression used in selecting the username instead of a separate function for a more linear viewing experience
               string customerName = allCustomers.Where(name => name.CustomerID == appointment.UserID).Select(name => name.CustomerName).ElementAt(0); //Lambda expression used in selecting the customer name for the same reason. Both increase simplicity by removing unneccessary separate functions.

               DateTime appointmentStart = appointment.StartDate;
               DateTime appointmentEnd = appointment.EndDate;

               if (viewTimeZoneLocalRadioBtn.Checked == true)
               {
                  appointmentStart = appointmentStart.ToLocalTime();
                  appointmentEnd = appointmentEnd.ToLocalTime();
               }
               else
               {
                  appointmentStart = appointmentStart.ToUniversalTime();
                  appointmentEnd = appointmentEnd.ToUniversalTime();
               }

               AppointmentListing listing = new AppointmentListing(appointment.ID, userName, customerName, appointment.Title, appointment.Description, appointment.Type, appointmentStart, appointmentEnd);
               userAppointments.Add(listing);
            }
         }
         if (userAppointments.Count > 0)
         {
            appointmentListDgv.DataSource = userAppointments;
         }
      }
      private void OnUserLoggedIn(object sender, LoggedInEventArgs e)
      {
         activeUser = e.User;
      }
      private void OnLoginScreenClosed(object sender, EventArgs e)
      {
         if (activeUser == null)
         {
            Close();
         }
         else
         {
            viewAppointmentsWeeklyRadioBtn.Checked = true;
            viewAppointmentsMonthlyRadioBtn.Checked = false;
            viewTimeZoneUTCRadioBtn.Checked = true;
            viewTimeZoneLocalRadioBtn.Checked = false;

            ResetHomeForm();
         }
      }

      private void OnDateViewMonthlyChanged(object sender, EventArgs e)
      {
         if (viewAppointmentsMonthlyRadioBtn.Checked)
         {

            viewAppointmentsWeeklyRadioBtn.Checked = false;
            viewAppointmentAllRadioBtn.Checked = false;
            earliestDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            latestDate = earliestDate.AddMonths(1).AddTicks(-1);

            ReloadCalendar(false);

         }
      }

      private void OnDateViewWeeklyChanged(object sender, EventArgs e)
      {
         if (viewAppointmentsWeeklyRadioBtn.Checked == true)
         {
            viewAppointmentsMonthlyRadioBtn.Checked = false;
            viewAppointmentAllRadioBtn.Checked = false;

            // Set Appointment Window to range from beginning to end of current week
            var diff = DateTime.Now.DayOfWeek - CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0) { diff += 7; }

            earliestDate = DateTime.Now.AddDays(-diff).Date;
            latestDate = earliestDate.AddDays(6);

            ReloadCalendar(false);

         }
      }

      private void OnTimeViewUTCRadioChanged(object sender, EventArgs e)
      {
         if (viewTimeZoneUTCRadioBtn.Checked == true)
         {
            viewTimeZoneLocalRadioBtn.Checked = false;
            ReloadCalendar(false);
         }
      }

      private void OnTimeViewLocalRadioChanged(object sender, EventArgs e)
      {
         if (viewTimeZoneLocalRadioBtn.Checked == true)
         {
            viewTimeZoneUTCRadioBtn.Checked = false;
            ReloadCalendar(false);
         }
      }
      private void OnCustomerIDCmbChanged(object sender, EventArgs e)
      {
         int id = int.Parse(customerIDCmb.SelectedItem.ToString());
         Customer currentCustomer = null;

         foreach (var customer in allCustomers)
         {
            if (customer.CustomerID == id)
            {
               currentCustomer = customer;
               break;
            }
         }
         if (currentCustomer == null)
         {
            MessageBox.Show("Could not load data.");
         }
         else
         {
            customerNameDataLbl.Text = currentCustomer.CustomerName;
            customerAddressDataLbl.Text = currentCustomer.AddressID.ToString();
            customerActiveDataLbl.Text = currentCustomer.Active.ToString();
            customerCreatedDataLbl.Text = $"{currentCustomer.DateCreated.ToString("d MMM yyyy HH:mm")}" + "\r\n" + $"By User: {currentCustomer.UpdatedBy}";
            customerUpdatedDataLbl.Text = $"{currentCustomer.DateUpdated.ToString("d MMM yyyy HH:mm")}" + "\r\n" + $"By User: {currentCustomer.CreatedBy}";
         }

      }

      private void OnAddressIDCmbChanged(Object sender, EventArgs e)
      {
         int id = int.Parse(addressIDCmb.SelectedItem.ToString());
         Address currentAddress = null;

         foreach (var address in allAddresses)
         {
            if (address.ID == id)
            {
               currentAddress = address;
               break;
            }
         }
         if (currentAddress == null)
         {
            MessageBox.Show("Could not load address data");
         }
         else
         {
            addressDataLbl.Text = currentAddress.Address1;
            addressContinueDatadLbl.Text = currentAddress.Address2;
            addressCityDataLbl.Text = currentAddress.CityID.ToString();
            addressPhoneDataLbl.Text = currentAddress.Phone;
            addressPostCodeDataLbl.Text = currentAddress.PostalCode;
            addressCreatedDataLbl.Text = currentAddress.CreatedBy;
            addressUpdatedDataLbl.Text = $"{currentAddress.Updated.ToString("d MMM yyyy HH:mm")}" + "\r\n" + $"By User: {currentAddress.UpdatedBy}";
            addressCreatedDataLbl.Text = $"{currentAddress.Created.ToString("d MMM yyyy HH:mm")}" + "\r\n" + $"By User: {currentAddress.CreatedBy}";

         }
      }

      #region Toolbar Items
      private void OnMonthlyReportsToolStripSelected(object sender, EventArgs e)
      {
         ReportsByTypeMonthly reportsByTypeMonthly = new ReportsByTypeMonthly();
         this.Visible = false;
         reportsByTypeMonthly.ShowDialog();
         this.Visible = true;
      }

      private void OnCustomerReportsToolStripSelected(object sender, EventArgs e)
      {
         ReportsByCustomerAddressID reportsByCustomerAddressID = new ReportsByCustomerAddressID();
         this.Visible = false;
         reportsByCustomerAddressID.ShowDialog();
         ResetHomeForm();
         this.Visible = true;
      }

      private void OnAppointmentReportsToolStripSelected(object sender, EventArgs e)
      {
         ReportsByUserAppointment reportsByUserAppointment = new ReportsByUserAppointment();
         this.Visible = false;
         reportsByUserAppointment.ShowDialog();
         ResetHomeForm();
         this.Visible = true;
      }
      private void OnNewAppointmentToolStripSelected(object sender, EventArgs e)
      {
         NewAppointmentForm newAppointmentForm = new NewAppointmentForm(activeUser);
         this.Visible = false;
         newAppointmentForm.ShowDialog();
         ResetHomeForm();
         this.Visible = true;
      }

      private void OnModifyDeleteAppointmentToolStripSelected(object sender, EventArgs e)
      {
         SelectAppointmentForm selectAppointmentForm = new SelectAppointmentForm(activeUser);
         this.Visible = false;
         selectAppointmentForm.ShowDialog();
         ResetHomeForm();
         this.Visible = true;
      }

      private void OnNewCustomerToolStripSelected(object sender, EventArgs e)
      {
         NewCustomerForm newCustomerForm = new NewCustomerForm(activeUser);
         this.Visible = false;
         newCustomerForm.ShowDialog();
         ResetHomeForm();
         this.Visible = true;
      }

      private void OnModifyDeleteCustomerToolStripSelected(object sender, EventArgs e)
      {
         SelectCustomerForm selectCustomerForm = new SelectCustomerForm(activeUser);
         this.Visible = false;
         selectCustomerForm.ShowDialog();
         ResetHomeForm();
         this.Visible = true;
      }
      #endregion

      private void viewAppointmentAllRadioBtn_CheckedChanged(object sender, EventArgs e)
      {
         if (viewAppointmentAllRadioBtn.Checked == true)
         {
            viewAppointmentsMonthlyRadioBtn.Checked = false;
            viewAppointmentsWeeklyRadioBtn.Checked = false;

            // Set Appointment Window to range from beginning to end of current week
            var diff = DateTime.Now.DayOfWeek - CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0) { diff += 7; }

            earliestDate = new DateTime();
            latestDate = DateTime.Now.AddYears(300);

            ReloadCalendar(false);
         }
      }
   }
}