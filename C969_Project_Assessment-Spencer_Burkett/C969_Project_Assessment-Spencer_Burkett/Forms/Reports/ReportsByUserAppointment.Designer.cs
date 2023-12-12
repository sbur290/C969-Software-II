namespace C969_Project_Assessment_Spencer_Burkett.Forms.Reports
{
   partial class ReportsByUserAppointment
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
         this.appointmentReportsUserIDTxtBx = new System.Windows.Forms.TextBox();
         this.customerReportsCancelBtn = new System.Windows.Forms.Button();
         this.appointmentReportsGenerateBtn = new System.Windows.Forms.Button();
         this.appointmentReportsUserIDLbl = new System.Windows.Forms.Label();
         this.appointmentReportsTitleLbl = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // appointmentReportsUserIDTxtBx
         // 
         this.appointmentReportsUserIDTxtBx.Location = new System.Drawing.Point(101, 100);
         this.appointmentReportsUserIDTxtBx.Name = "appointmentReportsUserIDTxtBx";
         this.appointmentReportsUserIDTxtBx.Size = new System.Drawing.Size(225, 20);
         this.appointmentReportsUserIDTxtBx.TabIndex = 17;
         // 
         // customerReportsCancelBtn
         // 
         this.customerReportsCancelBtn.Location = new System.Drawing.Point(261, 205);
         this.customerReportsCancelBtn.Name = "customerReportsCancelBtn";
         this.customerReportsCancelBtn.Size = new System.Drawing.Size(75, 23);
         this.customerReportsCancelBtn.TabIndex = 16;
         this.customerReportsCancelBtn.Text = "Cancel";
         this.customerReportsCancelBtn.UseVisualStyleBackColor = true;
         this.customerReportsCancelBtn.Click += new System.EventHandler(this.customerReportsCancelBtn_Click);
         // 
         // appointmentReportsGenerateBtn
         // 
         this.appointmentReportsGenerateBtn.Location = new System.Drawing.Point(15, 205);
         this.appointmentReportsGenerateBtn.Name = "appointmentReportsGenerateBtn";
         this.appointmentReportsGenerateBtn.Size = new System.Drawing.Size(75, 23);
         this.appointmentReportsGenerateBtn.TabIndex = 15;
         this.appointmentReportsGenerateBtn.Text = "Generate";
         this.appointmentReportsGenerateBtn.UseVisualStyleBackColor = true;
         this.appointmentReportsGenerateBtn.Click += new System.EventHandler(this.appointmentReportsGenerateBtn_Click);
         // 
         // appointmentReportsUserIDLbl
         // 
         this.appointmentReportsUserIDLbl.AutoSize = true;
         this.appointmentReportsUserIDLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.appointmentReportsUserIDLbl.Location = new System.Drawing.Point(12, 101);
         this.appointmentReportsUserIDLbl.Name = "appointmentReportsUserIDLbl";
         this.appointmentReportsUserIDLbl.Size = new System.Drawing.Size(51, 15);
         this.appointmentReportsUserIDLbl.TabIndex = 14;
         this.appointmentReportsUserIDLbl.Text = "User ID:";
         // 
         // appointmentReportsTitleLbl
         // 
         this.appointmentReportsTitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.appointmentReportsTitleLbl.Location = new System.Drawing.Point(12, 10);
         this.appointmentReportsTitleLbl.Name = "appointmentReportsTitleLbl";
         this.appointmentReportsTitleLbl.Size = new System.Drawing.Size(324, 50);
         this.appointmentReportsTitleLbl.TabIndex = 13;
         this.appointmentReportsTitleLbl.Text = "To generate a report, please type User ID, then press Generate ";
         this.appointmentReportsTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // ReportsByUserAppointment
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(348, 239);
         this.Controls.Add(this.appointmentReportsUserIDTxtBx);
         this.Controls.Add(this.customerReportsCancelBtn);
         this.Controls.Add(this.appointmentReportsGenerateBtn);
         this.Controls.Add(this.appointmentReportsUserIDLbl);
         this.Controls.Add(this.appointmentReportsTitleLbl);
         this.Name = "ReportsByUserAppointment";
         this.Text = "ReportsByCustomerAppointment";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox appointmentReportsUserIDTxtBx;
      private System.Windows.Forms.Button customerReportsCancelBtn;
      private System.Windows.Forms.Button appointmentReportsGenerateBtn;
      private System.Windows.Forms.Label appointmentReportsUserIDLbl;
      private System.Windows.Forms.Label appointmentReportsTitleLbl;
   }
}