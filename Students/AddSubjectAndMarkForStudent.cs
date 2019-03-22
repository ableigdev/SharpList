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
    public partial class AddSubjectAndMarkForStudent : Form
    {
        private List<string> m_Subjects;
        private List<float> m_Marks;
        private Student m_Student;
        private int m_OldSubjectSelect;
        private int m_OldMarkSelect;
        private int m_MaxExtMark;
        private int m_MaxExtSubject;

        public AddSubjectAndMarkForStudent()
        {
            InitializeComponent();
        }

        private void AddSubjectAndMarkForStudent_Load(object sender, EventArgs e)
        {
            this.Text = "Add Subject And Mark For The " + CommonFunctions.getStudentString(m_Student);
            ListBox_List_Mark.Items.Clear();
            ListBox_List_Subjects.Items.Clear();

            if (m_Subjects.isNotEmpty() && m_Marks.isNotEmpty())
            {
                for (int i = 0; i < m_Subjects.size; ++i, ++m_Subjects)
                {
                    string str = m_Subjects.currentData;
                    ListBox_List_Subjects.Items.Add(str);
                    CommonFunctions.correctHScrlAdd(ListBox_List_Subjects, str, ref m_MaxExtSubject);
                }
                for (int i = 0; i < m_Marks.size; ++i, ++m_Marks)
                {
                    string tempMark = m_Marks.currentData.ToString();
                    ListBox_List_Mark.Items.Add(tempMark);
                    CommonFunctions.correctHScrlAdd(ListBox_List_Mark, tempMark, ref m_MaxExtMark);
                }
            }
            m_OldMarkSelect = -1;
            m_OldSubjectSelect = -1;
        }

        public List<string> subjects
        {
            set
            {
                m_Subjects = value;
            }
            get
            {
                return m_Subjects;
            }
        }

        public List<float> marks
        {
            set
            {
                m_Marks = value;
            }
            get
            {
                return m_Marks;
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

        private void Button_Save_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Button_Add_Subject_Click(object sender, EventArgs e)
        {
            if (ListBox_List_Subjects.SelectedIndex != -1 && ListBox_List_Mark.SelectedIndex != -1)
            {
                m_Student.setRecordBookPair(m_Subjects.currentData, m_Marks.currentData);
            }
            else
            {
                MessageBox.Show("Choose elements from both lists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox_Find_Subject_Enter(object sender, EventArgs e)
        {
            CommonFunctions.activeEdit(TextBox_Find_Subject);
        }

        private void TextBox_Find_Subject_Click(object sender, EventArgs e)
        {
            CommonFunctions.activeEdit(TextBox_Find_Subject);
        }

        private void TextBox_Find_Mark_Enter(object sender, EventArgs e)
        {
            CommonFunctions.activeEdit(TextBox_Find_Mark);
        }

        private void TextBox_Find_Mark_Click(object sender, EventArgs e)
        {
            CommonFunctions.activeEdit(TextBox_Find_Mark);
        }

        private void TextBox_Find_Subject_TextChanged(object sender, EventArgs e)
        {
            int index = ListBox_List_Subjects.FindString(((TextBox)(sender)).Text);
            if (index != ListBox.NoMatches && ((TextBox)(sender)).TextLength > 0)
            {
                ListBox_List_Subjects.SetSelected(index, true);
                ListBox_List_Subjects_SelectedIndexChanged(ListBox_List_Subjects, e);
            }
        }

        private void ListBox_List_Subjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = ListBox_List_Subjects.SelectedIndex;
            if (selected != -1 && selected != m_OldSubjectSelect)
            {
                SecondCommon<string>.for_each_listbox(m_Subjects, ListBox_List_Subjects, ref m_OldSubjectSelect, ref selected);
            }
        }

        private void TextBox_Find_Mark_TextChanged(object sender, EventArgs e)
        {
            int index = ListBox_List_Mark.FindString(((TextBox)(sender)).Text);
            if (index != ListBox.NoMatches && ((TextBox)(sender)).TextLength > 0)
            {
                ListBox_List_Mark.SetSelected(index, true);
                ListBox_List_Mark_SelectedIndexChanged(ListBox_List_Mark, e);
            }
        }

        private void ListBox_List_Mark_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = ListBox_List_Mark.SelectedIndex;
            if (selected != -1 && selected != m_OldMarkSelect)
            {
                SecondCommon<float>.for_each_listbox(m_Marks, ListBox_List_Mark, ref m_OldMarkSelect, ref selected);
            }
        }
    }
}
