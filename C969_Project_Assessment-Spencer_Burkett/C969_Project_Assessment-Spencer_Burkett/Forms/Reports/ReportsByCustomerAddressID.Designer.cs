namespace C969_Project_Assessment_Spencer_Burkett.Forms.Reports
{
   partial class ReportsByCustomerAddressID
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
         this.customerReportsCancelBtn = new System.Windows.Forms.Button();
         this.customerReportsGenerateBtn = new System.Windows.Forms.Button();
         this.customerReportsAddressIDLbl = new System.Windows.Forms.Label();
         this.customerReportsTitleLbl = new System.Windows.Forms.Label();
         this.customerReportsAddressIDTxtBx = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // customerReportsCancelBtn
         // 
         this.customerReportsCancelBtn.Location = new System.Drawing.Point(261, 205);
         this.customerReportsCancelBtn.Name = "customerReportsCancelBtn";
         this.customerReportsCancelBtn.Size = new System.Drawing.Size(75, 23);
         this.customerReportsCancelBtn.TabIndex = 11;
         this.customerReportsCancelBtn.Text = "Cancel";
         this.customerReportsCancelBtn.UseVisualStyleBackColor = true;
         this.customerReportsCancelBtn.Click += new System.EventHandler(this.customerReportsCancelBtn_Click);
         // 
         // customerReportsGenerateBtn
         // 
         this.customerReportsGenerateBtn.Location = new System.Drawing.Point(15, 205);
         this.customerReportsGenerateBtn.Name = "customerReportsGenerateBtn";
         this.customerReportsGenerateBtn.Size = new System.Drawing.Size(75, 23);
         this.customerReportsGenerateBtn.TabIndex = 10;
         this.customerReportsGenerateBtn.Text = "Generate";
         this.customerReportsGenerateBtn.UseVisualStyleBackColor = true;
         this.customerReportsGenerateBtn.Click += new System.EventHandler(this.customerReportsGenerateBtn_Click);
         // 
         // customerReportsAddressIDLbl
         // 
         this.customerReportsAddressIDLbl.AutoSize = true;
         this.customerReportsAddressIDLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.customerReportsAddressIDLbl.Location = new System.Drawing.Point(12, 101);
         this.customerReportsAddressIDLbl.Name = "customerReportsAddressIDLbl";
         this.customerReportsAddressIDLbl.Size = new System.Drawing.Size(69, 15);
         this.customerReportsAddressIDLbl.TabIndex = 9;
         this.customerReportsAddressIDLbl.Text = "Address ID:";
         // 
         // customerReportsTitleLbl
         // 
         this.customerReportsTitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.customerReportsTitleLbl.Location = new System.Drawing.Point(12, 10);
         this.customerReportsTitleLbl.Name = "customerReportsTitleLbl";
         this.customerReportsTitleLbl.Size = new System.Drawing.Size(324, 50);
         this.customerReportsTitleLbl.TabIndex = 7;
         this.customerReportsTitleLbl.Text = "To generate a report, please type\r\n Address ID, then press Generate";
         this.customerReportsTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // customerReportsAddressIDTxtBx
         // 
         this.customerReportsAddressIDTxtBx.Location = new System.Drawing.Point(101, 100);
         this.customerReportsAddressIDTxtBx.Name = "customerReportsAddressIDTxtBx";
         this.customerReportsAddressIDTxtBx.Size = new System.Drawing.Size(225, 20);
         this.customerReportsAddressIDTxtBx.TabIndex = 12;
         // 
         // ReportsByCustomerAddressID
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(348, 239);
         this.Controls.Add(this.customerReportsAddressIDTxtBx);
         this.Controls.Add(this.customerReportsCancelBtn);
         this.Controls.Add(this.customerReportsGenerateBtn);
         this.Controls.Add(this.customerReportsAddressIDLbl);
         this.Controls.Add(this.customerReportsTitleLbl);
         this.Name = "ReportsByCustomerAddressID";
         this.Text = "Customers by Address";
         this.Load += new System.EventHandler(this.ReportsByCustomerAddressID_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Button customerReportsCancelBtn;
      private System.Windows.Forms.Button customerReportsGenerateBtn;
      private System.Windows.Forms.Label customerReportsAddressIDLbl;
      private System.Windows.Forms.Label customerReportsTitleLbl;
      private System.Windows.Forms.TextBox customerReportsAddressIDTxtBx;
   }
}