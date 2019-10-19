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
            DefaultFieldCharacter = FieldCharacter;
            IsDock = true;
        }

        public void SpawnShip()
        {
            FieldCharacter = "K";
            Ship = new Ship();
        }

        public void CheckForCharacter()
        {
            if(Ship.NumberOfDumps > 0)
            {
                FieldCharacter = "s";
            }
            else if(Ship.NumberOfDumps > 4)
            {
                FieldCharacter = "S";
            }
        }
    }
}
