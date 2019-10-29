using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Track
    {
        public virtual Track PreviousTrack { get; set; }
        public virtual string FieldCharacter { get; set; }
        public virtual string DefaultFieldCharacter { get; set; }
        public virtual Track NextTrack { get; set; }
        private Cart _cart;
        public virtual Cart Cart {
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
                    FieldCharacter = _cart.CartCharacter;
                }
                else
                {
                    FieldCharacter = DefaultFieldCharacter;
                }
            }
        }
        private List<Cart> _carts;
        public virtual List<Cart> Carts {
            get {
                return _carts;
            }
            set {
                _carts = value;
            }
        }
        private bool _isHorizontal;
        public bool IsHorizontal {
            get {
                return _isHorizontal;
            }
            set {
                _isHorizontal = value;
                if (_isHorizontal)
                {
                    FieldCharacter = "-";
                    DefaultFieldCharacter = FieldCharacter;
                }
                else
                {
                    FieldCharacter = "|";
                    DefaultFieldCharacter = FieldCharacter;
                }
            }
        }

        public int Id { get; set; }
        public bool IsSwitch { get; set; }

        public Track()
        {
            Carts = new List<Cart>();
            FieldCharacter = "-";
            DefaultFieldCharacter = FieldCharacter;
            IsHorizontal = true;
            IsSwitch = false;
        }

        public virtual bool CanEnterField(Track currentTrack)
        {
            // We are the next field of the cart
            // And we need to check if he could enter

            return true;
        }

    }
}
