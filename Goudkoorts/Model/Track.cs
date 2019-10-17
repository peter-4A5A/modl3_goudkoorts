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
        public virtual Cart Cart {
            get {
                return _cart;
            }
            set {
                _cart = value;
                if (_cart != null)
                {
                    if (_cart.IsFull)
                    {
                        FieldCharacter = "C";
                    }
                    else
                    {
                        FieldCharacter = "c";
                    }
                    
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
        public bool IsYard { get; set; }
        public bool IsTrackEnd { get; set; }

        public bool IsDock { get; set; }

        public Track()
        {
            FieldCharacter = "-";
            DefaultFieldCharacter = FieldCharacter;
            IsHorizontal = true;
            IsSwitch = false;
            IsYard = false;
            IsTrackEnd = false;
            IsDock = false;
        }

        public virtual bool CanEnterField(Track currentTrack)
        {
            if (NextTrack == null)
            {
                return false;
            }
            if (NextTrack.Cart != null && NextTrack.Cart.DrivesInverted)
            {
                if (NextTrack.Cart == null)
                {
                    return true;
                }
            }
            if (NextTrack.Cart == null)
            {
                return true;
            }
            if (NextTrack.Cart != null && NextTrack.Cart.Track.NextTrack != null && NextTrack.Cart.Track.NextTrack.Cart == null)
            {
                return true;
            }
            if (NextTrack.Cart != null && !NextTrack.Cart.DrivesInverted)
            {
                throw new Exception("Cart hit other cart");
            }
            else if (PreviouseTrack.Cart != null && PreviouseTrack.Cart.DrivesInverted)
            {
                throw new Exception("Cart hit other cart");
            }
            return false;
        }

    }
}
