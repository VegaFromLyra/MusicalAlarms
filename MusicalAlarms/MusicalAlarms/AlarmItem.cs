using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO.IsolatedStorage;

namespace MusicalAlarms
{
    public class AlarmItem
    {
        private DateTime alarmTime = new DateTime();
        public DateTime AlarmTime
        {
            get
            {
                return alarmTime;
            }

            set
            {
                alarmTime = value;
            }
        }

        private String songName;
        public String SongName
        {
            get
            {
                return songName;
            }

            set
            {
                songName = value;
            }
        }

        public String AlarmTimeTitle
        {
            get
            {
                return alarmTime.ToShortTimeString();
            }
        }

        private bool isNew = true;
        public bool IsNew
        {
            get
            {
                return isNew;
            }

            set
            {
                isNew = value;
            }
        }

        private Object uiObject = null;
        public Object UIObject
        {
            get
            {
                return uiObject;
            }

            set
            {
                uiObject = value;
            }
        }
       
    }
}
