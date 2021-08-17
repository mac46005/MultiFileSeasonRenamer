using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiFileRenamer.ClassLibrary
{
    public class FolderContentsRenamer
    {
        public FolderContentsRenamer()
        {

        }
        public FileRenamerResult FileRenamerResult { get; set; }

        private string _folderPath = "";
        public string FolderPath
        {
            get { return _folderPath; }
            set
            {
                if (Directory.Exists(value))
                {
                    _folderPath = value;
                    FileRenamerResult = FileRenamerResult.FolderExists;
                }
                else
                {
                    _folderPath = "";
                    FileRenamerResult = FileRenamerResult.FolderNotExists;
                }
            }
        }

        public string AlbumName { get; set; }
        public string SearchPattern { get; set; }



        private List<string> _listFiles;
        private List<string> ListFiles
        {
            get { return _listFiles; }
            set
            {
                if (value.Count > 0)
                {
                    _listFiles = value;
                    GetListOfFileStringsInPath();
                }
                else
                {
                    _listFiles = null;
                }
            }
        }




        private void GetListOfFileStringsInPath()
        {
            foreach (string file in Directory.GetFiles(_folderPath, SearchPattern))
            {
                ListFiles.Add(file);
            }
        }




        public void RenameFiles()
        {
            for (int i = 0; i < ListFiles.Count; i++)
            {
                try
                {
                    File.Copy(ListFiles[i], $"{AlbumName + (i + 1)}");
                    File.Delete(ListFiles[i]);
                    FileRenamerResult = FileRenamerResult.SuccessfullyRenamed;
                }
                catch (IOException ex)
                {
                    FileRenamerResult = FileRenamerResult.UnsuccessfullyRenamed;
                }
            }
        }

    }
}
