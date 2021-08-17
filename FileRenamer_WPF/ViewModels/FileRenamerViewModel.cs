using Caliburn.Micro;
using MultiFileRenamer.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileRenamer_WPF.ViewModels
{
    internal class FileRenamerViewModel : Caliburn.Micro.Screen
    {
        private FolderContentsRenamer _folderContentsRenamer;

        public FileRenamerViewModel(FolderContentsRenamer folderContentsRenamer)
        {
            _folderContentsRenamer = folderContentsRenamer;
        }



        public void ChooseFolder()
        {
            FolderResult = _folderContentsRenamer.SetFolderPath();
            FolderPath = _folderContentsRenamer.FolderPath;
            Files = _folderContentsRenamer.AllShortNameFolderContents;
        }
        public FileRenamerResult FolderResult { get; set; } = FileRenamerResult.FolderNotPicked;
        public List<string> Files { get; set; }
        public string FolderPath { get; set; }
        public string AlbumName { get; set; }
        public string SearchPattern { get; set; } 

        public void Rename()
        {
            _folderContentsRenamer.AlbumName = AlbumName;
            _folderContentsRenamer.SearchPattern = SearchPattern;
            _folderContentsRenamer.RenameSpecificExtensionFiles();
            if (((int)_folderContentsRenamer.FileRenamerResult) == 4)
            {
                MessageBox.Show("Successfully Renamed Files.");
            }
            else
            {
                MessageBox.Show("Unsuccessfully renamed files. Please try again!!");
            }


            

        }


        private void Reset()
        {
            _folderContentsRenamer = IoC.Get<FolderContentsRenamer>();
            FolderPath = null;
            AlbumName = null;
            SearchPattern = null;
            Files = null;

        }

    }
}
