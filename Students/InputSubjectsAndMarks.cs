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

        private void activeEdit(TextBoxBase edit)
        {
            edit.Focus();
            edit.SelectAll();
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
                        CommonCorrectScroll.correctHScrlAdd(ListBox_All_Marks, TextBox_Input_Mark.Text, ref m_MaxExtMarkList);
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
            activeEdit(TextBox_Input_Mark);
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
                    CommonCorrectScroll.correctHScrlAdd(ListBox_All_Subjects, str, ref m_MaxExtSubjectList);
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
            activeEdit(TextBox_Input_Subject);
        }
    }
}
