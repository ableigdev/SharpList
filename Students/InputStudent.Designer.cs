namespace Students
{
    partial class InputStudent
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
            this.GroupBox_Current_Group = new System.Windows.Forms.GroupBox();
            this.ComboBox_Groups = new System.Windows.Forms.ComboBox();
            this.Label_Choose_Group_To_Add = new System.Windows.Forms.Label();
            this.GroupBox_Add_Student_Info = new System.Windows.Forms.GroupBox();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.Button_OK = new System.Windows.Forms.Button();
            this.Button_Next = new System.Windows.Forms.Button();
            this.TextBox_Average_Mark = new System.Windows.Forms.TextBox();
            this.TextBox_Birth_Year = new System.Windows.Forms.TextBox();
            this.TextBox_Lastname = new System.Windows.Forms.TextBox();
            this.TextBox_Name = new System.Windows.Forms.TextBox();
            this.TextBox_Surname = new System.Windows.Forms.TextBox();
            this.Label_Average_Mark = new System.Windows.Forms.Label();
            this.Label_Birth_Year = new System.Windows.Forms.Label();
            this.Label_Lastname = new System.Windows.Forms.Label();
            this.Label_Name = new System.Windows.Forms.Label();
            this.Label_Surname = new System.Windows.Forms.Label();
            this.GroupBox_Current_Group.SuspendLayout();
            this.GroupBox_Add_Student_Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox_Current_Group
            // 
            this.GroupBox_Current_Group.Controls.Add(this.ComboBox_Groups);
            this.GroupBox_Current_Group.Controls.Add(this.Label_Choose_Group_To_Add);
            this.GroupBox_Current_Group.Location = new System.Drawing.Point(12, 13);
            this.GroupBox_Current_Group.Name = "GroupBox_Current_Group";
            this.GroupBox_Current_Group.Size = new System.Drawing.Size(413, 51);
            this.GroupBox_Current_Group.TabIndex = 0;
            this.GroupBox_Current_Group.TabStop = false;
            this.GroupBox_Current_Group.Text = "Current Group";
            // 
            // ComboBox_Groups
            // 
            this.ComboBox_Groups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_Groups.FormattingEnabled = true;
            this.ComboBox_Groups.Location = new System.Drawing.Point(250, 19);
            this.ComboBox_Groups.Name = "ComboBox_Groups";
            this.ComboBox_Groups.Size = new System.Drawing.Size(157, 21);
            this.ComboBox_Groups.TabIndex = 1;
            // 
            // Label_Choose_Group_To_Add
            // 
            this.Label_Choose_Group_To_Add.AutoSize = true;
            this.Label_Choose_Group_To_Add.Location = new System.Drawing.Point(6, 22);
            this.Label_Choose_Group_To_Add.Name = "Label_Choose_Group_To_Add";
            this.Label_Choose_Group_To_Add.Size = new System.Drawing.Size(167, 13);
            this.Label_Choose_Group_To_Add.TabIndex = 0;
            this.Label_Choose_Group_To_Add.Text = "Choose Group to add the student:";
            // 
            // GroupBox_Add_Student_Info
            // 
            this.GroupBox_Add_Student_Info.Controls.Add(this.Button_Cancel);
            this.GroupBox_Add_Student_Info.Controls.Add(this.Button_OK);
            this.GroupBox_Add_Student_Info.Controls.Add(this.Button_Next);
            this.GroupBox_Add_Student_Info.Controls.Add(this.TextBox_Average_Mark);
            this.GroupBox_Add_Student_Info.Controls.Add(this.TextBox_Birth_Year);
            this.GroupBox_Add_Student_Info.Controls.Add(this.TextBox_Lastname);
            this.GroupBox_Add_Student_Info.Controls.Add(this.TextBox_Name);
            this.GroupBox_Add_Student_Info.Controls.Add(this.TextBox_Surname);
            this.GroupBox_Add_Student_Info.Controls.Add(this.Label_Average_Mark);
            this.GroupBox_Add_Student_Info.Controls.Add(this.Label_Birth_Year);
            this.GroupBox_Add_Student_Info.Controls.Add(this.Label_Lastname);
            this.GroupBox_Add_Student_Info.Controls.Add(this.Label_Name);
            this.GroupBox_Add_Student_Info.Controls.Add(this.Label_Surname);
            this.GroupBox_Add_Student_Info.Location = new System.Drawing.Point(12, 70);
            this.GroupBox_Add_Student_Info.Name = "GroupBox_Add_Student_Info";
            this.GroupBox_Add_Student_Info.Size = new System.Drawing.Size(413, 169);
            this.GroupBox_Add_Student_Info.TabIndex = 1;
            this.GroupBox_Add_Student_Info.TabStop = false;
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Location = new System.Drawing.Point(332, 133);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Button_Cancel.TabIndex = 13;
            this.Button_Cancel.Text = "&Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // Button_OK
            // 
            this.Button_OK.Location = new System.Drawing.Point(172, 133);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 23);
            this.Button_OK.TabIndex = 12;
            this.Button_OK.Text = "&OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // Button_Next
            // 
            this.Button_Next.Location = new System.Drawing.Point(9, 133);
            this.Button_Next.Name = "Button_Next";
            this.Button_Next.Size = new System.Drawing.Size(75, 23);
            this.Button_Next.TabIndex = 11;
            this.Button_Next.Text = "&Next";
            this.Button_Next.UseVisualStyleBackColor = true;
            this.Button_Next.Click += new System.EventHandler(this.Button_Next_Click);
            // 
            // TextBox_Average_Mark
            // 
            this.TextBox_Average_Mark.Location = new System.Drawing.Point(307, 97);
            this.TextBox_Average_Mark.Name = "TextBox_Average_Mark";
            this.TextBox_Average_Mark.Size = new System.Drawing.Size(100, 20);
            this.TextBox_Average_Mark.TabIndex = 10;
            this.TextBox_Average_Mark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_Average_Mark_KeyPress);
            // 
            // TextBox_Birth_Year
            // 
            this.TextBox_Birth_Year.Location = new System.Drawing.Point(110, 97);
            this.TextBox_Birth_Year.MaxLength = 4;
            this.TextBox_Birth_Year.Name = "TextBox_Birth_Year";
            this.TextBox_Birth_Year.Size = new System.Drawing.Size(100, 20);
            this.TextBox_Birth_Year.TabIndex = 8;
            this.TextBox_Birth_Year.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_Birth_Year_KeyPress);
            // 
            // TextBox_Lastname
            // 
            this.TextBox_Lastname.Location = new System.Drawing.Point(110, 71);
            this.TextBox_Lastname.Name = "TextBox_Lastname";
            this.TextBox_Lastname.Size = new System.Drawing.Size(297, 20);
            this.TextBox_Lastname.TabIndex = 6;
            // 
            // TextBox_Name
            // 
            this.TextBox_Name.Location = new System.Drawing.Point(110, 45);
            this.TextBox_Name.Name = "TextBox_Name";
            this.TextBox_Name.Size = new System.Drawing.Size(297, 20);
            this.TextBox_Name.TabIndex = 4;
            // 
            // TextBox_Surname
            // 
            this.TextBox_Surname.Location = new System.Drawing.Point(110, 19);
            this.TextBox_Surname.Name = "TextBox_Surname";
            this.TextBox_Surname.Size = new System.Drawing.Size(297, 20);
            this.TextBox_Surname.TabIndex = 2;
            // 
            // Label_Average_Mark
            // 
            this.Label_Average_Mark.AutoSize = true;
            this.Label_Average_Mark.Location = new System.Drawing.Point(224, 100);
            this.Label_Average_Mark.Name = "Label_Average_Mark";
            this.Label_Average_Mark.Size = new System.Drawing.Size(77, 13);
            this.Label_Average_Mark.TabIndex = 9;
            this.Label_Average_Mark.Text = "Average Mark:";
            // 
            // Label_Birth_Year
            // 
            this.Label_Birth_Year.AutoSize = true;
            this.Label_Birth_Year.Location = new System.Drawing.Point(6, 100);
            this.Label_Birth_Year.Name = "Label_Birth_Year";
            this.Label_Birth_Year.Size = new System.Drawing.Size(56, 13);
            this.Label_Birth_Year.TabIndex = 7;
            this.Label_Birth_Year.Text = "Birth Year:";
            // 
            // Label_Lastname
            // 
            this.Label_Lastname.AutoSize = true;
            this.Label_Lastname.Location = new System.Drawing.Point(6, 74);
            this.Label_Lastname.Name = "Label_Lastname";
            this.Label_Lastname.Size = new System.Drawing.Size(56, 13);
            this.Label_Lastname.TabIndex = 5;
            this.Label_Lastname.Text = "Lastname:";
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Location = new System.Drawing.Point(6, 48);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(38, 13);
            this.Label_Name.TabIndex = 3;
            this.Label_Name.Text = "Name:";
            // 
            // Label_Surname
            // 
            this.Label_Surname.AutoSize = true;
            this.Label_Surname.Location = new System.Drawing.Point(6, 22);
            this.Label_Surname.Name = "Label_Surname";
            this.Label_Surname.Size = new System.Drawing.Size(52, 13);
            this.Label_Surname.TabIndex = 0;
            this.Label_Surname.Text = "Surname:";
            // 
            // InputStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 249);
            this.Controls.Add(this.GroupBox_Add_Student_Info);
            this.Controls.Add(this.GroupBox_Current_Group);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(453, 288);
            this.MinimumSize = new System.Drawing.Size(453, 288);
            this.Name = "InputStudent";
            this.Text = "InputStudent";
            this.Load += new System.EventHandler(this.InputStudent_Load);
            this.GroupBox_Current_Group.ResumeLayout(false);
            this.GroupBox_Current_Group.PerformLayout();
            this.GroupBox_Add_Student_Info.ResumeLayout(false);
            this.GroupBox_Add_Student_Info.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBox_Current_Group;
        private System.Windows.Forms.ComboBox ComboBox_Groups;
        private System.Windows.Forms.Label Label_Choose_Group_To_Add;
        private System.Windows.Forms.GroupBox GroupBox_Add_Student_Info;
        private System.Windows.Forms.TextBox TextBox_Average_Mark;
        private System.Windows.Forms.TextBox TextBox_Birth_Year;
        private System.Windows.Forms.TextBox TextBox_Lastname;
        private System.Windows.Forms.TextBox TextBox_Name;
        private System.Windows.Forms.TextBox TextBox_Surname;
        private System.Windows.Forms.Label Label_Average_Mark;
        private System.Windows.Forms.Label Label_Birth_Year;
        private System.Windows.Forms.Label Label_Lastname;
        private System.Windows.Forms.Label Label_Name;
        private System.Windows.Forms.Label Label_Surname;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.Button Button_Next;
    }
}