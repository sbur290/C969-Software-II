namespace C969_Project_Assessment_Spencer_Burkett.Forms
{
   partial class ReportsByTypeMonthly
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
         this.monthlyReportsTitleLbl = new System.Windows.Forms.Label();
         this.monthlyReportsTypeLbl = new System.Windows.Forms.Label();
         this.monthlyReportsMonthLbl = new System.Windows.Forms.Label();
         this.monthlyReportsGenerateBtn = new System.Windows.Forms.Button();
         this.monthlyReportsCancelBtn = new System.Windows.Forms.Button();
         this.monthlyReportsTypeCmb = new System.Windows.Forms.ComboBox();
         this.monthlyReportsMonthCmb = new System.Windows.Forms.ComboBox();
         this.SuspendLayout();
         // 
         // monthlyReportsTitleLbl
         // 
         this.monthlyReportsTitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.monthlyReportsTitleLbl.Location = new System.Drawing.Point(12, 9);
         this.monthlyReportsTitleLbl.Name = "monthlyReportsTitleLbl";
         this.monthlyReportsTitleLbl.Size = new System.Drawing.Size(324, 50);
         this.monthlyReportsTitleLbl.TabIndex = 0;
         this.monthlyReportsTitleLbl.Text = "To generate a report, please select Appointment Type and Month, then press Genera" +
    "te";
         this.monthlyReportsTitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // monthlyReportsTypeLbl
         // 
         this.monthlyReportsTypeLbl.AutoSize = true;
         this.monthlyReportsTypeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.monthlyReportsTypeLbl.Location = new System.Drawing.Point(12, 107);
         this.monthlyReportsTypeLbl.Name = "monthlyReportsTypeLbl";
         this.monthlyReportsTypeLbl.Size = new System.Drawing.Size(36, 15);
         this.monthlyReportsTypeLbl.TabIndex = 1;
         this.monthlyReportsTypeLbl.Text = "Type:";
         // 
         // monthlyReportsMonthLbl
         // 
         this.monthlyReportsMonthLbl.AutoSize = true;
         this.monthlyReportsMonthLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.monthlyReportsMonthLbl.Location = new System.Drawing.Point(12, 148);
         this.monthlyReportsMonthLbl.Name = "monthlyReportsMonthLbl";
         this.monthlyReportsMonthLbl.Size = new System.Drawing.Size(45, 15);
         this.monthlyReportsMonthLbl.TabIndex = 2;
         this.monthlyReportsMonthLbl.Text = "Month:";
         // 
         // monthlyReportsGenerateBtn
         // 
         this.monthlyReportsGenerateBtn.Location = new System.Drawing.Point(15, 204);
         this.monthlyReportsGenerateBtn.Name = "monthlyReportsGenerateBtn";
         this.monthlyReportsGenerateBtn.Size = new System.Drawing.Size(75, 23);
         this.monthlyReportsGenerateBtn.TabIndex = 3;
         this.monthlyReportsGenerateBtn.Text = "Generate";
         this.monthlyReportsGenerateBtn.UseVisualStyleBackColor = true;
         this.monthlyReportsGenerateBtn.Click += new System.EventHandler(this.monthlyReportsGenerateBtn_Click);
         // 
         // monthlyReportsCancelBtn
         // 
         this.monthlyReportsCancelBtn.Location = new System.Drawing.Point(261, 204);
         this.monthlyReportsCancelBtn.Name = "monthlyReportsCancelBtn";
         this.monthlyReportsCancelBtn.Size = new System.Drawing.Size(75, 23);
         this.monthlyReportsCancelBtn.TabIndex = 4;
         this.monthlyReportsCancelBtn.Text = "Cancel";
         this.monthlyReportsCancelBtn.UseVisualStyleBackColor = true;
         this.monthlyReportsCancelBtn.Click += new System.EventHandler(this.monthlyReportsCancelBtn_Click);
         // 
         // monthlyReportsTypeCmb
         // 
         this.monthlyReportsTypeCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.monthlyReportsTypeCmb.FormattingEnabled = true;
         this.monthlyReportsTypeCmb.Location = new System.Drawing.Point(65, 107);
         this.monthlyReportsTypeCmb.Name = "monthlyReportsTypeCmb";
         this.monthlyReportsTypeCmb.Size = new System.Drawing.Size(252, 21);
         this.monthlyReportsTypeCmb.TabIndex = 5;
         // 
         // monthlyReportsMonthCmb
         // 
         this.monthlyReportsMonthCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.monthlyReportsMonthCmb.FormattingEnabled = true;
         this.monthlyReportsMonthCmb.Location = new System.Drawing.Point(74, 147);
         this.monthlyReportsMonthCmb.Name = "monthlyReportsMonthCmb";
         this.monthlyReportsMonthCmb.Size = new System.Drawing.Size(243, 21);
         this.monthlyReportsMonthCmb.TabIndex = 6;
         // 
         // ReportsByTypeMonthly
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(348, 239);
         this.Controls.Add(this.monthlyReportsMonthCmb);
         this.Controls.Add(this.monthlyReportsTypeCmb);
         this.Controls.Add(this.monthlyReportsCancelBtn);
         this.Controls.Add(this.monthlyReportsGenerateBtn);
         this.Controls.Add(this.monthlyReportsMonthLbl);
         this.Controls.Add(this.monthlyReportsTypeLbl);
         this.Controls.Add(this.monthlyReportsTitleLbl);
         this.Name = "ReportsByTypeMonthly";
         this.Text = "Generate Report";
         this.Load += new System.EventHandler(this.ReportsByTypeMonthly_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label monthlyReportsTitleLbl;
      private System.Windows.Forms.Label monthlyReportsTypeLbl;
      private System.Windows.Forms.Label monthlyReportsMonthLbl;
      private System.Windows.Forms.Button monthlyReportsGenerateBtn;
      private System.Windows.Forms.Button monthlyReportsCancelBtn;
      private System.Windows.Forms.ComboBox monthlyReportsTypeCmb;
      private System.Windows.Forms.ComboBox monthlyReportsMonthCmb;
   }
}