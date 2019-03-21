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
        private NameList<NameList<Student>> m_Faculty;
        private NameList<Student> m_Group;
        private Student m_Student = new Student();
        private Student m_WorkStudent;
        private bool m_ChangeFlag;
        private bool m_IsModify;
        private int m_CurrentGroupIndex;

        public InputStudent()
        {
            InitializeComponent();
            //m_Student = new Student();
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
            get
            {
                return m_Student;
            }
        }

        private void setActiveSurname()
        {
            activeEdit(TextBox_Surname);
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
                    for (int i = 0; i < m_CurrentGroupIndex; ++i, ++m_Faculty);
                    m_Faculty.currentData.pushInSortList(m_Student);
                }
                return true;
            }
            m_IsModify = true;
            return false;
        }

        private void InputStudent_Load(object sender, EventArgs e)
        {
            ComboBox_Groups.Items.Clear();
            Button_Next.Enabled = !m_ChangeFlag;
            ComboBox_Groups.Enabled = !m_ChangeFlag;
            // Add mode
            if (!m_ChangeFlag)
            {
                m_Student = (Student)m_WorkStudent.Clone();
                m_IsModify = true;
                this.Text = "Input Student Information";
            }

            // Change mode
            if (m_ChangeFlag)
            {
                TextBox_Surname.Text = m_Student.surname;
                TextBox_Name.Text = m_Student.name;
                TextBox_Lastname.Text = m_Student.lastname;
                TextBox_Birth_Year.Text = m_Student.birthYear.ToString();
                TextBox_Average_Mark.Text = m_Student.mark.ToString();
                m_WorkStudent = m_Student;
                m_IsModify = false;
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
            }
        }

        private bool readDataFromControls()
        {
            string surname = TextBox_Surname.Text.Trim();
            string name = TextBox_Name.Text.Trim();
            string lastname = TextBox_Lastname.Text.Trim();

            if (surname.Length > 0 && name.Length > 0)
            {
                m_Student = new Student();
                m_Student.surname = surname;
                m_Student.name = name;
                m_Student.lastname = lastname;

                ushort year;
                if (System.UInt16.TryParse(TextBox_Birth_Year.Text, out year))
                {
                    if (year >= 1900 && year <= 2100)
                    {
                        m_Student.birthYear = (short)year;
                    }
                    else
                    {
                        return showMessageHelper("Value of years must be from 1900 to 2100");
                    }
                }
                else
                {
                    return showMessageHelper("Birth Year field is empty!");
                }

                float mark;
                if (System.Single.TryParse(TextBox_Average_Mark.Text, out mark))
                {
                    if (mark <= 5.0 && mark >= 0.0)
                    {
                        m_Student.mark = mark;
                    }
                    else
                    {
                        return showMessageHelper("Value of marks must be from 0.0 to 5.0");
                    }
                }
                else
                {
                    return showMessageHelper("Mark field is empty!");
                }
                return true;
            }
            MessageBox.Show("Surname or name is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            this.ActiveControl = surname.Length == 0 ? TextBox_Surname : TextBox_Name;
            return false;
        }

        private bool showMessageHelper(string str)
        {
            MessageBox.Show(str, "Invalid value of numbers", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

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

        private void activeEdit(TextBoxBase edit)
        {
            edit.Focus();
            edit.SelectAll();
        }

        private void TextBox_Surname_Enter(object sender, EventArgs e)
        {
            activeEdit(TextBox_Surname);
        }

        private void TextBox_Surname_Click(object sender, EventArgs e)
        {
            activeEdit(TextBox_Surname);
        }

        private void TextBox_Name_Click(object sender, EventArgs e)
        {
            activeEdit(TextBox_Name);
        }

        private void TextBox_Name_Enter(object sender, EventArgs e)
        {
            activeEdit(TextBox_Name);
        }

        private void TextBox_Lastname_Enter(object sender, EventArgs e)
        {
            activeEdit(TextBox_Lastname);
        }

        private void TextBox_Lastname_Click(object sender, EventArgs e)
        {
            activeEdit(TextBox_Lastname);
        }

        private void TextBox_Birth_Year_Enter(object sender, EventArgs e)
        {
            activeEdit(TextBox_Birth_Year);
        }

        private void TextBox_Birth_Year_Click(object sender, EventArgs e)
        {
            activeEdit(TextBox_Birth_Year);
        }

        private void TextBox_Average_Mark_Enter(object sender, EventArgs e)
        {
            activeEdit(TextBox_Average_Mark);
        }

        private void TextBox_Average_Mark_Click(object sender, EventArgs e)
        {
            activeEdit(TextBox_Average_Mark);
        }
    }
}
