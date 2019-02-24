using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            int elem = 0, i;

            Random r = new Random(10000);

            for (i = 0; i < 10; ++i)
            {
                elem = r.Next();
                list.pushBack(elem);
                Console.WriteLine("{0:D}", elem);
            }

            Console.WriteLine("\nSource list:");
            foreach (var curElem in list.chooseOrder(false))
                Console.WriteLine("{0:D}", curElem);

            list.setEnd();
            --list;
            list.deleteCurrentNode();

            Console.WriteLine("\nModified list:");

            foreach (var curElem in list.chooseOrder(false))
                Console.WriteLine("{0:D}", curElem);

            List<int> listNew = (List<int>)((ICloneable)list).Clone();

            Console.WriteLine("\nCopied list:");
            foreach (var curElem in listNew.chooseOrder(true))
                Console.WriteLine("{0:D}", curElem);

            NameList<int> nameList = new NameList<int>();
            nameList.nameList = "test";

            for (int j = 0; j < 5; ++j)
            {
                nameList.pushBack(j);
            }

            Console.WriteLine("\nSource nameList:");
            foreach (var curElem in nameList.chooseOrder(false))
                Console.WriteLine("{0:D}", curElem);

            NameList<int> cloneNameList = (NameList<int>)((ICloneable)nameList).Clone();

            Console.WriteLine("\nCopy nameList:");
            foreach (var curElem in cloneNameList.chooseOrder(false))
                Console.WriteLine("{0:D}", curElem);

            //Student student = new Student();
            //Student student2 = new Student();

            //student.name = new StringBuilder("name");
            //student.surname = new StringBuilder("surname");
            //student.lastname = new StringBuilder("lastname");
            //student.birthYear = 1998;
            //student.mark = 4;

            //student2.name = new StringBuilder("name2");
            //student2.surname = new StringBuilder("surname2");
            //student2.lastname = new StringBuilder("lastname2");
            //student2.birthYear = 1998;
            //student2.mark = 4;

            //if (student == student2)
            //{
            //    Console.WriteLine("student == student2");
            //}

            //if (student != student2)
            //{
            //    Console.WriteLine("student != student2");
            //}

            //if (student >= student2)
            //{
            //    Console.WriteLine("student >= student2");
            //}

            //if (student <= student2)
            //{
            //    Console.WriteLine("student <= student2");
            //}

            //if (student > student2)
            //{
            //    Console.WriteLine("student > student2");
            //}

            //if (student < student2)
            //{
            //    Console.WriteLine("student < student2");
            //}

            //if (!student2.Equals(student2))
            //{
            //    Console.WriteLine("!student2.Equals(student2)");
            //}

            //Console.WriteLine(student);
            //Console.WriteLine(student2);
        }
    }
}
