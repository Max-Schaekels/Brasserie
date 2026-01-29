using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.Model
{
    public class Counter
    {
        public Counter()
        {
            CounterValue = 0;
            LimitiMax = 10;
            PreAlarmThresold = 8;
            UpdatePreAlarmStatus();
        }

        public int CounterValue { get; set; }
        public int LimitiMax { get; set; }
        public int PreAlarmThresold { get; set; }
        public bool IsInPreAlarm { get; private set; }

        public void Increment()
        {
            if (CounterValue + 1 <= LimitiMax)
            {
                CounterValue++;
                UpdatePreAlarmStatus();
            }
        }

        private void UpdatePreAlarmStatus()
        {
            IsInPreAlarm = CounterValue >= PreAlarmThresold;
        }
    }
}
