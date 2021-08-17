using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFileRenamer.ClassLibrary
{
    public class IOHelper
    {
        public string FolderPath()
        {
            var folder = new FolderBrowserDialog();
            var path = "";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                path = folder.SelectedPath;
            }
            return path;
        }
    }
}
