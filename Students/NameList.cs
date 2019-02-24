using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class NameList<NODETYPE> : List<NODETYPE>, IComparable<NameList<NODETYPE>>, ICloneable where NODETYPE : IComparable<NODETYPE>, new()
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
                if (value != null)
                {
                    m_NameList = value;
                }
            }
        }

        private static int checkLists(NameList<NODETYPE> leftList, NameList<NODETYPE> rightList)
        {
            if (Object.ReferenceEquals(leftList, null) && Object.ReferenceEquals(rightList, null))
            {
                return 0;
            }
            else if (!Object.ReferenceEquals(leftList, null) && Object.ReferenceEquals(rightList, null))
            {
                return 1;
            }
            else if (Object.ReferenceEquals(leftList, null) && !Object.ReferenceEquals(rightList, null))
            {
                return -1;
            }
            return 2;
        }

        public static bool operator==(NameList<NODETYPE> leftList, NameList<NODETYPE> rightList)
        {
            int result = checkLists(leftList, rightList);
            return result == 0 ? true : result != 2 ? false : leftList.m_NameList.Equals(rightList.m_NameList);
        }

        public static bool operator!=(NameList<NODETYPE> leftList, NameList<NODETYPE> rightList)
        {
            return checkLists(leftList, rightList) != 2 ? false : leftList.m_NameList.Equals(rightList.m_NameList);
        }

        public static bool operator>=(NameList<NODETYPE> leftList, NameList<NODETYPE> rightList)
        {
            int result = checkLists(leftList, rightList);
            return result >= 0 && result <= 1 ? true : result < 0 ? false : leftList.m_NameList.Equals(rightList.m_NameList);
        }

        public static bool operator<=(NameList<NODETYPE> leftList, NameList<NODETYPE> rightList)
        {
            int result = checkLists(leftList, rightList);
            return result <= 0 ? true : result == 1 ? false : leftList.m_NameList.Equals(rightList.m_NameList);
        }

        public static bool operator>(NameList<NODETYPE> leftList, NameList<NODETYPE> rightList)
        {
            int result = checkLists(leftList, rightList);
            return result == 1 ? true : result <= 0 ? false : leftList.m_NameList.Equals(rightList.m_NameList);
        }

        public static bool operator<(NameList<NODETYPE> leftList, NameList<NODETYPE> rightList)
        {
            int result = checkLists(leftList, rightList);
            return result == -1 ? true : result >= 0 && result <= 1 ? false : leftList.m_NameList.Equals(rightList.m_NameList);
        }

        int IComparable<NameList<NODETYPE>>.CompareTo(NameList<NODETYPE> list)
        {
            int result = checkLists(this, list);
            return result != 2 ? result : this.m_NameList.CompareTo(list.m_NameList);
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
            var newList = (NameList<NODETYPE>)base.Clone();
            newList.m_NameList = this.m_NameList;
            return newList;
        }

        protected override List<NODETYPE> createInstanceForClone()
        {
            return new NameList<NODETYPE>();
        }
    }
}
