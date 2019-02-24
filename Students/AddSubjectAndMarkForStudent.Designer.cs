namespace Students
{
    partial class AddSubjectAndMarkForStudent
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
            this.Label_Choose_Subject = new System.Windows.Forms.Label();
            this.TextBox_Find_Subject = new System.Windows.Forms.TextBox();
            this.Label_Choose_Mark = new System.Windows.Forms.Label();
            this.TextBox_Find_Mark = new System.Windows.Forms.TextBox();
            this.ListBox_List_Mark = new System.Windows.Forms.ListBox();
            this.Button_Add_Subject = new System.Windows.Forms.Button();
            this.Button_Save = new System.Windows.Forms.Button();
            this.ListBox_List_Subjects = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Label_Choose_Subject
            // 
            this.Label_Choose_Subject.AutoSize = true;
            this.Label_Choose_Subject.Location = new System.Drawing.Point(13, 13);
            this.Label_Choose_Subject.Name = "Label_Choose_Subject";
            this.Label_Choose_Subject.Size = new System.Drawing.Size(83, 13);
            this.Label_Choose_Subject.TabIndex = 0;
            this.Label_Choose_Subject.Text = "Choose subject:";
            // 
            // TextBox_Find_Subject
            // 
            this.TextBox_Find_Subject.Location = new System.Drawing.Point(13, 37);
            this.TextBox_Find_Subject.Name = "TextBox_Find_Subject";
            this.TextBox_Find_Subject.Size = new System.Drawing.Size(141, 20);
            this.TextBox_Find_Subject.TabIndex = 1;
            // 
            // Label_Choose_Mark
            // 
            this.Label_Choose_Mark.AutoSize = true;
            this.Label_Choose_Mark.Location = new System.Drawing.Point(165, 13);
            this.Label_Choose_Mark.Name = "Label_Choose_Mark";
            this.Label_Choose_Mark.Size = new System.Drawing.Size(72, 13);
            this.Label_Choose_Mark.TabIndex = 3;
            this.Label_Choose_Mark.Text = "Choose mark:";
            // 
            // TextBox_Find_Mark
            // 
            this.TextBox_Find_Mark.Location = new System.Drawing.Point(165, 37);
            this.TextBox_Find_Mark.Name = "TextBox_Find_Mark";
            this.TextBox_Find_Mark.Size = new System.Drawing.Size(107, 20);
            this.TextBox_Find_Mark.TabIndex = 4;
            // 
            // ListBox_List_Mark
            // 
            this.ListBox_List_Mark.FormattingEnabled = true;
            this.ListBox_List_Mark.Location = new System.Drawing.Point(165, 65);
            this.ListBox_List_Mark.Name = "ListBox_List_Mark";
            this.ListBox_List_Mark.Size = new System.Drawing.Size(107, 95);
            this.ListBox_List_Mark.TabIndex = 5;
            // 
            // Button_Add_Subject
            // 
            this.Button_Add_Subject.Location = new System.Drawing.Point(165, 175);
            this.Button_Add_Subject.Name = "Button_Add_Subject";
            this.Button_Add_Subject.Size = new System.Drawing.Size(107, 23);
            this.Button_Add_Subject.TabIndex = 6;
            this.Button_Add_Subject.Text = "&Add Subject";
            this.Button_Add_Subject.UseVisualStyleBackColor = true;
            // 
            // Button_Save
            // 
            this.Button_Save.Location = new System.Drawing.Point(165, 215);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(107, 23);
            this.Button_Save.TabIndex = 7;
            this.Button_Save.Text = "&Save";
            this.Button_Save.UseVisualStyleBackColor = true;
            // 
            // ListBox_List_Subjects
            // 
            this.ListBox_List_Subjects.FormattingEnabled = true;
            this.ListBox_List_Subjects.Location = new System.Drawing.Point(13, 65);
            this.ListBox_List_Subjects.Name = "ListBox_List_Subjects";
            this.ListBox_List_Subjects.Size = new System.Drawing.Size(141, 186);
            this.ListBox_List_Subjects.TabIndex = 2;
            // 
            // AddSubjectAndMarkForStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.ListBox_List_Subjects);
            this.Controls.Add(this.Button_Save);
            this.Controls.Add(this.Button_Add_Subject);
            this.Controls.Add(this.ListBox_List_Mark);
            this.Controls.Add(this.TextBox_Find_Mark);
            this.Controls.Add(this.Label_Choose_Mark);
            this.Controls.Add(this.TextBox_Find_Subject);
            this.Controls.Add(this.Label_Choose_Subject);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "AddSubjectAndMarkForStudent";
            this.Text = "Add Subject And Mark For Student";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Choose_Subject;
        private System.Windows.Forms.TextBox TextBox_Find_Subject;
        private System.Windows.Forms.Label Label_Choose_Mark;
        private System.Windows.Forms.TextBox TextBox_Find_Mark;
        private System.Windows.Forms.ListBox ListBox_List_Mark;
        private System.Windows.Forms.Button Button_Add_Subject;
        private System.Windows.Forms.Button Button_Save;
        private System.Windows.Forms.ListBox ListBox_List_Subjects;
    }
}