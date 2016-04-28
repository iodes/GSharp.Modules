using System.IO;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

namespace GSharp.Modules.System.IO
{
    public class GFile : GModule
    {
        #region 사용자 함수
        [GCommand("{object}에서 {object}로 파일 복사")]
        public static void Copy(string source, string destination)
        {
            if (File.Exists(source))
            {
                File.Copy(source, destination);
            }
        }

        [GCommand("{object}에서 {object}로 파일 이동")]
        public static void Move(string source, string destination)
        {
            if (File.Exists(source))
            {
                File.Move(source, destination);
            }
        }

        [GCommand("{object}파일 삭제")]
        public static void Delete(string source)
        {
            if (File.Exists(source))
            {
                File.Delete(source);
            }
        }

        [GCommand("{object}파일의 이름을 {object}로 변경")]
        public static void Rename(string source, string name)
        {
            if (File.Exists(source))
            {
                File.Move(source, string.Format(@"{0}\{1}", Path.GetDirectoryName(source), name));
            }
        }
        #endregion
    }
}
