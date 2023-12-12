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
   public partial class ReportsByCustomerAddressID : Form
   {
      public ReportsByCustomerAddressID()
      {
         InitializeComponent();
      }
      private void ReportsByCustomerAddressID_Load(object sender, EventArgs e)
      {
         LoadForm();
      }

      private void LoadForm()
      {

      }
      private void customerReportsGenerateBtn_Click(object sender, EventArgs e)
      {

         List<Customer> allCustomers = DBConnection.GetCustomers();
         List<Customer> filteredCustomers = new List<Customer>();

         try
         {
            int.Parse(customerReportsAddressIDTxtBx.Text);
         }
         catch 
         {
            MessageBox.Show("Invalid Address ID Entered");
            return;
         }
         foreach (var customer in allCustomers)
         {

            if (customer.AddressID == int.Parse(customerReportsAddressIDTxtBx.Text))
            {
               filteredCustomers.Add(customer);
            }

         }

         if(filteredCustomers.Count > 0)
         {
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.Append($"Found {filteredCustomers.Count} customers with that address ID \r\n");
            reportBuilder.Append("Appointments Found: \r\n");

            foreach(var customer in filteredCustomers)
            {
               reportBuilder.Append($"ID: {customer.CustomerID} Name: {customer.CustomerName}\r\n");
            }
            MessageBox.Show(reportBuilder.ToString());
         }
         else
         {
            MessageBox.Show("No ID matches entered ID.");
         }
      }
      private void customerReportsCancelBtn_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
