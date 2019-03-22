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
    public partial class ShowSubjectsAndMarks : Form
    {
        private List<CommonPair> m_RecordBook;
        private Student m_Student;
        private int m_OldSubjectSelect;
        private int m_OldMarkSelect;
        private int m_MaxExtMark;
        private int m_MaxExtSubject;

        public ShowSubjectsAndMarks()
        {
            InitializeComponent();
            m_RecordBook = new List<CommonPair>();
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

        public List<CommonPair> recordBook
        {
            set
            {
                m_RecordBook = value;
            }
            get
            {
                return m_RecordBook;
            }
        }

        private void TextBox_Find_Subject_In_Show_Window_TextChanged(object sender, EventArgs e)
        {
            //CommonFunctions.activeEdit(TextBox_Find_Subject_In_Show_Window);
            int index = ListBox_Subjects_In_Show_Window.FindString(((TextBox)(sender)).Text);
            if (index != ListBox.NoMatches && ((TextBox)(sender)).TextLength > 0)
            {
                ListBox_Subjects_In_Show_Window.SetSelected(index, true);
                ListBox_Subjects_In_Show_Window_SelectedIndexChanged(ListBox_Subjects_In_Show_Window, e);
            }
        }

        private void Button_Exit_From_Show_Window_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void TextBox_Find_Subject_In_Show_Window_Enter(object sender, EventArgs e)
        {
            CommonFunctions.activeEdit(TextBox_Find_Subject_In_Show_Window);
        }

        private void TextBox_Find_Subject_In_Show_Window_Click(object sender, EventArgs e)
        {
            CommonFunctions.activeEdit(TextBox_Find_Subject_In_Show_Window);
        }

        private void ListBox_Subjects_In_Show_Window_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = ListBox_Subjects_In_Show_Window.SelectedIndex;
            if (selected != -1 && selected != m_OldSubjectSelect)
            {
                SecondCommon<CommonPair>.for_each_listbox(m_RecordBook, ListBox_Subjects_In_Show_Window, ref m_OldSubjectSelect, ref selected);
                if (ListBox_Marks_In_Show_Window.SelectedIndex != selected)
                {
                    ListBox_Marks_In_Show_Window.SelectedIndex = selected;
                    ListBox_Marks_In_Show_Window_SelectedIndexChanged(ListBox_Marks_In_Show_Window, e);
                }
            }
            Button_Delete_Subjects_In_Show_Window.Enabled = true;
        }

        private void ListBox_Marks_In_Show_Window_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seleted = ListBox_Marks_In_Show_Window.SelectedIndex;
            if (seleted != -1 && seleted != m_OldMarkSelect && ListBox_Subjects_In_Show_Window.SelectedIndex != seleted)
            {
                ListBox_Subjects_In_Show_Window.SelectedIndex = seleted;
                ListBox_Subjects_In_Show_Window_SelectedIndexChanged(ListBox_Marks_In_Show_Window, e);
            }
        }

        private void Button_Delete_Subjects_In_Show_Window_Click(object sender, EventArgs e)
        {
            m_RecordBook.deleteCurrentNode();
            int subjectIndex = ListBox_Subjects_In_Show_Window.SelectedIndex;
            int markIndex = ListBox_Marks_In_Show_Window.SelectedIndex;
            string tempSubject = ListBox_Subjects_In_Show_Window.Items[subjectIndex].ToString();
            string tempMark = ListBox_Marks_In_Show_Window.Items[markIndex].ToString();
            ListBox_Subjects_In_Show_Window.Items.RemoveAt(subjectIndex);
            ListBox_Marks_In_Show_Window.Items.RemoveAt(subjectIndex);
            CommonFunctions.corrctHScrlDel(ListBox_Subjects_In_Show_Window, tempSubject, ref m_MaxExtSubject);
            CommonFunctions.corrctHScrlDel(ListBox_Marks_In_Show_Window, tempMark, ref m_MaxExtMark);
            m_RecordBook.setStart();
            m_OldSubjectSelect = -1;
            m_OldMarkSelect = -1;
            Button_Delete_Subjects_In_Show_Window.Enabled = false;
            if (!m_RecordBook.isNotEmpty())
            {
                TextBox_Find_Subject_In_Show_Window.Enabled = false;
                ListBox_Subjects_In_Show_Window.Enabled = false;
                ListBox_Marks_In_Show_Window.Enabled = false;
            }
        }
    }
}
