using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students
{
    class CommonFunctions
    {
        public static void correctHScrlAdd(ListBox list, string currString, ref int maxExt)
        {
            int curExt = (int)TextRenderer.MeasureText(currString, list.Font).Width;
            if (curExt > maxExt)
            {
                maxExt = curExt;
            }
        }

        public static void corrctHScrlDel(ListBox list, string curString, ref int maxExt)
        {
            int curExt = (int)TextRenderer.MeasureText(curString, list.Font).Width;
            if (curExt == maxExt)
            {
                maxExt = 0;
                foreach (object elem in list.Items)
                {
                    if ((curExt = (int)TextRenderer.MeasureText(elem.ToString(), list.Font).Width) > maxExt)
                    {
                        maxExt = curExt;
                    }
                }
                list.HorizontalExtent = maxExt;
            }
        }

        public static void activeEdit(TextBoxBase edit)
        {
            edit.Focus();
            edit.SelectAll();
        }

        public static string getStudentString(Student student)
        {
            string str = student.surname + " " + student.name.Substring(0, 1) + ". ";
            if (student.lastname.Length > 0)
            {
                str += student.lastname.Substring(0, 1) + ".";
            }
            return str;
        }
    }
}
