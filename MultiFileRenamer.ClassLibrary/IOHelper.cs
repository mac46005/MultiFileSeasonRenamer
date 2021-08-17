using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFileRenamer.ClassLibrary
{
    public static class IOHelper
    {
        public static (string, bool) GetFolderPath()
        {
            var folder = new FolderBrowserDialog();
            string path = "";
            bool doesExists = false;
            if (folder.ShowDialog() == DialogResult.OK)
            {
                path = folder.SelectedPath;
                doesExists = true;
            }
            return (path, doesExists);
        }
        public static string[] AllFolderContentFullFilePath(string directory)
        {
            try
            {
                return Directory.GetFiles(directory);
            }
            catch (IOException ex)
            {

                throw;
            }
        }
        public static string[] AllFolderContentFullFilePath(string directory,string searchPattern)
        {
            try
            {
                return Directory.GetFiles(directory,searchPattern);
            }
            catch (IOException ex)
            {

                throw;
            }
        }
        public static string[] FolderContentShortName(string directory)
        {
            try
            {
                string[] fileNames = { };
                var filePaths = Directory.GetFiles(directory);
                for (int i = 0; i < filePaths.Length; i++)
                {
                    FileInfo fileInfo = new FileInfo(filePaths[i]);
                    fileNames[i] = fileInfo.Name;
                }
                return fileNames;
            }
            catch (IOException ex)
            {

                throw;
            }

        }
        public static string[] FolderContentShortName(string directory,string searchPattern)
        {
            try
            {
                string[] fileNames = { };
                var filePaths = Directory.GetFiles(directory,searchPattern);
                for (int i = 0; i < filePaths.Length; i++)
                {
                    FileInfo fileInfo = new FileInfo(filePaths[i]);
                    fileNames[i] = fileInfo.Name;
                }
                return fileNames;
            }
            catch (IOException ex)
            {

                throw;
            }

        }


        public static void CopyAndDeleteOriginalFile(string filePath, string newFileName)
        {
            try
            {
                File.Copy(filePath, newFileName);
                DeleteFile(filePath);
            }
            catch (IOException ex)
            {
                throw;
            }
        }


        public static void DeleteFile(string filePath)
        {
            try
            {
                File.Delete(filePath);
            }
            catch (IOException ex)
            {

                throw;
            }
        }
    }
}
