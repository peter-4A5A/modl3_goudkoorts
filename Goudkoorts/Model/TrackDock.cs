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
            Ship = new Ship();
        }

        public void CheckForShip()
        {
            if (Ship == null)
            {
                DefaultFieldCharacter = "k";
                return;
            }
            if(Cart != null)
            {
                FieldCharacter = Cart.CartCharacter;
            }else if (Ship.NumberOfDumps > 4)
            {
                FieldCharacter = "S";
                DefaultFieldCharacter = "S";
            }
            else if (Ship.NumberOfDumps > 0)
            {
                FieldCharacter = "s";
                DefaultFieldCharacter = "s";
            }
            else if(Ship != null)
            {
                DefaultFieldCharacter = "K";
                FieldCharacter = "K";
            }
            
            
        }
    }
}
