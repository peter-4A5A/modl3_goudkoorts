﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class TrackYard : Track
    {
        public Ship Ship { get; set; }

        public TrackYard()
        {
            FieldCharacter = "_";
            DefaultFieldCharacter = FieldCharacter;
            IsYard = true;
        }

        public override bool CanEnterField(Track track)
        {
            if (track.NextTrack == null)
            {
                return false;
            }
            if (track.NextTrack.Cart != null)
            {
                return false;
            }
            return true;
        }
    }
}
