using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System;

namespace GSharp.Modules.System
{
    public class Common : GModule
    {
        [GCommand("시스템 디렉토리 경로")]
        public static string Dir_Sys
        {
            get
            {
                return Environment.SystemDirectory;
            }
        }

        [GCommand("현재 디렉토리 경로")]
        public static string Dir_Cur
        {
            get
            {
                return Environment.CurrentDirectory;
            }
        }

        [GCommand("NETBIOS 이름")]
        public static string NETBIOS_name
        {
            get
            {
                return Environment.MachineName;
            }
        }

        [GCommand("도메인 이름")]
        public static string Domain_name
        {
            get
            {
                return Environment.UserDomainName;
            }
        }

        [GCommand("사용자 이름")]
        public static string OS_name
        {
            get
            {
                return Environment.UserName;
            }
        }

        [GCommand("컴퓨터 켜진 시간(ms)")]
        public static string Computer_time
        {
            get
            {
                return Environment.TickCount.ToString();
            }
        }

        [GCommand("OS 버전")]
        public static string OS_Ver
        {
            get
            {
                return Environment.OSVersion.ToString();
            }
        }

        [GCommand("사용자 운영체제")]
        public static string OS_rname
        {
            get
            {
                OperatingSystem os = Environment.OSVersion;
                Version v = os.Version;
                string os_names = "";
                if (v.Major == 5)
                {
                    if (v.Minor == 0)
                    {
                        os_names = "Windows 2000";
                    }
                    else if (v.Minor == 1)
                    {
                        os_names = "Windows XP";
                    }
                    else if (v.Minor == 2)
                    {
                        os_names = "Windows XP Professional x64 Edition";

                    }
                }
                else if (v.Major == 6)
                {
                    if (v.Minor == 0)
                    {
                        os_names = "Windows Vista";
                    }
                    else if (v.Minor == 1)
                    {
                        os_names = "Windows 7";
                    }
                    else if (v.Minor == 2)
                    {
                        os_names = "Windows 8";
                    }
                    else if (v.Minor == 3)
                    {
                        os_names = "Windows 8.1";
                    }
                }
                else if (v.Major == 10)
                {
                    if (v.Minor == 0)
                    {
                        os_names = "Windows 10";
                    }
                }

                return os_names;
            }
        }
    }
}
