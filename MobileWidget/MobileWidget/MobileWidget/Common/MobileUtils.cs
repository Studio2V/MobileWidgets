using System.Timers;

namespace MobileWidget.Common
{
    public class MobileUtils
    {
        private static MobileUtils instance;

        public static MobileUtils Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new MobileUtils();
                }
                return instance;
            }
        }

        public Timer TimerWrap;

        private MobileUtils()
        {
            TimerWrap = new Timer()
            {
                Interval = 8000,
                Enabled = true
            };
        }
    }
}
