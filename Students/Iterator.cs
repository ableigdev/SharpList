using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Iterator<T> where T : NameList<T>, new()
    {
        public Iterator(NameList<T> list)
        {
            m_List = list;
        }

        public NameList<T> next()
        {
            return ++m_List;
        }

        public NameList<T> prev()
        {
            return --m_List;
        }

        public NameList<T> get()
        {
            return m_List;
        }

        private NameList<T> m_List;
    }
}
