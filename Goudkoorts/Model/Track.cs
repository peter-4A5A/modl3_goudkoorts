using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    class Track : Field
    {
        public virtual Track PreviouseTrack { get; set; }
        public virtual Track NextTrack { get; set; }
        public Cart Cart { get; set; }

        public override string FieldCharacter {get; set; }

        public Track()
        {
            FieldCharacter = "-";
        }

    }
}
