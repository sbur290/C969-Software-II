namespace C969_Project_Assessment_Spencer_Burkett.Forms.Modify_Or_Delete
{
   partial class SelectAppointmentForm
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
         this.selectAppointmentIDLbl = new System.Windows.Forms.Label();
         this.selectAppointmentIDCmb = new System.Windows.Forms.ComboBox();
         this.selectAppointmentDetailsTxtBx = new System.Windows.Forms.RichTextBox();
         this.selectAppointmentDetailsLbl = new System.Windows.Forms.Label();
         this.selectAppointmentModifyBtn = new System.Windows.Forms.Button();
         this.selectAppointmentDeleteBtn = new System.Windows.Forms.Button();
         this.selectAppointmentCancelButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // selectAppointmentIDLbl
         // 
         this.selectAppointmentIDLbl.AutoSize = true;
         this.selectAppointmentIDLbl.Location = new System.Drawing.Point(22, 29);
         this.selectAppointmentIDLbl.Name = "selectAppointmentIDLbl";
         this.selectAppointmentIDLbl.Size = new System.Drawing.Size(21, 13);
         this.selectAppointmentIDLbl.TabIndex = 0;
         this.selectAppointmentIDLbl.Text = "ID:";
         // 
         // selectAppointmentIDCmb
         // 
         this.selectAppointmentIDCmb.FormattingEnabled = true;
         this.selectAppointmentIDCmb.Location = new System.Drawing.Point(75, 26);
         this.selectAppointmentIDCmb.Name = "selectAppointmentIDCmb";
         this.selectAppointmentIDCmb.Size = new System.Drawing.Size(121, 21);
         this.selectAppointmentIDCmb.TabIndex = 1;
         this.selectAppointmentIDCmb.SelectedIndexChanged += new System.EventHandler(this.selectAppointmentIDCmb_SelectedIndexChanged);
         // 
         // selectAppointmentDetailsTxtBx
         // 
         this.selectAppointmentDetailsTxtBx.Location = new System.Drawing.Point(12, 75);
         this.selectAppointmentDetailsTxtBx.Name = "selectAppointmentDetailsTxtBx";
         this.selectAppointmentDetailsTxtBx.Size = new System.Drawing.Size(223, 144);
         this.selectAppointmentDetailsTxtBx.TabIndex = 2;
         this.selectAppointmentDetailsTxtBx.Text = "";
         // 
         // selectAppointmentDetailsLbl
         // 
         this.selectAppointmentDetailsLbl.AutoSize = true;
         this.selectAppointmentDetailsLbl.Location = new System.Drawing.Point(22, 59);
         this.selectAppointmentDetailsLbl.Name = "selectAppointmentDetailsLbl";
         this.selectAppointmentDetailsLbl.Size = new System.Drawing.Size(39, 13);
         this.selectAppointmentDetailsLbl.TabIndex = 3;
         this.selectAppointmentDetailsLbl.Text = "Details";
         // 
         // selectAppointmentModifyBtn
         // 
         this.selectAppointmentModifyBtn.Location = new System.Drawing.Point(12, 247);
         this.selectAppointmentModifyBtn.Name = "selectAppointmentModifyBtn";
         this.selectAppointmentModifyBtn.Size = new System.Drawing.Size(71, 23);
         this.selectAppointmentModifyBtn.TabIndex = 4;
         this.selectAppointmentModifyBtn.Text = "Modify";
         this.selectAppointmentModifyBtn.UseVisualStyleBackColor = true;
         this.selectAppointmentModifyBtn.Click += new System.EventHandler(this.selectAppointmentsModifyBtn_Click);
         // 
         // selectAppointmentDeleteBtn
         // 
         this.selectAppointmentDeleteBtn.Location = new System.Drawing.Point(88, 247);
         this.selectAppointmentDeleteBtn.Name = "selectAppointmentDeleteBtn";
         this.selectAppointmentDeleteBtn.Size = new System.Drawing.Size(71, 23);
         this.selectAppointmentDeleteBtn.TabIndex = 5;
         this.selectAppointmentDeleteBtn.Text = "Delete";
         this.selectAppointmentDeleteBtn.UseVisualStyleBackColor = true;
         this.selectAppointmentDeleteBtn.Click += new System.EventHandler(this.selectAppointmentDeleteBtn_Click);
         // 
         // selectAppointmentCancelButton
         // 
         this.selectAppointmentCancelButton.Location = new System.Drawing.Point(164, 247);
         this.selectAppointmentCancelButton.Name = "selectAppointmentCancelButton";
         this.selectAppointmentCancelButton.Size = new System.Drawing.Size(71, 23);
         this.selectAppointmentCancelButton.TabIndex = 6;
         this.selectAppointmentCancelButton.Text = "Cancel";
         this.selectAppointmentCancelButton.UseVisualStyleBackColor = true;
         this.selectAppointmentCancelButton.Click += new System.EventHandler(this.selectAppointmentCancelButton_Click);
         // 
         // SelectAppointmentForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(247, 282);
         this.Controls.Add(this.selectAppointmentCancelButton);
         this.Controls.Add(this.selectAppointmentDeleteBtn);
         this.Controls.Add(this.selectAppointmentModifyBtn);
         this.Controls.Add(this.selectAppointmentDetailsLbl);
         this.Controls.Add(this.selectAppointmentDetailsTxtBx);
         this.Controls.Add(this.selectAppointmentIDCmb);
         this.Controls.Add(this.selectAppointmentIDLbl);
         this.Name = "SelectAppointmentForm";
         this.Text = "Select Appointment";
         this.Load += new System.EventHandler(this.SelectAppointmentForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label selectAppointmentIDLbl;
      private System.Windows.Forms.ComboBox selectAppointmentIDCmb;
      private System.Windows.Forms.RichTextBox selectAppointmentDetailsTxtBx;
      private System.Windows.Forms.Label selectAppointmentDetailsLbl;
      private System.Windows.Forms.Button selectAppointmentModifyBtn;
      private System.Windows.Forms.Button selectAppointmentDeleteBtn;
      private System.Windows.Forms.Button selectAppointmentCancelButton;
   }
}