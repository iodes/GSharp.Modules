using System;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

namespace GSharp.Modules.Core.Time
{
    public class GDateTime : GModule
    {
        #region 속성
        [GCommand("현재 연")]
        public static int Year
        {
            get
            {
                return DateTime.Now.Year;
            }
        }

        [GCommand("현재 월")]
        public static int Month
        {
            get
            {
                return DateTime.Now.Month;
            }
        }

        [GCommand("현재 일")]
        public static int Day
        {
            get
            {
                return DateTime.Now.Day;
            }
        }

        [GCommand("현재 시")]
        public static int Hour
        {
            get
            {
                return DateTime.Now.Hour;
            }
        }

        [GCommand("현재 분")]
        public static int Minute
        {
            get
            {
                return DateTime.Now.Minute;
            }
        }

        [GCommand("현재 초")]
        public static int Second
        {
            get
            {
                return DateTime.Now.Second;
            }
        }
        #endregion
    }
}
