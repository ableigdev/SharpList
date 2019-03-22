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
    public partial class InputSubjectsAndMarks : Form
    {
        private List<string> m_Subjects;
        private List<float> m_Marks;
        private int m_MaxExtMarkList;
        private int m_MaxExtSubjectList;
        private int m_OldSubjectSelect;
        private int m_OldMarkSelect;

        public InputSubjectsAndMarks()
        {
            InitializeComponent();
            m_Subjects = new List<string>();
            m_Marks = new List<float>();
        }

        private void Button_Add_Mark_Click(object sender, EventArgs e)
        {
            float mark;
            if (System.Single.TryParse(TextBox_Input_Mark.Text, out mark))
            {
                if (mark <= 5.0 && mark >= 0.0)
                {
                    if (!m_Marks.findValue(mark))
                    {
                        m_Marks.pushInSortList(mark);
                        ListBox_All_Marks.Items.Add(mark);
                        CommonFunctions.correctHScrlAdd(ListBox_All_Marks, TextBox_Input_Mark.Text, ref m_MaxExtMarkList);
                    }
                    else
                    {
                        MessageBox.Show("The mark exists in the list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Value of marks must be from 0.0 to 5.0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mark field is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CommonFunctions.activeEdit(TextBox_Input_Mark);
        }

        private void Button_Add_Subject_Click(object sender, EventArgs e)
        {
            string str = TextBox_Input_Subject.Text;
            str.Trim();
            if (str.Length > 0)
            {
                if (!m_Subjects.findValue(str))
                {
                    m_Subjects.pushInSortList(str);
                    ListBox_All_Subjects.Items.Add(str);
                    CommonFunctions.correctHScrlAdd(ListBox_All_Subjects, str, ref m_MaxExtSubjectList);
                }
                else
                {
                    MessageBox.Show("The subject exists in the list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You can't input the empty string!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CommonFunctions.activeEdit(TextBox_Input_Subject);
        }

        private void InputSubjectsAndMarks_Load(object sender, EventArgs e)
        {
            Button_Delete_Subject.Enabled = false;
            Button_Delete_Mark.Enabled = false;
            ListBox_All_Marks.Items.Clear();
            ListBox_All_Subjects.Items.Clear();
            TextBox_Input_Mark.Text = "";
            TextBox_Input_Subject.Text = "";

            if (m_Subjects.isNotEmpty())
            {
                for (int i = 0; i < m_Subjects.size; ++i, ++m_Subjects)
                {
                    var str = m_Subjects.currentData;
                    ListBox_All_Subjects.Items.Add(str);
                    CommonFunctions.correctHScrlAdd(ListBox_All_Subjects, str, ref m_MaxExtSubjectList);
                }
                m_Subjects.setStart();
            }

            if (m_Marks.isNotEmpty())
            {
                for (int i = 0; i < m_Marks.size; ++i, ++m_Marks)
                {
                    var mark = m_Marks.currentData;
                    ListBox_All_Marks.Items.Add(mark);
                    CommonFunctions.correctHScrlAdd(ListBox_All_Marks, mark.ToString(), ref m_MaxExtMarkList);
                }
                m_Marks.setStart();
            }
        }

        public List<string> listOfTheSubjects
        {
            get
            {
                return m_Subjects;
            }
        }

        public List<float> listOfTheMarks
        {
            get
            {
                return m_Marks;
            }
        }

        private void ListBox_All_Subjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = ListBox_All_Subjects.SelectedIndex;
            if (selected != -1 && selected != m_OldSubjectSelect)
            {
                SecondCommon<string>.for_each_listbox(m_Subjects, ListBox_All_Subjects, ref m_OldSubjectSelect, ref selected);
            }
            Button_Delete_Subject.Enabled = true;
        }

        private void ListBox_All_Marks_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = ListBox_All_Marks.SelectedIndex;
            if (selected != -1 && selected != m_OldMarkSelect)
            {
                SecondCommon<float>.for_each_listbox(m_Marks, ListBox_All_Marks, ref m_OldMarkSelect, ref selected);
            }
            Button_Delete_Mark.Enabled = true; 
        }

        private void Button_Delete_Subject_Click(object sender, EventArgs e)
        {
            int selected = ListBox_All_Subjects.SelectedIndex;
            string str = ListBox_All_Subjects.Items[selected].ToString();
            m_Subjects.deleteElement(str);
            ListBox_All_Subjects.Items.RemoveAt(selected);
            CommonFunctions.corrctHScrlDel(ListBox_All_Subjects, str, ref m_MaxExtSubjectList);
            m_Subjects.setStart();
            Button_Delete_Subject.Enabled = false;
        }

        private void Button_Delete_Mark_Click(object sender, EventArgs e)
        {
            int selected = ListBox_All_Marks.SelectedIndex;
            float tempValue = m_Marks.currentData;
            m_Marks.deleteElement(tempValue);
            string str = ListBox_All_Marks.Items[selected].ToString();
            ListBox_All_Marks.Items.RemoveAt(selected);
            CommonFunctions.corrctHScrlDel(ListBox_All_Marks, str, ref m_MaxExtMarkList);
            m_Marks.setStart();
            Button_Delete_Mark.Enabled = false;
        }

        private void Button_Save_Subjects_Click(object sender, EventArgs e)
        {
            m_Subjects.setStart();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
