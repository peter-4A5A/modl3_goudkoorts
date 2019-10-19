using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Cart
    {
        public bool IsFull { get; set; }
        private Track _track;
        public bool DrivesInverted { get; set; }

        private string _cartCharacter;

        public string CartCharacter
        {
            get
            {
                if (IsFull)
                {
                    _cartCharacter = "C";
                }
                else
                {
                    _cartCharacter = "c";
                }

                return _cartCharacter;
            }
        }
        public Track Track {
            get {
                return _track;
            }
            set {
                _track = value;
                if (_track != null)
                {
                    _track.FieldCharacter = "C";
                }
            }
        }

        public Cart()
        {
            DrivesInverted = false;
            IsFull = true;
        }

        public void Move()
        {
            bool nextInverted = AreWeGoingInverted();
            TrackSwitch trackSwitch = null;
            if (Track.IsSwitch)
            {
                trackSwitch = (TrackSwitch)Track;
                DrivesInverted = trackSwitch.IsInverted;
            }
            Track nextTrack = Track.NextTrack;
            if (nextTrack == null)
            {
                return;
            }
            if (nextTrack.IsYard)
            {
                TrackYard trackYard = (TrackYard)nextTrack;
                if (!trackYard.CanEnterField(Track))
                {
                    return;
                }
            }
            if (nextTrack.IsDock)
            {
                TrackDock dock = (TrackDock) nextTrack;
                if(dock.Ship != null)
                {
                    IsFull = false;
                    dock.Ship.NumberOfDumps++;
                }
            }
            else if (!nextTrack.CanEnterField(Track))
            {
                return;
            }

            if (!DrivesInverted || DrivesInverted && Track.IsSwitch)
            {
                // Just go to the next Field
                //Track nextTrack = Track.NextTrack;
                Track.Cart = null;
                Track = nextTrack;
                Track.Cart = this;
            }
            else if (DrivesInverted)
            {
                Track prevTrack = Track.PreviouseTrack;
                Track.Cart = null;
                Track = prevTrack;
                Track.Cart = this;
            }
            DrivesInverted = nextInverted;
        }

        private bool AreWeGoingInverted()
        {
            if (Track.PreviouseTrack == null)
            {
                return DrivesInverted;
            }
            Track nextTrack = Track.NextTrack;
            if (Track.IsSwitch)
            {
                if (Track == nextTrack.NextTrack)
                {
                    // We are going inverted
                    return true;
                }
                else if (Track == nextTrack.PreviouseTrack && !Track.IsSwitch && !nextTrack.IsSwitch)
                {
                    return false;
                }
                else if (Track.IsSwitch && DrivesInverted)
                {
                    return false;
                }
            }
            return DrivesInverted;
        }
    }
}
