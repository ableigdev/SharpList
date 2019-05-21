using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class ListInter<T> : List<T>, StructureInterface<T> where T : IComparable<T>
    {
        public ListInter()
        {

        }

        public void pushData(T data)
        {
            pushBack(data);
        }
    }
}
