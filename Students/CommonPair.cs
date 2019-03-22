using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class CommonPair : IComparable<CommonPair>
    {
        public string m_Subject;
        public float m_Mark;

        int IComparable<CommonPair>.CompareTo(CommonPair pair)
        {
            return !Object.ReferenceEquals(pair, null) ? pair.m_Subject.CompareTo(m_Subject) : 1;
        }
    }
}
