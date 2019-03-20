namespace Students
{
    partial class ShowSubjectsAndMarks
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
            this.Label_Subjects = new System.Windows.Forms.Label();
            this.TextBox_Find_Subject_In_Show_Window = new System.Windows.Forms.TextBox();
            this.ListBox_Subjects_In_Show_Window = new System.Windows.Forms.ListBox();
            this.ListBox_Marks_In_Show_Window = new System.Windows.Forms.ListBox();
            this.Button_Exit_From_Show_Window = new System.Windows.Forms.Button();
            this.Button_Delete_Subjects_In_Show_Window = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label_Subjects
            // 
            this.Label_Subjects.AutoSize = true;
            this.Label_Subjects.Location = new System.Drawing.Point(13, 13);
            this.Label_Subjects.Name = "Label_Subjects";
            this.Label_Subjects.Size = new System.Drawing.Size(51, 13);
            this.Label_Subjects.TabIndex = 0;
            this.Label_Subjects.Text = "Subjects:";
            // 
            // TextBox_Find_Subject_In_Show_Window
            // 
            this.TextBox_Find_Subject_In_Show_Window.Location = new System.Drawing.Point(16, 29);
            this.TextBox_Find_Subject_In_Show_Window.Name = "TextBox_Find_Subject_In_Show_Window";
            this.TextBox_Find_Subject_In_Show_Window.Size = new System.Drawing.Size(283, 20);
            this.TextBox_Find_Subject_In_Show_Window.TabIndex = 1;
            // 
            // ListBox_Subjects_In_Show_Window
            // 
            this.ListBox_Subjects_In_Show_Window.FormattingEnabled = true;
            this.ListBox_Subjects_In_Show_Window.Location = new System.Drawing.Point(16, 55);
            this.ListBox_Subjects_In_Show_Window.Name = "ListBox_Subjects_In_Show_Window";
            this.ListBox_Subjects_In_Show_Window.Size = new System.Drawing.Size(193, 160);
            this.ListBox_Subjects_In_Show_Window.TabIndex = 2;
            // 
            // ListBox_Marks_In_Show_Window
            // 
            this.ListBox_Marks_In_Show_Window.FormattingEnabled = true;
            this.ListBox_Marks_In_Show_Window.Location = new System.Drawing.Point(215, 55);
            this.ListBox_Marks_In_Show_Window.Name = "ListBox_Marks_In_Show_Window";
            this.ListBox_Marks_In_Show_Window.Size = new System.Drawing.Size(84, 160);
            this.ListBox_Marks_In_Show_Window.TabIndex = 3;
            // 
            // Button_Exit_From_Show_Window
            // 
            this.Button_Exit_From_Show_Window.Location = new System.Drawing.Point(16, 226);
            this.Button_Exit_From_Show_Window.Name = "Button_Exit_From_Show_Window";
            this.Button_Exit_From_Show_Window.Size = new System.Drawing.Size(131, 23);
            this.Button_Exit_From_Show_Window.TabIndex = 4;
            this.Button_Exit_From_Show_Window.Text = "&Exit";
            this.Button_Exit_From_Show_Window.UseVisualStyleBackColor = true;
            // 
            // Button_Delete_Subjects_In_Show_Window
            // 
            this.Button_Delete_Subjects_In_Show_Window.Location = new System.Drawing.Point(167, 226);
            this.Button_Delete_Subjects_In_Show_Window.Name = "Button_Delete_Subjects_In_Show_Window";
            this.Button_Delete_Subjects_In_Show_Window.Size = new System.Drawing.Size(131, 23);
            this.Button_Delete_Subjects_In_Show_Window.TabIndex = 5;
            this.Button_Delete_Subjects_In_Show_Window.Text = "&Delete";
            this.Button_Delete_Subjects_In_Show_Window.UseVisualStyleBackColor = true;
            // 
            // ShowSubjectsAndMarks
            // 
            this.AcceptButton = this.Button_Delete_Subjects_In_Show_Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 261);
            this.Controls.Add(this.Button_Delete_Subjects_In_Show_Window);
            this.Controls.Add(this.Button_Exit_From_Show_Window);
            this.Controls.Add(this.ListBox_Marks_In_Show_Window);
            this.Controls.Add(this.ListBox_Subjects_In_Show_Window);
            this.Controls.Add(this.TextBox_Find_Subject_In_Show_Window);
            this.Controls.Add(this.Label_Subjects);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(327, 300);
            this.MinimumSize = new System.Drawing.Size(327, 300);
            this.Name = "ShowSubjectsAndMarks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show Subjects And Marks";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Subjects;
        private System.Windows.Forms.TextBox TextBox_Find_Subject_In_Show_Window;
        private System.Windows.Forms.ListBox ListBox_Subjects_In_Show_Window;
        private System.Windows.Forms.ListBox ListBox_Marks_In_Show_Window;
        private System.Windows.Forms.Button Button_Exit_From_Show_Window;
        private System.Windows.Forms.Button Button_Delete_Subjects_In_Show_Window;
    }
}