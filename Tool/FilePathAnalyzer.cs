using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mklinker.Tool {
    class FilePathAnalyzer {
        bool exist;
        bool isFile;
        char driveLetter;
        string[] folders;
        string target;

        public FilePathAnalyzer(string filePath) {
            char[] separator = { '\\', '/' };
            string[] splited = filePath.Split(separator);
            folders = new string[splited.Length - 2];
            for (int i = 0; i < splited.Length - 2; i++) {
                folders[i] = splited[i + 1];
            }
            target = splited[splited.Length - 1];


            driveLetter = '-';
            driveLetter = GetDriveLetter(filePath);

        }

        private char GetDriveLetter(string filePath) {
            char[] separator = { ':' };
            string[] splited = filePath.Split(separator);
            return splited[0][0];
        }


        public char DriveLetter {
            get { return driveLetter; }
        }
        public string[] Folders {
            get { return folders; }
        }

        /// <summary>
        /// 自身より上部の階層にいくつフォルダーがあるか。ドライブ文字と自分自身を数えない。
        /// </summary>
        public int FolderDepth {
            get { return folders.Length; }
        }

        public string ParentFolder {
            get { return folders[folders.Length - 1]; }
        }

        public string Target {
            get { return target; }
        }

        public string FilePath {
            get {
                string filePath = driveLetter + @":\";
                foreach (var item in folders) {
                    filePath += item + "\\";
                }
                filePath += target;
                return filePath;
            }
        }

    }
}
