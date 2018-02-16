using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDLauncher.Utils
{
    public class StringUtils
    {

        public static String ToString(TimeSpan time)
        {
            if (time.Days > 1)
                return ((int)time.TotalDays) + "d " + ((int)time.TotalHours) + "h " + ((int)time.TotalMinutes) + "m";
            else if (time.Hours > 1)
                return ((int)time.TotalHours) + "h " + ((int)time.TotalMinutes) + "m " + ((int)time.TotalSeconds) + "s";
            else if (time.Minutes > 1)
                return ((int)time.TotalMinutes) + "m " + ((int)time.TotalSeconds) + "s";
            else if (time.TotalSeconds > 1)
                return ((int)time.TotalSeconds) + "s " + ((int)time.TotalMilliseconds) + "ms";
            else
                return ((int)time.TotalMilliseconds) + "ms";
        }

    }
}
