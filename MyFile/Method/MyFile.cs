using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MyFile.Method
{
    class MyFile : AbsFile
    {
        public override string Read()
        {
            return File.ReadAllText(filePath);
        }

        public override void Write()
        {
            File.WriteAllText(filePath, msg);
        }

        public override void Append()
        {
            File.AppendAllText(filePath, msg);
        }
    }
}
