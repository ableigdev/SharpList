﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Students
{
    class CommonCorrectScroll
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
    }
}
