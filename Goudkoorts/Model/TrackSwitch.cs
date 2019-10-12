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

        public string ListenToCharacter;

        public TrackSwitch(string character)
        {
            ListenToCharacter = character;
            FieldCharacter = "S";
        }

        public void Switch()
        {
            // We draaien met de klok mee
        }
    }
}
