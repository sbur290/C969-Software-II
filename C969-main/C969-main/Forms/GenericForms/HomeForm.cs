﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using C969.DBItems;
using C969.Events;

namespace C969 {
    public partial class HomeForm : Form {
        private UserAccount activeUser;
        private bool scheduleChecked;

        private List<UserAccount> allUsers;
        private List<Appointment> allAppointments;
        private List<Customer> allCustomers;
        private List<Address> allAddresses;
        private List<City> allCities;
        private List<Country> allCountries;

        private List<AppointmentListing> userAppointments;

        private DateTime earliestAppointmentViewDate;
        private DateTime latestAppointmentViewDate;

        public HomeForm() {
            InitializeComponent();

            allUsers = new List<UserAccount>();
            allAppointments = new List<Appointment>();
            allCustomers = new List<Customer>();
            allAddresses = new List<Address>();
            allCities = new List<City>();
            allCountries = new List<Country>();

            userAppointments = new List<AppointmentListing>();
        }
        private void HomeForm_Load(object sender, EventArgs e) {
         Settings.Initialize();

            activeUser = null;
            scheduleChecked = false;

            usersToolStripMenuItem.Enabled = false;

            LoginForm loginForm = new LoginForm();
            loginForm.UserLoggedIn += OnUserLoggedIn;
            loginForm.FormClosing += OnLoginFormClosed;
            loginForm.ShowDialog();
        }


