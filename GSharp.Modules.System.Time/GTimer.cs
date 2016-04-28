using System.Timers;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

namespace GSharp.Modules.System.Time
{
    public class GTimer : GModule
    {
        #region 이벤트
        [GCommand("시간이 변경된 경우")]
        public static event ElapsedEventHandler Elapsed;
        public delegate void ElapsedEventHandler();

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Elapsed?.Invoke();
        }
        #endregion

        #region 생성자
        static GTimer()
        {
            Timer timer = new Timer()
            {
                Interval = 1,
            };
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }
        #endregion
    }
}
