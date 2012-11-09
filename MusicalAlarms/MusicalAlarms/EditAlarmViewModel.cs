using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicalAlarms
{
    class EditAlarmViewModel
    {

        public EditAlarmViewModel()
        {
            Initialize();
        }

        private Dictionary<string, string> _longShortDayPairs = new Dictionary<string,string>();

        public void Initialize()
        {
            _longShortDayPairs.Add("Monday",    "Mon");
            _longShortDayPairs.Add("Tuesday",   "Tue");
            _longShortDayPairs.Add("Wednesday", "Wed");
            _longShortDayPairs.Add("Thursday",  "Thu");
            _longShortDayPairs.Add("Friday",    "Fri");
            _longShortDayPairs.Add("Saturday",  "Sat");
            _longShortDayPairs.Add("Sunday",    "Sun");
        }

        public string ConvertDayToShorterVersion(string fullNameDay)
        {
            return _longShortDayPairs[fullNameDay];
        }

        public string CheckForAllWeekdays(List<string> alarmDays)
        {
            if (alarmDays.Contains("Monday") &&
                alarmDays.Contains("Tuesday") &&
                alarmDays.Contains("Wednesday") &&
                alarmDays.Contains("Thursday") &&
                alarmDays.Contains("Friday"))
            {
                return "weekdays";
            }

            return null;
        }

        public string CheckForBothWeekends(List<string> alarmDays)
        {
            if (alarmDays.Contains("Saturday") &&
                alarmDays.Contains("Sunday"))
            {
                return "weekends";
            }

            return null;
        }

    }
}
