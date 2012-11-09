using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Navigation;
using System.Windows.Data;
using System.Globalization;
using Microsoft.Phone.Shell;

namespace MusicalAlarms
{
    public partial class AlarmHomePage : PhoneApplicationPage
    {
        public AlarmHomePage()
        {
            InitializeComponent();
            SetDataContext();
        }

        private void SetDataContext()
        {
            _alarmViewModel = new AlarmViewModel();
            ContentPanel.DataContext = _alarmViewModel;          
        }

        // TODO - Should each page create its own instance or should this 
        // be a singleton ?
        private AlarmViewModel _alarmViewModel;
        private void alarms_Click(object sender, RoutedEventArgs e)
        {
            PhoneApplicationService.Current.State["AlarmViewModel"] = _alarmViewModel;
            NavigationService.Navigate(new Uri("/Alarms.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            _alarmViewModel.StopPlayingSong();
        }

        private void snooze_Click(object sender, RoutedEventArgs e)
        {
            _alarmViewModel.SnoozeSong();
        }
    }

    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
                      object parameter, CultureInfo culture)
        {
            if (value is bool)
            {
                return ((bool)value) ? Visibility.Visible : Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType,
                          object parameter, CultureInfo culture)
        {
            if (value is Visibility)
            {
                return ((Visibility)value) == Visibility.Visible ? true : false;
            }

            return false;
        }
    }
}