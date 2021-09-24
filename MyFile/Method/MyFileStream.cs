using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace MyFile.Method
{
    class MyFileStream : AbsFile
    {
        public override string Read()
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                var length = (int)fs.Length;
                byte[] bytes = new byte[length];
                fs.Read(bytes, 0, length);
                return Encoding.Default.GetString(bytes);
            }
        }

        public override void Write()
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                var bytes = Encoding.Default.GetBytes(msg);
                fs.Write(bytes, 0, bytes.Length);
            }
        }

        public override void Append()
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Append))
            {
                var bytes = Encoding.Default.GetBytes(msg);
                fs.Write(bytes, 0, bytes.Length);
            }
        }

    }
}
