using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Clock
{
    public static class TravelTo
    {
        public static DateTime SomeFutureTime()
        {
            return new DateTime(2020, 01, 10, 00, 00, 00);
        }

        public static DateTime SomeFarAwayFutureTime()
        {
            return new DateTime(2100, 01, 01, 00, 00, 00);
        }

        public static DateTime SomePastTime()
        {
            return new DateTime(2010, 01, 01, 00, 00, 00);
        }

        public static DateTime SomeFarAwayPastTime()
        {
            return new DateTime(1990, 01, 01, 00, 00, 00);
        }
    }
}