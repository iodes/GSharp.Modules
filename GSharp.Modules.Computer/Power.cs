using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System.Diagnostics;

namespace GSharp.Modules.Computer
{
    public class Power : GModule
    {
        [GCommand("{0}초 후에 컴퓨터 종료하기")]
        public static void systemShutdown(float sec)
        {
            Process.Start("shutdown.exe", "-s -t " + ((int)sec).ToString());
        }

        [GCommand("{0}초 후에 컴퓨터 로그오프하기")]
        public static void systemReboot(float sec)
        {
            Process.Start("shutdown.exe", "-r -t " + ((int)sec).ToString());
        }

        [GCommand("컴퓨터 종료명령 취소하기")]
        public static void cancelShutdown()
        {
            Process.Start("shutdown.exe", "-a");
        }
    }
}
