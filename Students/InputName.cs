using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students
{
    public partial class InputName : Form
    {
        private string m_Name;
        private bool m_IsEdit = false;

        public InputName()
        {
            InitializeComponent();
        }

        public string nameOfTheList
        {
            set
            {
                if (value != null)
                {
                    this.TextBox_New_Name.Text = m_Name = value;
                }
            }
            get
            {
                return m_Name;
            }
        }

        public bool isEdit
        {
            set
            {
                m_IsEdit = value;
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            var str = this.TextBox_New_Name.Text.Trim();
            if (str.Length > 0)
            {
                m_Name = str;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("You must not enter empty strings!", "Error", MessageBoxButtons.OK);
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void InputName_Load(object sender, EventArgs e)
        {
            if (!m_IsEdit)
            {
                this.TextBox_New_Name.Text = "";
            }
        }

        private void TextBox_New_Name_Enter(object sender, EventArgs e)
        {
            CommonFunctions.activeEdit(TextBox_New_Name);
        }

        private void TextBox_New_Name_Click(object sender, EventArgs e)
        {
            CommonFunctions.activeEdit(TextBox_New_Name);
        }
    }
}
