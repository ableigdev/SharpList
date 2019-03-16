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
    public partial class InputStudent : Form
    {
        public InputStudent()
        {
            InitializeComponent();
            m_Student = new Student();
            m_WorkStudent = new Student();
        }

        public bool changeFlag
        {
            set
            {
                m_ChangeFlag = value;
            }
        }

        public int currentSelectedGroupIndex
        {
            set
            {
                m_CurrentGroupIndex = value;
            }
            get
            {
                return m_CurrentGroupIndex;
            }
        }

        public NameList<NameList<Student>> faculty
        {
            set
            {
                m_Faculty = value;
            }
        }

        public NameList<Student> group
        {
            set
            {
                m_Group = value;
            }
        }

        public Student student
        {
            set
            {
                m_Student = value;
            }
        }

        private void setActiveSurname()
        {
            // TODO: Just do it method!
            this.ActiveControl = TextBox_Surname;
            TextBox_Surname.SelectAll();
        }

        private bool checkConstruction()
        {
            return TextBox_Surname.Text.Length > 0 && TextBox_Name.Text.Length > 0;
        }

        private bool addStudent()
        {
            m_CurrentGroupIndex = ComboBox_Groups.SelectedIndex;

            if (checkConstruction())
            {
                // Add mode
                if (!m_ChangeFlag)
                {
                    m_Faculty.setStart();
                    // TODO: Correct the mistake
                    for (int i = 0; i < m_CurrentGroupIndex; ++i/*, ++m_Faculty*/);
                    m_Faculty.currentData.pushInSortList(m_Student);
                }
                return true;
            }
            MessageBox.Show("Surname or name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            this.ActiveControl = m_Student.surname.Length == 0 ? TextBox_Surname : TextBox_Name;
            m_IsModify = true;
            return false;
        }

        private void InputStudent_Load(object sender, EventArgs e)
        {
            // Add mode
            if (!m_ChangeFlag)
            {
                //m_Student = m_WorkStudent;
                m_IsModify = true;
                this.Text = "Input Student Information";
            }

            // Change mode
            if (m_ChangeFlag)
            {
                m_WorkStudent = m_Student;
                m_IsModify = false;
                Button_Next.Enabled = false;
                ComboBox_Groups.Enabled = false;
                this.Text = "Change Student Information";
            }

            setActiveSurname();

            if (!Object.ReferenceEquals(m_Faculty, null))
            {
                var currentGroup = m_Faculty.currentData;
                int counter = 0;
                foreach (var curElem in m_Faculty.chooseOrder(true))
                {
                    ComboBox_Groups.Items.Insert(counter++, curElem.nameList);
                }
                ComboBox_Groups.SelectedIndex = m_CurrentGroupIndex != -1 ? m_CurrentGroupIndex : 0;
                setBeginState(currentGroup);
            }
        }

        private void setBeginState(NameList<Student> group)
        {
            //while (!Object.ReferenceEquals(m_Faculty.currentData, group))
            {
                // TODO: Just Do it!
                //m_Faculty++;
            }
        }

        private bool readDataFromControls()
        {
            string surname = TextBox_Surname.Text.Trim();
            string name = TextBox_Name.Text.Trim();
            string lastname = TextBox_Lastname.Text.Trim();
            short year = (short)Int32.Parse(TextBox_Birth_Year.Text);
            float mark = float.Parse(TextBox_Average_Mark.Text, System.Globalization.CultureInfo.InvariantCulture);
            bool flag = false;
            if ((flag = year >= 1900 && year <= 2100) && (mark <= 5.0 && mark >= 0.0))
            {
                m_Student.surname = surname;
                m_Student.name = name;
                m_Student.lastname = lastname;
                m_Student.birthYear = year;
                m_Student.mark = mark;
                return true;
            }

            return flag ? showMessageHelper("Value of marks must be from 0.0 to 5.0") : showMessageHelper("Value of years must be from 1900 to 2100");
        }

        private bool showMessageHelper(string str)
        {
            MessageBox.Show(str, "Invalid value of numbers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private NameList<NameList<Student>> m_Faculty;
        private NameList<Student> m_Group;
        private Student m_Student = new Student();
        private Student m_WorkStudent;
        private bool m_ChangeFlag;
        private bool m_IsModify;
        private int m_CurrentGroupIndex;

        private void Button_Next_Click(object sender, EventArgs e)
        {
            if (readDataFromControls() && addStudent())
            {
                setActiveSurname();
            }
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            if (readDataFromControls() && addStudent())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            if (m_IsModify)
            {
                m_Student = m_WorkStudent;
            }
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TextBox_Birth_Year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TextBox_Average_Mark_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
