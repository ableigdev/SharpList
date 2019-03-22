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
    public partial class StudentsGUIDlg : Form
    {
        private InputName m_InputNewName;
        private InputStudent m_InputStudInfo;
        private SelectAction m_SelectAction;
        private InputSubjectsAndMarks m_InputSubjects;
        private NameList<NameList<Student>> m_Faculty;
        private NameList<Student> m_CurrentGroup;
        private Student m_CurrentStudent;
        private int m_OldGroupSelect;
        private int m_OldStudSelect;
        private int m_MaxExtListStud;
        private int m_MaxExtListInfoStud;
        private int m_MaxExtListGroup;

        public StudentsGUIDlg()
        {
            InitializeComponent();
            m_InputNewName = new InputName();
            m_InputStudInfo = new InputStudent();
            m_SelectAction = new SelectAction();
            m_InputSubjects = new InputSubjectsAndMarks();
            m_Faculty = new NameList<NameList<Student>>();
        }

        private void setFacultyActions(bool flag)
        {
            Button_Change_Faculty_Name.Enabled = flag;
            Button_Delete_Faculty.Enabled = flag;
            Button_Get_Faculty_Name.Enabled = flag;
            Button_Add_Group.Enabled = flag;
            setAddFacultyAction(!flag);
        }

        private void setAddFacultyAction(bool flag)
        {
            Button_Create_Faculty.Enabled = flag;
        }

        private bool setStudentActions(bool flag)
        {
            Button_Add_Students.Enabled = flag;
            TextBox_Edit_Student.Enabled = flag;
            ListBox_List_Students.Enabled = flag;
            ListBox_List_Stud_Info.Enabled = flag;
            return flag;
        }

        private bool setGroupActions(bool flag)
        {
            TextBox_Edit_Group.Enabled = flag;
            ListBox_List_Groups.Enabled = flag;
            return flag;
        }

        private void setSelectedActions(bool flag)
        {
            Button_Delete_Selected.Enabled = flag;
            Button_Change_Selected.Enabled = flag;
        }

        private void disableFaculty()
        {
            setStudentActions(false);
            setFacultyActions(false);
        }

        private void deleteAllLists()
        {
            deleteGroupList();
            deleteStudentList();
        }

        private void deleteGroupList()
        {
            clearList(ListBox_List_Groups, ref m_MaxExtListGroup);
        }

        private void deleteStudentList()
        {
            deleteStudentInformation();
            clearList(ListBox_List_Students, ref m_MaxExtListStud);
        }

        private void deleteStudentInformation()
        {
            clearList(ListBox_List_Stud_Info, ref m_MaxExtListInfoStud);
        }

        private void clearList(ListBox list, ref int maxExt)
        {
            list.HorizontalExtent = maxExt = 0;
            list.Items.Clear();
        }

        private int getGroupSelect()
        {
            return ListBox_List_Groups.SelectedIndex;
        }

        private void showString(NameList<Student> group)
        {
            ListBox_List_Groups.Items.Add(group.nameList);
            CommonFunctions.correctHScrlAdd(ListBox_List_Groups, group.nameList, ref m_MaxExtListGroup);
        }

        private void showGroups()
        {
            deleteGroupList();
            if (setGroupActions(m_Faculty.isNotEmpty()))
            {
                m_Faculty.setStart();
                for (int i = 0; i < m_Faculty.size; ++i, ++m_Faculty)
                {
                    m_CurrentGroup = m_Faculty.currentData;
                    showString(m_CurrentGroup);
                }
                m_Faculty.setStart();
                m_CurrentGroup = m_Faculty.currentData;
                m_OldGroupSelect = -1;
            }
        }

        private void Button_Create_Faculty_Click(object sender, EventArgs e)
        {
            m_InputNewName.Text = "Enter New Name of Faculty";
            m_InputNewName.isEdit = false;

            deleteAllLists();

            if (m_InputNewName.ShowDialog() == DialogResult.OK)
            {
                m_Faculty.nameList = m_InputNewName.nameOfTheList;
                setFacultyActions(true);
            }
        }

        private void Button_Change_Faculty_Name_Click(object sender, EventArgs e)
        {
            m_InputNewName.isEdit = true;
            m_InputNewName.nameOfTheList = m_Faculty.nameList;
            m_InputNewName.ShowDialog();
        }

        private void Button_Get_Faculty_Name_Click(object sender, EventArgs e)
        {
            MessageBox.Show(m_Faculty.nameList, "Faculty name", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Button_Delete_Faculty_Click(object sender, EventArgs e)
        {
            Button_Delete_All_Groups_Click(sender, e);
            disableFaculty();
            m_Faculty.deleteAllElements();
        }

        private void Button_Delete_All_Groups_Click(object sender, EventArgs e)
        {
            setStudentActions(false);
            setGroupActions(false);
            Button_Delete_All_Groups.Enabled = false;
            Button_Delete_All_Students_In_Group.Enabled = false;
            TextBox_Edit_Group.Text = "";
            TextBox_Edit_Student.Text = "";
            setSelectedActions(false);
            deleteAllLists();
            disableSubjectsButton();
            m_Faculty.deleteAllElements();
        }

        private void Button_Add_Students_Click(object sender, EventArgs e)
        {
            var firstSelect = getGroupSelect();
            m_InputStudInfo.faculty = m_Faculty;
            m_InputStudInfo.changeFlag = false;
            m_InputStudInfo.currentSelectedGroupIndex = firstSelect;
            m_InputStudInfo.ShowDialog();
            var selected = m_InputStudInfo.currentSelectedGroupIndex;
            showGroups();

            if (selected != ListBox.NoMatches)
            {
                ListBox_List_Groups.SelectedIndex = selected;
                // TODO: Check it!
                //ListBox_List_Groups_SelectedIndexChanged(sender, e);
            }
        }

        private void ListBox_List_Groups_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = getGroupSelect();
            if (selected != ListBox.NoMatches && selected != m_OldGroupSelect)
            {
                Iterator<NameList<Student>> it = new Iterator<NameList<Student>>(m_Faculty);
                Common<NameList<Student>>.for_each_listbox(it, ListBox_List_Groups, ref m_OldGroupSelect, ref selected);
                m_CurrentGroup = m_Faculty.currentData;
                showStudent();
                setSelectedActions(true);
                Button_Delete_All_Students_In_Group.Enabled = m_Faculty.currentData.isNotEmpty();
            }
        }

        private void showString(Student student)
        {
            var str = getStudentString(student);
            ListBox_List_Students.Items.Add(str);
            CommonFunctions.correctHScrlAdd(ListBox_List_Students, str, ref m_MaxExtListStud);
        }

        // TODO: Add to common
        private string getStudentString(Student student)
        {
            string str = student.surname + " " + student.name.Substring(0, 1) + ". ";
            if (student.lastname.Length > 0)
            {
                str += student.lastname.Substring(0, 1) + ".";
            }
            return str;
        }

        private void showStudent()
        {
            deleteStudentList();

            if (m_Faculty.isNotEmpty())
            {
                m_CurrentGroup = m_Faculty.currentData;
                if (m_CurrentGroup.isNotEmpty())
                {
                    m_CurrentGroup.setStart();
                    for (int i = 0; i < m_CurrentGroup.size; ++i, ++m_CurrentGroup)
                    {
                        m_CurrentStudent = m_CurrentGroup.currentData;
                        showString(m_CurrentStudent);
                    }
                    m_CurrentGroup.setStart();
                    m_CurrentStudent = m_CurrentGroup.currentData;
                    m_OldStudSelect = ListBox.NoMatches;
                }
            }
        }

        private void Button_Add_Group_Click(object sender, EventArgs e)
        {
            NameList<Student> newGroup = new NameList<Student>();
            m_InputNewName.Text = "Enter New Name of Group";
            m_InputNewName.isEdit = false;

            string buf = "";
            int select = getGroupSelect();
            if (select != ListBox.NoMatches)
            {
                buf = ListBox_List_Groups.GetItemText(ListBox_List_Groups.SelectedItem);
            }

            if (m_InputNewName.ShowDialog() == DialogResult.OK)
            {
                newGroup.nameList = m_InputNewName.nameOfTheList;
                m_Faculty.pushInSortList(newGroup);
                setGroupActions(true);
                setStudentActions(true);
                setSelectedActions(false);
                Button_Delete_All_Students_In_Group.Enabled = false;
                Button_Delete_All_Groups.Enabled = true;
            }
            showGroups();
            if (buf.Length > 0)
            {
                ListBox_List_Groups.SelectedIndex = ListBox_List_Groups.FindString(buf, -1);
                ListBox_List_Groups_SelectedIndexChanged(sender, e);
            }
        }

        private void showStudentInformation(Student student)
        {
            deleteStudentInformation();
            
            string str = "Surname              : " + student.surname;
            ListBox_List_Stud_Info.Items.Add(str);
            str = "Name                   : " + student.name;
            ListBox_List_Stud_Info.Items.Add(str);
            str = "Lastname             : " + student.lastname;
            ListBox_List_Stud_Info.Items.Add(str);
            str = "Birth Year             : " + student.birthYear;
            ListBox_List_Stud_Info.Items.Add(str);
            str = "Average Grade    : " + student.mark;
            ListBox_List_Stud_Info.Items.Add(str);

            ListBox_List_Stud_Info.HorizontalExtent = m_MaxExtListInfoStud;
        }

        private int setNewSelect(ListBox listBox, ref int maxExtCx)
        {
            int currentSelect = listBox.SelectedIndex;
            // TODO: Correct scroller
            // TODO: Check it!
            CommonFunctions.corrctHScrlDel(listBox, listBox.Items[currentSelect].ToString(), ref maxExtCx);

            if (currentSelect != 0)
            {
                --currentSelect;
            }

            listBox.SelectedIndex = currentSelect;
            return currentSelect;
        }

        private int changeItem(ListBox listBox, ref int maxExtCx, string name)
        {
            int currentSelect = listBox.SelectedIndex;
            if (currentSelect != ListBox.NoMatches)
            {
                // TODO: correct scroller and check it
                CommonFunctions.corrctHScrlDel(listBox, listBox.Items[currentSelect].ToString(), ref maxExtCx);
                listBox.Items.RemoveAt(currentSelect);
                listBox.SelectedIndex = (currentSelect = listBox.Items.Add(name));
                CommonFunctions.correctHScrlAdd(listBox, listBox.Items[currentSelect].ToString(), ref maxExtCx);
            }
            return currentSelect;
        }

        private void deleteStudent()
        {
            m_CurrentGroup = m_Faculty.currentData;
            m_CurrentGroup.deleteElement(m_CurrentGroup.currentData);
            if (m_CurrentGroup.isNotEmpty())
            {
                m_CurrentStudent = m_CurrentGroup.currentData;
                m_OldStudSelect = setNewSelect(ListBox_List_Students, ref m_MaxExtListStud);
                showStudentInformation(m_CurrentStudent);
            }
            else
            {
                deleteStudentList();
                setStudentActions(false);
            }
        }

        private void modifyStudent()
        {
            m_InputStudInfo.changeFlag = true;
            m_InputStudInfo.student = m_CurrentStudent;

            if (m_InputStudInfo.ShowDialog() == DialogResult.OK)
            {
                m_CurrentGroup = m_Faculty.currentData;
                m_CurrentGroup.sort();
                m_OldStudSelect = changeItem(ListBox_List_Students, ref m_MaxExtListStud, m_CurrentStudent.surname);
                showStudentInformation(m_CurrentStudent);
            }
        }

        private int getStudentSelect()
        {
            return ListBox_List_Students.SelectedIndex;
        }

        private void disableSubjectsButton()
        {
            Button_Get_Students_Subjects.Enabled = false;
            Button_Input_Subjects_And_Marks.Enabled = false;
        }

        private void deleteSelectedStudent()
        {
            int select = getStudentSelect();
            // TODO: Check it! Be careful!
            m_CurrentGroup.deleteCurrentNode();
            if (m_CurrentGroup.isNotEmpty())
            {
                m_CurrentGroup.setStart();
                m_CurrentStudent = m_CurrentGroup.currentData;
            }
            else
            {
                deleteStudentList();
                setSelectedActions(false);
                m_CurrentStudent = null;
                Button_Delete_All_Students_In_Group.Enabled = false;
                disableSubjectsButton();
            }
            showStudent();
            if (--select != -1)
            {
                ListBox_List_Students.SelectedIndex = select;
                // TODO: Check it!
                //ListBox_List_Students_SelectedIndexChanged(this, null);
            }
            else if (ListBox_List_Students.Items.Count >= 0)
            {
                ListBox_List_Students.SelectedIndex = 0;
                // TODO: Check it!
                //ListBox_List_Students_SelectedIndexChanged(this, null);
            }
        }

        private void ListBox_List_Students_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = getStudentSelect();

            if (selected != -1 && selected != m_OldStudSelect)
            {
                Iterator<Student> iter = new Iterator<Student>(m_CurrentGroup);
                Common<Student>.for_each_listbox(iter, ListBox_List_Groups, ref m_OldStudSelect, ref selected);
                m_CurrentStudent = m_CurrentGroup.currentData;
                showStudentInformation(m_CurrentStudent);
                setSelectedActions(true);
                // TODO: Add InputSubject actions
            }
        }

        private void deleteSelectedGroup()
        {
            int select = getGroupSelect();
            setSelectedActions(false);
            Button_Delete_All_Students_In_Group.Enabled = false;
            // TODO: Check it
            m_Faculty.deleteCurrentNode();
            if (m_Faculty.isNotEmpty())
            {
                m_Faculty.setStart();
                m_CurrentGroup = m_Faculty.currentData;
            }
            else
            {
                Button_Delete_All_Groups.Enabled = false;
                deleteAllLists();
                setStudentActions(false);
                setSelectedActions(false);
                m_CurrentGroup = null;
                disableSubjectsButton();
            }
            showGroups();
            showStudent();

            if (--select != -1)
            {
                ListBox_List_Groups.SelectedIndex = select;
                // TODO: Check it!
                //ListBox_List_Groups_SelectedIndexChanged(this, null);
            }
            else if (ListBox_List_Groups.Items.Count > 0)
            {
                ListBox_List_Groups.SelectedIndex = 0;
                // TODO: Check it!
                //ListBox_List_Groups_SelectedIndexChanged(this, null);
            }
        }

        private void Button_Delete_Selected_Click(object sender, EventArgs e)
        {
            doAction(deleteSelectedGroup, deleteSelectedStudent, "What would you like to delete?");
        }

        private void Button_Change_Selected_Click(object sender, EventArgs e)
        {
            doAction(changeSelectedGroup, changeSelectedStudent, "What would you like to change?");
        }

        private void Button_Delete_All_Students_In_Group_Click(object sender, EventArgs e)
        {
            m_CurrentGroup = m_Faculty.currentData;
            m_CurrentGroup.deleteAllElements();
            deleteStudentList();
            setSelectedActions(true);
            Button_Delete_All_Students_In_Group.Enabled = false;
            disableSubjectsButton();
        }

        private void TextBox_Edit_Student_TextChanged(object sender, EventArgs e)
        {
            int index = ListBox_List_Students.FindString(((TextBox)(sender)).Text);
            if (index != ListBox.NoMatches && ((TextBox)(sender)).TextLength > 0)
            {
                ListBox_List_Students.SetSelected(index, true);
                ListBox_List_Students_SelectedIndexChanged(ListBox_List_Students, e);
            }
        }

        private void TextBox_Edit_Student_Enter(object sender, EventArgs e)
        {
            if (TextBox_Edit_Student.Text.Length > 0)
            {
                TextBox_Edit_Student.SelectAll();
                TextBox_Edit_Student_TextChanged(sender, e);
            }
        }

        private void TextBox_Edit_Student_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox_Edit_Student_Enter(sender, e);
        }

        private void TextBox_Edit_Group_TextChanged(object sender, EventArgs e)
        {
            int index = ListBox_List_Groups.FindString(((TextBox)(sender)).Text);
            if (index != ListBox.NoMatches && ((TextBox)(sender)).TextLength > 0)
            {
                ListBox_List_Groups.SetSelected(index, true);
                ListBox_List_Groups_SelectedIndexChanged(sender, e);
            }
        }

        private void TextBox_Edit_Group_Enter(object sender, EventArgs e)
        {
            if (TextBox_Edit_Group.Text.Length > 0)
            {
                TextBox_Edit_Group.SelectAll();
                TextBox_Edit_Group_TextChanged(sender, e);
            }
        }

        private void TextBox_Edit_Group_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox_Edit_Group_Enter(sender, e);
        }

        private void changeSelectedGroup()
        {
            m_InputNewName.Text = "Change The Name Of The Group";
            m_InputNewName.nameOfTheList = m_CurrentGroup.nameList;
            m_InputNewName.isEdit = true;
            if (m_InputNewName.ShowDialog() == DialogResult.OK)
            {
                m_CurrentGroup.nameList = m_InputNewName.nameOfTheList;
                // TODO: Remake it!
                m_Faculty.sort();
                //ListBox_List_Groups.Items.RemoveAt(getGroupSelect());
                int select = changeItem(ListBox_List_Groups, ref m_MaxExtListGroup, m_CurrentGroup.nameList);
                int selectStudent = m_CurrentStudent != null && m_CurrentGroup.findValue(m_CurrentStudent) ? changeItem(ListBox_List_Students, ref m_MaxExtListStud, getStudentString(m_CurrentStudent)) : -1;
                showGroups();
                ListBox_List_Groups.SelectedIndex = select;
                //ListBox_List_Groups_SelectedIndexChanged(this, null);
                if (selectStudent != -1)
                {
                    ListBox_List_Students.SelectedIndex = selectStudent;
                }
            }
        }

        private void changeSelectedStudent()
        {
            m_InputStudInfo.faculty = m_Faculty;
            m_InputStudInfo.currentSelectedGroupIndex = getGroupSelect();
            m_InputStudInfo.student = m_CurrentGroup.currentData;
            m_InputStudInfo.changeFlag = true;
            if (m_InputStudInfo.ShowDialog() == DialogResult.OK)
            {
                m_CurrentGroup.currentData = m_CurrentStudent = m_InputStudInfo.student;
                // TODO: Remake it!
                m_CurrentGroup.sort();
                ListBox_List_Students.Items.RemoveAt(getStudentSelect());
                int select = changeItem(ListBox_List_Students, ref m_MaxExtListStud, getStudentString(m_CurrentStudent));
                showStudent();
                ListBox_List_Students.SelectedIndex = select;
                ListBox_List_Students_SelectedIndexChanged(this, null);
            }
        }

        private void doAction(Action groupAction, Action studentAction, string actionName)
        {
            int selectedStudent = getStudentSelect();
            int selectedGroup = getGroupSelect();
            if (selectedGroup != -1 && selectedStudent != -1)
            {
                m_SelectAction.Text = actionName;
                if (m_SelectAction.ShowDialog() == DialogResult.OK)
                {
                    if (m_SelectAction.answer == 0) // Group answer
                    {
                        groupAction();
                    }
                    else // Student answer
                    {
                        studentAction();
                    }
                    return;
                }
            }

            if (selectedGroup != -1 && selectedStudent == -1)
            {
                groupAction();
                return;
            }

            if (selectedGroup == -1 && selectedStudent != -1)
            {
                studentAction();
            }
        }

        private void Button_Input_Subjects_And_Marks_Click(object sender, EventArgs e)
        {
            m_InputSubjects.ShowDialog();
        }
    }
}
