using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace MusicalAlarms
{
    public class SongPickerViewModel 
    {
        private String title;

        public String Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }
    }
}
