using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MultiFileRenamer.ClassLibrary.IOHelper;

namespace MultiFileRenamer.ClassLibrary
{
    public class FolderContentsRenamer
    {
        public FileRenamerResult FileRenamerResult { get; set; }
        public string FolderPath { get; set; }

        public string AlbumName { get; set; }
        public string SearchPattern { get; set; }
        public List<string> AllShortNameFolderContents { get; set; }


        public FileRenamerResult SetFolderPath()
        {
            FileRenamerResult result = FileRenamerResult.FolderNotExists;
            (string folderPath,bool exists) = GetFolderPath();
            if (exists == true)
            {
                FolderPath = folderPath;
                SetAllShortNameFolderContents();
                result = FileRenamerResult.FolderExists;
            }
            return result;
        }


        private void SetAllShortNameFolderContents()
        {
            AllShortNameFolderContents.AddRange(FolderContentShortName(FolderPath));
        }




        public void RenameSpecificExtensionFiles()
        {
            var extensionSpecificFiles = AllFolderContentFullFilePath(FolderPath, SearchPattern);
            for (int i = 0; i < extensionSpecificFiles.Length; i++)
            {
                try
                {
                    CopyAndDeleteOriginalFile(extensionSpecificFiles[i], $"{AlbumName + (i + 1)}");
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
