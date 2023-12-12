﻿
namespace C969 {
    partial class NewAddressForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
         this.lblAddressId = new System.Windows.Forms.Label();
         this.tboxAddressId = new System.Windows.Forms.TextBox();
         this.grpAddressDetails = new System.Windows.Forms.GroupBox();
         this.label1 = new System.Windows.Forms.Label();
         this.lblPhoneExample = new System.Windows.Forms.Label();
         this.btnAddNewCity = new System.Windows.Forms.Button();
         this.lblAddressCityName = new System.Windows.Forms.Label();
         this.cmbAddressCityId = new System.Windows.Forms.ComboBox();
         this.lblAddressCityId = new System.Windows.Forms.Label();
         this.tboxAddressPostalCode = new System.Windows.Forms.TextBox();
         this.lblAddressPostalCode = new System.Windows.Forms.Label();
         this.tboxAddressPhone = new System.Windows.Forms.TextBox();
         this.lblAddressPhone = new System.Windows.Forms.Label();
         this.tboxAddressAddress2 = new System.Windows.Forms.TextBox();
         this.lblAddressAddress2 = new System.Windows.Forms.Label();
         this.tboxAddressAddress1 = new System.Windows.Forms.TextBox();
         this.lblAddressAddress1 = new System.Windows.Forms.Label();
         this.btnSave = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.grpAddressDetails.SuspendLayout();
         this.SuspendLayout();
         // 
         // lblAddressId
         // 
         this.lblAddressId.AutoSize = true;
         this.lblAddressId.Location = new System.Drawing.Point(12, 25);
         this.lblAddressId.Name = "lblAddressId";
         this.lblAddressId.Size = new System.Drawing.Size(21, 13);
         this.lblAddressId.TabIndex = 0;
         this.lblAddressId.Text = "ID:";
         // 
         // tboxAddressId
         // 
         this.tboxAddressId.Location = new System.Drawing.Point(39, 22);
         this.tboxAddressId.Name = "tboxAddressId";
         this.tboxAddressId.ReadOnly = true;
         this.tboxAddressId.Size = new System.Drawing.Size(52, 20);
         this.tboxAddressId.TabIndex = 1;
         // 
         // grpAddressDetails
         // 
         this.grpAddressDetails.Controls.Add(this.label1);
         this.grpAddressDetails.Controls.Add(this.lblPhoneExample);
         this.grpAddressDetails.Controls.Add(this.btnAddNewCity);
         this.grpAddressDetails.Controls.Add(this.lblAddressCityName);
         this.grpAddressDetails.Controls.Add(this.cmbAddressCityId);
         this.grpAddressDetails.Controls.Add(this.lblAddressCityId);
         this.grpAddressDetails.Controls.Add(this.tboxAddressPostalCode);
         this.grpAddressDetails.Controls.Add(this.lblAddressPostalCode);
         this.grpAddressDetails.Controls.Add(this.tboxAddressPhone);
         this.grpAddressDetails.Controls.Add(this.lblAddressPhone);
         this.grpAddressDetails.Controls.Add(this.tboxAddressAddress2);
         this.grpAddressDetails.Controls.Add(this.lblAddressAddress2);
         this.grpAddressDetails.Controls.Add(this.tboxAddressAddress1);
         this.grpAddressDetails.Controls.Add(this.lblAddressAddress1);
         this.grpAddressDetails.Location = new System.Drawing.Point(15, 56);
         this.grpAddressDetails.Name = "grpAddressDetails";
         this.grpAddressDetails.Size = new System.Drawing.Size(332, 154);
         this.grpAddressDetails.TabIndex = 2;
         this.grpAddressDetails.TabStop = false;
         this.grpAddressDetails.Text = "Details (Bold are required)";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.Location = new System.Drawing.Point(246, 135);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(54, 13);
         this.label1.TabIndex = 13;
         this.label1.Text = "ex. 12345";
         // 
         // lblPhoneExample
         // 
         this.lblPhoneExample.AutoSize = true;
         this.lblPhoneExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblPhoneExample.Location = new System.Drawing.Point(63, 135);
         this.lblPhoneExample.Name = "lblPhoneExample";
         this.lblPhoneExample.Size = new System.Drawing.Size(90, 13);
         this.lblPhoneExample.TabIndex = 12;
         this.lblPhoneExample.Text = "ex. 111-222-3333";
         // 
         // btnAddNewCity
         // 
         this.btnAddNewCity.Location = new System.Drawing.Point(225, 81);
         this.btnAddNewCity.Name = "btnAddNewCity";
         this.btnAddNewCity.Size = new System.Drawing.Size(75, 23);
         this.btnAddNewCity.TabIndex = 11;
         this.btnAddNewCity.Text = "New City";
         this.btnAddNewCity.UseVisualStyleBackColor = true;
         // 
         // lblAddressCityName
         // 
         this.lblAddressCityName.AutoSize = true;
         this.lblAddressCityName.Location = new System.Drawing.Point(126, 84);
         this.lblAddressCityName.Name = "lblAddressCityName";
         this.lblAddressCityName.Size = new System.Drawing.Size(52, 13);
         this.lblAddressCityName.TabIndex = 10;
         this.lblAddressCityName.Text = "CityName";
         // 
         // cmbAddressCityId
         // 
         this.cmbAddressCityId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.cmbAddressCityId.FormattingEnabled = true;
         this.cmbAddressCityId.Location = new System.Drawing.Point(59, 81);
         this.cmbAddressCityId.Name = "cmbAddressCityId";
         this.cmbAddressCityId.Size = new System.Drawing.Size(61, 21);
         this.cmbAddressCityId.TabIndex = 9;
         // 
         // lblAddressCityId
         // 
         this.lblAddressCityId.AutoSize = true;
         this.lblAddressCityId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblAddressCityId.Location = new System.Drawing.Point(21, 84);
         this.lblAddressCityId.Name = "lblAddressCityId";
         this.lblAddressCityId.Size = new System.Drawing.Size(32, 13);
         this.lblAddressCityId.TabIndex = 8;
         this.lblAddressCityId.Text = "City:";
         // 
         // tboxAddressPostalCode
         // 
         this.tboxAddressPostalCode.Location = new System.Drawing.Point(230, 112);
         this.tboxAddressPostalCode.MaxLength = 5;
         this.tboxAddressPostalCode.Name = "tboxAddressPostalCode";
         this.tboxAddressPostalCode.Size = new System.Drawing.Size(69, 20);
         this.tboxAddressPostalCode.TabIndex = 7;
         // 
         // lblAddressPostalCode
         // 
         this.lblAddressPostalCode.AutoSize = true;
         this.lblAddressPostalCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblAddressPostalCode.Location = new System.Drawing.Point(159, 115);
         this.lblAddressPostalCode.Name = "lblAddressPostalCode";
         this.lblAddressPostalCode.Size = new System.Drawing.Size(65, 13);
         this.lblAddressPostalCode.TabIndex = 6;
         this.lblAddressPostalCode.Text = "PostCode:";
         // 
         // tboxAddressPhone
         // 
         this.tboxAddressPhone.Location = new System.Drawing.Point(73, 112);
         this.tboxAddressPhone.MaxLength = 12;
         this.tboxAddressPhone.Name = "tboxAddressPhone";
         this.tboxAddressPhone.Size = new System.Drawing.Size(80, 20);
         this.tboxAddressPhone.TabIndex = 5;
         // 
         // lblAddressPhone
         // 
         this.lblAddressPhone.AutoSize = true;
         this.lblAddressPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblAddressPhone.Location = new System.Drawing.Point(20, 115);
         this.lblAddressPhone.Name = "lblAddressPhone";
         this.lblAddressPhone.Size = new System.Drawing.Size(47, 13);
         this.lblAddressPhone.TabIndex = 4;
         this.lblAddressPhone.Text = "Phone:";
         // 
         // tboxAddressAddress2
         // 
         this.tboxAddressAddress2.Location = new System.Drawing.Point(118, 55);
         this.tboxAddressAddress2.Name = "tboxAddressAddress2";
         this.tboxAddressAddress2.Size = new System.Drawing.Size(182, 20);
         this.tboxAddressAddress2.TabIndex = 3;
         // 
         // lblAddressAddress2
         // 
         this.lblAddressAddress2.AutoSize = true;
         this.lblAddressAddress2.Location = new System.Drawing.Point(21, 58);
         this.lblAddressAddress2.Name = "lblAddressAddress2";
         this.lblAddressAddress2.Size = new System.Drawing.Size(91, 13);
         this.lblAddressAddress2.TabIndex = 2;
         this.lblAddressAddress2.Text = "Apt / Suite / Unit:";
         // 
         // tboxAddressAddress1
         // 
         this.tboxAddressAddress1.Location = new System.Drawing.Point(83, 29);
         this.tboxAddressAddress1.Name = "tboxAddressAddress1";
         this.tboxAddressAddress1.Size = new System.Drawing.Size(217, 20);
         this.tboxAddressAddress1.TabIndex = 1;
         // 
         // lblAddressAddress1
         // 
         this.lblAddressAddress1.AutoSize = true;
         this.lblAddressAddress1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.lblAddressAddress1.Location = new System.Drawing.Point(21, 32);
         this.lblAddressAddress1.Name = "lblAddressAddress1";
         this.lblAddressAddress1.Size = new System.Drawing.Size(56, 13);
         this.lblAddressAddress1.TabIndex = 0;
         this.lblAddressAddress1.Text = "Address:";
         // 
         // btnSave
         // 
         this.btnSave.Location = new System.Drawing.Point(15, 215);
         this.btnSave.Name = "btnSave";
         this.btnSave.Size = new System.Drawing.Size(75, 23);
         this.btnSave.TabIndex = 3;
         this.btnSave.Text = "Save";
         this.btnSave.UseVisualStyleBackColor = true;
         // 
         // btnCancel
         // 
         this.btnCancel.Location = new System.Drawing.Point(272, 215);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 4;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // NewAddressForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(363, 250);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnSave);
         this.Controls.Add(this.grpAddressDetails);
         this.Controls.Add(this.tboxAddressId);
         this.Controls.Add(this.lblAddressId);
         this.Name = "NewAddressForm";
         this.Text = "New Address";
         this.Load += new System.EventHandler(this.NewAddressForm_Load);
         this.grpAddressDetails.ResumeLayout(false);
         this.grpAddressDetails.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddressId;
        private System.Windows.Forms.TextBox tboxAddressId;
        private System.Windows.Forms.GroupBox grpAddressDetails;
        private System.Windows.Forms.Button btnAddNewCity;
        private System.Windows.Forms.Label lblAddressCityName;
        private System.Windows.Forms.ComboBox cmbAddressCityId;
        private System.Windows.Forms.Label lblAddressCityId;
        private System.Windows.Forms.TextBox tboxAddressPostalCode;
        private System.Windows.Forms.Label lblAddressPostalCode;
        private System.Windows.Forms.TextBox tboxAddressPhone;
        private System.Windows.Forms.Label lblAddressPhone;
        private System.Windows.Forms.TextBox tboxAddressAddress2;
        private System.Windows.Forms.Label lblAddressAddress2;
        private System.Windows.Forms.TextBox tboxAddressAddress1;
        private System.Windows.Forms.Label lblAddressAddress1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPhoneExample;
    }
}