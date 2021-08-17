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

            string path = IoC.Get<IOHelper>().FolderPath();
            _folderContentsRenamer.FolderPath = path;
            FolderPath = path;
            FolderResult = _folderContentsRenamer.FileRenamerResult;
        }
        public FileRenamerResult FolderResult { get; set; } = FileRenamerResult.FolderNotPicked;
        public string FolderPath { get; set; }
        public string AlbumName { get; set; }
        public string SearchPattern { get; set; }


        public void Rename()
        {

        }
    }
}
