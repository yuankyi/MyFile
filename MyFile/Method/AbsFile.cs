using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;

namespace MyFile.Method
{
    abstract class AbsFile
    {
        protected string filePath;

        public abstract string Read();

        public abstract void Write();

        public abstract void Append();

        protected string msg
        {
            get { return DateTime.Now.ToString(); }
        }

        protected AbsFile()
        {
            var fileDirc = Application.StartupPath + @"\files";
            var fileName = this.GetType().FullName;
            filePath = string.Format(@"{0}\{1}.txt", fileDirc, fileName);
        }
    }
}
