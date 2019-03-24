using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Students
{
    class FileProcess<T> : FileSimple
    {
        // Описание делегатов, используемых для выполнения обработки прочитанных данных
        public delegate void ProcessBuf<Type>(byte[] Buf, int BufLen, ref Type CurVal);
        public delegate void ProcessVal<Type>(Type CurVal, ref Type Val);

        private bool IsOverl;

        bool IsOverlapped
        {
            get
            {
                return IsOverl;
            }
        }

        public enum Mode { first };
        public FileProcess(string fileName, StructureInterface<T> interf, Mode mod)
        {

        }

        /*
        Класс, массив экземпляров которых используется при реализации асинхронного и синхронного режимов работы
        */
        public class StateObject
        {
            // буфер для чтения данных
            public byte[] Buf;
            // экземпляр класса FileStream, используется только для асинхронного режима
            public FileStream fs;
            /*
            Логическое значение, показывающее завершение отложенной операции ввода-вывода. Используется только для асинхронного режима. Ключевое слово volatile используется для отключения попыток компилятора при оптимизации сохраниться значение поля в регистре. Это необходимо для корректной работы release версии проекта 
            */
            public volatile bool EndInOut;
            // Количество прочитанных из потока байт
            public int ReadBytes;

            // Конструктор с параметрами
            public StateObject(int BufSz, FileStream fsVal)
            {
                Buf = new byte[BufSz];
                fs = fsVal;
            }

        }

        // Массив объектов состояния
        StateObject[] States = null;

        // Метод инициализации массива объектов состояния

        private void InitBufs(bool IsOverl = false)
        {
            // Количество объектов состояния массива зависит от режима работы.
            int NStates = IsOverl ? 2 : 1;
            States = new StateObject[NStates];
            /*
            // Для повышения скорости работы в асинхронном режиме можно использовать 
            // закомментированные строки кода
                        if (IsOverl)
                            BufLen <<= 4;
             */
            // Инициализация элементов массива
            for (; NStates > 0; NStates--)
                States[NStates - 1] = new StateObject(BufLen, fIn);
        }

        /*
        Конструктор с параметрами. 1-ый аргумент  имя файла, 2-ой режим работы: false  синхронный, а true  асинхронный
        */
        public FileProcess(string FNIn, bool IsOverl = false)
        {
            this.IsOverl = IsOverl;
            if (Init(FNIn, IsOverl))
                InitBufs(IsOverl);
        }
    }
}
