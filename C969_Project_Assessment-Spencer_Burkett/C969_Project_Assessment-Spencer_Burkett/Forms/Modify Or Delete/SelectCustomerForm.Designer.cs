namespace C969_Project_Assessment_Spencer_Burkett.Forms.Modify_Or_Delete
{
   partial class SelectCustomerForm
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
         this.selectCustomerCancelButton = new System.Windows.Forms.Button();
         this.selectCustomerDeleteBtn = new System.Windows.Forms.Button();
         this.selectCustomerModifyBtn = new System.Windows.Forms.Button();
         this.selectCustomerDetailsLbl = new System.Windows.Forms.Label();
         this.selectCustomerDetailsTxtBx = new System.Windows.Forms.RichTextBox();
         this.selectCustomerIDCmb = new System.Windows.Forms.ComboBox();
         this.selectCustomerIDLbl = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // selectCustomerCancelButton
         // 
         this.selectCustomerCancelButton.Location = new System.Drawing.Point(164, 248);
         this.selectCustomerCancelButton.Name = "selectCustomerCancelButton";
         this.selectCustomerCancelButton.Size = new System.Drawing.Size(71, 23);
         this.selectCustomerCancelButton.TabIndex = 13;
         this.selectCustomerCancelButton.Text = "Cancel";
         this.selectCustomerCancelButton.UseVisualStyleBackColor = true;
         this.selectCustomerCancelButton.Click += new System.EventHandler(this.selectCustomerCancelButton_Click);
         // 
         // selectCustomerDeleteBtn
         // 
         this.selectCustomerDeleteBtn.Location = new System.Drawing.Point(88, 248);
         this.selectCustomerDeleteBtn.Name = "selectCustomerDeleteBtn";
         this.selectCustomerDeleteBtn.Size = new System.Drawing.Size(71, 23);
         this.selectCustomerDeleteBtn.TabIndex = 12;
         this.selectCustomerDeleteBtn.Text = "Delete";
         this.selectCustomerDeleteBtn.UseVisualStyleBackColor = true;
         this.selectCustomerDeleteBtn.Click += new System.EventHandler(this.selectCustomerDeleteBtn_Click);
         // 
         // selectCustomerModifyBtn
         // 
         this.selectCustomerModifyBtn.Location = new System.Drawing.Point(12, 248);
         this.selectCustomerModifyBtn.Name = "selectCustomerModifyBtn";
         this.selectCustomerModifyBtn.Size = new System.Drawing.Size(71, 23);
         this.selectCustomerModifyBtn.TabIndex = 11;
         this.selectCustomerModifyBtn.Text = "Modify";
         this.selectCustomerModifyBtn.UseVisualStyleBackColor = true;
         this.selectCustomerModifyBtn.Click += new System.EventHandler(this.selectCustomerModifyBtn_Click);
         // 
         // selectCustomerDetailsLbl
         // 
         this.selectCustomerDetailsLbl.AutoSize = true;
         this.selectCustomerDetailsLbl.Location = new System.Drawing.Point(22, 60);
         this.selectCustomerDetailsLbl.Name = "selectCustomerDetailsLbl";
         this.selectCustomerDetailsLbl.Size = new System.Drawing.Size(39, 13);
         this.selectCustomerDetailsLbl.TabIndex = 10;
         this.selectCustomerDetailsLbl.Text = "Details";
         // 
         // selectCustomerDetailsTxtBx
         // 
         this.selectCustomerDetailsTxtBx.Location = new System.Drawing.Point(12, 76);
         this.selectCustomerDetailsTxtBx.Name = "selectCustomerDetailsTxtBx";
         this.selectCustomerDetailsTxtBx.Size = new System.Drawing.Size(223, 144);
         this.selectCustomerDetailsTxtBx.TabIndex = 9;
         this.selectCustomerDetailsTxtBx.Text = "";
         // 
         // selectCustomerIDCmb
         // 
         this.selectCustomerIDCmb.FormattingEnabled = true;
         this.selectCustomerIDCmb.Location = new System.Drawing.Point(75, 27);
         this.selectCustomerIDCmb.Name = "selectCustomerIDCmb";
         this.selectCustomerIDCmb.Size = new System.Drawing.Size(121, 21);
         this.selectCustomerIDCmb.TabIndex = 8;
         this.selectCustomerIDCmb.SelectedIndexChanged += new System.EventHandler(this.selectCustomerIDCmb_SelectedIndexChanged);
         // 
         // selectCustomerIDLbl
         // 
         this.selectCustomerIDLbl.AutoSize = true;
         this.selectCustomerIDLbl.Location = new System.Drawing.Point(22, 30);
         this.selectCustomerIDLbl.Name = "selectCustomerIDLbl";
         this.selectCustomerIDLbl.Size = new System.Drawing.Size(21, 13);
         this.selectCustomerIDLbl.TabIndex = 7;
         this.selectCustomerIDLbl.Text = "ID:";
         // 
         // SelectCustomerForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(247, 282);
         this.Controls.Add(this.selectCustomerCancelButton);
         this.Controls.Add(this.selectCustomerDeleteBtn);
         this.Controls.Add(this.selectCustomerModifyBtn);
         this.Controls.Add(this.selectCustomerDetailsLbl);
         this.Controls.Add(this.selectCustomerDetailsTxtBx);
         this.Controls.Add(this.selectCustomerIDCmb);
         this.Controls.Add(this.selectCustomerIDLbl);
         this.Name = "SelectCustomerForm";
         this.Text = "Select Customer";
         this.Load += new System.EventHandler(this.SelectCustomerForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button selectCustomerCancelButton;
      private System.Windows.Forms.Button selectCustomerDeleteBtn;
      private System.Windows.Forms.Button selectCustomerModifyBtn;
      private System.Windows.Forms.Label selectCustomerDetailsLbl;
      private System.Windows.Forms.RichTextBox selectCustomerDetailsTxtBx;
      private System.Windows.Forms.ComboBox selectCustomerIDCmb;
      private System.Windows.Forms.Label selectCustomerIDLbl;
   }
}