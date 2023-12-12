using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Project_Assessment_Spencer_Burkett.Database
{
   public class DBConnection
   {
      public static MySqlConnection conn { get; set; }

      public static void OpenConnection()
      {
         string connectionStr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

         try
         {
            conn = new MySqlConnection(connectionStr);

            //open the connection
            conn.Open();
         }
         catch (MySqlException)
         {
            MessageBox.Show(Settings.CurrentLabel[Settings.LOGIN_FORM_EXCEPTIONTEXT_INVALID_LOGIN]);
         }
      }

      public static List<Address> GetAddresses()
      {
         List<Address> allAddresss = new List<Address>();

         OpenConnection();
         string query = "SELECT * FROM Address";
         MySqlCommand selectAllAddresss = new MySqlCommand(query, conn);

         MySqlDataReader reader = selectAllAddresss.ExecuteReader();

         while (reader.Read())
         {
            Address address = new Address(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), 
                                          reader.GetDateTime(6), reader.GetString(7), reader.GetDateTime(8), reader.GetString(9));
            allAddresss.Add(address);
         }

         return allAddresss;
      }

      public static Address GetAddressById(int id) 
      { 
         OpenConnection();
         string query = $"SELECT * FROM address WHERE addressId = {id}";
         MySqlCommand command = new MySqlCommand(query, conn);

         try
         {
            MySqlDataReader reader = command.ExecuteReader();
            Address newAddress = null;

            while (reader.Read())
            {
               newAddress = new Address(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), 
                                        reader.GetDateTime(6), reader.GetString(7), reader.GetDateTime(8), reader.GetString(9));
            }
            return newAddress;
         }
         catch(MySqlException ex)
         {
            MessageBox.Show(ex.Message);
            return null;
         }
         finally 
         {
            CloseConnection();
         }
      }

      public static List<Appointment> GetAppointments()
      {
         List<Appointment> allAppointments = new List<Appointment>();

         OpenConnection();
         string query = "SELECT * FROM appointment";
         MySqlCommand selectAllAppointments = new MySqlCommand(query, conn);

         MySqlDataReader reader = selectAllAppointments.ExecuteReader();

         while (reader.Read())
         {
            Appointment appointment = new Appointment(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetString(5),
                                                      reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetDateTime(9), reader.GetDateTime(10),
                                                      reader.GetDateTime(11), reader.GetString(12), reader.GetDateTime(13), reader.GetString(14));
            allAppointments.Add(appointment);
         }
         CloseConnection();
         return allAppointments;
      }

      public static List<City> GetCities()
      {
         List<City> allCities = new List<City>();

         OpenConnection();
         string query = "SELECT * FROM City";
         MySqlCommand selectAllCites = new MySqlCommand(query, conn);

         MySqlDataReader reader = selectAllCites.ExecuteReader();

         while (reader.Read())
         {
            City city = new City(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetString(4), reader.GetDateTime(5), 
                                 reader.GetString(6));
            allCities.Add(city);
         }

         return allCities;
      }

      public static List<Country> GetCountry() 
      {
         List<Country> allCountries = new List<Country>();

         OpenConnection();
         string query = "SELECT * FROM Country";
         MySqlCommand selectAllCountries = new MySqlCommand(query, conn);

         MySqlDataReader reader = selectAllCountries.ExecuteReader();

         while (reader.Read())
         {
            Country country = new Country(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5));
            allCountries.Add(country);
         }

         return allCountries;
      }
      public static List<Customer> GetCustomers()
      {
         List<Customer> allCustomers = new List<Customer>();

         OpenConnection();
         string query = "SELECT * FROM customer";
         MySqlCommand selectAllcustomers = new MySqlCommand(query, conn);

         MySqlDataReader reader = selectAllcustomers.ExecuteReader();

         while (reader.Read())
         {
            Customer customer = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetBoolean(3), reader.GetDateTime(4), reader.GetString(5),
                                             reader.GetDateTime(6), reader.GetString(7));
            allCustomers.Add(customer);
         }

         return allCustomers;
      }
      public static List<User> GetUsers()
      {
         List<User> allUsers = new List<User>();

         OpenConnection();
         string query = "SELECT * FROM user";
         MySqlCommand selectAllUsers = new MySqlCommand(query, conn);

         MySqlDataReader reader = selectAllUsers.ExecuteReader();


         while (reader.Read())
         {
            User user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3), reader.GetDateTime(4), reader.GetString(5));
            allUsers.Add(user);
         }

         CloseConnection();
         return allUsers;
      }
      
      public static int GenerateID(string table, string idColumnName)
      {
         OpenConnection();
         string query = $"SELECT MAX({idColumnName}) FROM {table}";
         MySqlCommand command = new MySqlCommand(query, conn);

         try
         {
            int maxID = 9999999;
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
               maxID = reader.GetInt32(0);
            }
            return maxID + 1;
         }
         catch(MySqlException ex) 
         {
            MessageBox.Show(ex.Message);
            return -1;
         }
         finally 
         {
            CloseConnection();
         }
      }

      public static int InsertNewRecord(string table, string values)
      {
         OpenConnection();
         StringBuilder queryBuilder = new StringBuilder();
         queryBuilder.Append($"INSERT INTO {table} VALUES ({values});");
         string query = queryBuilder.ToString();

         MySqlCommand insert = new MySqlCommand(query, conn);

         try
         {
            return insert.ExecuteNonQuery();
         }
         catch (MySqlException ex) 
         {
            MessageBox.Show(ex.Message);
            return -1;
         }
         finally
         {
            CloseConnection();
         }
      }
      public static int ModifyRecord(string table, string values, string where = "")
      {
         OpenConnection ();
         StringBuilder queryBuilder = new StringBuilder();
         queryBuilder.Append($"UPDATE {table} SET {values}");
         if(where != "")
         {
            queryBuilder.Append($" WHERE {where};");
         }
         else
         {
            queryBuilder.Append(";");
         }

         string query = queryBuilder.ToString();
         MySqlCommand insert = new MySqlCommand(query, conn);

         try
         {
            return insert.ExecuteNonQuery();
         }
         catch (MySqlException ex)
         {
            MessageBox.Show(ex.Message);
            return -1;
         }
         finally
         {
            CloseConnection();
         }
      }
      public static int DeleteRecord(string table, string where)
      {
         OpenConnection();
         StringBuilder queryBuilder = new StringBuilder();
         queryBuilder.Append($"DELETE FROM {table} WHERE {where}");

         string query = queryBuilder.ToString();
         MySqlCommand delete = new MySqlCommand(query, conn);

         try
         {
            return delete.ExecuteNonQuery();
         }
         catch (MySqlException ex) 
         {
            MessageBox.Show(ex.Message);
            return -1;
         }
         finally 
         { 
            CloseConnection(); 
         }
      }

      public static void CloseConnection() 
      {
         try
         {
            if (conn != null)
            {
               conn.Close();
            }
            conn = null;
         }
         catch (MySqlException ex)
         {
            MessageBox.Show(ex.Message);
         }
      }
   }
}
