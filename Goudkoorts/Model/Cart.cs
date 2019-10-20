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
                IsFull = false;
            }
            else if (!nextTrack.CanEnterField(Track))
            {
                return;
            }

            if (!DrivesInverted || DrivesInverted && Track.IsSwitch)
            {
                // Just go to the next Field
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
        }
    }
}
