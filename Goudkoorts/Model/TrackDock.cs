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
        private Cart _cart;
        public override Cart Cart {
            get {
                return _cart;
            }
            set {
                if (value == null)
                {
                    Carts.Remove(_cart);
                    _cart = value;
                }
                else
                {
                    _cart = value;
                    if (!Carts.Contains(_cart))
                    {
                        Carts.Add(_cart);
                    }
                }
                if (_cart != null)
                {
                    addCargoToShip();
                    FieldCharacter = _cart.CartCharacter;
                    
                }
                else
                {
                    FieldCharacter = DefaultFieldCharacter;
                }
                CheckForShip();
            }
        }
        public override string FieldCharacter { get; set; }
        private Game _game;
        public TrackDock(Game game)
        {
            FieldCharacter = "k";
            DefaultFieldCharacter = FieldCharacter;
            _game = game;
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

        private void addCargoToShip()
        {
            if (Ship == null)
            {
                return;
            }
            Cart.IsFull = false;
            Ship.NumberOfDumps++;
            if (Ship.NumberOfDumps == 8)
            {
                _game.Score += 10;
                Ship = null;
            }
            _game.Score++;
        }
    }
}
