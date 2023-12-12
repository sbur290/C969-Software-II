namespace C969_Project_Assessment_Spencer_Burkett.Forms.Entry_Addition
{
   partial class NewCityForm
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
         this.newCityIDTxtBx = new System.Windows.Forms.TextBox();
         this.newCityIDLbl = new System.Windows.Forms.Label();
         this.newCityNameLbl = new System.Windows.Forms.Label();
         this.newCityCountryIDLbl = new System.Windows.Forms.Label();
         this.newCityNameTxtBx = new System.Windows.Forms.TextBox();
         this.newCityCountryLbl = new System.Windows.Forms.Label();
         this.newCityCountryIDCmb = new System.Windows.Forms.ComboBox();
         this.newCitySaveBtn = new System.Windows.Forms.Button();
         this.newCityCancelBtn = new System.Windows.Forms.Button();
         this.newCityNewCountryBtn = new System.Windows.Forms.Button();
         this.newCityCountryDataLbl = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // newCityIDTxtBx
         // 
         this.newCityIDTxtBx.Location = new System.Drawing.Point(37, 12);
         this.newCityIDTxtBx.Name = "newCityIDTxtBx";
         this.newCityIDTxtBx.ReadOnly = true;
         this.newCityIDTxtBx.Size = new System.Drawing.Size(44, 20);
         this.newCityIDTxtBx.TabIndex = 3;
         // 
         // newCityIDLbl
         // 
         this.newCityIDLbl.AutoSize = true;
         this.newCityIDLbl.Location = new System.Drawing.Point(10, 15);
         this.newCityIDLbl.Name = "newCityIDLbl";
         this.newCityIDLbl.Size = new System.Drawing.Size(21, 13);
         this.newCityIDLbl.TabIndex = 2;
         this.newCityIDLbl.Text = "ID:";
         // 
         // newCityNameLbl
         // 
         this.newCityNameLbl.AutoSize = true;
         this.newCityNameLbl.Location = new System.Drawing.Point(10, 50);
         this.newCityNameLbl.Name = "newCityNameLbl";
         this.newCityNameLbl.Size = new System.Drawing.Size(58, 13);
         this.newCityNameLbl.TabIndex = 4;
         this.newCityNameLbl.Text = "City Name:";
         // 
         // newCityCountryIDLbl
         // 
         this.newCityCountryIDLbl.AutoSize = true;
         this.newCityCountryIDLbl.Location = new System.Drawing.Point(8, 91);
         this.newCityCountryIDLbl.Name = "newCityCountryIDLbl";
         this.newCityCountryIDLbl.Size = new System.Drawing.Size(60, 13);
         this.newCityCountryIDLbl.TabIndex = 5;
         this.newCityCountryIDLbl.Text = "Country ID:";
         // 
         // newCityNameTxtBx
         // 
         this.newCityNameTxtBx.Location = new System.Drawing.Point(85, 47);
         this.newCityNameTxtBx.Name = "newCityNameTxtBx";
         this.newCityNameTxtBx.Size = new System.Drawing.Size(125, 20);
         this.newCityNameTxtBx.TabIndex = 6;
         // 
         // newCityCountryLbl
         // 
         this.newCityCountryLbl.AutoSize = true;
         this.newCityCountryLbl.Location = new System.Drawing.Point(8, 130);
         this.newCityCountryLbl.Name = "newCityCountryLbl";
         this.newCityCountryLbl.Size = new System.Drawing.Size(46, 13);
         this.newCityCountryLbl.TabIndex = 8;
         this.newCityCountryLbl.Text = "Country:";
         // 
         // newCityCountryIDCmb
         // 
         this.newCityCountryIDCmb.FormattingEnabled = true;
         this.newCityCountryIDCmb.Location = new System.Drawing.Point(85, 91);
         this.newCityCountryIDCmb.Name = "newCityCountryIDCmb";
         this.newCityCountryIDCmb.Size = new System.Drawing.Size(52, 21);
         this.newCityCountryIDCmb.TabIndex = 9;
         this.newCityCountryIDCmb.SelectedIndexChanged += new System.EventHandler(this.newCityCountryIDCmb_SelectedIndexChanged);
         // 
         // newCitySaveBtn
         // 
         this.newCitySaveBtn.Location = new System.Drawing.Point(6, 202);
         this.newCitySaveBtn.Name = "newCitySaveBtn";
         this.newCitySaveBtn.Size = new System.Drawing.Size(75, 23);
         this.newCitySaveBtn.TabIndex = 10;
         this.newCitySaveBtn.Text = "Save";
         this.newCitySaveBtn.UseVisualStyleBackColor = true;
         this.newCitySaveBtn.Click += new System.EventHandler(this.newCitySaveBtn_Click);
         // 
         // newCityCancelBtn
         // 
         this.newCityCancelBtn.Location = new System.Drawing.Point(135, 202);
         this.newCityCancelBtn.Name = "newCityCancelBtn";
         this.newCityCancelBtn.Size = new System.Drawing.Size(75, 23);
         this.newCityCancelBtn.TabIndex = 11;
         this.newCityCancelBtn.Text = "Cancel";
         this.newCityCancelBtn.UseVisualStyleBackColor = true;
         this.newCityCancelBtn.Click += new System.EventHandler(this.newCityCancelBtn_Click);
         // 
         // newCityNewCountryBtn
         // 
         this.newCityNewCountryBtn.Location = new System.Drawing.Point(11, 159);
         this.newCityNewCountryBtn.Name = "newCityNewCountryBtn";
         this.newCityNewCountryBtn.Size = new System.Drawing.Size(79, 23);
         this.newCityNewCountryBtn.TabIndex = 12;
         this.newCityNewCountryBtn.Text = "New Country";
         this.newCityNewCountryBtn.UseVisualStyleBackColor = true;
         this.newCityNewCountryBtn.Click += new System.EventHandler(this.newCityNewCountryBtn_Click);
         // 
         // newCityCountryDataLbl
         // 
         this.newCityCountryDataLbl.AutoSize = true;
         this.newCityCountryDataLbl.Location = new System.Drawing.Point(82, 130);
         this.newCityCountryDataLbl.Name = "newCityCountryDataLbl";
         this.newCityCountryDataLbl.Size = new System.Drawing.Size(34, 13);
         this.newCityCountryDataLbl.TabIndex = 13;
         this.newCityCountryDataLbl.Text = "Spain";
         // 
         // NewCityForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(221, 237);
         this.Controls.Add(this.newCityCountryDataLbl);
         this.Controls.Add(this.newCityNewCountryBtn);
         this.Controls.Add(this.newCityCancelBtn);
         this.Controls.Add(this.newCitySaveBtn);
         this.Controls.Add(this.newCityCountryIDCmb);
         this.Controls.Add(this.newCityCountryLbl);
         this.Controls.Add(this.newCityNameTxtBx);
         this.Controls.Add(this.newCityCountryIDLbl);
         this.Controls.Add(this.newCityNameLbl);
         this.Controls.Add(this.newCityIDTxtBx);
         this.Controls.Add(this.newCityIDLbl);
         this.Name = "NewCityForm";
         this.Text = "New City";
         this.Load += new System.EventHandler(this.NewCityForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox newCityIDTxtBx;
      private System.Windows.Forms.Label newCityIDLbl;
      private System.Windows.Forms.Label newCityNameLbl;
      private System.Windows.Forms.Label newCityCountryIDLbl;
      private System.Windows.Forms.TextBox newCityNameTxtBx;
      private System.Windows.Forms.Label newCityCountryLbl;
      private System.Windows.Forms.ComboBox newCityCountryIDCmb;
      private System.Windows.Forms.Button newCitySaveBtn;
      private System.Windows.Forms.Button newCityCancelBtn;
      private System.Windows.Forms.Button newCityNewCountryBtn;
      private System.Windows.Forms.Label newCityCountryDataLbl;
   }
}