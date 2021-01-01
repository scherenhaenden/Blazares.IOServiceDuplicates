using System.Collections.Generic;
using System.IO;
using System.Linq;
using Blazares.IOServiceDuplicates.Engine.Hashers;
using Blazares.IOServiceDuplicates.Engine.Models;

namespace Blazares.IOServiceDuplicates.Engine.DeleteDuplicates
{
    public class FileModelDeleteDuplicates
    {
        private readonly IFileHasher fileHasher;

        public FileModelDeleteDuplicates(IFileHasher fileHasher)
        {
            this.fileHasher = fileHasher;
        }

        public List<FileModel> Run(List<FileModel> allFiles)
        {
            var totalDupeItems = allFiles.GroupBy (x => x.GeneralFileInformation.Length).Where (x => x.Skip (1).Any ()).ToList();
            foreach(var groupd in totalDupeItems)
            {
                var resultwithHash=EachGroupGetHash (groupd);
                var ListToDelete= DeleteDuplicates(resultwithHash);
                foreach (var eachHashedFile in ListToDelete) 
                {
                    File.Delete (eachHashedFile.FullPathOfFile);
                    allFiles.RemoveAll (x => x.FullPathOfFile == eachHashedFile.FullPathOfFile);
                }
            }
            return allFiles;            
        }

        public List<FileModel> EachGroupGetHash(IGrouping<long,FileModel> igr)
        {
            List<FileModel> Files = new List<FileModel> ();
            foreach (var gr in igr) 
            {
                gr.Hash = fileHasher.GetHashFromFileByPath (gr.FullPathOfFile);
                Files.Add (gr);
            }
            return Files;

        }
        public List<FileModel> DeleteDuplicates(List<FileModel> eachGroupGetHash)
        {
            string PivotValue = eachGroupGetHash [0].FullPathOfFile;
            List<FileModel> Deletable = new List<FileModel> ();

            var NotSame=eachGroupGetHash.Where (x => x.FullPathOfFile != PivotValue).ToList ();

            foreach (var file in NotSame) 
            {
                if (file.FullPathOfFile != PivotValue && file.Hash == eachGroupGetHash [0].Hash) 
                {
                    Deletable.Add (file);
                }
            }
            return Deletable;
        }
    }
}