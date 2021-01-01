using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Blazares.IOServiceDuplicates.FilesFinder
{
    public class FilesSeeker: IFilesSeeker
    {
        public List<string> ByPath(string path)
        {
            return ByPathAndExtensions(path, null);
        }

        public List<string> ByPathAndExtensions(string path, string[] wantedExtensions)
        {
            List<string> files = Enumerable.Where(Directory
                    .GetFiles(path, "*.*", System.IO.SearchOption.AllDirectories), file => Enumerable.Any(wantedExtensions, file.EndsWith))?
                .ToList();
            return files;
        }
    }
}