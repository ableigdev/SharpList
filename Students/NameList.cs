using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class NameList<NODETYPE> : List<NODETYPE>, IComparable<NameList<NODETYPE>>, ICloneable where NODETYPE : IComparable<NODETYPE>, new()
    {
        private string m_NameList;

        public NameList()
        {

        }

        public string nameList
        {
            get
            {
                return m_NameList;
            }
            set
            {
                if (!Object.ReferenceEquals(value, null))
                {
                    m_NameList = value;
                }
            }
        }

        private static int checkLists(NameList<NODETYPE> leftList, NameList<NODETYPE> rightList)
        {
            bool resultRightList = Object.ReferenceEquals(rightList, null);
           
            return Object.ReferenceEquals(leftList, null) ? (resultRightList ? 0 : -1) : (resultRightList ? 1 : leftList.m_NameList.CompareTo(rightList.m_NameList));
        }

        public static bool operator==(NameList<NODETYPE> leftList, NameList<NODETYPE> rightList)
        {
            return checkLists(leftList, rightList) == 0;
        }

        public static bool operator!=(NameList<NODETYPE> leftList, NameList<NODETYPE> rightList)
        {
            return checkLists(leftList, rightList) != 0;
        }

        public static bool operator>=(NameList<NODETYPE> leftList, NameList<NODETYPE> rightList)
        {
            return checkLists(leftList, rightList) >= 0;
        }

        public static bool operator<=(NameList<NODETYPE> leftList, NameList<NODETYPE> rightList)
        {
            return checkLists(leftList, rightList) <= 0;
        }

        public static bool operator>(NameList<NODETYPE> leftList, NameList<NODETYPE> rightList)
        {
            return checkLists(leftList, rightList) > 0;
        }

        public static bool operator<(NameList<NODETYPE> leftList, NameList<NODETYPE> rightList)
        {
            return checkLists(leftList, rightList) < 0;
        }

        int IComparable<NameList<NODETYPE>>.CompareTo(NameList<NODETYPE> list)
        {
            return checkLists(this, list);
        }

        public override bool Equals(object obj)
        {
            return (Object.ReferenceEquals(obj, null) || (Object.ReferenceEquals((object)(obj as NameList<NODETYPE>), null))) ? false : m_NameList.Equals(((NameList<NODETYPE>)(obj)).m_NameList);
        }

        public bool Equals(NameList<NODETYPE> list)
        {
            return Object.ReferenceEquals(list, null) ? false : this.m_NameList.Equals(list.m_NameList);
        }

        public override object Clone()
        {
            NameList<NODETYPE> newList = (NameList<NODETYPE>)base.Clone();
            newList.m_NameList = this.m_NameList;
            return newList;
        }

        protected override List<NODETYPE> createInstanceForClone()
        {
            return new NameList<NODETYPE>();
        }
    }
}
