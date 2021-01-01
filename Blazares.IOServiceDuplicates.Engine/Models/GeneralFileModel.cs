using System;
using System.IO;

namespace Blazares.IOServiceDuplicates.Engine.Models
{
    public class GeneralFileModel
    {	
        protected string _FullPathOfFile;
        protected string _Path;
        protected string _FileName;
        protected string _Hash;
        protected FileInfo _GeneralFileInformation;
        protected DateTime _DateCreation;

        public DateTime DateCreation
        {
            get
            {
                return _DateCreation;
            }
            set
            {
                _DateCreation=value;

            }
        }

        public string PathOfFile
        {
            get
            {
                return _Path;
            }
            set
            {
                _Path=value;

            }
        }

        public string FullPathOfFile
        {
            get
            {
                return _FullPathOfFile;
            }
            set
            {
				
                _FullPathOfFile=value;
                CheckValues ();
                CreateFileInfo ();

            }
        }
        public string FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName=value;
            }
        }
        public string Hash
        {
            get
            {
                return _Hash;
            }
            set
            {
                _Hash=value;
            }
        }
        public FileInfo GeneralFileInformation
        {
            get
            {
                return _GeneralFileInformation;
            }
            set
            {
                _GeneralFileInformation=value;
            }
        }

        protected void CheckValues()
        {
            if (_FullPathOfFile != "") 
            {
                _FileName = Path.GetFileName (_FullPathOfFile);
                _Path = Path.GetDirectoryName (_FullPathOfFile);
                CreateFileInfo ();
            }
        }

        protected void CreateFileInfo()
        {
            FileInfo FInfo = new FileInfo (_FullPathOfFile);
            _GeneralFileInformation = FInfo;



        }
        protected void GetHashValue()
        {
			
        }
    }
}