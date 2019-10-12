using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class TrackEnd : Track
    {
        public override string FieldCharacter { get; set; }
        public TrackEnd()
        {
            FieldCharacter = "x";
        }
    }
}
