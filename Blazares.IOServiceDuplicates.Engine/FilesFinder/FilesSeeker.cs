using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Blazares.IOServiceDuplicates.Engine.FilesFinder
{
    public class FilesSeeker: IFilesSeeker
    {
        //FIXME: do this better
        public List<string> ByPath(string path, string[] wantedExtensions = null)
        {
            List<string> files = Directory
                .GetFiles(path, "*.*", SearchOption.AllDirectories).ToList();

            if (wantedExtensions != null)
            {
                files = files.Where(file => wantedExtensions.Any(file.EndsWith))?
                    .ToList();
            }
            return files;
        }
    }
}