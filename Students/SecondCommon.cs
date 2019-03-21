using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students
{
    class SecondCommon<T> where T : IComparable<T>
    {
        public static void for_each_listbox(List<T> list, ListBox listBox, ref int oldSelect, ref int selected)
        {
            if (oldSelect == -1)
            {
                if ((oldSelect = selected >= (oldSelect = listBox.Items.Count - 1) >> 1 ? oldSelect : 0) == 0)
                {
                    list.setStart();
                }
                else
                {
                    list.setEnd();
                }
            }
            for (; selected < oldSelect; --oldSelect, --list) ;
            for (; selected > oldSelect; ++oldSelect, ++list) ;
        }
    }
}
