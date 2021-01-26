using System.Collections.Generic;

namespace Blazares.IOServiceDuplicates.Engine.FilesFinder
{
    public interface IFilesSeeker
    {
        List<string> ByPath(string path, string [] wantedExtensions = null);

    }
}