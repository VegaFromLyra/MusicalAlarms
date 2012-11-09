using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.ComponentModel;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace MusicalAlarms
{

    public partial class AlarmDayPicker : PhoneApplicationPage
    {
        AlarmDayPickerModel _viewModel;
        bool _isNewPageInstance = false;

        public AlarmDayPicker()
        {
            InitializeComponent();
            _isNewPageInstance = true;
        }

        private List<ListBoxItem> selectedItems = new List<ListBoxItem>();

        private void DayPicker_ItemsSelected(object sender, SelectionChangedEventArgs e)
        {
            selectedItems.Clear();
            foreach (ListBoxItem item in (sender as ListBox).SelectedItems)
            {
                selectedItems.Add(item);
            }
        }

        private void On_AppBarSave_Clicked(object sender, EventArgs e)
        {
            foreach(ListBoxItem item in selectedItems)
            {
                // App.AlarmDays.Add(item.Content.ToString());       
            }
            
            NavigationService.GoBack();
        }

        private void On_AppBarCancel_Clicked(object sender, EventArgs e)
        {
            // App.AlarmDays.Clear();
            NavigationService.GoBack();
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            // App.AlarmDays.Clear();
            e.Cancel = false;
        }


        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (e.NavigationMode != System.Windows.Navigation.NavigationMode.Back)
            {
                State["ViewModel"] = _viewModel;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (_isNewPageInstance)
            {
                // App.AlarmDays.Clear();

                if (_viewModel == null)
                {
                    if (State.Count > 0)
                    {
                        _viewModel = (AlarmDayPickerModel)State["ViewModel"];
                    }
                    else
                    {
                        _viewModel = new AlarmDayPickerModel();
                    }
                }

                DataContext = _viewModel;
            }

            _isNewPageInstance = false;
        }

    }
}