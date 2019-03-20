namespace Students
{
    partial class InputName
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
            this.Label_Enter_New_Name = new System.Windows.Forms.Label();
            this.TextBox_New_Name = new System.Windows.Forms.TextBox();
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label_Enter_New_Name
            // 
            this.Label_Enter_New_Name.AutoSize = true;
            this.Label_Enter_New_Name.Location = new System.Drawing.Point(28, 23);
            this.Label_Enter_New_Name.Name = "Label_Enter_New_Name";
            this.Label_Enter_New_Name.Size = new System.Drawing.Size(88, 13);
            this.Label_Enter_New_Name.TabIndex = 0;
            this.Label_Enter_New_Name.Text = "Enter New Name";
            // 
            // TextBox_New_Name
            // 
            this.TextBox_New_Name.Location = new System.Drawing.Point(31, 44);
            this.TextBox_New_Name.Name = "TextBox_New_Name";
            this.TextBox_New_Name.Size = new System.Drawing.Size(338, 20);
            this.TextBox_New_Name.TabIndex = 1;
            // 
            // Button_OK
            // 
            this.Button_OK.Location = new System.Drawing.Point(65, 79);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 23);
            this.Button_OK.TabIndex = 2;
            this.Button_OK.Text = "&OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Button_Cancel.Location = new System.Drawing.Point(254, 79);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Button_Cancel.TabIndex = 3;
            this.Button_Cancel.Text = "&Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // InputName
            // 
            this.AcceptButton = this.Button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Button_Cancel;
            this.ClientSize = new System.Drawing.Size(409, 116);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.TextBox_New_Name);
            this.Controls.Add(this.Label_Enter_New_Name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(425, 155);
            this.MinimumSize = new System.Drawing.Size(425, 155);
            this.Name = "InputName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter New Name of";
            this.Load += new System.EventHandler(this.InputName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Enter_New_Name;
        private System.Windows.Forms.TextBox TextBox_New_Name;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Cancel;
    }
}