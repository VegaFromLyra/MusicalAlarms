using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace MusicalAlarms
{

    class AlarmDayPickerModel :INotifyPropertyChanged
    {
        private bool _mondayChecked;
        private bool _tuesdayChecked;
        private bool _wednesdayChecked;
        private bool _thursdayChecked;
        private bool _fridayChecked;
        private bool _saturdayChecked;
        private bool _sundayChecked;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool SundayChecked
        {
            get
            {
                return _sundayChecked;
            }
            set
            {
                _sundayChecked = value;
                NotifyPropertyChanged("SundayChecked");
            }
        }

        public bool MondayChecked
        {
            get
            {
                return _mondayChecked;
            }
            set
            {
                _mondayChecked = value;
                NotifyPropertyChanged("MondayChecked");
            }
        }

        public bool TuesdayChecked
        {
            get
            {
                return _tuesdayChecked;
            }
            set
            {
                _tuesdayChecked = value;
                NotifyPropertyChanged("TuesdayChecked");
            }
        }

        public bool WednesdayChecked
        {
            get
            {
                return _wednesdayChecked;
            }
            set
            {
                _wednesdayChecked = value;
                NotifyPropertyChanged("WednesdayChecked");
            }
        }

        public bool ThursdayChecked
        {
            get
            {
                return _thursdayChecked;
            }
            set
            {
                _thursdayChecked = value;
                NotifyPropertyChanged("ThursdayChecked");
            }
        }

        public bool FridayChecked
        {
            get
            {
                return _fridayChecked;
            }
            set
            {
                _fridayChecked = value;
                NotifyPropertyChanged("FridayChecked");
            }
        }

        public bool SaturdayChecked
        {
            get
            {
                return _saturdayChecked;
            }
            set
            {
                _saturdayChecked = value;
                NotifyPropertyChanged("SaturdayChecked");
            }
        }
    }
}
