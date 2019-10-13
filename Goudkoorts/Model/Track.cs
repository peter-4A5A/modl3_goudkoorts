using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Track : Field
    {
        public virtual Track PreviouseTrack { get; set; }
        public virtual Track NextTrack { get; set; }

        private Cart _cart;
        public Cart Cart {
            get {
                return _cart;
            }
            set {
                _cart = value;
                if (_cart != null)
                {
                    FieldCharacter = "C";
                }
                else
                {
                    FieldCharacter = DefaultFieldCharacter;
                }
            }
        }

        public override string FieldCharacter {get; set; }

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
            FieldCharacter = "-";
            DefaultFieldCharacter = FieldCharacter;
            IsHorizontal = true;
            IsSwitch = false;
        }

        public virtual bool CanEnterField(Track track)
        {
            if (Cart != null)
            {
                return false;
            }
            return true;
        }

    }
}
