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
                    IsHorizontal = IsHorizontal;
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
                }
                else
                {
                    FieldCharacter = "|";
                }
            }
        }

        public Track()
        {
            FieldCharacter = "-";
            IsHorizontal = true;
        }

    }
}
