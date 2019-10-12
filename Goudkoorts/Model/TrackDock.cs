using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class TrackDock : Track
    {
        public Ship Ship { get; set; }
        public override string FieldCharacter { get; set; }
        public TrackDock()
        {
            FieldCharacter = "k";
        }
    }
}
