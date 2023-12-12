using C969_Project_Assessment_Spencer_Burkett.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Project_Assessment_Spencer_Burkett.Forms.Modify_Or_Delete
{
   public partial class SelectCustomerForm : Form
   {
      User currentUser;
      public SelectCustomerForm(User user)
      {
         InitializeComponent();
         currentUser = user;
      }

      private void SelectCustomerForm_Load(object sender, EventArgs e)
      {
         LoadForm();
      }

      private void LoadForm()
      {
         List<Customer> allCustomers = DBConnection.GetCustomers();
         foreach (var customer in allCustomers)
         {
            selectCustomerIDCmb.Items.Add(customer.CustomerID);
         }
         selectCustomerIDCmb.SelectedIndex = 0;
      }

      private void SetDetails(Customer customer)
      {
         StringBuilder entryBuilder = new StringBuilder();
         entryBuilder.Append($"Customer ID: {customer.CustomerID} \r\n");
         entryBuilder.Append($"Customer Name: {customer.CustomerName} \r\n");
         entryBuilder.Append($"Address ID: {customer.AddressID} \r\n");
         entryBuilder.Append($"Created: ID: {customer.DateCreated} \r\n");
         entryBuilder.Append($"Created By: {customer.CreatedBy} \r\n");
         entryBuilder.Append($"Updated: {customer.DateUpdated} \r\n");
         entryBuilder.Append($"Updated By: {customer.UpdatedBy} \r\n");

         selectCustomerDetailsTxtBx.Text = entryBuilder.ToString();
      }

      private void selectCustomerIDCmb_SelectedIndexChanged(object sender, EventArgs e)
      {
         DBConnection.OpenConnection();
         string query = $"SELECT * FROM customer WHERE customerId = {int.Parse(selectCustomerIDCmb.SelectedItem.ToString())}";
         MySqlCommand command = new MySqlCommand(query, DBConnection.conn);

         MySqlDataReader reader = command.ExecuteReader();
         Customer selectedCustomer = null;

         while (reader.Read())
         {
            selectedCustomer = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetBoolean(3), reader.GetDateTime(4), reader.GetString(5),
                                            reader.GetDateTime(6), reader.GetString(7));
         }
         SetDetails(selectedCustomer);

         DBConnection.CloseConnection();
      }

      private void selectCustomerModifyBtn_Click(object sender, EventArgs e)
      {
         DBConnection.OpenConnection();
         string query = $"SELECT * FROM customer WHERE customerId = {int.Parse(selectCustomerIDCmb.SelectedItem.ToString())}";
         MySqlCommand command = new MySqlCommand(query, DBConnection.conn);

         MySqlDataReader reader = command.ExecuteReader();
         Customer selectedCustomer = null;

         while (reader.Read())
         {
            selectedCustomer = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetBoolean(3), reader.GetDateTime(4), reader.GetString(5),
                                            reader.GetDateTime(6), reader.GetString(7));
         }

         if (selectedCustomer != null)
         {
            ModifyCustomerForm modifyCustomerForm = new ModifyCustomerForm(currentUser, selectedCustomer);
            this.Visible = false;
            modifyCustomerForm.ShowDialog();
         }
         else
         {
            MessageBox.Show("Error loading customer.");
         }
      }

      private void selectCustomerDeleteBtn_Click(object sender, EventArgs e)
      {
         DialogResult confirmMessage = MessageBox.Show("Are you sure you want to delete this Customer?", "This action is permanent.", MessageBoxButtons.YesNo);

         if (confirmMessage == DialogResult.Yes)
         {
            int rowsAffected = DBConnection.DeleteRecord("customer", $"customerId = {int.Parse(selectCustomerIDCmb.SelectedItem.ToString())}");

            if (rowsAffected > 0)
            {
               MessageBox.Show("Record deleted successfully.");
               LoadForm();
            }
         }
      }

      private void selectCustomerCancelButton_Click(object sender, EventArgs e)
      {
         Close();
      }
   }
}
