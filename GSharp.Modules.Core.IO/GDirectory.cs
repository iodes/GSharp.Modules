using System.IO;
using System.Linq;
using System.Collections.Generic;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

namespace GSharp.Modules.Core.IO
{
    public class GDirectory : GModule
    {
        #region 내부 함수
        private static void CopyDirectory(string source, string destination, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(source);

            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destination, file.Name);
                file.CopyTo(temppath, false);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    CopyDirectory(subdir.FullName, Path.Combine(destination, subdir.Name), copySubDirs);
                }
            }
        }
        #endregion

        #region 사용자 함수
        [GCommand("{0}에서 {1}로 폴더 복사")]
        public static void Copy(string source, string destination)
        {
            if (Directory.Exists(source))
            {
                CopyDirectory(source, destination, true);
            }
        }

        [GCommand("{0}에서 {1}로 폴더 이동")]
        public static void Move(string source, string destination)
        {
            if (Directory.Exists(source))
            {
                Directory.Move(source, destination);
            }
        }

        [GCommand("{0}에서 {1}폴더 생성")]
        public static void Create(string path, string name)
        {
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(string.Format(@"{0}\{1}", path, name));
            }
        }

        [GCommand("{0}폴더 삭제")]
        public static void Delete(string source)
        {
            if (Directory.Exists(source))
            {
                Directory.Delete(source, true);
            }
        }

        [GCommand("{0}폴더의 이름을 {1}로 변경")]
        public static void Rename(string source, string name)
        {
            if (Directory.Exists(source))
            {
                Directory.Move(source, string.Format(@"{0}\{1}", new DirectoryInfo(source).Parent.FullName, name));
            }
        }

        [GCommand("{0}폴더에서 {1}파일 찾기")]
        public static List<object> GetFiles(string path, string pattern)
        {
            return Directory.GetFiles(path, pattern, SearchOption.AllDirectories).ToList<object>();
        }
        #endregion
    }
}
