using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Blazares.IOServiceDuplicates.Engine.FilesFinder
{
    public class FilesSeeker: IFilesSeeker
    {
        public List<string> ByPath(string path)
        {
            return ByPathAndExtensions(path, null);
        }

        //FIXME: do this better
        public List<string> ByPathAndExtensions(string path, string[] wantedExtensions)
        {
            List<string> files = Directory
                .GetFiles(path, "*.*", System.IO.SearchOption.AllDirectories).ToList();

            if (wantedExtensions != null)
            {
                files = files.Where(file => wantedExtensions.Any(file.EndsWith))?
                    .ToList();
            }

            
            return files;
        }
    }
}