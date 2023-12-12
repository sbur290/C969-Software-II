namespace C969_Project_Assessment_Spencer_Burkett
{
   partial class LoginScreen
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
         this.usernameLbl = new System.Windows.Forms.Label();
         this.passwordLbl = new System.Windows.Forms.Label();
         this.usernameTxtbox = new System.Windows.Forms.TextBox();
         this.passwordTxtbox = new System.Windows.Forms.TextBox();
         this.loginBtn = new System.Windows.Forms.Button();
         this.loginTitleLbl = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // usernameLbl
         // 
         resources.ApplyResources(this.usernameLbl, "usernameLbl");
         this.usernameLbl.Name = "usernameLbl";
         // 
         // passwordLbl
         // 
         resources.ApplyResources(this.passwordLbl, "passwordLbl");
         this.passwordLbl.Name = "passwordLbl";
         // 
         // usernameTxtbox
         // 
         resources.ApplyResources(this.usernameTxtbox, "usernameTxtbox");
         this.usernameTxtbox.Name = "usernameTxtbox";
         // 
         // passwordTxtbox
         // 
         resources.ApplyResources(this.passwordTxtbox, "passwordTxtbox");
         this.passwordTxtbox.Name = "passwordTxtbox";
         // 
         // loginBtn
         // 
         resources.ApplyResources(this.loginBtn, "loginBtn");
         this.loginBtn.Name = "loginBtn";
         this.loginBtn.UseVisualStyleBackColor = true;
         this.loginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
         // 
         // loginTitleLbl
         // 
         resources.ApplyResources(this.loginTitleLbl, "loginTitleLbl");
         this.loginTitleLbl.Name = "loginTitleLbl";
         // 
         // LoginScreen
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.loginTitleLbl);
         this.Controls.Add(this.loginBtn);
         this.Controls.Add(this.passwordTxtbox);
         this.Controls.Add(this.usernameTxtbox);
         this.Controls.Add(this.passwordLbl);
         this.Controls.Add(this.usernameLbl);
         this.Name = "LoginScreen";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label usernameLbl;
      private System.Windows.Forms.Label passwordLbl;
      private System.Windows.Forms.TextBox usernameTxtbox;
      private System.Windows.Forms.TextBox passwordTxtbox;
      private System.Windows.Forms.Button loginBtn;
      private System.Windows.Forms.Label loginTitleLbl;
   }
}

