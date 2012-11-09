using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace MusicalAlarms
{
    public partial class SongPicker : PhoneApplicationPage
    {
        ObservableCollection<SongPickerViewModel> mySongs = new ObservableCollection<SongPickerViewModel>();  

        public SongPicker()
        { 
            InitializeComponent();

            MediaLibrary library = new MediaLibrary();
            SongCollection songs = library.Songs;

            foreach (Song song in songs)
            {
                SongPickerViewModel mySong = new SongPickerViewModel();
                mySong.Title = song.Name;
                mySongs.Add(mySong);
            }

            listBoxSongs.ItemsSource = mySongs;
        }

        private void On_Selecting_Song(object sender, SelectionChangedEventArgs e)
        {
            SongPickerViewModel songItem = (sender as ListBox).SelectedItem as SongPickerViewModel;
            // TODO - highlight selected item
            // add play icon and play preview of song
            App.SongName = songItem.Title;
            NavigationService.GoBack();
        }
    }
}