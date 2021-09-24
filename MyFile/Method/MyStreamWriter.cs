using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MyFile.Method
{
    class MyStreamWriter : AbsFile
    {
        public override string Read()
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                return sr.ReadToEnd();
            }
        }

        public override void Write()
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(msg);
            }
        }

        public override void Append()
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(msg);
            }
        }

    }
}
