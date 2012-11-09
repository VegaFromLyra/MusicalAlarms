using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Scheduler;

namespace MusicalAlarms
{
    public partial class NewAlarm : PhoneApplicationPage
    {
        EditAlarmViewModel _viewModel = new EditAlarmViewModel();

        public NewAlarm()
        {
            InitializeComponent();
        }

        // TODO - Need to add code to hydrate/re-hydrate this page

        private string alarmTimeOnADay;
        private void timePickerValueChanged(object sender, DateTimeValueChangedEventArgs e)
        {
            if (e.NewDateTime.Value != null)
            {
                (sender as TimePicker).ValueStringFormat = e.NewDateTime.Value.ToLongTimeString();
                alarmTimeOnADay = e.NewDateTime.Value.ToLongTimeString();
            }
        }

        // private bool _didNavigateToAlarmDayPicker = false;
        private void RepeatAlarmButton_Clicked(object sender, RoutedEventArgs e)
        {
            // _didNavigateToAlarmDayPicker = true;
            NavigationService.Navigate(new Uri("/AlarmDayPicker.xaml", UriKind.Relative));
        }

        private bool _didNavigateToSongPicker = false;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (_didNavigateToSongPicker == true)
            {
                // songName is in App.SongName
                _didNavigateToSongPicker = false;

                if (App.SongName != null)
                {
                    SoundPickerButton.Content = App.SongName;
                }
            }
        }

        // TODO - need to update sound picker button with 
        // the name of the selected song
        private void soundpicker_Clicked(object sender, RoutedEventArgs e)
        {
            _didNavigateToSongPicker = true;
            NavigationService.Navigate(new Uri("/SongPicker.xaml", UriKind.Relative));
        }
        

        private void On_AppBar_Save(object sender, EventArgs e)
        {            
            // alarm time 
            // song name to be played when alarm is triggered

            DateTime alarmTime = DateTime.Parse(alarmTimeOnADay);

            // the alarm needs to go off the next day so 
            // add 1

            alarmTime.AddDays(1.0);

            AlarmItem alarm = new AlarmItem();
            alarm.AlarmTime = alarmTime;
            alarm.SongName = App.SongName;
            // Do we need to send some UI object from the main page here ?

            App.ListAlarms.Add(alarm);

            NavigationService.GoBack();
        }

    }

}