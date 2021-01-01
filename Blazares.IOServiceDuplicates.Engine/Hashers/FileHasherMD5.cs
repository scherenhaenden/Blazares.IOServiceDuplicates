using System;
using System.IO;
using System.Security.Cryptography;

namespace Blazares.IOServiceDuplicates.Engine.Hashers
{
    public class FileHasherMd5: IFileHasherMd5
    {
        //FIXME: look if this is the fasttest way
        public string GetHashFromFileByPath(string filePath)
        {
            var sFile = new BufferedStream(File.OpenRead(filePath), 1200000);
            var hashvalue = MD5.Create();
            string first = BitConverter.ToString(hashvalue.ComputeHash(sFile)).Replace("-", string.Empty);
            sFile.Flush();
            sFile.Close();
            return first;
        }
    }
}