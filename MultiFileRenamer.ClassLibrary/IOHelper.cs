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
        public (string,bool) FolderPath()
        {
            var folder = new FolderBrowserDialog();
            string path = "";
            bool doesExists = false;
            if (folder.ShowDialog() == DialogResult.OK)
            {
                path = folder.SelectedPath;
                doesExists = true;
            }
            return (path,doesExists);
        }
    }
}
