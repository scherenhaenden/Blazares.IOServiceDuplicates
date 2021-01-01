using System.Collections.Generic;

namespace Blazares.IOServiceDuplicates.Engine.FilesFinder
{
    public interface IFilesSeeker
    {
        List<string> ByPath(string path);
        
        List<string> ByPathAndExtensions(string path, string [] wantedExtensions);

    }
}