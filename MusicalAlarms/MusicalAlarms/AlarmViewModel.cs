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
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Phone.BackgroundAudio;
using System.ComponentModel;
using System.Windows.Data;

namespace MusicalAlarms
{
    public class AlarmViewModel : INotifyPropertyChanged
    { 
        // private members
        private MediaLibrary _library = new MediaLibrary();

        // Declare the PropertyChanged event
        // TODO - Figure out who instantiates this event ?
        public event PropertyChangedEventHandler PropertyChanged;

        // Properties
        private bool isSongPlaying = false;
        public bool IsSongPlaying
        {
            get
            {
                return isSongPlaying;
            }

            set
            {
                isSongPlaying = value;                
                NotifyPropertyChanged("IsSongPlaying");
            }
        }

        // Methods
        public void AddAlarm(AlarmItem alarmItem, FrameworkElement uiObject)
        {
            if (alarmItem.IsNew)
            {
                if (alarmItem.AlarmTime <= DateTime.Now)
                {
                    alarmItem.AlarmTime = alarmItem.AlarmTime.AddDays(1);
                }

                TimeSpan alarmInterval = alarmItem.AlarmTime - DateTime.Now;

                alarmItem.UIObject = uiObject;

                // When creating timer, need to pass some UI object so that 
                // the timer can use the dispatcher on that object
                Timer alarmTimer = new Timer(AlarmTimerCallback,
                                             alarmItem,
                                             (long)alarmInterval.TotalMilliseconds,
                                             (long)alarmInterval.TotalMilliseconds);

                alarmItem.IsNew = false;
            }
        }

        private void AlarmTimerCallback(object state)
        {
            AlarmItem alarm = state as AlarmItem;

            foreach (Song song in _library.Songs)
            {
                if (song.Name == alarm.SongName)
                {
                    FrameworkDispatcher.Update();
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Play(song);

                    // TODO - Instead of ListBox, can this be a generic UI object ?
                    FrameworkElement frameworkElement = alarm.UIObject as ListBox;
                    frameworkElement.Dispatcher.BeginInvoke(delegate { IsSongPlaying = true; });
                }
            }
        }

        public void StopPlayingSong()
        {
            // also UX should be notified automatically that 
            // song is not playing so stop and snooze should go away
            // TODO - Is this being called on UI thread ?
            isSongPlaying = false;

            MediaPlayer.Stop();
            FrameworkDispatcher.Update();

            // TODO - Need to remove song from media queue
        }

        public void SnoozeSong()
        {
            // also UX should be notified automatically that 
            // song is not playing so stop and snooze should go away
            // TODO - Is this being called on UI thread ?
            isSongPlaying = false;
            MediaPlayer.Pause();
            FrameworkDispatcher.Update();

            // Need to remove song from media queue and re-play
            // since the pause above is automatically resumed
            // after a minute or so

            // Create a timer to go off 
            // in 5 minutes 
            // and to play the song that was 
            // currently active
            int snoozeInterval = 5 * 60 * 1000;

            Timer snoozeTimer = new Timer(AlarmTimerCallback,
                                          MediaPlayer.Queue.ActiveSong.Name,
                                          snoozeInterval,
                                          System.Threading.Timeout.Infinite);                                           
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
