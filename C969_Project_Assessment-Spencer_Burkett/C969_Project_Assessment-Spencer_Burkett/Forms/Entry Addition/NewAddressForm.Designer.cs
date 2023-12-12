namespace C969_Project_Assessment_Spencer_Burkett.Forms.Entry_Addition
{
   partial class NewAddressForm
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
         this.newAddressIDLbl = new System.Windows.Forms.Label();
         this.newAddressIDTxtBx = new System.Windows.Forms.TextBox();
         this.newAddressDetailsGrpBx = new System.Windows.Forms.GroupBox();
         this.label1 = new System.Windows.Forms.Label();
         this.newAddressPhoneExLbl = new System.Windows.Forms.Label();
         this.newAddressNewCityBtn = new System.Windows.Forms.Button();
         this.newAddressCityNameLbl = new System.Windows.Forms.Label();
         this.newAddressPostalCodeTxtBx = new System.Windows.Forms.TextBox();
         this.newAddressPostalCodeLbl = new System.Windows.Forms.Label();
         this.newAddressPhoneTxtBx = new System.Windows.Forms.TextBox();
         this.newAddressPhoneLbl = new System.Windows.Forms.Label();
         this.newAddressCityIDCmb = new System.Windows.Forms.ComboBox();
         this.newAddressCityIDLbl = new System.Windows.Forms.Label();
         this.newAddress2TxtBx = new System.Windows.Forms.TextBox();
         this.newAddressTxtBx = new System.Windows.Forms.TextBox();
         this.newAddress2Lbl = new System.Windows.Forms.Label();
         this.newAddressLbl = new System.Windows.Forms.Label();
         this.newAddressSaveBtn = new System.Windows.Forms.Button();
         this.newAddressCancelBtn = new System.Windows.Forms.Button();
         this.newAddressDetailsGrpBx.SuspendLayout();
         this.SuspendLayout();
         // 
         // newAddressIDLbl
         // 
         this.newAddressIDLbl.AutoSize = true;
         this.newAddressIDLbl.Location = new System.Drawing.Point(26, 22);
         this.newAddressIDLbl.Name = "newAddressIDLbl";
         this.newAddressIDLbl.Size = new System.Drawing.Size(21, 13);
         this.newAddressIDLbl.TabIndex = 0;
         this.newAddressIDLbl.Text = "ID:";
         // 
         // newAddressIDTxtBx
         // 
         this.newAddressIDTxtBx.Location = new System.Drawing.Point(53, 19);
         this.newAddressIDTxtBx.Name = "newAddressIDTxtBx";
         this.newAddressIDTxtBx.ReadOnly = true;
         this.newAddressIDTxtBx.Size = new System.Drawing.Size(44, 20);
         this.newAddressIDTxtBx.TabIndex = 1;
         // 
         // newAddressDetailsGrpBx
         // 
         this.newAddressDetailsGrpBx.Controls.Add(this.label1);
         this.newAddressDetailsGrpBx.Controls.Add(this.newAddressPhoneExLbl);
         this.newAddressDetailsGrpBx.Controls.Add(this.newAddressNewCityBtn);
         this.newAddressDetailsGrpBx.Controls.Add(this.newAddressCityNameLbl);
         this.newAddressDetailsGrpBx.Controls.Add(this.newAddressPostalCodeTxtBx);
         this.newAddressDetailsGrpBx.Controls.Add(this.newAddressPostalCodeLbl);
         this.newAddressDetailsGrpBx.Controls.Add(this.newAddressPhoneTxtBx);
         this.newAddressDetailsGrpBx.Controls.Add(this.newAddressPhoneLbl);
         this.newAddressDetailsGrpBx.Controls.Add(this.newAddressCityIDCmb);
         this.newAddressDetailsGrpBx.Controls.Add(this.newAddressCityIDLbl);
         this.newAddressDetailsGrpBx.Controls.Add(this.newAddress2TxtBx);
         this.newAddressDetailsGrpBx.Controls.Add(this.newAddressTxtBx);
         this.newAddressDetailsGrpBx.Controls.Add(this.newAddress2Lbl);
         this.newAddressDetailsGrpBx.Controls.Add(this.newAddressLbl);
         this.newAddressDetailsGrpBx.Location = new System.Drawing.Point(12, 56);
         this.newAddressDetailsGrpBx.Name = "newAddressDetailsGrpBx";
         this.newAddressDetailsGrpBx.Size = new System.Drawing.Size(346, 204);
         this.newAddressDetailsGrpBx.TabIndex = 2;
         this.newAddressDetailsGrpBx.TabStop = false;
         this.newAddressDetailsGrpBx.Text = "Details";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(71, 173);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(51, 13);
         this.label1.TabIndex = 14;
         this.label1.Text = "ex 12345";
         // 
         // newAddressPhoneExLbl
         // 
         this.newAddressPhoneExLbl.AutoSize = true;
         this.newAddressPhoneExLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.newAddressPhoneExLbl.Location = new System.Drawing.Point(71, 116);
         this.newAddressPhoneExLbl.Name = "newAddressPhoneExLbl";
         this.newAddressPhoneExLbl.Size = new System.Drawing.Size(87, 13);
         this.newAddressPhoneExLbl.TabIndex = 13;
         this.newAddressPhoneExLbl.Text = "ex 111-222-3333";
         // 
         // newAddressNewCityBtn
         // 
         this.newAddressNewCityBtn.Location = new System.Drawing.Point(245, 163);
         this.newAddressNewCityBtn.Name = "newAddressNewCityBtn";
         this.newAddressNewCityBtn.Size = new System.Drawing.Size(75, 23);
         this.newAddressNewCityBtn.TabIndex = 12;
         this.newAddressNewCityBtn.Text = "New City";
         this.newAddressNewCityBtn.UseVisualStyleBackColor = true;
         this.newAddressNewCityBtn.Click += new System.EventHandler(this.newAddressNewCityBtn_Click);
         // 
         // newAddressCityNameLbl
         // 
         this.newAddressCityNameLbl.AutoSize = true;
         this.newAddressCityNameLbl.Location = new System.Drawing.Point(232, 130);
         this.newAddressCityNameLbl.Name = "newAddressCityNameLbl";
         this.newAddressCityNameLbl.Size = new System.Drawing.Size(27, 13);
         this.newAddressCityNameLbl.TabIndex = 10;
         this.newAddressCityNameLbl.Text = "City:";
         // 
         // newAddressPostalCodeTxtBx
         // 
         this.newAddressPostalCodeTxtBx.Location = new System.Drawing.Point(74, 149);
         this.newAddressPostalCodeTxtBx.Name = "newAddressPostalCodeTxtBx";
         this.newAddressPostalCodeTxtBx.Size = new System.Drawing.Size(64, 20);
         this.newAddressPostalCodeTxtBx.TabIndex = 9;
         // 
         // newAddressPostalCodeLbl
         // 
         this.newAddressPostalCodeLbl.AutoSize = true;
         this.newAddressPostalCodeLbl.Location = new System.Drawing.Point(6, 152);
         this.newAddressPostalCodeLbl.Name = "newAddressPostalCodeLbl";
         this.newAddressPostalCodeLbl.Size = new System.Drawing.Size(59, 13);
         this.newAddressPostalCodeLbl.TabIndex = 8;
         this.newAddressPostalCodeLbl.Text = "Post Code:";
         // 
         // newAddressPhoneTxtBx
         // 
         this.newAddressPhoneTxtBx.Location = new System.Drawing.Point(74, 93);
         this.newAddressPhoneTxtBx.Name = "newAddressPhoneTxtBx";
         this.newAddressPhoneTxtBx.Size = new System.Drawing.Size(85, 20);
         this.newAddressPhoneTxtBx.TabIndex = 7;
         // 
         // newAddressPhoneLbl
         // 
         this.newAddressPhoneLbl.AutoSize = true;
         this.newAddressPhoneLbl.Location = new System.Drawing.Point(6, 93);
         this.newAddressPhoneLbl.Name = "newAddressPhoneLbl";
         this.newAddressPhoneLbl.Size = new System.Drawing.Size(41, 13);
         this.newAddressPhoneLbl.TabIndex = 6;
         this.newAddressPhoneLbl.Text = "Phone:";
         // 
         // newAddressCityIDCmb
         // 
         this.newAddressCityIDCmb.FormattingEnabled = true;
         this.newAddressCityIDCmb.Location = new System.Drawing.Point(276, 97);
         this.newAddressCityIDCmb.Name = "newAddressCityIDCmb";
         this.newAddressCityIDCmb.Size = new System.Drawing.Size(44, 21);
         this.newAddressCityIDCmb.TabIndex = 5;
         this.newAddressCityIDCmb.SelectedIndexChanged += new System.EventHandler(this.newAddressCityIDCmb_SelectedIndexChanged);
         // 
         // newAddressCityIDLbl
         // 
         this.newAddressCityIDLbl.AutoSize = true;
         this.newAddressCityIDLbl.Location = new System.Drawing.Point(229, 100);
         this.newAddressCityIDLbl.Name = "newAddressCityIDLbl";
         this.newAddressCityIDLbl.Size = new System.Drawing.Size(41, 13);
         this.newAddressCityIDLbl.TabIndex = 4;
         this.newAddressCityIDLbl.Text = "City ID:";
         // 
         // newAddress2TxtBx
         // 
         this.newAddress2TxtBx.Location = new System.Drawing.Point(74, 58);
         this.newAddress2TxtBx.Name = "newAddress2TxtBx";
         this.newAddress2TxtBx.Size = new System.Drawing.Size(246, 20);
         this.newAddress2TxtBx.TabIndex = 3;
         // 
         // newAddressTxtBx
         // 
         this.newAddressTxtBx.Location = new System.Drawing.Point(74, 20);
         this.newAddressTxtBx.Name = "newAddressTxtBx";
         this.newAddressTxtBx.Size = new System.Drawing.Size(246, 20);
         this.newAddressTxtBx.TabIndex = 2;
         // 
         // newAddress2Lbl
         // 
         this.newAddress2Lbl.AutoSize = true;
         this.newAddress2Lbl.Location = new System.Drawing.Point(6, 58);
         this.newAddress2Lbl.Name = "newAddress2Lbl";
         this.newAddress2Lbl.Size = new System.Drawing.Size(54, 13);
         this.newAddress2Lbl.TabIndex = 1;
         this.newAddress2Lbl.Text = "Address2:";
         // 
         // newAddressLbl
         // 
         this.newAddressLbl.AutoSize = true;
         this.newAddressLbl.Location = new System.Drawing.Point(6, 23);
         this.newAddressLbl.Name = "newAddressLbl";
         this.newAddressLbl.Size = new System.Drawing.Size(48, 13);
         this.newAddressLbl.TabIndex = 0;
         this.newAddressLbl.Text = "Address:";
         // 
         // newAddressSaveBtn
         // 
         this.newAddressSaveBtn.Location = new System.Drawing.Point(12, 288);
         this.newAddressSaveBtn.Name = "newAddressSaveBtn";
         this.newAddressSaveBtn.Size = new System.Drawing.Size(75, 23);
         this.newAddressSaveBtn.TabIndex = 13;
         this.newAddressSaveBtn.Text = "Save";
         this.newAddressSaveBtn.UseVisualStyleBackColor = true;
         this.newAddressSaveBtn.Click += new System.EventHandler(this.newAddressSaveBtn_Click);
         // 
         // newAddressCancelBtn
         // 
         this.newAddressCancelBtn.Location = new System.Drawing.Point(283, 288);
         this.newAddressCancelBtn.Name = "newAddressCancelBtn";
         this.newAddressCancelBtn.Size = new System.Drawing.Size(75, 23);
         this.newAddressCancelBtn.TabIndex = 14;
         this.newAddressCancelBtn.Text = "Cancel";
         this.newAddressCancelBtn.UseVisualStyleBackColor = true;
         this.newAddressCancelBtn.Click += new System.EventHandler(this.newAddressCancelBtn_Click);
         // 
         // NewAddressForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(370, 323);
         this.Controls.Add(this.newAddressCancelBtn);
         this.Controls.Add(this.newAddressSaveBtn);
         this.Controls.Add(this.newAddressDetailsGrpBx);
         this.Controls.Add(this.newAddressIDTxtBx);
         this.Controls.Add(this.newAddressIDLbl);
         this.Name = "NewAddressForm";
         this.Text = "New Address";
         this.Load += new System.EventHandler(this.NewAddressForm_Load);
         this.newAddressDetailsGrpBx.ResumeLayout(false);
         this.newAddressDetailsGrpBx.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label newAddressIDLbl;
      private System.Windows.Forms.TextBox newAddressIDTxtBx;
      private System.Windows.Forms.GroupBox newAddressDetailsGrpBx;
      private System.Windows.Forms.TextBox newAddress2TxtBx;
      private System.Windows.Forms.TextBox newAddressTxtBx;
      private System.Windows.Forms.Label newAddress2Lbl;
      private System.Windows.Forms.Label newAddressLbl;
      private System.Windows.Forms.Label newAddressPhoneLbl;
      private System.Windows.Forms.ComboBox newAddressCityIDCmb;
      private System.Windows.Forms.Label newAddressCityIDLbl;
      private System.Windows.Forms.TextBox newAddressPhoneTxtBx;
      private System.Windows.Forms.Label newAddressCityNameLbl;
      private System.Windows.Forms.TextBox newAddressPostalCodeTxtBx;
      private System.Windows.Forms.Label newAddressPostalCodeLbl;
      private System.Windows.Forms.Button newAddressNewCityBtn;
      private System.Windows.Forms.Button newAddressSaveBtn;
      private System.Windows.Forms.Button newAddressCancelBtn;
      private System.Windows.Forms.Label newAddressPhoneExLbl;
      private System.Windows.Forms.Label label1;
   }
}