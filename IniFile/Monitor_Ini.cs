using System;
using System.Collections.Generic;
using System.Text;

namespace IniFileLibrary
{
    public class Monitor_Ini : IniFile
    {
        public int IntervalTime = 0;
        public int IntervalMinute = 1;
        public const int OneMinute = 60000;//1000ms * 60s = 1 min
        public Monitor_Ini()
        {
            Get();
        }
        public void Set()
        {
            IniWriteValue("Monitor", "IntervalMinute", IntervalMinute.ToString());
        }
        public void Get()
        {
            IntervalMinute = 1;
            int.TryParse(IniReadValue("Monitor", "IntervalMinute"), out IntervalMinute); if (0 == IntervalMinute) { IntervalMinute = 1; }
            this.IntervalTime = IntervalMinute * OneMinute;
            //this.IntervalTime = 2000;
        }
    }
}
