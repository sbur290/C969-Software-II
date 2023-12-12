namespace C969_Project_Assessment_Spencer_Burkett.Forms.Entry_Addition
{
   partial class NewCountryForm
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
         this.newCountryIDTxtBx = new System.Windows.Forms.TextBox();
         this.newCountryIDLbl = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.newCountryNameTxtBx = new System.Windows.Forms.TextBox();
         this.newCountrySaveBtn = new System.Windows.Forms.Button();
         this.newCountryCancelBtn = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // newCountryIDTxtBx
         // 
         this.newCountryIDTxtBx.Location = new System.Drawing.Point(38, 12);
         this.newCountryIDTxtBx.Name = "newCountryIDTxtBx";
         this.newCountryIDTxtBx.ReadOnly = true;
         this.newCountryIDTxtBx.Size = new System.Drawing.Size(44, 20);
         this.newCountryIDTxtBx.TabIndex = 5;
         // 
         // newCountryIDLbl
         // 
         this.newCountryIDLbl.AutoSize = true;
         this.newCountryIDLbl.Location = new System.Drawing.Point(11, 15);
         this.newCountryIDLbl.Name = "newCountryIDLbl";
         this.newCountryIDLbl.Size = new System.Drawing.Size(21, 13);
         this.newCountryIDLbl.TabIndex = 4;
         this.newCountryIDLbl.Text = "ID:";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 62);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(35, 13);
         this.label1.TabIndex = 6;
         this.label1.Text = "Name";
         // 
         // newCountryNameTxtBx
         // 
         this.newCountryNameTxtBx.Location = new System.Drawing.Point(65, 59);
         this.newCountryNameTxtBx.Name = "newCountryNameTxtBx";
         this.newCountryNameTxtBx.Size = new System.Drawing.Size(147, 20);
         this.newCountryNameTxtBx.TabIndex = 7;
         // 
         // newCountrySaveBtn
         // 
         this.newCountrySaveBtn.Location = new System.Drawing.Point(15, 145);
         this.newCountrySaveBtn.Name = "newCountrySaveBtn";
         this.newCountrySaveBtn.Size = new System.Drawing.Size(75, 23);
         this.newCountrySaveBtn.TabIndex = 8;
         this.newCountrySaveBtn.Text = "Save";
         this.newCountrySaveBtn.UseVisualStyleBackColor = true;
         this.newCountrySaveBtn.Click += new System.EventHandler(this.newCountrySaveBtn_Click);
         // 
         // newCountryCancelBtn
         // 
         this.newCountryCancelBtn.Location = new System.Drawing.Point(172, 145);
         this.newCountryCancelBtn.Name = "newCountryCancelBtn";
         this.newCountryCancelBtn.Size = new System.Drawing.Size(75, 23);
         this.newCountryCancelBtn.TabIndex = 9;
         this.newCountryCancelBtn.Text = "Cancel";
         this.newCountryCancelBtn.UseVisualStyleBackColor = true;
         this.newCountryCancelBtn.Click += new System.EventHandler(this.newCountryCancelBtn_Click);
         // 
         // NewCountryForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(259, 175);
         this.Controls.Add(this.newCountryCancelBtn);
         this.Controls.Add(this.newCountrySaveBtn);
         this.Controls.Add(this.newCountryNameTxtBx);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.newCountryIDTxtBx);
         this.Controls.Add(this.newCountryIDLbl);
         this.Name = "NewCountryForm";
         this.Text = "New Country";
         this.Load += new System.EventHandler(this.NewCountryForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox newCountryIDTxtBx;
      private System.Windows.Forms.Label newCountryIDLbl;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox newCountryNameTxtBx;
      private System.Windows.Forms.Button newCountrySaveBtn;
      private System.Windows.Forms.Button newCountryCancelBtn;
   }
}