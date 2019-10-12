using System;
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
        }
    }
}
