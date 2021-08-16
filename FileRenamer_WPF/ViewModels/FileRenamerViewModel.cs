using Caliburn.Micro;
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


        public FileRenamerViewModel()
        {

        }



        public void ChooseFolder()
        {

            var folder = IoC.Get<FolderBrowserDialog>();
            var path = "";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                path = folder.SelectedPath;
            }
        }
        public string AlbumName { get; set; }
        public string SearchPattern { get; set; }



    }
}
