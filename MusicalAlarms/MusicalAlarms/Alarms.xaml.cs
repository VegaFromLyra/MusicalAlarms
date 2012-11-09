using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Threading;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MusicalAlarms
{
    public partial class MainPage : PhoneApplicationPage
    {
        private ObservableCollection<AlarmItem> _listAlarms = new ObservableCollection<AlarmItem>();  

        // Constructor
        public MainPage()
        {            
            InitializeComponent();
        }

        private void OnAddClicked(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/EditAlarm.xaml", UriKind.Relative));
        }

        // This alarmvidemodel needs to be passed in from MainPage.xaml
        private AlarmViewModel _alarmViewModel;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (PhoneApplicationService.Current.State.ContainsKey("AlarmViewModel"))
            {
                _alarmViewModel = (AlarmViewModel)PhoneApplicationService.Current.State["AlarmViewModel"];

                foreach (AlarmItem alarm in App.ListAlarms)
                {
                    _alarmViewModel.AddAlarm(alarm, listBoxAlarms);
                    _listAlarms.Add(alarm);
                }

                if (_listAlarms.Count > 0)
                {
                    listBoxAlarms.ItemsSource = _listAlarms;
                    NoAlarmsTextBlock.Visibility = System.Windows.Visibility.Collapsed;
                }
                else
                {
                    NoAlarmsTextBlock.Visibility = System.Windows.Visibility.Visible;
                }

            }
            else
            {
                // the view model could not be passed! fix it! 
                Debug.Assert(true);
            }
        }

    }
}