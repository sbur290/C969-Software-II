using C969_Project_Assessment_Spencer_Burkett.Database;
using C969_Project_Assessment_Spencer_Burkett.Events;
using C969_Project_Assessment_Spencer_Burkett.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969_Project_Assessment_Spencer_Burkett
{
   public partial class LoginScreen : Form
   {
      public event EventHandler<LoggedInEventArgs> LoggedIn;

      static MySqlCommand cmd = null;
      static MySqlDataReader reader = null;
      public LoginScreen()
      {
         InitializeComponent();
         LocalizeFormText();
      }
      private void LocalizeFormText()
      {
         loginTitleLbl.Text = Settings.CurrentLabel[Settings.LOGIN_FORM__TITLE_LBL_ID];
         usernameLbl.Text = Settings.CurrentLabel[Settings.LOGIN_FORM_USERNAME_LBLTEXT_ID];
         passwordLbl.Text = Settings.CurrentLabel[Settings.LOGIN_FORM_PASSWORD_LBLTEXT_ID];
         loginBtn.Text = Settings.CurrentLabel[Settings.LOGIN_FORM_LOGIN_BTNTEXT_ID];
      }

      private void OnLogin(User user)
      {
         MessageBox.Show("Successful Log In");
         LoggedIn?.Invoke(null, new LoggedInEventArgs(user));
         StringBuilder log = new StringBuilder();
         log.Append($"{DateTime.Now}: ");
         log.Append($"User successfully logged in with username \"{user.Username}\". \r\n");
         using(StreamWriter fileWriter = File.AppendText("logs.txt"))
         {
            fileWriter.Write(log.ToString());
         }

         Close();
      }
      private void LoginBtn_Click(object sender, EventArgs e)
      {
         string username = usernameTxtbox.Text;
         string password = passwordTxtbox.Text;
         //Two different exception control mechanisms are utilized here (conditional, try/catch)
         try
         {
            DBConnection.OpenConnection();
            string query = "SELECT * FROM user WHERE userName = '" + username + "' AND password = '" + password + "'";
            cmd = new MySqlCommand(query, DBConnection.conn);
            reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
               MessageBox.Show(Settings.CurrentLabel[Settings.LOGIN_FORM_EXCEPTIONTEXT_INVALID_LOGIN]);
               StringBuilder log = new StringBuilder();
               log.Append($"{DateTime.Now}: ");
               log.Append($"User unsuccessfully logged in with username \"{usernameTxtbox.Text}\". \r\n");
               using (StreamWriter fileWriter = File.AppendText("logs.txt"))
               {
                  fileWriter.Write(log.ToString());
               }
            }
            else
            {
               List<User> allUsers = DBConnection.GetUsers();
               foreach (User user in allUsers) 
               {
                  if (user.Username == username && user.Password == password)
                  {
                     OnLogin(user);
                  }
                  else 
                  {
                     MessageBox.Show(Settings.CurrentLabel[Settings.LOGIN_FORM_EXCEPTIONTEXT_INVALID_LOGIN]);
                     StringBuilder log = new StringBuilder();
                     log.Append($"{DateTime.Now}: ");
                     log.Append($"User unsuccessfully logged in with username \"{usernameTxtbox.Text}\". \r\n");
                     using (StreamWriter fileWriter = File.AppendText("logs.txt"))
                     {
                        fileWriter.Write(log.ToString());
                     }
                  }
               }
            }
         }
         catch (MySqlException)
         {

         }
         finally
         {
            DBConnection.CloseConnection();
         }
      }
   }
}
