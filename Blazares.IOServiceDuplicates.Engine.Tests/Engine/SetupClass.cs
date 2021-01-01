using System;
using System.IO;
using System.Linq;
using Blazares.IOServiceDuplicates.Engine.DeleteDuplicates;
using Blazares.IOServiceDuplicates.Engine.FilesFinder;
using Blazares.IOServiceDuplicates.Engine.Hashers;
using Blazares.IOServiceDuplicates.Engine.Models;
using NUnit.Framework;

namespace Blazares.IOServiceDuplicates.Engine.Tests.Engine
{
    
    public class SetupClass
    {
        private static string TestRunDirectoryPath;
        private static int CountOfOriginFiles;
        
        [OneTimeSetUp]
        public void Setup()
        {
            var currentDirectory = Environment.CurrentDirectory;
            //DirectoryInfo.
            //System.IO.Path.GetDirectoryName(SetupClass..GetEntryAssembly().Location);
            var zusatz = "../../../../TestOrigin";
            var zusatz1 = "../../../../TestRun";
            
            var di = new DirectoryInfo(currentDirectory + zusatz);
            var di2 = new DirectoryInfo(currentDirectory + zusatz1);
            
            //foreach(System.IO.FileInfo file in di2.GetFiles()) file.Delete();
            //foreach(System.IO.DirectoryInfo subDirectory in di2.GetDirectories()) subDirectory.Delete(true);

            var fnss =di.FullName;
            if (di2.Exists)
            {
                Directory.Delete(di2.FullName, true);
            }
            di2.Create();
            

            TestRunDirectoryPath = di2.FullName;

            var files = Directory.GetFiles(fnss).Where(x=> !x.Contains(".directory")).ToArray();

            CountOfOriginFiles = files.Length;
            
            

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                File.Copy(file, di2.FullName + "/" +fileInfo.Name);
                
                //other copies
                
                string fileNameOnly = Path.GetFileNameWithoutExtension(file);
                string extension = Path.GetExtension(file);
                var newName1 = fileNameOnly + "test1" + extension;
                var newName2 = fileNameOnly + "test2" + extension;
                var newName3 = fileNameOnly + "test3" + extension;
                var newName4 = fileNameOnly + "test4" + extension;
                var newName5 = fileNameOnly + "test5" + extension;
                
                File.Copy(file, di2.FullName + "/" +newName1);
                File.Copy(file, di2.FullName + "/" +newName2);
                File.Copy(file, di2.FullName + "/" +newName3);
                File.Copy(file, di2.FullName + "/" +newName4);
                File.Copy(file, di2.FullName + "/" +newName5);
            }
            
            
            Console.WriteLine(currentDirectory);
            
        }
        //07c73e0a87f0bf08c956312289a0263c
        
        [Test]
        public void Test1_FileSeeker_ByPath()
        {
            IFilesSeeker filesSeeker = new FilesSeeker();
            var result = filesSeeker.ByPath(TestRunDirectoryPath);

            var countOfFiles = result.Count;
            var expectedResult = CountOfOriginFiles * 6;
            
            
            Assert.AreEqual(expectedResult, countOfFiles);
        }
        
        
        [Test]
        public void Test2_FileSeeker_ByPath_And_ByExtension()
        {
            IFilesSeeker filesSeeker = new FilesSeeker();
            
            if (!Directory.Exists(TestRunDirectoryPath))
            {
                Setup();
            }
            
            
            var result = filesSeeker.ByPath(TestRunDirectoryPath);

            var countOfFiles = result.Count;
            var expectedResult = CountOfOriginFiles * 6;
            
            
            Assert.AreEqual(expectedResult, countOfFiles);
        }
        
        
        [Test]
        public void Test3_GetHash()
        {
            if (!Directory.Exists(TestRunDirectoryPath))
            {
                Setup();
            }
            
            IFileHasher fileHasher = new FileHasherMd5();
            var hashResult = fileHasher.GetHashFromFileByPath(TestRunDirectoryPath + "/" + "./1c5442f6-6bb6-4ab7-b603-f598e7579dd2");
            Assert.AreEqual("07c73e0a87f0bf08c956312289a0263c", hashResult.ToLower());
        }
        
        
        [Test]
        public void Test9_DeleteDuplicates()
        {
            if (!Directory.Exists(TestRunDirectoryPath))
            {
                Setup();
            }
            
            IFilesSeeker filesSeeker = new FilesSeeker();
            var files = filesSeeker.ByPath(TestRunDirectoryPath);
            files = files.Where(x=> !x.Contains(".directory")).ToList();
            
            GenerateFiles gf = new GenerateFiles ();
            var allFiles=gf.StringsToModels (files.ToArray());
            
            var value =new FileModelDeleteDuplicates(new FileHasherMd5()).Run(allFiles);
            
            
            
            Assert.AreEqual(CountOfOriginFiles, value.Count);
        }
        
        [TearDown]
        public void GlobalTeardown()
        {
            if (Directory.Exists(TestRunDirectoryPath))
            {
                Directory.Delete(TestRunDirectoryPath, true);
            }
        }
    }
}