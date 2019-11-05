using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.Model
{
    public class Cart
    {
        public bool IsFull { get; set; }
        private Track _track;

        private string _cartCharacter;

        public string CartCharacter
        {
            get
            {
                if (IsFull)
                {
                    _cartCharacter = "C";
                }
                else
                {
                    _cartCharacter = "c";
                }

                return _cartCharacter;
            }
        }
        public Track Track {
            get {
                return _track;
            }
            set {
                _track = value;
                if (_track != null)
                {
                    _track.FieldCharacter = "C";
                }
            }
        }

        public Cart()
        {
            IsFull = true;
        }

        public void Move()
        {
            Track nextTrack = Track.NextTrack;
            if (nextTrack == null)
            {
                return;
            }
            else if (!nextTrack.CanEnterField(Track))
            {
                return;
            }

            // Just go to the next Field
            Track.Cart = null;
            Track = nextTrack;
            Track.Cart = this;
        }
    }
}
