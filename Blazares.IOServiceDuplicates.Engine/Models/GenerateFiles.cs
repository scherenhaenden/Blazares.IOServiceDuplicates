using System.Collections.Generic;

namespace Blazares.IOServiceDuplicates.Engine.Models
{
    public class GenerateFiles
    {
        public GenerateFiles ()
        {
        }

        public List<GeneralFileModel> StringsToModels(string [] Files)
        {
            List<GeneralFileModel> AllFiles = new List<GeneralFileModel> ();
            GeneralFileModel TempFile;
            foreach(var filestring in Files)
            {
				
                TempFile = new GeneralFileModel ();
                TempFile.FullPathOfFile = filestring;
                AllFiles.Add (TempFile);
            }
            return AllFiles;
        }

    }
}