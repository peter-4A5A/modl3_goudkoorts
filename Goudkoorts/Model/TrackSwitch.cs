using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class TrackSwitch : Track
    {
        public Track UpTrack { get; set; }
        public Track DownTrack { get; set; }
        public Track LeftTrack { get; set; }

        public Track RightTrack { get; set; }

        public override Track NextTrack { get; set; }
        public override Track PreviousTrack { get; set; }

        public override string FieldCharacter { get; set; }


        public string ListenToCharacter { get; set; }

        public List<Track> Tracks { get; set; }

        private int _nextIndex = 0;

        public bool IsInverted { get; set; }

        public TrackSwitch(string character)
        {
            IsInverted = false;
            //┌ ┐
            //└ ┘
            ListenToCharacter = character;
            FieldCharacter = "S";
            IsSwitch = true;
        }

        public override bool CanEnterField(Track currentTrack)
        {
            if (!IsInverted)
            {
                if (PreviousTrack != currentTrack)
                {
                    return false;
                }
            }
            return true;
        }
        public void Switch()
        {
            if (Tracks == null)
            {
                SetupTrackList();
            }
            if (Cart != null)
            {
                // Switch can not used when there is a cart
                return;
            }
            // We draaien met de klok mee
            // Onder en boven mogen niet samen
            if (!IsInverted)
            {
                PreviousTrack = Tracks[_nextIndex];
                
                NextTrack = Tracks[1];
                _nextIndex += 2;
                if (_nextIndex > Tracks.Count - 1)
                {
                    _nextIndex = 0;
                }
                HandleFieldCharacter();
                return;
            }
            if (IsInverted)
            {
                PreviousTrack = Tracks[2];
                NextTrack = Tracks[_nextIndex];
                _nextIndex--;
                if (_nextIndex < 0)
                {
                    _nextIndex = Tracks.Count - 2;
                }
                HandleFieldCharacter();
                return;
            }
        }

        private void HandleFieldCharacter()
        {
            if (PreviousTrack == UpTrack && NextTrack == RightTrack)
            {
                FieldCharacter = "└";
                DefaultFieldCharacter = FieldCharacter;
                return;
            }
            else if (NextTrack == UpTrack && PreviousTrack == RightTrack)
            {
                FieldCharacter = "└";
                DefaultFieldCharacter = FieldCharacter;
                return;
            }
            if (PreviousTrack == RightTrack && NextTrack == DownTrack)
            {
                FieldCharacter = "┌";
                DefaultFieldCharacter = FieldCharacter;
                return;
            }
            else if (NextTrack == RightTrack && PreviousTrack == DownTrack)
            {
                FieldCharacter = "┌";
                DefaultFieldCharacter = FieldCharacter;
                return;
            }
            if (PreviousTrack == DownTrack && NextTrack == LeftTrack)
            {
                FieldCharacter = "┐";
                DefaultFieldCharacter = FieldCharacter;
                return;
            }
            else if (NextTrack == DownTrack && PreviousTrack == LeftTrack)
            {
                FieldCharacter = "┐";
                DefaultFieldCharacter = FieldCharacter;
                return;
            }
            if (PreviousTrack == LeftTrack && NextTrack == UpTrack)
            {
                FieldCharacter = "┘";
                DefaultFieldCharacter = FieldCharacter;
                return;
            }
            else if (NextTrack == LeftTrack && PreviousTrack == UpTrack)
            {
                FieldCharacter = "┘";
                DefaultFieldCharacter = FieldCharacter;
                return;
            }
        }

        private void SetupTrackList()
        {
            Random random = new Random();
            Tracks = new List<Track>();
            if (UpTrack != null)
            {
                UpTrack.Id = random.Next(1, 5000);
                Tracks.Add(UpTrack);
            }
            if (RightTrack != null)
            {
                RightTrack.Id = random.Next(1, 5000);
                Tracks.Add(RightTrack);
            }
            if (DownTrack != null)
            {
                DownTrack.Id = random.Next(1, 5000);
                Tracks.Add(DownTrack);
            }
            if (LeftTrack != null)
            {
                LeftTrack.Id = random.Next(1, 5000);
                Tracks.Add(LeftTrack);
            }
        }
    }
}
