namespace Students
{
    partial class SelectAction
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
            this.Button_Group = new System.Windows.Forms.Button();
            this.Button_Student = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Button_Group
            // 
            this.Button_Group.Location = new System.Drawing.Point(12, 12);
            this.Button_Group.Name = "Button_Group";
            this.Button_Group.Size = new System.Drawing.Size(75, 23);
            this.Button_Group.TabIndex = 0;
            this.Button_Group.Text = "&Group";
            this.Button_Group.UseVisualStyleBackColor = true;
            // 
            // Button_Student
            // 
            this.Button_Student.Location = new System.Drawing.Point(163, 12);
            this.Button_Student.Name = "Button_Student";
            this.Button_Student.Size = new System.Drawing.Size(75, 23);
            this.Button_Student.TabIndex = 1;
            this.Button_Student.Text = "&Student";
            this.Button_Student.UseVisualStyleBackColor = true;
            // 
            // SelectAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 52);
            this.Controls.Add(this.Button_Student);
            this.Controls.Add(this.Button_Group);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(266, 91);
            this.MinimumSize = new System.Drawing.Size(266, 91);
            this.Name = "SelectAction";
            this.Text = "Select Action";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_Group;
        private System.Windows.Forms.Button Button_Student;
    }
}