        #region Form Functions
        private void CleanupCustomerAndAddressDetailsLabels() {
            lblAddressAddress1Data.Text = "";
            lblAddressAddress2Data.Text = "";
            lblAddressCreatedByData.Text = "";
            lblAddressLastUpdatedData.Text = "";
            lblAddressPhoneData.Text = "";
            lblAddressPostalCodeData.Text = "";
            lblAddressCityData.Text = "";

            lblCustomerActiveData.Text = "";
            lblCustomerNameData.Text = "";
            lblCustomerAddressData.Text = "";
            lblCustomerCreatedData.Text = "";
            lblCustomerLastUpdatedData.Text = "";
        }
        private void ResetHomeForm() {
            // Temporarily Unsubcribe from Control Events
            #region MenuItem Selection Events
            newUserToolStripMenuItem.Click -= OnNewUserMenuItemSelected;
            modifyUserToolStripMenuItem.Click -= OnModifyUserMenuItemSelected;

            newAppointmentToolStripMenuItem.Click -= OnNewAppointmentMenuItemSelected;
            modifyAppointmentToolStripMenuItem.Click -= OnModifyAppointmentMenuItemSelected;

            newCustomerToolStripMenuItem.Click -= OnNewCustomerMenuItemSelected;
            modifyCustomerToolStripMenuItem.Click -= OnModifyCustomerMenuItemSelected;

            newAddressToolStripMenuItem.Click -= OnNewAddressMenuItemSelected;
            modifyAddressToolStripMenuItem.Click -= OnModifyAddressMenuItemSelected;

            newCityToolStripMenuItem.Click -= OnNewCityMenuItemSelected;
            modifyCityToolStripMenuItem.Click -= OnModifyCityMenuItemSelected;

            newCountryToolStripMenuItem.Click -= OnNewCountryMenuItemSelected;
            modifyCountryToolStripMenuItem.Click -= OnModifyCountryMenuItemsSelected;

            scheduleByUSERToolStripMenuItem.Click -= OnScheduleByUserReportMenuItemSelected;
            appointmentsByTYPEByMONTHToolStripMenuItem.Click -= OnScheduleByTypeReportMenuItemSelected;
            activeCustomersToolStripMenuItem.Click -= OnActiveCustomersReportMenuItemSelected;
            #endregion
            #region ComboBox Selection Events
            cmbCustomerId.SelectedIndexChanged -= OnCustomerIdSelectionChanged;
            cmbAddressId.SelectedIndexChanged -= OnAddressIdSelectionChanged;
            #endregion
            #region
            radioDateMonthly.CheckedChanged -= OnDateViewMonthlyCheckedChanged;
            radioDateWeekly.CheckedChanged -= OnDateViewWeeklyCheckedChanged;
            radioTimeUTC.CheckedChanged -= OnTimeViewUTCCheckedChanged;
            radioTimeLocal.CheckedChanged -= OnTimeViewLocalCheckedChanged;
            #endregion

            // Disconnect dvgAppointmentList from userAppointments, if needed
            if(dgvAppointmentList.DataSource != null) {
                dgvAppointmentList.DataSource = null;
            }

            // Set Appointment Window to range from beginning to end of current week
            var diff = DateTime.Now.DayOfWeek - CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            if(diff < 0) { diff += 7; }

            earliestAppointmentViewDate = DateTime.Now.AddDays(-diff).Date;
            latestAppointmentViewDate = earliestAppointmentViewDate.AddDays(6);

            // Clear out lists, if needed
            allUsers.Clear();
            allAppointments.Clear();
            allCustomers.Clear();
            allAddresses.Clear();
            allCities.Clear();
            allCountries.Clear();
            userAppointments.Clear();
            cmbAddressId.Items.Clear();
            cmbCustomerId.Items.Clear();

            // Get Current Data from Database
            allUsers = DBManager.GetAllUserAccounts();
            allAppointments = DBManager.GetAllAppointments();
            allCustomers = DBManager.GetAllCustomers();
            allAddresses = DBManager.GetAllAddresses();
            allCities = DBManager.GetAllCities();
            allCountries = DBManager.GetAllCountries();

            // Perform HomeForm setup using activeUser
            CleanupCustomerAndAddressDetailsLabels();

            // Fill Read-Only HomeForm Controls
            foreach(var customer in allCustomers) {
                cmbCustomerId.Items.Add(customer.CustomerID.ToString());
            }

            foreach(var address in allAddresses) {
                cmbAddressId.Items.Add(address.ID.ToString());
            }

            // Create a filtered view of all user appointments based on Weekly/Monthly view option chosen
            IEnumerable<Appointment> filteredAppointments =
                    from appt in allAppointments
                    where appt.UserID == activeUser.ID
                    select appt;

            foreach(var appt in filteredAppointments) {
                if(appt.StartTime >= earliestAppointmentViewDate &&
                    appt.EndTime <= latestAppointmentViewDate) {
                    // It is cleaner and more straightforward to use these lambdas with LINQ to select the items we need, rather than build a wholly separate function for these
                    string userName = allUsers.Where(name => name.ID == appt.UserID).Select(name => name.Username).ElementAt(0);
                    string customerName = allCustomers.Where(name => name.CustomerID == appt.CustomerID).Select(name => name.Name).ElementAt(0);

                    DateTime apptStart = appt.StartTime;
                    DateTime apptEnd = appt.EndTime;

                    if(radioTimeLocal.Checked == true) {
                        apptStart = apptStart.ToLocalTime();
                        apptEnd = apptEnd.ToLocalTime();
                    }
                    else {
                        apptStart = apptStart.ToUniversalTime();
                        apptEnd = apptEnd.ToUniversalTime();
                    }

                    AppointmentListing listing = new AppointmentListing(appt.ID, userName, customerName, appt.Title, appt.Description, appt.Type, apptStart, apptEnd);
                    userAppointments.Add(listing);
                }
            }

            if(userAppointments.Count > 0) {
                dgvAppointmentList.DataSource = userAppointments;
            }

            // Set Any Additional Labels, as necessary
            lblAppointmentDateRange.Text = $"Viewing User Appointments from\r\n{earliestAppointmentViewDate.ToString("dd MMM yyyy")} to {latestAppointmentViewDate.ToString("dd MMM yyyy")}";

            // If HomeForm is Resetting for first time, check for immediate appointments
            if(scheduleChecked == false) {
                if(userAppointments.Count > 0) {
                    IEnumerable<AppointmentListing> todayAppointments =
                        from appt in userAppointments
                        orderby appt.StartDate.ToLocalTime().TimeOfDay ascending
                        where appt.StartDate.ToLocalTime().Date == DateTime.Now.ToLocalTime().Date
                        select appt;

                    AppointmentListing closestListing = todayAppointments.Last();

                    foreach(var appt in todayAppointments) {
                        DateTime apptStart = appt.StartDate.ToLocalTime();
                        DateTime closestStart = closestListing.StartDate.ToLocalTime();
                        DateTime timeNow = DateTime.Now.ToLocalTime();

                        if(apptStart.TimeOfDay < closestStart.TimeOfDay && apptStart.TimeOfDay > timeNow.TimeOfDay){
                            closestListing = appt;
                        }
                    }

                    DateTime closestApptStart = closestListing.StartDate.ToLocalTime();
                    DateTime currentTimeLocal = DateTime.Now.ToLocalTime();

                    // Once we have the closes appointment, check if its within 15 minutes of now
                    if(closestApptStart.Date == currentTimeLocal.Date) {
                        if(closestApptStart.Hour - currentTimeLocal.Hour == 0 &&
                            closestApptStart.Minute - currentTimeLocal.Minute <= 15 &&
                            closestApptStart.Minute - currentTimeLocal.Minute >= 0) {
                            // Date and Hour are the same, and time is less than 15 minutes, but more than 0.
                            MessageBox.Show($"You have an appointment in {closestListing.StartDate.Minute - DateTime.Now.Minute} minutes with {closestListing.CustomerName}");
                        }
                    }
                }

                // Even if an appointment is not found at login, disable re-checking
                scheduleChecked = true;
            }

            // Subscribe to Controls
            #region MenuItem Selection Events
            newUserToolStripMenuItem.Click += OnNewUserMenuItemSelected;
            modifyUserToolStripMenuItem.Click += OnModifyUserMenuItemSelected;

            newAppointmentToolStripMenuItem.Click += OnNewAppointmentMenuItemSelected;
            modifyAppointmentToolStripMenuItem.Click += OnModifyAppointmentMenuItemSelected;

            newCustomerToolStripMenuItem.Click += OnNewCustomerMenuItemSelected;
            modifyCustomerToolStripMenuItem.Click += OnModifyCustomerMenuItemSelected;

            newAddressToolStripMenuItem.Click += OnNewAddressMenuItemSelected;
            modifyAddressToolStripMenuItem.Click += OnModifyAddressMenuItemSelected;

            newCityToolStripMenuItem.Click += OnNewCityMenuItemSelected;
            modifyCityToolStripMenuItem.Click += OnModifyCityMenuItemSelected;

            newCountryToolStripMenuItem.Click += OnNewCountryMenuItemSelected;
            modifyCountryToolStripMenuItem.Click += OnModifyCountryMenuItemsSelected;

            scheduleByUSERToolStripMenuItem.Click += OnScheduleByUserReportMenuItemSelected;
            appointmentsByTYPEByMONTHToolStripMenuItem.Click += OnScheduleByTypeReportMenuItemSelected;
            activeCustomersToolStripMenuItem.Click += OnActiveCustomersReportMenuItemSelected;
            #endregion
            #region ComboBox Selection Events
            cmbCustomerId.SelectedIndexChanged += OnCustomerIdSelectionChanged;
            cmbAddressId.SelectedIndexChanged += OnAddressIdSelectionChanged;
            #endregion
            #region
            radioDateMonthly.CheckedChanged += OnDateViewMonthlyCheckedChanged;
            radioDateWeekly.CheckedChanged += OnDateViewWeeklyCheckedChanged;
            radioTimeUTC.CheckedChanged += OnTimeViewUTCCheckedChanged;
            radioTimeLocal.CheckedChanged += OnTimeViewLocalCheckedChanged;
            #endregion
        }
        private void ReloadAppointmentCalendar() {
            if(userAppointments.Count > 0) {
                userAppointments = new List<AppointmentListing>();
                dgvAppointmentList.DataSource = null;
                dgvAppointmentList.Rows.Clear();   
            }

            if(radioTimeLocal.Checked == true) {
                earliestAppointmentViewDate = earliestAppointmentViewDate.ToLocalTime();
                latestAppointmentViewDate = latestAppointmentViewDate.ToLocalTime();
            }
            else {
                earliestAppointmentViewDate = earliestAppointmentViewDate.ToUniversalTime();
                latestAppointmentViewDate = latestAppointmentViewDate.ToUniversalTime();
            }

            IEnumerable<Appointment> filteredAppointments =
                    from appt in allAppointments
                    where appt.UserID == activeUser.ID
                    select appt;

            foreach(var appt in filteredAppointments) {
                if(appt.StartTime >= earliestAppointmentViewDate &&
                    appt.EndTime <= latestAppointmentViewDate) {
                    // It is cleaner and more straightforward to use these lambdas with LINQ to select the items we need, rather than build a wholly separate function for these
                    string userName = allUsers.Where(name => name.ID == appt.UserID).Select(name => name.Username).ElementAt(0);
                    string customerName = allCustomers.Where(name => name.CustomerID == appt.CustomerID).Select(name => name.Name).ElementAt(0);

                    DateTime apptStart = appt.StartTime;
                    DateTime apptEnd = appt.EndTime;

                    if(radioTimeLocal.Checked == true) {
                        apptStart = apptStart.ToLocalTime();
                        apptEnd = apptEnd.ToLocalTime();
                        lblAppointmentDateRange.Text = $"Viewing User Appointments from\r\n{earliestAppointmentViewDate.ToLocalTime():dd MMM yyyy HH:mm:ss} to {latestAppointmentViewDate.ToLocalTime():dd MMM yyyy HH:mm:ss}";
                    }

                    if(radioTimeUTC.Checked == true) {
                        lblAppointmentDateRange.Text = $"Viewing User Appointments from\r\n{earliestAppointmentViewDate.ToUniversalTime():dd MMM yyyy HH:mm:ss} to {latestAppointmentViewDate.ToUniversalTime():dd MMM yyyy HH:mm:ss}";
                    }

                    AppointmentListing listing = new AppointmentListing(appt.ID, userName, customerName, appt.Title, appt.Description, appt.Type, apptStart, apptEnd);

                    

                    userAppointments.Add(listing);
                }
            }

            if(userAppointments.Count > 0) {
                dgvAppointmentList.DataSource = userAppointments;
            }
        }
        private void GenerateCustomerReport() {
            List<Customer> allCustomers = DBManager.GetAllCustomers();

            IEnumerable<string> filteredCustomer = allCustomers.Where(cust => cust.IsActive == true).Select(cust => cust.Name);

            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.Append($"There are {filteredCustomer.Count()} active Customers.\r\n\r\n");
            reportBuilder.Append("Active Customers:\r\n");
            foreach(var name in filteredCustomer) {
                reportBuilder.Append($"{name}\r\n");
            }

            MessageBox.Show(reportBuilder.ToString());
        }
        #endregion

