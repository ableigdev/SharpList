using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Students
{
    class FileSimple
    {
        protected FileStream fIn;
        protected long FLen;
        protected int BufLen;

        protected void FreeRes()
        {
            FileBase.CloseFile(ref fIn);
        }

        protected bool OpenFiles(string FNIn, bool IsOverl = false)
        {
            FreeRes();
            FileBase.GetClusterSize(FNIn, ref BufLen);
            FileBase.OpenFile(ref fIn, FNIn, BufLen, true, IsOverl);

            return true;
        }

        public FileSimple()
        {
        }

        ~FileSimple()
        {
            FreeRes();
        }

        public bool CanWork()
        {
            return fIn != null;
        }

        public bool Init(string FNIn, bool IsOverl = false)
        {
            return OpenFiles(FNIn, IsOverl);
        }

        public long GetInputFileSize()
        {
            return FLen != 0 ? FLen : CanWork() ? (FLen = fIn.Length) : 0;
        }
    }
}
