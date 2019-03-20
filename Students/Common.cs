using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students
{
    class Common<T> where T : List<T>, new()
    {
        //public static void for_each_listbox(Iterator<T> list, ListBox listBox, ref int oldSelect, ref int selected)
        //{
        //    if (oldSelect == -1)
        //    {
        //        if ((oldSelect = selected >= (oldSelect = listBox.Items.Count - 1) >> 1 ? oldSelect : 0) == 0)
        //        {
        //            list.get().setStart();
        //        }
        //        else
        //        {
        //            list.get().setEnd();
        //        }
        //    }
        //    for (; selected < oldSelect; --oldSelect, list.prev());
        //    for (; selected > oldSelect; ++oldSelect, list.next());
        //}
    }
}
