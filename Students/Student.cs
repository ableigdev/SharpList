using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students 
{
    class Student : IComparable<Student>, ICloneable
    {
        public Student()
        {
            m_BirthYear = 0;
            m_Mark = 0.0f;
        }

        public string name
        {
            get
            {
                return m_Name;
            }
            set
            {
                if (value != null)
                {
                    m_Name = value;
                }
            }
        }

        public string surname
        {
            get
            {
                return m_Surname;
            }
            set
            {
                if (value != null)
                {
                    m_Surname = value;
                }
            }
        }

        public string lastname
        {
            get
            {
                return m_LastName;
            }
            set
            {
                if (value != null)
                {
                    m_LastName = value;
                }
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
            return Student.compareStudens(firstStudent, secondStudent) == 0;
        }

        public static bool operator!=(Student firstStudent, Student secondStudent)
        {
            return Object.ReferenceEquals(firstStudent, secondStudent) ? false : Student.compareStudens(firstStudent, secondStudent) != 0;
        }

        public static bool operator>=(Student firstStudent, Student secondStudent)
        {
            if (Object.ReferenceEquals(firstStudent, secondStudent))
            {
                return true;
            }
            return Student.compareStudens(firstStudent, secondStudent) >= 0;
        }

        public static bool operator<=(Student firstStudent, Student secondStudent)
        {
            if (Object.ReferenceEquals(firstStudent, secondStudent))
            {
                return true;
            }
            return Student.compareStudens(firstStudent, secondStudent) <= 0;
        }

        public static bool operator>(Student firstStudent, Student secondStudent)
        {
            return Object.ReferenceEquals(firstStudent, secondStudent) ? false : Student.compareStudens(firstStudent, secondStudent) > 0;
        }

        public static bool operator<(Student firstStudent, Student secondStudent)
        {
            return Object.ReferenceEquals(firstStudent, secondStudent) ? false : Student.compareStudens(firstStudent, secondStudent) < 0;
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
            return generateHash(ref m_Surname) ^ generateHash(ref m_Name) ^ generateHash(ref m_LastName);
        }

        private int generateHash(ref string stringValue)
        {
            int hCode = 0;

            if (stringValue.Length > 0)
            {
                unsafe
                {
                    var str = stringValue.ToCharArray();
                    fixed (char* ptr = &str[0])
                    {
                        int length = stringValue.Length;
                        uint* ptrStr = (uint*)(&ptr[0]);

                        for (int i = 0; i < length >> 1; ++i)
                        {
                            hCode ^= (int)ptrStr[i];
                        }

                        return (((uint)(length << 31)) >> 31) == 1 ? hCode ^ (int)(str[length - 1]) : hCode;
                    }
                }
            }
            return hCode;
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
            bool resultFirstStudent = Object.ReferenceEquals(firstStudent, null);
            bool resultSecondStudent = Object.ReferenceEquals(secondStudent, null);
            if (resultFirstStudent && resultSecondStudent)
            {
                return 0;
            }
            else if (resultFirstStudent && !resultSecondStudent)
            {
                return -1;
            }
            else if (!resultFirstStudent && resultSecondStudent)
            {
                return 1;
            }

            int result = firstStudent.m_Surname.CompareTo(secondStudent.m_Surname);
            if (result == 0)
            {
                result = firstStudent.m_Name.CompareTo(secondStudent.m_Name);
                if (result == 0)
                {
                    return firstStudent.m_LastName.CompareTo(secondStudent.m_LastName);
                }
            }
            return result;
        }

        public object Clone()
        {
            Student newStudent = new Student();
            newStudent.surname = m_Surname;
            newStudent.name = m_Name;
            newStudent.lastname = m_LastName;
            newStudent.birthYear = m_BirthYear;
            newStudent.mark = m_Mark;

            return newStudent;
        }

        private string m_Name;
        private string m_Surname;
        private string m_LastName;
        private short m_BirthYear;
        private float m_Mark;
    }
}
