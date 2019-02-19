using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students 
{
    class Student : IComparable<Student>
    {
        public Student()
        {
            m_Name = new StringBuilder();
            m_Surname = new StringBuilder();
            m_LastName = new StringBuilder();
            m_BirthYear = 0;
            m_Mark = 0.0f;
        }

        public StringBuilder name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        public StringBuilder surname
        {
            get
            {
                return m_Surname;
            }
            set
            {
                m_Surname = value;
            }
        }

        public StringBuilder lastname
        {
            get
            {
                return m_LastName;
            }
            set
            {
                m_LastName = value;
            }
        }

        public short birthYear
        {
            get
            {
                return m_BirthYear;
            }
            set
            {
                m_BirthYear = value;
            }
        }

        public float mark
        {
            get
            {
                return m_Mark;
            }
            set
            {
                m_Mark = value;
            }
        }

        public static bool operator==(Student firstStudent, Student secondStudent)
        {
            if (Object.ReferenceEquals(firstStudent, secondStudent))
            {
                return true;
            }
            return ((object)firstStudent == null || (object)secondStudent == null) ? false : Student.compareStudens(firstStudent, secondStudent) == 0;
        }

        public static bool operator!=(Student firstStudent, Student secondStudent)
        {
            return (Object.ReferenceEquals(firstStudent, secondStudent) || (object)firstStudent == null || (object)secondStudent == null) ? false : Student.compareStudens(firstStudent, secondStudent) != 0;
        }

        public static bool operator>=(Student firstStudent, Student secondStudent)
        {
            if (Object.ReferenceEquals(firstStudent, secondStudent))
            {
                return true;
            }
            return ((object)firstStudent == null || (object)secondStudent == null) ? false : Student.compareStudens(firstStudent, secondStudent) >= 0;
        }

        public static bool operator<=(Student firstStudent, Student secondStudent)
        {
            if (Object.ReferenceEquals(firstStudent, secondStudent))
            {
                return true;
            }
            return ((object)firstStudent == null || (object)secondStudent == null) ? false : Student.compareStudens(firstStudent, secondStudent) <= 0;
        }

        public static bool operator>(Student firstStudent, Student secondStudent)
        {
            return (Object.ReferenceEquals(firstStudent, secondStudent) || (object)firstStudent == null || (object)secondStudent == null) ? false : Student.compareStudens(firstStudent, secondStudent) > 0;
        }

        public static bool operator<(Student firstStudent, Student secondStudent)
        {
            return (Object.ReferenceEquals(firstStudent, secondStudent) || (object)firstStudent == null || (object)secondStudent == null) ? false : Student.compareStudens(firstStudent, secondStudent) < 0;
        }

        public override bool Equals(object obj)
        {
            return (Object.ReferenceEquals(obj, null) || ((object)(obj as Student) == null)) ? false : Student.compareStudens(this, (Student)obj) == 0;
        }

        public bool Equals(Student student)
        {
            return Object.ReferenceEquals(student, null) ? false : Student.compareStudens(this, student) == 0;
        }

        public override int GetHashCode()
        {
            return m_Surname.GetHashCode() ^ m_Name.GetHashCode() ^ m_LastName.GetHashCode();
        }

        public override string ToString()
        {
            return m_Surname.ToString() + " " + m_Name.ToString() + " " + m_LastName.ToString() + " " + m_BirthYear + " " + m_Mark;
        }

        int IComparable<Student>.CompareTo(Student other)
        {
            return compareStudens(this, other);
        }

        private static int compareStudens(Student firstStudent, Student secondStudent)
        {
            int result = firstStudent.m_Surname.ToString().CompareTo(secondStudent.m_Surname.ToString());
            if (result == 0)
            {
                result = firstStudent.m_Name.ToString().CompareTo(secondStudent.m_Name.ToString());
                if (result == 0)
                {
                    return firstStudent.m_LastName.ToString().CompareTo(secondStudent.m_LastName.ToString());
                }
            }
            return result;
        }
        private StringBuilder m_Name;
        private StringBuilder m_Surname;
        private StringBuilder m_LastName;
        private short m_BirthYear;
        private float m_Mark;
    }
}
