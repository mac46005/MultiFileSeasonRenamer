﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiFileRenamer.ClassLibrary
{
    public class MultiFileRenamer
    {
        private string _folderPath = "";
        private string _albumName = "";
        private string _searchPattern = "";
        public MultiFileRenamer(string folderPath,string albumName,string searchPattern)
        {
            _folderPath = folderPath;
            _albumName = albumName;
            _searchPattern = searchPattern;




            GetListOfFileStringsInPath();
            RenameFiles();

        }


        private List<string> ListFiles { get; set; } = new List<string>();

        private void GetListOfFileStringsInPath()
        {
            foreach (string file in Directory.GetFiles(_folderPath, _searchPattern))
            {
                ListFiles.Add(file);
            }
        }
        private void RenameFiles()
        {
            for (int i = 0; i < ListFiles.Count; i++)
            {
                File.Copy(ListFiles[i],$"{_albumName + (i + 1)}") ;
            }
        }

    }
}
