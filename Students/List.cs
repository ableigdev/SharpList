using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class List<NODETYPE> : IEnumerable<NODETYPE>, IComparable<List<NODETYPE>>, ICloneable where NODETYPE : IComparable<NODETYPE>, new()
    {
        private class ListNode
        {
            public ListNode(NODETYPE data)
            {
                m_Data = checkType(ref data);
            }

            public ListNode(ListNode prevPtr, NODETYPE data)
            {
                m_PrevPtr = prevPtr;
                m_Data = checkType(ref data);
            }

            public ListNode(NODETYPE data, ListNode nextPtr)
            {
                m_NextPtr = nextPtr;
                m_Data = checkType(ref data);
            }

            public ListNode(NODETYPE data, ListNode nextPtr, ListNode prevPtr)
            {
                m_NextPtr = nextPtr;
                m_PrevPtr = prevPtr;
                m_Data = checkType(ref data);
            }

            public NODETYPE data
            {
                get
                {
                    return m_Data;
                }
                set
                {
                    m_Data = value;
                }
            }

            public ListNode nextPtr
            {
                get
                {
                    return m_NextPtr;
                }
                set
                {
                    m_NextPtr = value;
                }
            }

            public ListNode prevPtr
            {
                get
                {
                    return m_PrevPtr;
                }
                set
                {
                    m_PrevPtr = value;
                }
            }

            private NODETYPE checkType(ref NODETYPE data)
            {
                return (Object.ReferenceEquals(data as ValueType, null)) ? (NODETYPE)(((ICloneable)data).Clone()) : data;
            }

            private NODETYPE m_Data;
            private ListNode m_NextPtr;
            private ListNode m_PrevPtr;
        }

        private ListNode m_FirstPtr;
        private ListNode m_CurrentNodePtr;
        private uint m_Size;

        public NODETYPE currentData
        {
            get
            {
                return m_CurrentNodePtr != null ? m_CurrentNodePtr.data : default(NODETYPE);
            }
            set
            {
                if (m_CurrentNodePtr != null && !Object.ReferenceEquals(value, null))
                {
                    m_CurrentNodePtr.data = value;
                }
            }
        }

        public uint size
        {
            get
            {
                return m_Size;
            }
        }

        public List()
        {

        }

        public List(NODETYPE data)
        {
            pushFront(data);
        }

        public void pushFront(NODETYPE data)
        {
            if (!Object.ReferenceEquals(data, null))
            {
                ListNode newPtr = new ListNode(data);
                if (m_FirstPtr != null)
                {
                    m_FirstPtr.prevPtr.nextPtr = newPtr;
                    newPtr.prevPtr = m_FirstPtr.prevPtr;
                }
                else
                {
                    m_CurrentNodePtr = m_FirstPtr = newPtr;
                }
                newPtr.nextPtr = m_FirstPtr;
                m_FirstPtr.prevPtr = newPtr;
                m_FirstPtr = newPtr;
                ++m_Size;
            }
        }

        public void pushBack(NODETYPE data)
        {
            if (!Object.ReferenceEquals(data, null))
            {
                ListNode newPtr = new ListNode(data);
                if (m_FirstPtr != null)
                {
                    m_FirstPtr.prevPtr.nextPtr = newPtr;
                    newPtr.prevPtr = m_FirstPtr.prevPtr;
                }
                else
                {
                    m_CurrentNodePtr = m_FirstPtr = newPtr;
                }
                newPtr.nextPtr = m_FirstPtr;
                m_FirstPtr.prevPtr = newPtr;
                ++m_Size;
            }
        }

        public void pushInSortList(NODETYPE data)
        {
            if (!Object.ReferenceEquals(data, null))
            {
                if (m_FirstPtr == null || data.CompareTo(m_FirstPtr.data) <= 0)
                {
                    pushFront(data);
                }
                else if (data.CompareTo(m_FirstPtr.prevPtr.data) >= 0)
                {
                    pushBack(data);
                }
                else
                {
                    ListNode newPtr = new ListNode(data);
                    ListNode currentPtr = m_FirstPtr;

                    do
                    {
                        if (newPtr.data.CompareTo(currentPtr.data) <= 0)
                        {
                            ListNode tempPtr = currentPtr.prevPtr;
                            tempPtr.nextPtr = newPtr;
                            newPtr.prevPtr = tempPtr;
                            newPtr.nextPtr = currentPtr;
                            currentPtr.prevPtr = newPtr;
                            ++m_Size;
                            return;
                        }
                        currentPtr = currentPtr.nextPtr;
                    } while (currentPtr != m_FirstPtr);
                }
            }
        }

        public bool deleteElement(NODETYPE data)
        {
            if (m_FirstPtr != null && !Object.ReferenceEquals(data, null))
            {
                ListNode currentPtr = m_FirstPtr;

                do
                {
                    if (currentPtr.data.CompareTo(data) == 0)
                    {
                        detachNode(currentPtr);

                        if (currentPtr == m_FirstPtr)
                        {
                            m_FirstPtr = currentPtr.nextPtr != m_FirstPtr ? currentPtr.nextPtr : null;
                        }
                        --m_Size;
                        return true;
                    }
                    currentPtr = currentPtr.nextPtr;
                } while (currentPtr != m_FirstPtr);
            }
            return false;
        }

        public void deleteAllElements()
        {
            m_FirstPtr = m_CurrentNodePtr = null;
            m_Size = 0;
        }

        public bool findValue(NODETYPE data)
        {
            if (m_FirstPtr != null && !Object.ReferenceEquals(data, null))
            {
                ListNode currentPtr = m_FirstPtr;
                do
                {
                    if (data.CompareTo(currentPtr.data) == 0)
                    {
                        return true;
                    }
                    currentPtr = currentPtr.nextPtr;
                } while (currentPtr != m_FirstPtr);
            }
            return false;
        }

        public void sort()
        {
            mergeSort(m_FirstPtr, m_Size);
        }

        private ListNode fusion(ListNode leftListPtr, uint leftListSize, ListNode rightListPtr, uint rightListSize)
        {
            ListNode currentPtr = null;
            ListNode tempPtr;

            while (leftListSize > 0 && rightListSize > 0)
            {
                if (leftListPtr.data.CompareTo(rightListPtr.data) <= 0)
                {
                    tempPtr = leftListPtr;
                    leftListPtr = leftListPtr.nextPtr;
                    --leftListSize;
                }
                else
                {
                    tempPtr = rightListPtr;
                    rightListPtr = rightListPtr.nextPtr;
                    --rightListSize;
                }
                detachNode(tempPtr);
                tempPtr.nextPtr = tempPtr.prevPtr = tempPtr;

                if (currentPtr == null)
                {
                    currentPtr = tempPtr;
                }
                else
                {
                    tempPtr.prevPtr = currentPtr.prevPtr;
                    tempPtr.nextPtr = currentPtr;
                    currentPtr.prevPtr.nextPtr = tempPtr;
                    currentPtr.prevPtr = tempPtr;
                }
            }

            if (leftListSize > 0)
            {
                if (currentPtr == null)
                {
                    currentPtr = leftListPtr;
                }
                else
                {
                    tempPtr = leftListPtr.prevPtr;
                    leftListPtr.prevPtr = currentPtr.prevPtr;
                    tempPtr.nextPtr = currentPtr;
                    currentPtr.prevPtr.nextPtr = leftListPtr;
                    currentPtr.prevPtr = tempPtr;
                }
            }

            if (rightListSize > 0)
            {
                if (currentPtr == null)
                {
                    currentPtr = rightListPtr;
                }
                else
                {
                    tempPtr = rightListPtr.prevPtr;
                    rightListPtr.prevPtr = currentPtr.prevPtr;
                    tempPtr.nextPtr = currentPtr;
                    currentPtr.prevPtr.nextPtr = rightListPtr;
                    currentPtr.prevPtr = tempPtr;
                }
            }
            m_FirstPtr = m_CurrentNodePtr = currentPtr;
            return currentPtr;
        }

        private ListNode mergeSort(ListNode rootPtr, uint sizeList)
        {
            ListNode leftListPtr;
            ListNode rightListPtr;
            uint leftListSize;
            uint rightListSize;

            if (sizeList < 2)
            {
                return rootPtr;
            }

            for (rightListPtr = leftListPtr = rootPtr, leftListSize = 0, rightListSize = sizeList; leftListSize < rightListSize; ++leftListSize, --rightListSize)
            {
                rightListPtr = rightListPtr.nextPtr;
            }

            leftListPtr = mergeSort(leftListPtr, leftListSize);
            rightListPtr = mergeSort(rightListPtr, rightListSize);
            rootPtr = fusion(leftListPtr, leftListSize, rightListPtr, rightListSize);
            return rootPtr;
        }

        public void sortCurrentNodePtr()
        {
            if (m_FirstPtr != null && m_Size > 1)
            {
                if (m_CurrentNodePtr.data.CompareTo(m_CurrentNodePtr.nextPtr.data) > 0)
                {
                    ListNode tempPtr = m_CurrentNodePtr.nextPtr;

                    while (m_CurrentNodePtr.data.CompareTo(tempPtr.data) > 0)
                    {
                        tempPtr = tempPtr.nextPtr;
                    }
                    detachNode(m_CurrentNodePtr);

                    tempPtr.prevPtr.nextPtr = m_CurrentNodePtr;
                    m_CurrentNodePtr.prevPtr = tempPtr.prevPtr;
                    m_CurrentNodePtr.nextPtr = tempPtr;
                    tempPtr.prevPtr = m_CurrentNodePtr;
                }

                if (m_CurrentNodePtr.data.CompareTo(m_CurrentNodePtr.prevPtr.data) < 0)
                {
                    if (m_CurrentNodePtr != m_FirstPtr)
                    {
                        if (m_CurrentNodePtr.data.CompareTo(m_FirstPtr.data) < 0)
                        {
                            detachNode(m_CurrentNodePtr);

                            m_FirstPtr.prevPtr.nextPtr = m_CurrentNodePtr;
                            m_CurrentNodePtr.prevPtr = m_FirstPtr.prevPtr;
                            m_CurrentNodePtr.nextPtr = m_FirstPtr;
                            m_FirstPtr.prevPtr = m_CurrentNodePtr;
                            m_FirstPtr = m_CurrentNodePtr;
                        }
                        else
                        {
                            ListNode tempPtr = m_CurrentNodePtr.prevPtr;

                            while (m_CurrentNodePtr.data.CompareTo(tempPtr.data) < 0 && tempPtr != m_FirstPtr)
                            {
                                tempPtr = tempPtr.prevPtr;
                            }

                            detachNode(m_CurrentNodePtr);

                            tempPtr.nextPtr.prevPtr = m_CurrentNodePtr;
                            m_CurrentNodePtr.nextPtr = tempPtr.nextPtr;
                            m_CurrentNodePtr.prevPtr = tempPtr;
                            tempPtr.nextPtr = m_CurrentNodePtr;
                        }
                    }
                }
            }
        }

        public bool deleteCurrentNode()
        {
            if (m_CurrentNodePtr != null)
            {
                if (m_CurrentNodePtr != m_FirstPtr)
                {
                    detachNode(m_CurrentNodePtr);
                }
                else
                {
                    ListNode tempPtr = m_FirstPtr.nextPtr;
                    detachNode(m_FirstPtr);
                    m_FirstPtr = tempPtr;
                }

                m_CurrentNodePtr = m_CurrentNodePtr.nextPtr;
                --m_Size;
                return true;
            }
            return false;
        }

        private void detachNode(ListNode ptr)
        {
            ptr.prevPtr.nextPtr = ptr.nextPtr;
            ptr.nextPtr.prevPtr = ptr.prevPtr;
        }

        public bool isNotEmpty()
        {
            return m_FirstPtr != null;
        }

        public bool isNotGetEnd()
        {
            return m_FirstPtr != null && m_CurrentNodePtr.nextPtr != m_FirstPtr;
        }

        public void setStart()
        {
            m_CurrentNodePtr = m_FirstPtr;
        }

        public void setEnd()
        {
            m_CurrentNodePtr = m_FirstPtr == null ? null : m_FirstPtr.prevPtr;
        }

        public static bool operator !(List<NODETYPE> list)
        {
            return list != null && list.m_FirstPtr != null;
        }

        public static List<NODETYPE> operator++(List<NODETYPE> list)
        {
            if (list.m_CurrentNodePtr != null)
            {
                list.m_CurrentNodePtr = list.m_CurrentNodePtr.nextPtr;
            }
            return list;
        }

        public static List<NODETYPE> operator--(List<NODETYPE> list)
        {
            if (list.m_CurrentNodePtr != null)
            {
                list.m_CurrentNodePtr = list.m_CurrentNodePtr.prevPtr;
            }
            return list;
        }

        public IEnumerator<NODETYPE> GetEnumerator()
        {
            if (m_FirstPtr != null)
            {
                ListNode currentPtr = m_FirstPtr;
                do
                {
                    yield return currentPtr.data;
                    currentPtr = currentPtr.nextPtr;
                } while (currentPtr != m_FirstPtr);
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<NODETYPE> headToTail
        {
            get
            {
                return this;
            }
        }

        public IEnumerable<NODETYPE> tailToHead
        {
            get
            {
                if (m_FirstPtr != null && m_FirstPtr.prevPtr != null)
                {
                    ListNode currentPtr = m_FirstPtr.prevPtr;
                    do
                    {
                        yield return currentPtr.data;
                        currentPtr = currentPtr.prevPtr;
                    } while (currentPtr != m_FirstPtr.prevPtr);
                }
            }
        }

        public IEnumerable<NODETYPE> chooseOrder(bool fromHead = true)
        {
            return fromHead ? headToTail : tailToHead;
        }

        int IComparable<List<NODETYPE>>.CompareTo(List<NODETYPE> list)
        {
            return !Object.ReferenceEquals(list, null) ? (m_Size > list.m_Size ? 1 : m_Size == list.m_Size ? 0 : -1) : 1;
        }

        public override bool Equals(object obj)
        {
            return (obj == null || ((object)(obj as List<NODETYPE>) == null)) ? false : m_Size == ((List<NODETYPE>)(obj)).m_Size;
        }

        public bool Equals(List<NODETYPE> list)
        {
            return Object.ReferenceEquals(list, null) ? false : m_Size == list.m_Size;
        }

        public virtual object Clone()
        {
            List<NODETYPE> newList = createInstanceForClone();
            ListNode currNode, prevNode;

            if (isNotEmpty())
            {
                newList.m_Size = m_Size;
                prevNode = newList.m_FirstPtr = new ListNode(m_FirstPtr.data);
                currNode = m_FirstPtr.nextPtr;

                while (currNode != m_CurrentNodePtr)
                {
                    prevNode = prevNode.nextPtr = newList.m_FirstPtr.prevPtr = new ListNode(currNode.data, newList.m_FirstPtr, prevNode);
                    currNode = currNode.nextPtr;
                }

                if (currNode == m_FirstPtr)
                {
                    newList.m_CurrentNodePtr = newList.m_FirstPtr;
                    return newList;
                }
                else
                {
                    newList.m_CurrentNodePtr = prevNode = prevNode.nextPtr = newList.m_FirstPtr.prevPtr = new ListNode(currNode.data, newList.m_FirstPtr, prevNode);
                    currNode = currNode.nextPtr;
                }

                while (currNode != m_FirstPtr)
                {
                    prevNode = prevNode.nextPtr = newList.m_FirstPtr.prevPtr = new ListNode(currNode.data, newList.m_FirstPtr, prevNode);
                    currNode = currNode.nextPtr;
                }
            }
            return newList;
        }

        protected virtual List<NODETYPE> createInstanceForClone()
        {
            return new List<NODETYPE>();
        }

    }
}
