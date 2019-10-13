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
        public bool DrivesInverted { get; set; }
        public Track Track {
            get {
                return _track;
            }
            set {
                _track = value;
                _track.FieldCharacter = "C";
            }
        }

        public Cart()
        {
            DrivesInverted = false;
        }
    }
}
