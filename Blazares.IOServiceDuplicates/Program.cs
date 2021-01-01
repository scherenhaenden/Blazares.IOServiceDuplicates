using System;
using Blazares.IOServiceDuplicates.Engine.DeleteDuplicates;
using Blazares.IOServiceDuplicates.Engine.FilesFinder;
using Blazares.IOServiceDuplicates.Engine.Hashers;
using Blazares.IOServiceDuplicates.Engine.Models;

namespace Blazares.IOServiceDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            //FIXME: also tech deb
            
            /*IFilesSeeker filesSeeker = new FilesSeeker();
            var files = filesSeeker.ByPath("");
            
            GenerateFiles gf = new GenerateFiles ();
            var allFiles=gf.StringsToModels (files.ToArray());
            
            var value =new FileModelDeleteDuplicates(new FileHasherMd5()).Run(allFiles);*/
            
            Console.WriteLine("Hello World!");
        }
    }
}