using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class TrackYard : Track
    {
        public TrackYard()
        {
            FieldCharacter = "_";
            DefaultFieldCharacter = FieldCharacter;
        }

        public override bool CanEnterField(Track currentTrack)
        {
            if (currentTrack.NextTrack == null)
            {
                return false;
            }
            if (currentTrack.NextTrack.Cart != null)
            {
                return false;
            }
            return true;
        }
    }
}