        #region Event Functions
        private void OnLoginFormClosed(object sender, EventArgs e) {
            if(activeUser == null) {
                Close();
            }
            else {
                // Set Default View Options
                radioDateWeekly.Checked = true;
                radioDateMonthly.Checked = false;
                radioTimeLocal.Checked = true;
                radioTimeUTC.Checked = false;

                // Reset Home Form
                ResetHomeForm();
            }
        }
        private void OnUserLoggedIn(object sender, UserLoggedInEventArgs e) {
            activeUser = e.User;
        }
        private void OnFormSaved(object sender, EventArgs e) {
            ResetHomeForm();
        }
        private void OnSelectFormClosing(object sender, SelectFormEventArgs e) {
            // Check if the SelectForm has generated a Child Form
            if(e.ChildForm != null) {
                // Attach to the ChildForm's FormSaving event
                e.ChildForm.FormSaved += OnFormSaved;
                e.ChildForm.ShowDialog();
            }

            ResetHomeForm();
            ReloadAppointmentCalendar();
        }

        private void OnNewUserMenuItemSelected(object sender, EventArgs e) {
            
        }
        private void OnModifyUserMenuItemSelected(object sender, EventArgs e) {

        }
        private void OnNewAppointmentMenuItemSelected(object sender, EventArgs e) {
            NewAppointmentForm newApptForm = new NewAppointmentForm(activeUser);
            newApptForm.FormSaved += OnFormSaved;
            newApptForm.ShowDialog();
        }
        private void OnModifyAppointmentMenuItemSelected(object sender, EventArgs e) {
            SelectAppointmentForm selectAppointmentForm = new SelectAppointmentForm(activeUser);
            selectAppointmentForm.FormClosing += OnSelectFormClosing;
            selectAppointmentForm.ShowDialog();
        }
        private void OnNewCustomerMenuItemSelected(object sender, EventArgs e) {
            NewCustomerForm newCustomerForm = new NewCustomerForm(activeUser);
            newCustomerForm.FormSaved += OnFormSaved;
            newCustomerForm.ShowDialog();
        }
        private void OnModifyCustomerMenuItemSelected(object sender, EventArgs e) {
            SelectCustomerForm selectCustomerForm = new SelectCustomerForm(activeUser);
            selectCustomerForm.FormClosing += OnSelectFormClosing;
            selectCustomerForm.ShowDialog();
        }
        private void OnNewAddressMenuItemSelected(object sender, EventArgs e) {
            NewAddressForm newAddressForm = new NewAddressForm(activeUser);
            newAddressForm.FormSaved += OnFormSaved;
            newAddressForm.ShowDialog();
        }
        private void OnModifyAddressMenuItemSelected(object sender, EventArgs e) {
            SelectAddressForm selectAddressForm = new SelectAddressForm(activeUser);
            selectAddressForm.FormClosing += OnSelectFormClosing;
            selectAddressForm.ShowDialog();
        }
        private void OnNewCityMenuItemSelected(object sender, EventArgs e) {
            NewCityForm newCityForm = new NewCityForm(activeUser);
            newCityForm.FormSaved += OnFormSaved;
            newCityForm.ShowDialog();
        }
        private void OnModifyCityMenuItemSelected(object sender, EventArgs e) {
            SelectCityForm selectCityForm = new SelectCityForm(activeUser);
            selectCityForm.FormClosing += OnSelectFormClosing;
            selectCityForm.ShowDialog();
        }
        private void OnNewCountryMenuItemSelected(object sender, EventArgs e) {
            NewCountryForm newCountryForm = new NewCountryForm(activeUser);
            newCountryForm.FormSaved += OnFormSaved;
            newCountryForm.ShowDialog();
        }
        private void OnModifyCountryMenuItemsSelected(object sender, EventArgs e) {
            SelectCountryForm selectCountryForm = new SelectCountryForm(activeUser);
            selectCountryForm.FormClosing += OnSelectFormClosing;
            selectCountryForm.ShowDialog();
        }

