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
        private NameList<NameList<Student>> m_Faculty;
        private NameList<Student> m_CurrentGroup;
        private Student m_CurrentStudent;
        private int m_OldGroupSelect;
        private int m_OldStudSelect;

        public StudentsGUIDlg()
        {
            InitializeComponent();
            m_InputNewName = new InputName();
            m_InputStudInfo = new InputStudent();
            m_Faculty = new NameList<NameList<Student>>();
        }

        private void setFacultyActions(bool flag)
        {
            Button_Change_Faculty_Name.Enabled = flag;
            Button_Delete_Faculty.Enabled = flag;
            Button_Get_Faculty_Name.Enabled = flag;
            Button_Add_Group.Enabled = flag;
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
            ListBox_List_Groups.Items.Clear();
            // TODO: Add correct scroller
        }

        private void deleteStudentList()
        {
            deleteStudentInformation();
            ListBox_List_Students.Items.Clear();
            // TODO: Add correct scroller
        }

        private void deleteStudentInformation()
        {
            ListBox_List_Stud_Info.Items.Clear();
            // TODO: Add correct scroller
        }

        private int getGroupSelect()
        {
            return ListBox_List_Groups.SelectedIndex;
        }

        private void showString(NameList<Student> group)
        {
            ListBox_List_Groups.Items.Add(group.nameList);
        }

        private void showGroups()
        {
            deleteGroupList();
            if (setGroupActions(m_Faculty.isNotEmpty()))
            {
                //m_Faculty.setStart();
                foreach (var tempGroup in m_Faculty.chooseOrder())
                {
                    showString(tempGroup);
                }
                m_Faculty.setStart();
                m_CurrentGroup = m_Faculty.currentData;
            }
        }

        private void Button_Create_Faculty_Click(object sender, EventArgs e)
        {
            m_InputNewName.Text = "Enter New Name of Faculty";

            deleteAllLists();

            if (m_InputNewName.ShowDialog() == DialogResult.OK)
            {
                m_Faculty.nameList = m_InputNewName.nameOfTheList;
                setFacultyActions(true);
            }
        }

        private void Button_Change_Faculty_Name_Click(object sender, EventArgs e)
        {
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
                ListBox_List_Groups_SelectedIndexChanged(sender, e);
            }
        }

        private void ListBox_List_Groups_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = getGroupSelect();
            if (selected != ListBox.NoMatches && selected != m_OldGroupSelect)
            {
                int counter = 0;
                // TODO: Refactor this part of code 
                // Because it has danger situation
                // m_CurrentGroup has reference on the temporary node
                foreach(var tempGroup in m_Faculty.chooseOrder())
                {
                    m_CurrentGroup = tempGroup;
                    if (counter++ == selected)
                    {
                        break;
                    }
                }
                showStudent();
                setSelectedActions(true);
                Button_Delete_All_Students_In_Group.Enabled = m_Faculty.currentData.isNotEmpty();
            }
        }

        private void showStudent()
        {
            deleteAllLists();

            if (m_Faculty.isNotEmpty())
            {
                m_CurrentGroup = m_Faculty.currentData;
                if (m_CurrentGroup.isNotEmpty())
                {
                    m_CurrentGroup.setStart();
                    // TODO: Create cycle which will be traversaling all students in the group
                    //for (size_t i = 0; i < m_CurrentGroup->getSize(); ++i)
                    //{
                    //    m_Student = &m_CurrentGroup->getReferencesCurrentData();
                    //    showString(*m_Student);
                    //    ++*m_CurrentGroup;
                    //}
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
            
            StringBuilder buff = new StringBuilder();
            buff.AppendFormat("Surname              : %s", student.surname);
            ListBox_List_Stud_Info.Items.Add(buff.ToString());
            buff.AppendFormat("Name                   : %s", student.name);
            ListBox_List_Stud_Info.Items.Add(buff.ToString());
            buff.AppendFormat("Lastname             : %s", student.lastname);
            ListBox_List_Stud_Info.Items.Add(buff.ToString());
            buff.AppendFormat("Birth Year             : %i", student.birthYear);
            ListBox_List_Stud_Info.Items.Add(buff.ToString());
            buff.AppendFormat("Average Grade    : %4.2f", student.mark);
            ListBox_List_Stud_Info.Items.Add(buff.ToString());

            // TODO: Correct scroller
        }
    }
}
