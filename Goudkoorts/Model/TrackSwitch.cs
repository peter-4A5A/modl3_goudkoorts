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
        public override Track PreviouseTrack { get; set; }

        public override string FieldCharacter { get; set; }

        public string ListenToCharacter { get; set; }

        public List<Track> Tracks { get; set; }

        private int nextIndex = 0;

        public TrackSwitch(string character)
        {
            ListenToCharacter = character;
            FieldCharacter = "S";
        }
        private void SetupTrackList()
        {
            Tracks = new List<Track>();
            if (UpTrack != null)
            {
                Tracks.Add(UpTrack);
            }
            if (RightTrack != null)
            {
                Tracks.Add(RightTrack);
            }
            if (DownTrack != null)
            {
                Tracks.Add(DownTrack);
            } 
            if (LeftTrack != null)
            {
                Tracks.Add(LeftTrack);
            }
        }
        public void Switch()
        {
            if (Tracks == null)
            {
                SetupTrackList();
            }
            if (Cart != null)
            {
                // Can not switch with a cart on us
                return;
            }
            // We draaien met de klok mee
            if (NextTrack == null && PreviouseTrack == null)
            {
                PreviouseTrack = Tracks[0];
                NextTrack = Tracks[1];
                nextIndex = 1;
                return;
            }
            PreviouseTrack = Tracks[nextIndex];
            nextIndex++;
            nextIndex = nextIndex % 2;
            NextTrack = Tracks[nextIndex];
        }
    }
}