        private void OnScheduleByTypeReportMenuItemSelected(object sender, EventArgs e) {
            ReportByTypeMonthForm reportByTypeMonthForm = new ReportByTypeMonthForm();
            reportByTypeMonthForm.ShowDialog();
        }
        private void OnScheduleByUserReportMenuItemSelected(object sender, EventArgs e) {
            ScheduleByUserForm scheduleByUserForm = new ScheduleByUserForm();
            scheduleByUserForm.ShowDialog();
        }
        private void OnActiveCustomersReportMenuItemSelected(object sender, EventArgs e) {
            GenerateCustomerReport();
        }

        private void OnCustomerIdSelectionChanged(object sender, EventArgs e) {
            int id = int.Parse(cmbCustomerId.SelectedItem.ToString());
            Customer currentCustomer = null;

            foreach(var customer in allCustomers) {
                if(customer.CustomerID == id) {
                    currentCustomer = customer;
                    break;
                }
            }

            if(currentCustomer == null) {
                MessageBox.Show("Could not load data.");
            }
            else {
                lblCustomerActiveData.Text = currentCustomer.IsActive.ToString();
                lblCustomerNameData.Text = currentCustomer.Name;
                lblCustomerAddressData.Text = DBManager.GetFullAddressById(currentCustomer.AddressID);
                lblCustomerCreatedData.Text = $"{currentCustomer.DateCreated.ToString("d MMM yy HH:mm")}" +
                    "\r\n" +
                    $"By User: {currentCustomer.CreatedBy}";
                lblCustomerLastUpdatedData.Text = $"{currentCustomer.DateLastUpdated.ToString("d MMM yy HH:mm")}" +
                    "\r\n" +
                    $"By User: {currentCustomer.LastUpdatedBy}";
            }
        }
        private void OnAddressIdSelectionChanged(object sender, EventArgs e) {
            int id = int.Parse(cmbAddressId.SelectedItem.ToString());
            Address currentAddress = null;

            foreach(var addr in allAddresses) {
                if(addr.ID == id) {
                    currentAddress = addr;
                    break;
                }
            }

            if(currentAddress == null) {
                MessageBox.Show("Could not load address data");
            }
            else {
                lblAddressAddress1Data.Text = currentAddress.Address1;
                lblAddressAddress2Data.Text = currentAddress.Address2;
                lblAddressCityData.Text = DBManager.GetCityById(currentAddress.CityID).Name ?? "CITY NOT FOUND";
                lblAddressPhoneData.Text = currentAddress.Phone;
                lblAddressPostalCodeData.Text = currentAddress.PostalCode;
                lblAddressCreatedByData.Text = $"{currentAddress.DateCreated.ToString("d MMM yy HH:mm")}" +
                    $"\r\n" +
                    $"By User: {currentAddress.CreatedBy}";
                lblAddressLastUpdatedData.Text = $"{currentAddress.DateLastUpdated.ToString("d MMM yy HH:mm")}" +
                    $"\r\n" +
                    $"By User: {currentAddress.LastUpdatedBy}";
            }
        }
        private void OnDateViewWeeklyCheckedChanged(object sender, EventArgs e) {
            if(radioDateWeekly.Checked == true) {
                radioDateMonthly.Checked = false;

                // Set Appointment Window to range from beginning to end of current week
                var diff = DateTime.Now.DayOfWeek - CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
                if(diff < 0) { diff += 7; }

                earliestAppointmentViewDate = DateTime.Now.AddDays(-diff).Date;
                latestAppointmentViewDate = earliestAppointmentViewDate.AddDays(6);

                ReloadAppointmentCalendar();
            }
        }
        private void OnDateViewMonthlyCheckedChanged(object sender, EventArgs e) {
            if(radioDateMonthly.Checked == true) {
                radioDateWeekly.Checked = false;

                // Set Appointment Window to range from 1st of current month to end of current month
                earliestAppointmentViewDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                latestAppointmentViewDate = earliestAppointmentViewDate.AddMonths(1).AddTicks(-1);

                ReloadAppointmentCalendar();
            }
        }
        private void OnTimeViewUTCCheckedChanged(object sender, EventArgs e) {
            if(radioTimeUTC.Checked == true) {
                radioTimeLocal.Checked = false;
                ReloadAppointmentCalendar();
            }
        }
        private void OnTimeViewLocalCheckedChanged(object sender, EventArgs e) {
            if(radioTimeLocal.Checked == true) {
                radioTimeUTC.Checked = false;
                ReloadAppointmentCalendar();
            }
        }
      #endregion
   }
}
